using GraphQL;
using GraphQL.Types;
using QueryMind.Interaction.Inputs;
using QueryMind.Interaction.Models;
using QueryMind.Interaction.Types;
using QueryMind.Service.Interfaces;

namespace QueryMind.Interaction.Resolvers
{
    public class MutationResolver : ObjectGraphType
    {
        public MutationResolver(IConversationService conversationService, IUserService userService)
        {
            Name = "Mutation";

            Field<UserType>("register").Argument<RegisterInputType>("input", "Registro de usuário.")
                .ResolveAsync(async context =>
                {
                    var registerInput = context.GetArgument<RegisterModel>("input");
                    var result = await userService.RegisterAsync(registerInput.Name, registerInput.Email, registerInput.Password);
                    return result;
                });

            Field<UserType>("login").Argument<LoginInputType>("input", "Login de usuário.")
                .ResolveAsync(async context =>
                {
                    var loginInput = context.GetArgument<LoginModel>("input");
                    var result = await userService.LoginAsync(loginInput.Email, loginInput.Password);
                    return result;
                });

            Field<ConversationType>("createConversation").Argument<CreateConversationInputType>("input", "Criar conversa.")
                .ResolveAsync(async context =>
                {
                    var conversationInput = context.GetArgument<CreateConversationModel>("input");
                    var result = await conversationService.CreateConversationAsync(conversationInput.Name, conversationInput.UserId);
                    return result;
                });

            Field<bool>("deleteConversation").Argument<DeleteConversationInputType>("input", "Deletar conversa.")
                .ResolveAsync(async context =>
                {
                    var conversationInput = context.GetArgument<DeleteConversationModel>("input");
                    var result = await conversationService.DeleteConversationAsync(conversationInput.ConversationId);
                    return result;
                });

            Field<MessageType>("sendMessage").Argument<SendMessageInputType>("input", "Enviar mensagem.")
                .ResolveAsync(async context =>
                {
                    var messageInput = context.GetArgument<SendMessageModel>("input");
                    var result = await conversationService.SendMessageAsync(messageInput.ConversationId, messageInput.Content);
                    return result;
                });
        }
    }
}