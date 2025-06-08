using ECommerce.Domain.Entities.User;
using Microsoft.AspNet.Identity;

namespace Features.Auth.Commands
{
    public class RegisterUserCommandHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> Handle(RegisterUserCommand command)
        {
            var existingUsers = await _userRepository.GetAllAsync();
            if (existingUsers.Any(u => u.Email == command.Email))
                throw new Exception("This email is already registered.");

            var hashedPassword = _passwordHasher.HashPassword(command.Password);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = command.Email,
                PasswordHash = hashedPassword,
                IsActive = true,
                CreatedOn = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);

            return true;
        }
    }
}
