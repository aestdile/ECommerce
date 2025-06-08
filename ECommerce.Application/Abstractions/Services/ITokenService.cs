using ECommerce.Domain.Entities.User;

namespace ECommerce.Application.Abstractions.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}
