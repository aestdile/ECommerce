namespace ECommerce.Application.Abstractions.Persistence;

public interface IUnitOfWork
{
    IProductRepository Products { get; }
    IOrderRepository Orders { get; }
    IUserRepository Users { get; }
    IPaymentRepository Payments { get; }
    ICategoryRepository Categories { get; }
    Task<Guid> SaveChangesAsync(CancellationToken cancellationToken = default);
}
