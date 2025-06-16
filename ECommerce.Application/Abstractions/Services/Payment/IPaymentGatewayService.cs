namespace ECommerce.Application.Abstractions.Services.Payment;
public interface IPaymentGatewayService
{
    Task<bool> ProcessPaymentAsync(Guid paymentId);
}
