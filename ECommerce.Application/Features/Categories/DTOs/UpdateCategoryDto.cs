namespace ECommerce.Application.Features.Categories.DTOs;

public class UpdateCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
}
