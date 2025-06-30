using ECommerce.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(p => p.Price)
               .IsRequired()
               .HasPrecision(18, 2);

        builder.Property(p => p.Description)
               .HasMaxLength(500);

        builder.Property(p => p.Quantity)
               .IsRequired()
               .HasDefaultValue(0);

        builder.HasOne(p => p.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(p => p.CategoryId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Brand)
               .WithMany(b => b.Products)
               .HasForeignKey(p => p.BrandId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Images)
               .WithOne(pi => pi.Product)
               .HasForeignKey(pi => pi.ProductId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Reviews)
               .WithOne(pr => pr.Product)
               .HasForeignKey(pr => pr.ProductId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(p => p.CreatedOn).IsRequired();
        builder.Property(p => p.UpdatedOn).IsRequired(false);
    }
}
