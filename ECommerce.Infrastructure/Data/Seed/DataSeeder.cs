using ECommerce.Domain.Entities.User;
using ECommerce.Domain.Entities.Payment;
using ECommerce.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using ECommerce.Infrastructure.Data;

namespace ECommerce.Persistence.Data;

public static class DataSeeder
{
    public static async Task SeedAsync(ECommerceDbContext context)
    {
        // Ma'lumotlar mavjud emasligini tekshiramiz
        if (!await context.Roles.AnyAsync())
        {
            var roles = new List<Role>
            {
                new Role { Id = Guid.NewGuid(), Name = "Admin" },
                new Role { Id = Guid.NewGuid(), Name = "Customer" }
            };
            await context.Roles.AddRangeAsync(roles);
        }

        if (!await context.PaymentMethods.AnyAsync())
        {
            var methods = new List<PaymentMethod>
            {
                new PaymentMethod { Id = Guid.NewGuid(), Name = "Credit Card" },
                new PaymentMethod { Id = Guid.NewGuid(), Name = "PayPal" },
                new PaymentMethod { Id = Guid.NewGuid(), Name = "Cash" }
            };
            await context.PaymentMethods.AddRangeAsync(methods);
        }

        if (!await context.Categories.AnyAsync())
        {
            var categories = new List<Category>
            {
                new Category { Id = Guid.NewGuid(), Name = "Electronics" },
                new Category { Id = Guid.NewGuid(), Name = "Books" },
                new Category { Id = Guid.NewGuid(), Name = "Fashion" }
            };
            await context.Categories.AddRangeAsync(categories);
        }

        await context.SaveChangesAsync();
    }
}
