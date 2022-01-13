using EbolaApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Linq;

namespace EbolaApi.SqlServer
{
    public class SqlServerContext : AbstractContext<SqlServerContext>
    {
        private const int UniqueConstraintViolationErrorCode = 2627;

        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options)
        { }
        public override bool IsUniqueConstraintViolationException(DbUpdateException exception)
        {
            if (exception.GetBaseException() is SqlException sqlException)
            {
                return sqlException.Errors
                    .OfType<SqlError>()
                    .Any(error => error.Number == UniqueConstraintViolationErrorCode);
            }

            return false;
        }
    }
}
