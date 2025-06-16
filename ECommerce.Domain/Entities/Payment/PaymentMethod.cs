using Microsoft.WindowsAzure.MediaServices.Client;

namespace ECommerce.Domain.Entities.Payment;

public class PaymentMethod : BaseEntity<Guid>
{
    public string Name { get; set; } = default!;
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();

}