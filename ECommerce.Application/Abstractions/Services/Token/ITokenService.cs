using System.Security.Claims;
using ECommerce.Domain.Entities.User;

namespace ECommerce.Application.Abstractions.Services.Token;

public interface ITokenService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}
