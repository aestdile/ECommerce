using ECommerce.Domain.Entities.Product;

namespace ECommerce.Application.Abstractions.Persistence;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id);
    Task<List<Product>> GetAllAsync();
    Task<List<Product>> GetAllActiveAsync(); // Faqat IsDeleted = false bo‘lganlar uchun.

    Task<Product> AddAsync(Product product);
    Task<Product> UpdateAsync(Product product);

    Task<bool> SoftDeleteAsync(Guid id);      // IsDeleted = true qiladi.
    Task<bool> RestoreAsync(Guid id);         // IsDeleted = false qiladi.
}
