using AutoMapper;
using Features.Auth.Commands;
using Features.Auth.DTOs;

namespace Features.Auth.Mappings;

public class AuthMapping : Profile
{
    public AuthMapping()
    {
        CreateMap<RegisterDto, RegisterUserCommand>();
        CreateMap<LoginDto, LoginUserCommand>();
    }
}
