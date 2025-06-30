
using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities.Order;

public class OrderItem : BaseEntity<Guid>
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = default!;

    public Guid ProductId { get; set; }
    public Product.Product Product { get; set; } = default!;

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}