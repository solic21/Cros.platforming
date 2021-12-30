using EbolaApi.Core.Entities;
using EbolaApi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EbolaApi.InMemory
{
    public class InMemoryContext : AbstractContext<InMemoryContext>
    {
        /// <summary>
        /// The Sqlite error code for when a unique constraint is violated.
        /// </summary>

        public InMemoryContext(DbContextOptions<InMemoryContext> options)
            : base(options)
        { }

        public override bool IsUniqueConstraintViolationException(DbUpdateException exception)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
