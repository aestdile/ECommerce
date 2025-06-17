using AutoMapper;
using ECommerce.Domain.Entities.Product;
using ECommerce.Application.Features.Categories.DTOs;

namespace ECommerce.Application.Features.Categories.Mappings;

public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
