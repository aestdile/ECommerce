using ECommerce.Application.Features.Brands.DTOs;

namespace ECommerce.Application.Abstractions.Services.Brand;

public interface IBrandService
{
    Task<List<BrandDto>> GetAllAsync();
    Task<BrandDto> GetByIdAsync(Guid id);
    Task<BrandDto> CreateAsync(CreateBrandDto dto);
    Task<bool> DeleteAsync(Guid id);
}
