using System;
using ECommerce.Application.Abstractions.Persistence;
using ECommerce.Domain.Entities.Order;
using ECommerce.Domain.Enums;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ECommerceDbContext _context;

    public OrderRepository(ECommerceDbContext context)
    {
        _context = context;
    }

    public async Task<Order?> GetByIdAsync(Guid id)
        => await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);

    public async Task<List<Order>> GetAllAsync()
        => await _context.Orders.ToListAsync();

    public async Task<Order> AddAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<Order> UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<Order> CancelAsync(Guid orderId)
    {
        var order = await GetByIdAsync(orderId);
        if (order is null) throw new Exception("Order not found");
        order.Status = OrderStatus.Cancelled;
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<Order> SetStatusAsync(Guid orderId, OrderStatus status)
    {
        var order = await GetByIdAsync(orderId);
        if (order is null) throw new Exception("Order not found");
        order.Status = status;
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
        return order;
    }
}
