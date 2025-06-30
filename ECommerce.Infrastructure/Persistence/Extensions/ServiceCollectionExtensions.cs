using ECommerce.Application.Abstractions.Persistence;
using ECommerce.Infrastructure.Data;
using ECommerce.Infrastructure.Services.FileStorage;
using ECommerce.Infrastructure.Services.Notifications;
using ECommerce.Infrastructure.Services;
using ECommerce.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ECommerce.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using ECommerce.Application.Abstractions.Services.Auth;
using ECommerce.Application.Abstractions.Services.NotificationService;
using ECommerce.Application.Abstractions.Services.Payment;
using ECommerce.Application.Abstractions.Services.Token;
using ECommerce.Application.Abstractions.Services.FileStorage;
using ECommerce.Infrastructure.Services.Payment;
using ECommerce.Application.Abstractions.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ECommerceDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("ECommerceDb")));

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();


        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IFileStorageService, LocalFileStorageService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IPaymentGatewayService, FakePaymentGatewayService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();



        return services;
    }
}
