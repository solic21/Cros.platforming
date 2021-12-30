using EbolaApi.Core;
using EbolaApi.Core.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EbolaAPI.Extensions
{
    public static class IHostExtensions
    {
        public static IHostBuilder UseEbola(this IHostBuilder host, Action<EbolaApplication> configure)
        {
            return host.ConfigureServices(services =>
            {
                services.AddEbolaWebApplication(configure);
            });
        }

        public static async Task RunMigrationsAsync(
            this IHost host,
            CancellationToken cancellationToken = default)
        {
            // Run migrations if necessary.
            var options = host.Services.GetRequiredService<IOptions<EbolaOptions>>();

            if (options.Value.RunMigrationsAtStartup)
            {
                using (var scope = host.Services.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<IContext>();
                    if (ctx != null)
                    {
                        await ctx.RunMigrationsAsync(cancellationToken);
                    }
                }
            }
        }

        //public static bool ValidateStartupOptions(this IHost host)
        //{
        //    return host
        //        .Services
        //        .GetRequiredService<ValidateStartupOptions>()
        //        .Validate();
        //}
    }
}
