using GraphQL.Types;

namespace QueryMind.Interaction.Inputs
{
    public class RegisterInputType : InputObjectGraphType
    {
        public RegisterInputType()
        {
            Name = "RegisterInput";

            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("email");
            Field<NonNullGraphType<StringGraphType>>("password");
            Field<NonNullGraphType<StringGraphType>>("confirmedPassword");
        }
    }
}