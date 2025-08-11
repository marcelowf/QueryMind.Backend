
using GraphQL.Types;
using QueryMind.Domain.Entities;
using QueryMind.Interaction.Types;
using QueryMind.Service.Interfaces;

namespace QueryMind.Interaction.Resolvers
{
    public class QueryResolver : ObjectGraphType
    {
        public QueryResolver(IUserService userService)
        {
            Name = "Query";

            Field<UserType>("teste")
                .Resolve(context =>
                {
                    return new User
                    {
                        Id = 1,
                        Name = "Usuário de Teste",
                        Email = "teste@example.com",
                        Password = "senha123"
                    };
                });

            // user por email
            // users buscar users
            // conversations por userId
            // conversation por id
        }
    }
}