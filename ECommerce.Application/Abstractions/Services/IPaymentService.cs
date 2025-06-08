using ECommerce.Domain.Entities.Payment;
using ECommerce.Domain.Enums;

namespace ECommerce.Application.Abstractions.Services
{
    public interface IPaymentService
    {
        Task<Payment> CreatePaymentAsync(Guid orderId, decimal amount, Guid paymentMethodId, string? createdBy = null);

        Task<bool> ProcessPaymentAsync(Guid paymentId);

        Task<List<Payment>> GetPaymentHistoryByUserIdAsync(Guid userId);

        Task UpdatePaymentStatusAsync(Guid paymentId, PaymentStatus status, string? modifiedBy = null);
    }
}
