using System;
using ECommerce.Application.Abstractions.Persistence;
using ECommerce.Domain.Entities.Payment;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly ECommerceDbContext _context;

    public PaymentRepository(ECommerceDbContext context)
    {
        _context = context;
    }

    public async Task<Payment> GetByIdAsync(Guid id)
        => await _context.Payments.FirstOrDefaultAsync(p => p.Id == id);

    public async Task<List<Payment>> GetPaymentsByUserIdAsync(Guid userId)
        => await _context.Payments.Where(p => p.UserId == userId).ToListAsync();

    public async Task<Payment> AddAsync(Payment payment)
    {
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
        return payment;
    }

    public async Task<Payment> UpdateAsync(Payment payment)
    {
        _context.Payments.Update(payment);
        await _context.SaveChangesAsync();
        return payment;
    }

    public async Task<bool> ExistsAsync(Guid id)
        => await _context.Payments.AnyAsync(p => p.Id == id);
}