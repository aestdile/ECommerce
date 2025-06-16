using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities.Product;

public class Brand : BaseEntity<Guid>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}