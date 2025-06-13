using ECommerce.Application.Abstractions.Services;

public class FakePaymentGatewayService : IPaymentGatewayService
{
    public Task<bool> ProcessPaymentAsync(Guid paymentId)
    {
        return Task.FromResult(true);
    }
}
