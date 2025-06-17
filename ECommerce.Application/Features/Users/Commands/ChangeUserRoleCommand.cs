namespace ECommerce.Application.Features.Users.Commands;

public class ChangeUserRoleCommand
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
}
