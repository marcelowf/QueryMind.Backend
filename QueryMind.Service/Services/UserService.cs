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
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Senha não pode ser vazia.");

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var lastUser = await _userRepository.GetLastUserAsync();
            var nextId = lastUser != null ? lastUser.Id + 1 : 1;

            var user = new User
            {
                Id = nextId,
                Name = name,
                Email = email,
                Password = hashedPassword
            };

            await _userRepository.CreateAsync(user);
            return user;
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                throw new Exception("Usuário não encontrado.");

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.Password);
            if (!isPasswordValid)
                throw new Exception("Senha inválida.");

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
