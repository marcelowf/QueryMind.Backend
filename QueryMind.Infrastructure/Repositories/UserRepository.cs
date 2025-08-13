using MongoDB.Driver;
using QueryMind.Domain.Entities;
using QueryMind.Infrastructure.Database;
using QueryMind.Infrastructure.Interfaces;

namespace QueryMind.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _users;

    public UserRepository(NoSqlContext context)
    {
        _users = context.Users;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _users.Find(_ => true).ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _users.Find(u => u.Id == id).FirstOrDefaultAsync();
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _users.Find(u => u.Email == email).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(User user)
    {
        await _users.InsertOneAsync(user);
    }

    public async Task UpdateAsync(int id, User user)
    {
        await _users.ReplaceOneAsync(u => u.Id == id, user);
    }

    public async Task DeleteAsync(int id)
    {
        await _users.DeleteOneAsync(u => u.Id == id);
    }

    public async Task<User> GetLastUserAsync()
    {
        return await _users
            .Find(FilterDefinition<User>.Empty)
            .SortByDescending(u => u.Id)
            .FirstOrDefaultAsync();
    }
}
