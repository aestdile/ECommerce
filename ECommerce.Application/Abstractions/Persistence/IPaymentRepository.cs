using ECommerce.Domain.Entities.Payment;

namespace ECommerce.Application.Abstractions.Persistence;

public interface IPaymentRepository
{
    Task<Payment> GetByIdAsync(Guid id);
    Task<List<Payment>> GetPaymentsByUserIdAsync(Guid userId);
    Task<Payment> AddAsync(Payment payment);
    Task<Payment> UpdateAsync(Payment payment);
    Task<bool> ExistsAsync(Guid id);
}

