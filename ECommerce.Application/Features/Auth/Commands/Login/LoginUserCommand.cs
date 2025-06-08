namespace Features.Auth.Commands;

public class LoginUserCommand
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
