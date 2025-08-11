using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using QueryMind.Domain.Entities;

namespace QueryMind.Infrastructure.Database;

public class NoSqlContext
{
    private readonly IMongoDatabase _database;

    public NoSqlContext(IConfiguration config)
    {
        var connectionString = config["ConnectionStrings:DefaultConnection"];
        var databaseName = "queryminddbqa"; //config["ConnectionStrings:DatabaseName"];

        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
    public IMongoCollection<Conversation> Conversations => _database.GetCollection<Conversation>("Conversations");
}
