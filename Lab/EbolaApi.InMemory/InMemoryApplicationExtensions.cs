using EbolaApi.Core;
using EbolaApi.Core.Extensions;
using EbolaApi.InMemory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace EbolaApi
{
    public static class InMemoryApplicationExtensions
    {
        public static EbolaApplication AddInMemoryDatabase(this EbolaApplication app)
        {
            app.Services.AddEbolaDbContextProvider<InMemoryContext>("InMemory", (provider, options) =>
            {
                var databaseOptions = provider.GetRequiredService<IOptionsSnapshot<DatabaseOptions>>();

                options.UseInMemoryDatabase(databaseOptions.Value.ConnectionString);
            });

            return app;
        }

        public static EbolaApplication AddInMemoryDatabase(
            this EbolaApplication app,
            Action<DatabaseOptions> configure)
        {
            app.AddInMemoryDatabase();
            app.Services.Configure(configure);
            return app;
        }
    }
}
