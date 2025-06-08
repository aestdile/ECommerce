﻿using ECommerce.Domain.Entities.User;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ECommerceDbContext _context;

    public UserRepository(ECommerceDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(Guid id)
        => await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

    public async Task<List<User>> GetAllAsync()
        => await _context.Users.ToListAsync();

    public async Task<List<User>> GetAllActiveAsync()
        => await _context.Users.Where(u => u.IsActive).ToListAsync();

    public async Task<User> AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> DeactivateAsync(Guid userId)
    {
        var user = await GetByIdAsync(userId);
        if (user == null) throw new Exception("User not found");
        user.IsActive = false;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> ActivateAsync(Guid userId)
    {
        var user = await GetByIdAsync(userId);
        if (user == null) throw new Exception("User not found");
        user.IsActive = true;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> GetByEmailAsync(string email)
        => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
}
