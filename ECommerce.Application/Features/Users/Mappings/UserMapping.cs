using AutoMapper;
using ECommerce.Application.DTOs.User;
using ECommerce.Domain.Entities.User;

namespace ECommerce.Application.Features.Users.Mappings;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}
