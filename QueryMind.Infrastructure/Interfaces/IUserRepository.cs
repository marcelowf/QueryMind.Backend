using QueryMind.Domain.Entities;

namespace QueryMind.Infrastructure.Interfaces;

public interface IConversationRepository
{
    Task<List<Conversation>> GetAllAsync();
    Task<Conversation?> GetByIdAsync(int id);
    Task CreateAsync(Conversation conversation);
    Task UpdateAsync(int id, Conversation conversation);
    Task DeleteAsync(int id);
}
