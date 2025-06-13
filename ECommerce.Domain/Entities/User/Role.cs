
using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities.User;

public class Role : BaseEntity<Guid>
{
    public string Name { get; set; } = default!;
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}