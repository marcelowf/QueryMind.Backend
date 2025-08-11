using QueryMind.Domain.Entities;

namespace QueryMind.Service.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterAsync(string name, string email, string password);
        Task<User?> LoginAsync(string email, string password);
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
    }
}