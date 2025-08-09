
using GraphQL.Types;
using QueryMind.Domain.Entities;
using QueryMind.Interaction.Types;
using QueryMind.Service.interfaces;

namespace QueryMind.Interaction.Resolvers
{
    public class QueryResolver : ObjectGraphType
    {
        public QueryResolver(IUserService userService)
        {
            Name = "Query";
        }
    }
}