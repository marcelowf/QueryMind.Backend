
using GraphQL;
using GraphQL.Types;
using QueryMind.Interaction.Types;
using QueryMind.Service.Interfaces;

namespace QueryMind.Interaction.Resolvers
{
    public class QueryResolver : ObjectGraphType
    {
        public QueryResolver(IUserService userService, IConversationService conversationService)
        {
            Name = "Query";

            Field<UserType>("user")
                .Argument<NonNullGraphType<StringGraphType>>("email", "E-mail do usuário.")
                .ResolveAsync(async context =>
                {
                    var email = context.GetArgument<string>("email");
                    return await userService.GetByEmailAsync(email);
                });

            Field<NonNullGraphType<ListGraphType<NonNullGraphType<UserType>>>>("users")
                .ResolveAsync(async _ => await userService.GetAllAsync());

            Field<NonNullGraphType<ListGraphType<NonNullGraphType<ConversationType>>>>("conversations")
                .Argument<NonNullGraphType<IdGraphType>>("userId", "ID do usuário.")
                .ResolveAsync(async context =>
                {
                    var userId = context.GetArgument<int>("userId");
                    return await conversationService.GetByIdAsync(userId);
                });

            Field<ConversationType>("conversation")
                .Argument<NonNullGraphType<IdGraphType>>("id", "ID da conversa.")
                .ResolveAsync(async context =>
                {
                    var id = context.GetArgument<int>("id");
                    return await conversationService.GetByIdAsync(id);
                });
        }
    }
}