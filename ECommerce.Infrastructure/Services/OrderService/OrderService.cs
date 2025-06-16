using ECommerce.Application.Abstractions.Services;
using ECommerce.Application.DTOs.Order;
using ECommerce.Domain.Entities.Order;
using ECommerce.Domain.Enums;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly ECommerceDbContext _context;

    public OrderService(ECommerceDbContext context)
    {
        _context = context;
    }

    public async Task<OrderDto> CreateOrderAsync(CreateOrderDto dto)
    {
        var items = new List<OrderItem>();
        decimal totalPrice = 0;

        foreach (var item in dto.OrderItems)
        {
            var product = await _context.Products.FindAsync(item.ProductId)
                          ?? throw new Exception("Mahsulot topilmadi");

            decimal itemPrice = product.Price * item.Quantity;
            totalPrice += itemPrice;

            items.Add(new OrderItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = product.Price
            });
        }

        var order = new Order
        {
            Id = Guid.NewGuid(),
            UserId = dto.UserId,
            ShippingAddress = dto.ShippingAddress,
            OrderItems = items,
            Status = OrderStatus.Pending,
            TotalPrice = totalPrice,
            CreatedOn = DateTime.UtcNow
        };

        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();

        return await GetByIdAsync(order.Id);
    }

    public async Task<OrderDto> GetByIdAsync(Guid orderId)
    {
        var order = await _context.Orders
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
            .Include(o => o.User)
            .FirstOrDefaultAsync(o => o.Id == orderId);

        if (order == null)
            throw new Exception("Buyurtma topilmadi");

        return new OrderDto
        {
            Id = order.Id,
            UserId = order.UserId,
            UserFullName = $"{order.User.FirstName} {order.User.LastName}",
            CreatedOn = order.CreatedOn,
            ShippingAddress = order.ShippingAddress,
            Status = order.Status,
            TotalPrice = order.TotalPrice,
            OrderItems = order.OrderItems.Select(i => new OrderItemDto
            {
                ProductId = i.ProductId,
                ProductName = i.Product.Name,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            }).ToList()
        };
    }

    public async Task<List<OrderDto>> GetOrdersByUserIdAsync(Guid userId)
    {
        var orders = await _context.Orders
            .Include(o => o.OrderItems)
                .ThenInclude(i => i.Product)
            .Include(o => o.User)
            .Where(o => o.UserId == userId)
            .ToListAsync();

        return orders.Select(o => new OrderDto
        {
            Id = o.Id,
            UserId = o.UserId,
            UserFullName = $"{o.User.FirstName} {o.User.LastName}",
            CreatedOn = o.CreatedOn,
            ShippingAddress = o.ShippingAddress,
            Status = o.Status,
            TotalPrice = o.TotalPrice,
            OrderItems = o.OrderItems.Select(i => new OrderItemDto
            {
                ProductId = i.ProductId,
                ProductName = i.Product.Name,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            }).ToList()
        }).ToList();
    }

    public async Task<bool> DeleteAsync(Guid orderId)
    {
        var order = await _context.Orders.FindAsync(orderId);
        if (order == null) return false;

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
        return true;
    }
}
