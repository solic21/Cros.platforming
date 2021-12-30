using EbolaApi.Core;
using EbolaApi.Core.Extensions;
using EbolaApi.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace EbolaApi
{
    public static class PostgreSqlApplicationExtensions
    {
        public static EbolaApplication AddPostgreSqlDatabase(this EbolaApplication app)
        {
            app.Services.AddEbolaDbContextProvider<PostgreSqlContext>("PostgreSql", (provider, options) =>
            {
                var databaseOptions = provider.GetRequiredService<IOptionsSnapshot<DatabaseOptions>>();

                options.UseNpgsql(databaseOptions.Value.ConnectionString);
            });

            return app;
        }

        public static EbolaApplication AddPostgreSqlDatabase(
            this EbolaApplication app,
            Action<DatabaseOptions> configure)
        {
            app.AddPostgreSqlDatabase();
            app.Services.Configure(configure);
            return app;
        }
    }
}
