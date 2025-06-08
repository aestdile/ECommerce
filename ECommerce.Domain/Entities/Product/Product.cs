using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities.Product;

public class Product : AuditableEntity<Guid>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public bool IsDeleted { get; set; } = false;

    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = default!;

    public Guid BrandId { get; set; }
    public Brand Brand { get; set; } = default!;

    public ICollection<ProductImage>? Images { get; set; }
    public ICollection<ProductReview>? Reviews { get; set; }
}