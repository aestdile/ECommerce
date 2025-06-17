namespace ECommerce.Application.Features.Brands.Commands;

public class CreateBrandCommand
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}
