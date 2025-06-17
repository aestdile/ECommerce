using ECommerce.Domain.Enums;

namespace ECommerce.Application.Features.Orders.Commands;

public class UpdateOrderStatusCommand
{
    public Guid OrderId { get; set; }
    public OrderStatus NewStatus { get; set; }
}
