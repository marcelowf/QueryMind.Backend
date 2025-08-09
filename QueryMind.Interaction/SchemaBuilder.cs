using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using QueryMind.Interaction.Resolvers;

namespace QueryMind.Interaction
{
    public class SchemaBuilder : Schema
    {
        public SchemaBuilder(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<QueryResolver>();
            Mutation = serviceProvider.GetRequiredService<MutationResolver>();
        }
    }
}
