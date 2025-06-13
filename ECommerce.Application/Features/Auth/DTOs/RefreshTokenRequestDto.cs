namespace ECommerce.Application.Features.Auth.DTOs;

public class RefreshTokenRequestDto
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}

