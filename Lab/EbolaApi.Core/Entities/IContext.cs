using EbolaApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace EbolaApi.Core.Entities
{
    public interface IContext
    {
        DatabaseFacade Database { get; }

        DbSet<Cars> MyCars { get; set; }
        DbSet<TableModels> MyTableModels { get; set; }
        DbSet<Manufacturers> MyManufacturers { get; set; }
        DbSet<Customers> MyCustomers { get; set; }
        DbSet<ServiceBookings> MyServiceBookings { get; set; }
        DbSet<Mechanics> MyMechanics { get; set; }
        DbSet<MechanicsOnServices> MyMechanicsOnServices { get; set; }

        /// <summary>
        /// Check whether a <see cref="DbUpdateException"/> is due to a SQL unique constraint violation.
        /// </summary>
        /// <param name="exception">The exception to inspect.</param>
        /// <returns>Whether the exception was caused to SQL unique constraint violation.</returns>
        bool IsUniqueConstraintViolationException(DbUpdateException exception);

        /// <summary>
        /// Whether this database engine supports LINQ "Take" in subqueries.
        /// </summary>
        bool SupportsLimitInSubqueries { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Applies any pending migrations for the context to the database.
        /// Creates the database if it does not already exist.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the task.</param>
        /// <returns>A task that completes once migrations are applied.</returns>
        Task RunMigrationsAsync(CancellationToken cancellationToken);
    }
}
