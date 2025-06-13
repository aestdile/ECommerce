namespace ECommerce.Application.Abstractions.Services;
public interface IPaymentGatewayService
{
    Task<bool> ProcessPaymentAsync(Guid paymentId);
}
