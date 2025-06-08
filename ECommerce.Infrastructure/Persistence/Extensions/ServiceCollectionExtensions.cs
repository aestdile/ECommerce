using ECommerce.Application.Abstractions.Persistence;
using ECommerce.Application.Abstractions.Services;
using ECommerce.Infrastructure.Data;
using ECommerce.Infrastructure.Services;
using ECommerce.Infrastructure.Services.FileStorage;
using ECommerce.Infrastructure.Services.Notifications;
using ECommerce.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ECommerceDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IFileStorageService, LocalFileStorageService>();

        services.AddScoped<INotificationService, NotificationService>();

        services.AddScoped<IPaymentService, PaymentService>();

        return services;
    }
}
