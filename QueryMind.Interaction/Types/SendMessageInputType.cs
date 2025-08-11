using GraphQL.Types;

namespace QueryMind.Interaction.Inputs
{
    public class SendMessageInputType : InputObjectGraphType
    {
        public SendMessageInputType()
        {
            Name = "SendMessageInput";

            Field<NonNullGraphType<StringGraphType>>("conversationId");
            Field<NonNullGraphType<StringGraphType>>("content");
        }
    }
}