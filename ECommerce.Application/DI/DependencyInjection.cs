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
            services.AddValidatorsFromAssembly(typeof(IApplicationMarker).Assembly);

            services.AddAutoMapper(typeof(IApplicationMarker).Assembly);

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(IApplicationMarker).Assembly);
            });

            return services;
        }
    }
}