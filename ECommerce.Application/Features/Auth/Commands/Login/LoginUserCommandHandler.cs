using ECommerce.Application.Abstractions.Services.Token;
using Microsoft.AspNet.Identity;

namespace Features.Auth.Commands
{
    public class LoginUserCommandHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public LoginUserCommandHandler(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<string> Handle(LoginUserCommand command)
        {
            var user = await _userRepository.GetByEmailAsync(command.Email);
            if (user == null)
            {
                throw new Exception("Email yoki parol noto‘g‘ri.");
            }

            if (!user.IsActive)
            {
                throw new Exception("Foydalanuvchi faol emas, iltimos tizim administratoriga murojaat qiling.");
            }

            var result = _passwordHasher.VerifyHashedPassword(user.PasswordHash, command.Password);
            if (result != PasswordVerificationResult.Success)
            {
                throw new Exception("Email yoki parol noto‘g‘ri.");
            }

            var token = _tokenService.GenerateAccessToken(user);

            return token;
        }
    }
}
