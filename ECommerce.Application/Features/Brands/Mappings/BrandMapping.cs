using AutoMapper;
using ECommerce.Application.Features.Brands.DTOs;
using ECommerce.Domain.Entities.Product;

namespace ECommerce.Application.Features.Brands.Mappings
{
    public class BrandMapping : Profile
    {
        public BrandMapping()
        {
            CreateMap<Brand, BrandDto>().ReverseMap();
        }
    }
}
