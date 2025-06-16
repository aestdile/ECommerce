using ECommerce.Application.Abstractions.Services;
using ECommerce.Application.Features.Categories.DTOs;
using ECommerce.Domain.Entities.Product;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Services;

public class CategoryService : ICategoryService
{
    private readonly ECommerceDbContext _context;

    public CategoryService(ECommerceDbContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryDto>> GetAllAsync()
    {
        var categories = await _context.Categories.ToListAsync();
        return categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();
    }

    public async Task<CategoryDto> GetByIdAsync(Guid id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) throw new Exception("Kategoriya topilmadi");

        return new CategoryDto { Id = category.Id, Name = category.Name };
    }

    public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
    {
        var category = new Category { Id = Guid.NewGuid(), Name = dto.Name };
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        return new CategoryDto { Id = category.Id, Name = category.Name };
    }

    public async Task<CategoryDto> UpdateAsync(UpdateCategoryDto dto)
    {
        var category = await _context.Categories.FindAsync(dto.Id);
        if (category == null) throw new Exception("Kategoriya topilmadi");

        category.Name = dto.Name;
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();

        return new CategoryDto { Id = category.Id, Name = category.Name };
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) return false;

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();

        return true;
    }
}
