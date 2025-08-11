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

            Field<ConversationType>("createConversation").Argument<CreateConversationInputType>("input", "Criar conversa.")
                .Resolve(context =>
                {
                    var conversationInput = context.GetArgument<CreateConversationModel>("input");

                    return new Conversation
                    {
                        Id = 1,
                        UserId = conversationInput.UserId,
                        Name = conversationInput.Name,
                        Messages = new List<Message>(),
                        IsDeleted = false
                    };
                });

            Field<bool>("deleteConversation").Argument<DeleteConversationInputType>("input", "Deletar conversa.")
                .Resolve(context =>
                {
                    Console.WriteLine("Cheuei na Mutaion.cs");
                    var conversationInput = context.GetArgument<DeleteConversationModel>("input");
                    Console.WriteLine("IDs: " + conversationInput.ConversationId + " - " + conversationInput.UserId);
                    // Logica e tals ...
                    return true;
                });

            Field<MessageType>("sendMessage").Argument<SendMessageInputType>("input", "Enviar mensagem.")
                .Resolve(context =>
                {
                    var messageInput = context.GetArgument<SendMessageModel>("input");
                    // messageInput.ConversationId vai ser para jogar tudo junto no MongoDB
                    return new Message
                    {
                        Id = 1,
                        Role = "Bot", // ou User --- Fazer Enum?
                        Content = messageInput.Content,
                        Timestamp = DateTime.UtcNow
                    };
                });
        }
    }
}