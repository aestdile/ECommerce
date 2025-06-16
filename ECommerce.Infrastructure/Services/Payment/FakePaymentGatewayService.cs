using ECommerce.Application.Abstractions.Services.Payment;

public class FakePaymentGatewayService : IPaymentGatewayService
{
    public Task<bool> ProcessPaymentAsync(Guid paymentId)
    {
        return Task.FromResult(true);
    }
}
