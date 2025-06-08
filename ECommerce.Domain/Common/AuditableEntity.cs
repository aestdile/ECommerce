namespace ECommerce.Domain.Common;

public abstract class AuditableEntity<TId> : BaseEntity<TId>
{
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
    public string? ModifiedBy { get; set; }
}
