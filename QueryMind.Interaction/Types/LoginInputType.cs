using GraphQL.Types;

namespace QueryMind.Interaction.Inputs
{
    public class LoginInputType : InputObjectGraphType
    {
        public LoginInputType()
        {
            Name = "LoginInput";

            Field<NonNullGraphType<StringGraphType>>("email");
            Field<NonNullGraphType<StringGraphType>>("password");
        }
    }
}