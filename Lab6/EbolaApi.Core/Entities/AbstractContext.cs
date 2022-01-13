using EbolaApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EbolaApi.Core.Entities
{
    public abstract class AbstractContext<TContext> : DbContext, IContext where TContext : DbContext
    {
        //public const int DefaultMaxStringLength = 4000;

        //public const int MaxPackageIdLength = 128;
        //public const int MaxPackageVersionLength = 64;
        //public const int MaxPackageMinClientVersionLength = 44;
        //public const int MaxPackageLanguageLength = 20;
        //public const int MaxPackageTitleLength = 256;
        //public const int MaxPackageTypeNameLength = 512;
        //public const int MaxPackageTypeVersionLength = 64;
        //public const int MaxRepositoryTypeLength = 100;
        //public const int MaxTargetFrameworkLength = 256;

        //public const int MaxPackageDependencyVersionRangeLength = 256;

        public AbstractContext(DbContextOptions<TContext> options)
            : base(options)
        { }

        public DbSet<Cars> MyCars { get; set; }
        public DbSet<TableModels> MyTableModels { get; set; }
        public DbSet<Manufacturers> MyManufacturers { get; set; }
        public DbSet<Customers> MyCustomers { get; set; }
        public DbSet<ServiceBookings> MyServiceBookings { get; set; }
        public DbSet<Mechanics> MyMechanics { get; set; } 
        public DbSet<MechanicsOnServices> MyMechanicsOnServices { get; set; } 

        public Task<int> SaveChangesAsync() => SaveChangesAsync(default);

        public virtual async Task RunMigrationsAsync(CancellationToken cancellationToken)
            => await Database.MigrateAsync(cancellationToken);

        public abstract bool IsUniqueConstraintViolationException(DbUpdateException exception);

        public virtual bool SupportsLimitInSubqueries => true;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cars>(BuildCarsEntity);
            builder.Entity<TableModels>(BuildTableModelsEntity);
            builder.Entity<Manufacturers>(BuildManufacturersEntity);
            builder.Entity<Customers>(BuildCustomersEntity);
            builder.Entity<ServiceBookings>(BuildServiceBookingsEntity);
            builder.Entity<Mechanics>(BuildMechanicsEntity);
            builder.Entity<MechanicsOnServices>(BuildMechanicsOnServicesEntity);
        }

        private void BuildCarsEntity(EntityTypeBuilder<Cars> cars)
        {
            cars.HasKey(l => l.LicenceNumber);
            cars.HasIndex(l => l.LicenceNumber);

            cars.Property(l => l.LicenceNumber).IsRequired();
            cars.Property(l => l.CurrentMileage).IsRequired().HasMaxLength(500);
            cars.Property(l => l.CustomerId).IsRequired().HasMaxLength(500);
            cars.Property(l => l.EngineSize).IsRequired().HasMaxLength(500);
            cars.Property(l => l.ModelCode).IsRequired().HasMaxLength(500);
            cars.Property(l => l.OtherCarDetails).IsRequired().HasMaxLength(500);

            cars.HasOne(l => l.TableModels).WithMany(l => l.Cars).HasForeignKey(l => l.ModelCode);
            cars.HasOne(l => l.Customers).WithMany(l => l.Cars).HasForeignKey(l => l.CustomerId);
        }

        private void BuildTableModelsEntity(EntityTypeBuilder<TableModels> model)
        {
            model.HasKey(l => l.ModelCode);
            model.HasIndex(l => l.ModelCode);

            model.Property(l => l.ModelCode).IsRequired();
            model.Property(l => l.ManufacturerCode).IsRequired().HasMaxLength(500);
            model.Property(l => l.ModelName).IsRequired().HasMaxLength(500);
            model.Property(l => l.OtherModelDetails).IsRequired().HasMaxLength(500);

            model.HasOne(l => l.Manufacturers).WithMany(l => l.TableModels).HasForeignKey(l => l.ManufacturerCode);
        }

        private void BuildManufacturersEntity(EntityTypeBuilder<Manufacturers> model)
        {
            model.HasKey(l => l.ManufacturerCode);
            model.HasIndex(l => l.ManufacturerCode);

            model.Property(l => l.ManufacturerCode).IsRequired();
            model.Property(l => l.ManufacturerName).IsRequired().HasMaxLength(500);
            model.Property(l => l.OtherManufacturerDetails).IsRequired().HasMaxLength(500);
        }

        private void BuildCustomersEntity(EntityTypeBuilder<Customers> model)
        {
            model.HasKey(l => l.CustomerId);
            model.HasIndex(l => l.CustomerId);

            model.Property(l => l.CustomerId).IsRequired();
            model.Property(l => l.AddressLine1).IsRequired().HasMaxLength(500);
            model.Property(l => l.AddressLine2).IsRequired().HasMaxLength(500);
            model.Property(l => l.AddressLine3).IsRequired().HasMaxLength(500);
            model.Property(l => l.City).IsRequired().HasMaxLength(500);
            model.Property(l => l.State).IsRequired().HasMaxLength(500);
            model.Property(l => l.EmailAddress).IsRequired().HasMaxLength(500);
            model.Property(l => l.FirstName).IsRequired().HasMaxLength(500);
            model.Property(l => l.LastName).IsRequired().HasMaxLength(500);
            model.Property(l => l.OtherCustomerDetails).IsRequired().HasMaxLength(500);
            model.Property(l => l.PhoneNumber).IsRequired().HasMaxLength(500);
            model.Property(l => l.Title).IsRequired().HasMaxLength(500);
            model.Property(l => l.Gender).IsRequired().HasMaxLength(500);
        }

        private void BuildServiceBookingsEntity(EntityTypeBuilder<ServiceBookings> model)
        {
            model.HasKey(l => l.SvcBookingId);
            model.HasIndex(l => l.SvcBookingId);

            model.Property(l => l.SvcBookingId).IsRequired();
            model.Property(l => l.CustomerId).IsRequired().HasMaxLength(500);
            model.Property(l => l.LicenceNumber).IsRequired().HasMaxLength(500);
            model.Property(l => l.DatatimeOfService).IsRequired().HasMaxLength(500);
            model.Property(l => l.PaymentReceivedYn).IsRequired().HasMaxLength(500);
            model.Property(l => l.OtherSvcBookingDetails).IsRequired().HasMaxLength(500);

            model.HasOne(l => l.Cars).WithMany(l => l.ServiceBookings).HasForeignKey(l => l.LicenceNumber);
            model.HasOne(l => l.Customers).WithMany(l => l.ServiceBookings).HasForeignKey(l => l.CustomerId);
        }

        private void BuildMechanicsEntity(EntityTypeBuilder<Mechanics> model) 
        {
            model.HasKey(l => l.MechanicId);
            model.HasIndex(l => l.MechanicId);

            model.Property(l => l.MechanicId).IsRequired();
            model.Property(l => l.MechanicName).IsRequired().HasMaxLength(500);
            model.Property(l => l.OtherMechanicDetails).IsRequired().HasMaxLength(500);
        }

        private void BuildMechanicsOnServicesEntity(EntityTypeBuilder<MechanicsOnServices> model)
        {
            model.HasKey(l => l.MechanicsOnServicesId);
            model.HasIndex(l => l.MechanicsOnServicesId);

            model.Property(l => l.MechanicsOnServicesId).IsRequired();
            model.Property(l => l.MechanicId).IsRequired();
            model.Property(l => l.SvcBookingId).IsRequired();

            model.HasOne(l => l.Mechanics).WithMany(l => l.MechanicsOnServices).HasForeignKey(l => l.MechanicId);
            model.HasOne(l => l.ServiceBookings).WithMany(l => l.MechanicsOnServices).HasForeignKey(l => l.SvcBookingId);
        }
    }
}
