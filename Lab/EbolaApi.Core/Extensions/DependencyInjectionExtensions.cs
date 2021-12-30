using EbolaApi.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbolaApi.Core
{
    public static partial class DependencyInjectionExtensions
    {
        public static IServiceCollection AddEbolaApplication(
            this IServiceCollection services,
            Action<EbolaApplication> configureAction)
        {
            var app = new EbolaApplication(services); 

            services.AddConfiguration();
            services.AddEbolaServices();
            services.AddDefaultProviders();

            configureAction(app);

            services.AddFallbackServices();

            return services;
        }

        /// <summary>
        /// Configures and validates options.
        /// </summary>
        /// <typeparam name="TOptions">The options type that should be added.</typeparam>
        /// <param name="services">The dependency injection container to add options.</param>
        /// <param name="key">
        /// The configuration key that should be used when configuring the options.
        /// If null, the root configuration will be used to configure the options.
        /// </param>
        /// <returns>The dependency injection container.</returns>
        public static IServiceCollection AddEbolaOptions<TOptions>(
            this IServiceCollection services,
            string key = null)
            where TOptions : class
        {
            services.AddSingleton<IValidateOptions<TOptions>>(new ValidateBaGetOptions<TOptions>(key));
            services.AddSingleton<IConfigureOptions<TOptions>>(provider =>
            {
                var config = provider.GetRequiredService<IConfiguration>();
                if (key != null)
                {
                    config = config.GetSection(key);
                }

                return new BindOptions<TOptions>(config);
            });

            return services;
        }

        private static void AddConfiguration(this IServiceCollection services)
        {
            services.AddEbolaOptions<EbolaOptions>();
            services.AddEbolaOptions<DatabaseOptions>(nameof(EbolaOptions.Database));
        }

        private static void AddEbolaServices(this IServiceCollection services)
        {
            services.TryAddTransient<CarsService>();
            services.TryAddTransient<TableModelsService>();
            services.TryAddTransient<ManufacturersService>();
            services.TryAddTransient<CustomersService>();
            services.TryAddTransient<MechanicsService>();
            services.TryAddTransient<MechanicsOnServicesService>();
            services.TryAddTransient<ServiceBookingsService>();
        }

        private static void AddDefaultProviders(this IServiceCollection services)
        {
            
        }

        private static void AddFallbackServices(this IServiceCollection services)
        {
            services.TryAddTransient<ICarsService>(provider => provider.GetRequiredService<CarsService>());
            services.TryAddTransient<ITableModelsService>(provider => provider.GetRequiredService<TableModelsService>());
            services.TryAddTransient<IManufacturersService>(provider => provider.GetRequiredService<ManufacturersService>());
            services.TryAddTransient<ICustomersService>(provider => provider.GetRequiredService<CustomersService>());
            services.TryAddTransient<IMechanicsService>(provider => provider.GetRequiredService<MechanicsService>());
            services.TryAddTransient<IServiceBookingsService>(provider => provider.GetRequiredService<ServiceBookingsService>());
            services.TryAddTransient<IMechanicsOnServicesService>(provider => provider.GetRequiredService<MechanicsOnServicesService>());
        }
    }
}
