namespace ECommerce.Application.Features.Products.Commands;

public class UpdateProductCommand
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public Guid CategoryId { get; set; }
    public Guid BrandId { get; set; }
}
