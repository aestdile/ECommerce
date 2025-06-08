using ECommerce.Domain.Common;
using ECommerce.Domain.Entities.Order;

namespace ECommerce.Domain.Events;

public sealed class OrderCreatedEvent : IDomainEvent
{
    public Order Order { get; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;

    public OrderCreatedEvent(Order order)
    {
        Order = order;
    }
}
