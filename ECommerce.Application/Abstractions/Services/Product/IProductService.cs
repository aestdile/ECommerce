using ECommerce.Application.DTOs.Product;

namespace ECommerce.Application.Abstractions.Services;

public interface IProductService
{
    Task<ProductDto> GetByIdAsync(Guid id);
    Task<List<ProductDto>> GetAllAsync();
    Task<ProductDto> CreateAsync(CreateProductDto dto);
    Task<ProductDto> UpdateAsync(Guid id, UpdateProductDto dto);
    Task<bool> DeleteAsync(Guid id);
}
