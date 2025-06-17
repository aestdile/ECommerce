namespace ECommerce.Application.Features.Payments.Commands;

public class ProcessPaymentCommand
{
    public Guid OrderId { get; set; }
    public Guid PaymentMethodId { get; set; }
    public decimal Amount { get; set; }
}
