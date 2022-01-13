using EbolaApi.Core;
using EbolaApi.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace EbolaApi.SqLite
{
    public static class SqliteApplicationExtensions
    {
        public static EbolaApplication AddSqliteDatabase(this EbolaApplication app)
        {
            app.Services.AddEbolaDbContextProvider<SqliteContext>("Sqlite", (provider, options) =>
            {
                var databaseOptions = provider.GetRequiredService<IOptionsSnapshot<DatabaseOptions>>();

                options.UseSqlite(databaseOptions.Value.ConnectionString);
            });

            return app;
        }

        public static EbolaApplication AddSqliteDatabase(
            this EbolaApplication app,
            Action<DatabaseOptions> configure)
        {
            app.AddSqliteDatabase();
            app.Services.Configure(configure);
            return app;
        }
    }
}
