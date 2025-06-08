using ECommerce.Application.Abstractions.Persistence;
using ECommerce.Infrastructure.Data;

namespace ECommerce.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ECommerceDbContext _context;

    public UnitOfWork(
        ECommerceDbContext context,
        IProductRepository products,
        IOrderRepository orders,
        IUserRepository users,
        IPaymentRepository payments,
        ICategoryRepository categories)
    {
        _context = context;
        Products = products;
        Orders = orders;
        Users = users;
        Payments = payments;
        Categories = categories;
    }

    public IProductRepository Products { get; }
    public IOrderRepository Orders { get; }
    public IUserRepository Users { get; }
    public IPaymentRepository Payments { get; }
    public ICategoryRepository Categories { get; }

    public async Task<Guid> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
        return Guid.NewGuid(); // yoki boshqa relevant qiymat
    }
}
