using ECommerce.Domain.Common;
using ECommerce.Domain.Enums;

namespace ECommerce.Domain.Entities.Payment;

public class Payment : AuditableEntity<Guid>
{
    public Guid UserId { get; set; }
    public User.User User { get; set; } = default!;

    public Guid OrderId { get; set; }
    public Order.Order Order { get; set; } = default!;

    public Guid UserId { get; set; }
    public PaymentStatus Status { get; set; }
    public decimal Amount { get; set; }

    public Guid PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; } = default!;
}