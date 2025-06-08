using ECommerce.Domain.Common;
using ECommerce.Domain.Enums;
using ECommerce.Domain.ValueObjects;

namespace ECommerce.Domain.Entities.Order;

public class Order : AuditableEntity<Guid>
{
    public Guid UserId { get; set; }
    public User.User User { get; set; } = default!;

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    public Address ShippingAddress { get; set; } = default!;

    public decimal TotalPrice { get; set; }
}
