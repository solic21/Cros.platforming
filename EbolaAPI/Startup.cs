using EbolaApi.Core;
using EbolaApi.Core.Entities;
using EbolaAPI.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using EbolaApi.Core.Services;
using EbolaApi.SqlServer;
using EbolaApi.SqLite;
using EbolaApi;

namespace EbolaAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: Ideally we'd use:
            //
            //       services.ConfigureOptions<ConfigureBaGetOptions>();
            //
            //       However, "ConfigureOptions" doesn't register validations as expected.
            //       We'll instead register all these configurations manually.
            // See: https://github.com/dotnet/runtime/issues/38491
            services.AddTransient<IValidateOptions<EbolaOptions>, ConfigureEbolaOptions>();

            services.AddEbolaWebApplication(ConfigureEbolaApplication);

            // You can swap between implementations of subsystems like storage and search using BaGet's configuration.
            // Each subsystem's implementation has a provider that reads the configuration to determine if it should be
            // activated. BaGet will run through all its providers until it finds one that is active.
            services.AddScoped(EbolaApi.Core.Extensions.DependencyInjectionExtensions.GetServiceFromProviders<IContext>);

            services.AddTransient(EbolaApi.Core.Extensions.DependencyInjectionExtensions.GetServiceFromProviders<ICarsService>);
            services.AddTransient(EbolaApi.Core.Extensions.DependencyInjectionExtensions.GetServiceFromProviders<ITableModelsService>);
            services.AddTransient(EbolaApi.Core.Extensions.DependencyInjectionExtensions.GetServiceFromProviders<IManufacturersService>);
            services.AddTransient(EbolaApi.Core.Extensions.DependencyInjectionExtensions.GetServiceFromProviders<ICustomersService>);
            services.AddTransient(EbolaApi.Core.Extensions.DependencyInjectionExtensions.GetServiceFromProviders<IMechanicsService>);
            services.AddTransient(EbolaApi.Core.Extensions.DependencyInjectionExtensions.GetServiceFromProviders<IMechanicsOnServicesService>);
            services.AddTransient(EbolaApi.Core.Extensions.DependencyInjectionExtensions.GetServiceFromProviders<IServiceBookingsService>);

            services.AddSwaggerGen();
        }

        private void ConfigureEbolaApplication(EbolaApplication app)
        {
            // Add database providers.
            app.AddSqliteDatabase();
            app.AddSqlServerDatabase();
            app.AddPostgreSqlDatabase();
            app.AddInMemoryDatabase();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EbolaAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
