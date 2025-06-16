using ECommerce.Domain.ValueObjects;

namespace ECommerce.Application.DTOs.Order;

public class CreateOrderDto
{
    public Guid UserId { get; set; }
    public Address ShippingAddress { get; set; } = default!;
    public List<CreateOrderItemDto> OrderItems { get; set; } = new();
}

public class CreateOrderItemDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
