using Microsoft.WindowsAzure.MediaServices.Client;

namespace ECommerce.Domain.Entities.User;

public class Role : BaseEntity
{
    public string Name { get; set; } = default!;
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}