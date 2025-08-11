using GraphQL.Resolvers;
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
            Field(c => c.UserId, type: typeof(IdGraphType)).Description("O ID do usuario.");

            AddField(new FieldType
            {
                Name = "messages",
                Description = "Lista de mensagens associadas à conversa.",
                Type = typeof(ListGraphType<MessageType>),
                Resolver = new FuncFieldResolver<List<Message>>(context =>
                {
                    var conversation = context.Source as Conversation;
                    return conversation?.Messages;
                })
            });

            Field(c => c.Name).Description("O nome da conversa (opcional).");
            Field(c => c.IsDeleted).Description("Indica se a conversa foi deletada.");
        }
    }
}