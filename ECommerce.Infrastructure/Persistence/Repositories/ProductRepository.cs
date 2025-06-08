using ECommerce.Application.Abstractions.Persistence;
using ECommerce.Domain.Entities.Product;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ECommerceDbContext _context;

    public ProductRepository(ECommerceDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetByIdAsync(Guid id)
        => await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

    public async Task<List<Product>> GetAllAsync()
        => await _context.Products.ToListAsync();

    public async Task<List<Product>> GetAllActiveAsync()
        => await _context.Products.Where(p => !p.IsDeleted).ToListAsync();

    public async Task<Product> AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<bool> SoftDeleteAsync(Guid id)
    {
        var product = await GetByIdAsync(id);
        if (product == null) return false;
        product.IsDeleted = true;
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RestoreAsync(Guid id)
    {
        var product = await GetByIdAsync(id);
        if (product == null) return false;
        product.IsDeleted = false;
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return true;
    }
}
