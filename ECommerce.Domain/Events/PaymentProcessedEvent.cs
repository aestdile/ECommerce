using ECommerce.Domain.Common;
using ECommerce.Domain.Entities.Payment;

namespace ECommerce.Domain.Events;

public sealed class PaymentProcessedEvent : IDomainEvent
{
    public Payment Payment { get; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;

    public PaymentProcessedEvent(Payment payment)
    {
        Payment = payment;
    }
}
