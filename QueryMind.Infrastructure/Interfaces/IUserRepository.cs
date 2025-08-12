using QueryMind.Domain.Entities;

namespace QueryMind.Infrastructure.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task CreateAsync(User user);
    Task UpdateAsync(int id, User user);
    Task DeleteAsync(int id);
    Task<User?> GetByEmailAsync(string email);
    Task<User> GetLastUserAsync();
}
