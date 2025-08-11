using MongoDB.Driver;
using QueryMind.Domain.Entities;
using QueryMind.Infrastructure.Database;
using QueryMind.Infrastructure.Interfaces;

namespace QueryMind.Infrastructure.Repositories;

public class UserRepository: IUserRepository
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

    public async Task CreateAsync(User user)
    {
        user.Id = 11;
        Console.WriteLine("vou inserir os dados:" + user.Id + " " + user.Email + " " + user.Name + " " + user.Password); 
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
}
