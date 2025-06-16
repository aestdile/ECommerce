using ECommerce.Application.DTOs.Order;

namespace ECommerce.Application.Abstractions.Services;

public interface IOrderService
{
    Task<OrderDto> CreateOrderAsync(CreateOrderDto dto);
    Task<OrderDto> GetByIdAsync(Guid orderId);
    Task<List<OrderDto>> GetOrdersByUserIdAsync(Guid userId);
    Task<bool> DeleteAsync(Guid orderId);
}
