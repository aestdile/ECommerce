using ECommerce.Application.Features.Auth.DTOs;
using Features.Auth.DTOs;

namespace ECommerce.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto registerDto);
        Task<string> LoginAsync(LoginDto loginDto);
        Task<string> RefreshTokenAsync(RefreshTokenRequestDto dto);
    }
}
