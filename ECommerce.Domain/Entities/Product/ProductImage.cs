
using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities.Product;

public class ProductImage : BaseEntity<Guid>
{
    public string ImageUrl { get; set; } = default!;
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = default!;
}