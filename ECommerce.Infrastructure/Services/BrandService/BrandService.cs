using ECommerce.Application.Abstractions.Services.Brand;
using ECommerce.Application.Features.Brands.DTOs;
using ECommerce.Domain.Entities.Product;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Services;

public class BrandService : IBrandService
{
    private readonly ECommerceDbContext _context;

    public BrandService(ECommerceDbContext context)
    {
        _context = context;
    }

    public async Task<List<BrandDto>> GetAllAsync()
    {
        var brands = await _context.Brands.ToListAsync();
        return brands.Select(b => new BrandDto
        {
            Id = b.Id,
            Name = b.Name,
            Description = b.Description
        }).ToList();
    }

    public async Task<BrandDto> GetByIdAsync(Guid id)
    {
        var brand = await _context.Brands.FindAsync(id)
                    ?? throw new Exception("Brand topilmadi");

        return new BrandDto
        {
            Id = brand.Id,
            Name = brand.Name,
            Description = brand.Description
        };
    }

    public async Task<BrandDto> CreateAsync(CreateBrandDto dto)
    {
        var brand = new Brand
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description
        };

        await _context.Brands.AddAsync(brand);
        await _context.SaveChangesAsync();

        return new BrandDto
        {
            Id = brand.Id,
            Name = brand.Name,
            Description = brand.Description
        };
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var brand = await _context.Brands.FindAsync(id);
        if (brand == null) return false;

        _context.Brands.Remove(brand);
        await _context.SaveChangesAsync();
        return true;
    }
}
