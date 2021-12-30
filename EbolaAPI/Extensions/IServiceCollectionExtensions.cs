using EbolaApi.Core;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EbolaAPI.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddEbolaWebApplication(
            this IServiceCollection services,
            Action<EbolaApplication> configureAction)
        {
            services
                .AddControllers();

            services.AddEbolaApplication(configureAction);

            return services;
        }
    }  
}
