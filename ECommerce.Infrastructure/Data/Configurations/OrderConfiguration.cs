using ECommerce.Domain.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.TotalPrice)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

        builder.Property(o => o.Status)
               .IsRequired()
               .HasConversion<int>();

        builder.HasOne(o => o.User)
               .WithMany(u => u.Orders)
               .HasForeignKey(o => o.UserId)
               .OnDelete(DeleteBehavior.Restrict); 

        builder.HasMany(o => o.OrderItems)
               .WithOne(oi => oi.Order)
               .HasForeignKey(oi => oi.OrderId)
               .OnDelete(DeleteBehavior.Cascade); 

        builder.HasOne(o => o.Payment)
               .WithOne(p => p.Order)
               .HasForeignKey<ECommerce.Domain.Entities.Payment.Payment>(p => p.OrderId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
