using EbolaApi.Core.Entities;
using EbolaApi.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbolaApi.Core.Extensions
{
    public static partial class DependencyInjectionExtensions
    {
        private static readonly string DatabaseTypeKey = $"{nameof(EbolaOptions.Database)}:{nameof(DatabaseOptions.Type)}";

        /// <summary>
        /// Add a new provider to the dependency injection container. The provider may
        /// provide an implementation of the service, or it may return null.
        /// </summary>
        /// <typeparam name="TService">The service that may be provided.</typeparam>
        /// <param name="services">The dependency injection container.</param>
        /// <param name="func">A handler that provides the service, or null.</param>
        /// <returns>The dependency injection container.</returns>
        public static IServiceCollection AddProvider<TService>(
            this IServiceCollection services,
            Func<IServiceProvider, IConfiguration, TService> func)
            where TService : class
        {
            services.AddSingleton<IProvider<TService>>(new DelegateProvider<TService>(func));

            return services;
        }

        /// <summary>
        /// Determine whether a database type is currently active.
        /// </summary>
        /// <param name="config">The application's configuration.</param>
        /// <param name="value">The database type that should be checked.</param>
        /// <returns>Whether the database type is active.</returns>
        public static bool HasDatabaseType(this IConfiguration config, string value)
        {
            return config[DatabaseTypeKey].Equals(value, StringComparison.OrdinalIgnoreCase);
        }

        public static IServiceCollection AddEbolaDbContextProvider<TContext>(
            this IServiceCollection services,
            string databaseType,
            Action<IServiceProvider, DbContextOptionsBuilder> configureContext)
            where TContext : DbContext, IContext
        {
            services.TryAddScoped<IContext>(provider => provider.GetRequiredService<TContext>());

            //services.TryAddTransient<IPackageService>(provider => provider.GetRequiredService<PackageService>());

            services.AddDbContext<TContext>(configureContext);

            services.AddProvider<IContext>((provider, config) =>
            {
                if (!config.HasDatabaseType(databaseType)) return null;

                return provider.GetRequiredService<TContext>();
            });

            //services.AddProvider<IPackageService>((provider, config) =>
            //{
            //    if (!config.HasDatabaseType(databaseType)) return null;

            //    return provider.GetRequiredService<PackageService>();
            //});

            //services.AddProvider<ISearchIndexer>((provider, config) =>
            //{
            //    if (!config.HasSearchType(DatabaseSearchType)) return null;
            //    if (!config.HasDatabaseType(databaseType)) return null;

            //    return provider.GetRequiredService<NullSearchIndexer>();
            //});

            services.AddProvider<ICarsService>((provider, config) =>
            {
                if (!config.HasDatabaseType(databaseType)) return null;

                return provider.GetRequiredService<CarsService>();
            });

            services.AddProvider<ITableModelsService>((provider, config) =>
            {
                if (!config.HasDatabaseType(databaseType)) return null;

                return provider.GetRequiredService<TableModelsService>();
            });

            services.AddProvider<IManufacturersService>((provider, config) =>
            {
                if (!config.HasDatabaseType(databaseType)) return null;

                return provider.GetRequiredService<ManufacturersService>();
            });

            services.AddProvider<ICustomersService>((provider, config) =>
            {
                if (!config.HasDatabaseType(databaseType)) return null;

                return provider.GetRequiredService<CustomersService>();
            });

            services.AddProvider<IMechanicsService>((provider, config) =>
            {
                if (!config.HasDatabaseType(databaseType)) return null;

                return provider.GetRequiredService<MechanicsService>();
            });

            services.AddProvider<IServiceBookingsService>((provider, config) =>
            {
                if (!config.HasDatabaseType(databaseType)) return null;

                return provider.GetRequiredService<ServiceBookingsService>();
            });

            services.AddProvider<IMechanicsOnServicesService>((provider, config) =>
            {
                if (!config.HasDatabaseType(databaseType)) return null;

                return provider.GetRequiredService<MechanicsOnServicesService>();
            });

            return services;
        }

        /// <summary>
        /// Runs through all providers to resolve the <typeparamref name="TService"/>.
        /// </summary>
        /// <typeparam name="TService">The service that will be resolved using providers.</typeparam>
        /// <param name="services">The dependency injection container.</param>
        /// <returns>An instance of the service created by the providers.</returns>
        public static TService GetServiceFromProviders<TService>(IServiceProvider services)
            where TService : class
        {
            // Run through all the providers for the type. Find the first provider that results a non-null result.
            var providers = services.GetRequiredService<IEnumerable<IProvider<TService>>>();
            var configuration = services.GetRequiredService<IConfiguration>();

            foreach (var provider in providers)
            {
                var result = provider.GetOrNull(services, configuration);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }
    }
}
