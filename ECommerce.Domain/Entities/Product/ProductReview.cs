using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities.Product;

public class ProductReview : AuditableEntity<Guid>
{
    public int Rating { get; set; }
    public string Comment { get; set; } = default!;

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = default!;

    public Guid UserId { get; set; }
    public User.User User { get; set; } = default!;
}