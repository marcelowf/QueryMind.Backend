using Azure.Identity;
using GraphQL;
using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using GraphQL.Types;
using QueryMind.Interaction;
using QueryMind.Interaction.Types;
using QueryMind.Interaction.Resolvers;
using QueryMind.Domain.Entities;
using QueryMind.Service.Interfaces;
using QueryMind.Service.Services;
using QueryMind.Interaction.Models;
using QueryMind.Interaction.Inputs;
using QueryMind.Infrastructure.Interfaces;
using QueryMind.Infrastructure.Repositories;
using QueryMind.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

#region Loggers
builder.Logging.ClearProviders().AddConsole().AddDebug();

Console.WriteLine("✅ Loggers configured.");
#endregion

#region Open Telemetry
builder.Services.AddOpenTelemetry()
    .WithMetrics(metrics =>
    {
        metrics
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("QueryMind-Backend"))
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddRuntimeInstrumentation()
            .AddPrometheusExporter();
    });

Console.WriteLine("✅ Open Telemetry configured.");
#endregion

#region App Settings
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

Console.WriteLine("✅ App Settings configured.");
#endregion

#region Azure Key Vault
var keyVaultUri = builder.Configuration["AzureKeyVaultUrl"];

if (!string.IsNullOrEmpty(keyVaultUri))
{
    try
    {
        builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUri), new DefaultAzureCredential());
        Console.WriteLine("✅ Key Vault overwrote App Settings.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("⚠️  Key Vault is not available.\n" + ex);
    }
}
#endregion

#region Health Checks
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new MongoClient(connectionString);
});

builder.Services.AddHealthChecks()
    .AddMongoDb(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        name: "Mongo Database",
        failureStatus: HealthStatus.Degraded);

Console.WriteLine("✅ Health Checks configured.");
#endregion

#region Dependency Injection
Console.WriteLine("✅ Dependency Injection configured.");
#endregion

#region CORS
builder.Services.AddCors(options => options.AddPolicy("MyPolicy", corsBuilder =>
{
    corsBuilder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin()
        .WithExposedHeaders("X-Pagination")
        .WithHeaders("authorization", "accept", "content-type", "origin", "X-Pagination", "OPTIONS");
}));

Console.WriteLine("✅ Cross-Origin Resource Sharing configured.");
#endregion

#region GraphQL
builder.Services.AddSingleton<User>();
builder.Services.AddSingleton<Conversation>();
builder.Services.AddSingleton<Message>();

builder.Services.AddSingleton<UserType>();
builder.Services.AddSingleton<ConversationType>();
builder.Services.AddSingleton<MessageType>();

builder.Services.AddSingleton<RegisterInputType>();
builder.Services.AddSingleton<LoginInputType>();
builder.Services.AddSingleton<SendMessageInputType>();
builder.Services.AddSingleton<CreateConversationInputType>();
builder.Services.AddSingleton<DeleteConversationInputType>();

builder.Services.AddSingleton<CreateConversationModel>();
builder.Services.AddSingleton<DeleteConversationModel>();
builder.Services.AddSingleton<SendMessageModel>();
builder.Services.AddSingleton<RegisterModel>();
builder.Services.AddSingleton<LoginModel>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IConversationRepository, ConversationRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IConversationService, ConversationService>();

builder.Services.AddSingleton<NoSqlContext>();

builder.Services.AddSingleton<QueryResolver>();
builder.Services.AddSingleton<MutationResolver>();
builder.Services.AddSingleton<ISchema, SchemaBuilder>();
builder.Services.AddGraphQL(b => b.AddSystemTextJson());

Console.WriteLine("✅ GraphQL configured.");
#endregion

#region Database
try
{
    var client = new MongoClient(builder.Configuration.GetConnectionString("DefaultConnection"));
    var databaseList = await client.ListDatabaseNamesAsync();
    Console.WriteLine("✅ MongoDB configured.");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ MongoDB is not available.\n{ex}");
}
#endregion

#region Redis
try
{
    var redisConnectionString = builder.Configuration["RedisConnectionStrings:DefaultConnection"];
    var redis = await StackExchange.Redis.ConnectionMultiplexer.ConnectAsync(redisConnectionString);
    builder.Services.AddSingleton(redis);
    Console.WriteLine("✅ Redis configured.");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Redis is not available.\n{ex}");
}
#endregion

#region Middleware
var app = builder.Build();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = async (context, report) =>
    {
        context.Response.ContentType = "application/json";

        var result = JsonSerializer.Serialize(new
        {
            status = report.Status.ToString(),
            checks = report.Entries.Select(e => new
            {
                name = e.Key,
                status = e.Value.Status.ToString()
            })
        });

        await context.Response.WriteAsync(result);
    }
});

app.UseOpenTelemetryPrometheusScrapingEndpoint();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors("MyPolicy");
app.UseHttpsRedirection();

app.UseRouting();

app.UseGraphQL("/graphql");
app.UseGraphQLGraphiQL("/ui/graphiql");

app.Run();
#endregion
