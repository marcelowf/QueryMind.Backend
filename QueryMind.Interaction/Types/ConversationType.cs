using GraphQL.Types;
using QueryMind.Domain.Entities;

namespace QueryMind.Interaction.Types
{
    public class ConversationType : ObjectGraphType<Conversation>
    {
        public ConversationType()
        {
            Name = "Conversation";

            Field(c => c.Id, type: typeof(IdGraphType)).Description("O ID da conversa.");
            Field(c => c.userId, type: typeof(IdGraphType)).Description("O ID do usuario.");
            // Messages
            Field(c => c.Name).Description("O nome da conversa (opcional).");
            Field(c => c.IsDeleted).Description("Indica se a conversa foi deletada.");
        }
    }
}