using GraphQL.Types;
using QueryMind.Domain.Entities;

namespace QueryMind.Interaction.Types
{
    public class MessageType : ObjectGraphType<Message>
    {
        public MessageType()
        {
            Name = "Message";

            Field(m => m.Id, type: typeof(IdGraphType)).Description("O ID da mensagem.");
            Field(m => m.Role).Description("O papel da mensagem (por exemplo, 'user' ou 'bot').");
            Field(m => m.Content).Description("O conteúdo da mensagem.");
            Field(m => m.Timestamp).Description("O timestamp da mensagem.");
        }
    }
}