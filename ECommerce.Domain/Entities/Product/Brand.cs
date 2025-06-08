using Microsoft.WindowsAzure.MediaServices.Client;

namespace ECommerce.Domain.Entities.Product;

public class Brand : BaseEntity<Guid>
{
    public string Name { get; set; } = default!;
    public ICollection<Product>? Products { get; set; }
}