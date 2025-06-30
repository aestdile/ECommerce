namespace ECommerce.Application.DTOs.Product;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public Guid BrandId { get; set; }
    public Guid CategoryId { get; set; }
}
