using ECommerce.Application.Abstractions.Persistence;
using ECommerce.Domain.Entities.Product;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ECommerceDbContext _context;

    public CategoryRepository(ECommerceDbContext context)
    {
        _context = context;
    }

    public async Task<Category> GetByIdAsync(Guid id)
        => await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

    public async Task<List<Category>> GetAllAsync()
        => await _context.Categories.ToListAsync();

    public async Task<Category> AddAsync(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<bool> Delete(Category category)
    {
        _context.Categories.Remove(category);
        return await _context.SaveChangesAsync() > 0;
    }
}