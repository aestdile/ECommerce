using AutoMapper;
using ECommerce.Application.DTOs.Product;
using ECommerce.Domain.Entities.Product;

namespace ECommerce.Application.Features.Products.Mappings;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}
