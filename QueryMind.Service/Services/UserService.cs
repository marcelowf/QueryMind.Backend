using QueryMind.Domain.Entities;
using QueryMind.Infrastructure.Interfaces;
using QueryMind.Service.Interfaces;

namespace QueryMind.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> RegisterAsync(string name, string email, string password)
        {
            // Aqui você deve aplicar validações e hash de senha
            var user = new User
            {
                Name = name,
                Email = email,
                Password = password // 🔒 em produção, use hashing (BCrypt, etc.)
            };

            await _userRepository.CreateAsync(user);
            return user;
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            var users = await _userRepository.GetAllAsync();
            var user = users.FirstOrDefault(u => u.Email == email && u.Password == password);

            // 🔒 em produção, use verificação de hash em vez de comparar direto
            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }
    }
}
