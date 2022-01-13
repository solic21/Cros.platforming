using EbolaApi.Core;
using EbolaApi.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace EbolaApi.SqlServer
{
    public static class SqlServerApplicationExtensions
    {
        public static EbolaApplication AddSqlServerDatabase(this EbolaApplication app)
        {
            app.Services.AddEbolaDbContextProvider<SqlServerContext>("SqlServer", (provider, options) =>
            {
                var databaseOptions = provider.GetRequiredService<IOptionsSnapshot<DatabaseOptions>>();

                options.UseSqlServer(databaseOptions.Value.ConnectionString);
            });

            return app;
        }

        public static EbolaApplication AddSqlServerDatabase(
            this EbolaApplication app,
            Action<DatabaseOptions> configure)
        {
            app.AddSqlServerDatabase();
            app.Services.Configure(configure);
            return app;
        }
    }
}
