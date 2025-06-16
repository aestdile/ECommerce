namespace ECommerce.Application.Features.Brands.DTOs;

public class CreateBrandDto
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}
