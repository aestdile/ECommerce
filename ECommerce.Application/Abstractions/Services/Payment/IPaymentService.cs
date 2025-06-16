using ECommerce.Domain.Enums;
namespace ECommerce.Application.Abstractions.Services.Payment;

public interface IPaymentService
{
    Task<Domain.Entities.Payment.Payment> CreatePaymentAsync(Guid orderId, decimal amount, Guid paymentMethodId, string? createdBy = null);

    Task<bool> ProcessPaymentAsync(Guid paymentId);

    Task<List<Domain.Entities.Payment.Payment>> GetPaymentHistoryByUserIdAsync(Guid userId);

    Task UpdatePaymentStatusAsync(Guid paymentId, PaymentStatus status, string? modifiedBy = null);
    //Task CreatePaymentAsync(Guid orderId, decimal amount, Guid paymentMethodId, Guid userId);
}
