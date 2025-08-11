using MongoDB.Driver;
using QueryMind.Domain.Entities;
using QueryMind.Infrastructure.Database;
using QueryMind.Infrastructure.Interfaces;

namespace QueryMind.Infrastructure.Repositories;

public class ConversationRepository: IConversationRepository
{
    private readonly IMongoCollection<Conversation> _conversations;

    public ConversationRepository(NoSqlContext context)
    {
        _conversations = context.Conversations;
    }

    public async Task<List<Conversation>> GetAllAsync()
    {
        return await _conversations.Find(_ => true).ToListAsync();
    }

    public async Task<Conversation?> GetByIdAsync(int id)
    {
        return await _conversations.Find(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(Conversation conversation)
    {
        await _conversations.InsertOneAsync(conversation);
    }

    public async Task UpdateAsync(int id, Conversation conversation)
    {
        await _conversations.ReplaceOneAsync(c => c.Id == id, conversation);
    }

    public async Task DeleteAsync(int id)
    {
        await _conversations.DeleteOneAsync(c => c.Id == id);
    }
}
