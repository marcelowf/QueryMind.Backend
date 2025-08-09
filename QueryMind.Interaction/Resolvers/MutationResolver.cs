using GraphQL;
using GraphQL.Types;
using QueryMind.Domain.Entities;
using QueryMind.Interaction.Inputs;
using QueryMind.Interaction.Models;
using QueryMind.Interaction.Types;
using QueryMind.Service.interfaces;

namespace QueryMind.Interaction.Resolvers
{
    public class MutationResolver : ObjectGraphType
    {
        public MutationResolver(IConversationService conversationService, IUserService userService)
        {
            Name = "Mutation";

            Field<UserType>("register").Argument<RegisterInputType>("input", "Registro de usuário.")
                .Resolve(context =>
                {
                    var registerInput = context.GetArgument<RegisterModel>("input");

                    return new User
                    {
                        Id = 1,
                        Name = registerInput.Name,
                        Email = registerInput.Email,
                        Password = registerInput.Password
                    };
                });

            Field<UserType>("login").Argument<LoginInputType>("input", "Login de usuário.")
                .Resolve(context =>
                {
                    var loginInput = context.GetArgument<LoginModel>("input");

                    return new User
                    {
                        Id = 1,
                        Name = "Logado",
                        Email = loginInput.Email,
                        Password = loginInput.Password
                    };
                });
        }

    }
}