using ECommerce.Domain.Entities.Payment;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Amount)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Status)
               .IsRequired()
               .HasConversion<int>();

        builder.HasOne(p => p.User)
               .WithMany(u => u.Payments)
               .HasForeignKey(p => p.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Order)
               .WithOne(o => o.Payment)
               .HasForeignKey<Payment>(p => p.OrderId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.PaymentMethod)
               .WithMany(pm => pm.Payments)
               .HasForeignKey(p => p.PaymentMethodId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("Payments");
    }
}
