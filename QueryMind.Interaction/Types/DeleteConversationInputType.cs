using GraphQL.Types;

namespace QueryMind.Interaction.Inputs
{
    public class DeleteConversationInputType : InputObjectGraphType
    {
        public DeleteConversationInputType()
        {
            Name = "DeleteConversationInput";

            Field<NonNullGraphType<StringGraphType>>("conversationId");
            Field<NonNullGraphType<StringGraphType>>("userId");
        }
    }
}