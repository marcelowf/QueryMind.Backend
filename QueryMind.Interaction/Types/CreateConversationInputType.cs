using GraphQL.Types;

namespace QueryMind.Interaction.Inputs
{
    public class CreateConversationInputType : InputObjectGraphType
    {
        public CreateConversationInputType()
        {
            Name = "CreateConversationInput";

            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("userId");
        }
    }
}