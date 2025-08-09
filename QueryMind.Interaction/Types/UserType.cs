using GraphQL.Types;
using QueryMind.Domain.Entities;

namespace QueryMind.Interaction.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Name = "User";

            Field(u => u.Id, type: typeof(IdGraphType)).Description("O ID do usuário.");
            Field(u => u.Name).Description("O nome do usuário.");
            Field(u => u.Email).Description("O e-mail do usuário.");
            Field(u => u.Password).Description("A senha do usuário.");
        }
    }
}