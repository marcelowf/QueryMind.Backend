
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

            // user por email
            // users buscar users
            // conversations por userId
            // conversation por id
        }
    }
}