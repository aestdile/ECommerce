using ECommerce.Application.Features.Categories.DTOs;

namespace ECommerce.Application.Abstractions.Services;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllAsync();
    Task<CategoryDto> GetByIdAsync(Guid id);
    Task<CategoryDto> CreateAsync(CreateCategoryDto dto);
    Task<CategoryDto> UpdateAsync(UpdateCategoryDto dto);
    Task<bool> DeleteAsync(Guid id);
}
