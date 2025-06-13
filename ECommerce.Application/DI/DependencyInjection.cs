using AutoMapper;
using ECommerce.Application.Common.Markers;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // FluentValidation qo'shish
            services.AddValidatorsFromAssembly(typeof(IApplicationMarker).Assembly);

            // AutoMapper qo'shish
            services.AddAutoMapper(typeof(IApplicationMarker).Assembly);

            // MediatR qo'shish (yangi versiya uchun)
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(IApplicationMarker).Assembly);
            });

            return services;
        }
    }
}