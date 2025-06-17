namespace ECommerce.Application.Features.Orders.Commands;

public class CreateOrderCommand
{
    public Guid UserId { get; set; }
    public List<OrderItemDto> OrderItems { get; set; } = new();
    public AddressDto ShippingAddress { get; set; } = default!;
}

public class OrderItemDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

public class AddressDto
{
    public string Country { get; set; } = default!;
    public string State { get; set; } = default!;
    public string City { get; set; } = default!;
    public string Street { get; set; } = default!;
    public string ZipCode { get; set; } = default!;
}
