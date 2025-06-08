using ECommerce.Domain.Entities.Product;

namespace ECommerce.Application.Abstractions.Persistence;

public interface ICategoryRepository
{
    Task<Category> GetByIdAsync(Guid id);
    Task<List<Category>> GetAllAsync();
    Task<Category> AddAsync(Category category);
    Task<bool> Delete(Category category);
}

