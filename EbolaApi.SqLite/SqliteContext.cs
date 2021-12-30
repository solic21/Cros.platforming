using EbolaApi.Core.Entities;
using EbolaApi.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

namespace EbolaApi.SqLite
{
    public class SqliteContext : AbstractContext<SqliteContext>
    {
        /// <summary>
        /// The Sqlite error code for when a unique constraint is violated.
        /// </summary>
        private const int SqliteUniqueConstraintViolationErrorCode = 19;

        public SqliteContext(DbContextOptions<SqliteContext> options)
            : base(options)
        { }

        public override bool IsUniqueConstraintViolationException(DbUpdateException exception)
        {
            return exception.InnerException is SqliteException sqliteException &&
                sqliteException.SqliteErrorCode == SqliteUniqueConstraintViolationErrorCode;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Location>()
                .Property(p => p.Description)
                .IsRequired(true)
                .HasColumnType("TEXT COLLATE NOCASE");

            builder.Entity<Location>()
                .Property(p => p.OtherInformation)
                .IsRequired(true)
                .HasColumnType("TEXT COLLATE NOCASE");

            //builder.Entity<Package>()
            //    .Property(p => p.NormalizedVersionString)
            //    .HasColumnType("TEXT COLLATE NOCASE");

            //builder.Entity<PackageDependency>()
            //    .Property(d => d.Id)
            //    .HasColumnType("TEXT COLLATE NOCASE");

            //builder.Entity<PackageType>()
            //    .Property(t => t.Name)
            //    .HasColumnType("TEXT COLLATE NOCASE");

            //builder.Entity<TargetFramework>()
            //    .Property(f => f.Moniker)
            //    .HasColumnType("TEXT COLLATE NOCASE");
        }
    }
}
