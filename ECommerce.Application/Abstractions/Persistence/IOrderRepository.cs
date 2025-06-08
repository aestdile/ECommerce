using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Domain.Entities.Order;
using ECommerce.Domain.Enums;

namespace ECommerce.Application.Abstractions.Persistence
{
    public interface IOrderRepository
    {
        Task<Order?> GetByIdAsync(Guid id);
        Task<List<Order>> GetAllAsync();

        Task<Order> AddAsync(Order order);
        Task<Order> UpdateAsync(Order order);

        Task<Order> CancelAsync(Guid orderId); // agar order cancel bo'lsa, OrderStatus.Cancelled ga o'zgartiriladi.
        Task<Order> SetStatusAsync(Guid orderId, OrderStatus status);
    }
}
