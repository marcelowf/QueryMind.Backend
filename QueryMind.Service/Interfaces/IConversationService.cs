using QueryMind.Domain.Entities;

namespace QueryMind.Service.Interfaces
{
    public interface IConversationService
    {
        Task<Conversation> CreateConversationAsync(string name, int userId);
        Task<bool> DeleteConversationAsync(int conversationId);
        Task<Message> SendMessageAsync(int conversationId, string content);
        Task<List<Conversation>> GetAllAsync();
        Task<Conversation?> GetByIdAsync(int id);
    }
}
