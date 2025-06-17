namespace ECommerce.Application.Features.Users.Commands;

public class UpdateUserProfileCommand
{
    public Guid UserId { get; set; }
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string? ProfileImageUrl { get; set; }
}
