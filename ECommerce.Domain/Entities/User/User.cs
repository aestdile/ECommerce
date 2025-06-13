using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities.User;

public class User : AuditableEntity<Guid>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public bool IsActive { get; set; } = true;

    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public ICollection<Order.Order>? Orders { get; set; }
    public ICollection<Product.ProductReview>? Reviews { get; set; }
}