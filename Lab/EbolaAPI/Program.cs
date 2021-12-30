using EbolaApi.Core;
using EbolaAPI.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Threading;

namespace EbolaAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            bool migration = host.Services.GetService<IOptions<DatabaseOptions>>().Value.RunMigration;

            if (migration)
                host.RunMigrationsAsync(new CancellationToken()).GetAwaiter().GetResult();
            host.RunAsync(new CancellationToken()).GetAwaiter().GetResult();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
