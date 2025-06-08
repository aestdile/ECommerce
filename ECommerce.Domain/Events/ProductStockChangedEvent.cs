using ECommerce.Domain.Common;
using ECommerce.Domain.Entities.Product;

namespace ECommerce.Domain.Events;

public sealed class ProductStockChangedEvent : IDomainEvent
{
    public Product Product { get; }
    public int OldStock { get; }
    public int NewStock { get; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;

    public ProductStockChangedEvent(Product product, int oldStock, int newStock)
    {
        Product = product;
        OldStock = oldStock;
        NewStock = newStock;
    }
}
