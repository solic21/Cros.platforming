// <auto-generated />
using EbolaApi.SqLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EbolaApi.SqLite.Migrations
{
    [DbContext(typeof(SqliteContext))]
    [Migration("20211128160033_MigrationName")]
    partial class MigrationName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("EbolaApi.Models.Cars", b =>
                {
                    b.Property<int>("LicenceNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentMileage")
                        .HasMaxLength(500)
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasMaxLength(500)
                        .HasColumnType("INTEGER");

                    b.Property<int>("EngineSize")
                        .HasMaxLength(500)
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModelCode")
                        .HasMaxLength(500)
                        .HasColumnType("INTEGER");

                    b.Property<string>("OtherCarDetails")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.HasKey("LicenceNumber");

                    b.HasIndex("CustomerId");

                    b.HasIndex("LicenceNumber");

                    b.HasIndex("ModelCode");

                    b.ToTable("MyCars");
                });

            modelBuilder.Entity("EbolaApi.Models.Customers", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressLine3")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("OtherCustomerDetails")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("MyCustomers");
                });

            modelBuilder.Entity("EbolaApi.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT COLLATE NOCASE");

                    b.Property<string>("OtherInformation")
                        .IsRequired()
                        .HasColumnType("TEXT COLLATE NOCASE");

                    b.HasKey("LocationId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("EbolaApi.Models.Manufacturers", b =>
                {
                    b.Property<int>("ManufacturerCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ManufacturerName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("OtherManufacturerDetails")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.HasKey("ManufacturerCode");

                    b.HasIndex("ManufacturerCode");

                    b.ToTable("MyManufacturers");
                });

            modelBuilder.Entity("EbolaApi.Models.Mechanics", b =>
                {
                    b.Property<int>("MechanicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MechanicName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("OtherMechanicDetails")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.HasKey("MechanicId");

                    b.HasIndex("MechanicId");

                    b.ToTable("MyMechanics");
                });

            modelBuilder.Entity("EbolaApi.Models.MechanicsOnServices", b =>
                {
                    b.Property<int>("MechanicsOnServicesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MechanicId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SvcBookingId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MechanicsOnServicesId");

                    b.HasIndex("MechanicId");

                    b.HasIndex("MechanicsOnServicesId");

                    b.HasIndex("SvcBookingId");

                    b.ToTable("MyMechanicsOnServices");
                });

            modelBuilder.Entity("EbolaApi.Models.ServiceBookings", b =>
                {
                    b.Property<int>("SvcBookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasMaxLength(500)
                        .HasColumnType("INTEGER");

                    b.Property<string>("DatatimeOfService")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int>("LicenceNumber")
                        .HasMaxLength(500)
                        .HasColumnType("INTEGER");

                    b.Property<string>("OtherSvcBookingDetails")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<bool>("PaymentReceivedYn")
                        .HasMaxLength(500)
                        .HasColumnType("INTEGER");

                    b.HasKey("SvcBookingId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("LicenceNumber");

                    b.HasIndex("SvcBookingId");

                    b.ToTable("MyServiceBookings");
                });

            modelBuilder.Entity("EbolaApi.Models.TableModels", b =>
                {
                    b.Property<int>("ModelCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ManufacturerCode")
                        .HasMaxLength(500)
                        .HasColumnType("INTEGER");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("OtherModelDetails")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.HasKey("ModelCode");

                    b.HasIndex("ManufacturerCode");

                    b.HasIndex("ModelCode");

                    b.ToTable("MyTableModels");
                });

            modelBuilder.Entity("EbolaApi.Models.Cars", b =>
                {
                    b.HasOne("EbolaApi.Models.Customers", "Customers")
                        .WithMany("Cars")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EbolaApi.Models.TableModels", "TableModels")
                        .WithMany("Cars")
                        .HasForeignKey("ModelCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");

                    b.Navigation("TableModels");
                });

            modelBuilder.Entity("EbolaApi.Models.MechanicsOnServices", b =>
                {
                    b.HasOne("EbolaApi.Models.Mechanics", "Mechanics")
                        .WithMany("MechanicsOnServices")
                        .HasForeignKey("MechanicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EbolaApi.Models.ServiceBookings", "ServiceBookings")
                        .WithMany("MechanicsOnServices")
                        .HasForeignKey("SvcBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mechanics");

                    b.Navigation("ServiceBookings");
                });

            modelBuilder.Entity("EbolaApi.Models.ServiceBookings", b =>
                {
                    b.HasOne("EbolaApi.Models.Customers", "Customers")
                        .WithMany("ServiceBookings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EbolaApi.Models.Cars", "Cars")
                        .WithMany("ServiceBookings")
                        .HasForeignKey("LicenceNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cars");

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("EbolaApi.Models.TableModels", b =>
                {
                    b.HasOne("EbolaApi.Models.Manufacturers", "Manufacturers")
                        .WithMany("TableModels")
                        .HasForeignKey("ManufacturerCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturers");
                });

            modelBuilder.Entity("EbolaApi.Models.Cars", b =>
                {
                    b.Navigation("ServiceBookings");
                });

            modelBuilder.Entity("EbolaApi.Models.Customers", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("ServiceBookings");
                });

            modelBuilder.Entity("EbolaApi.Models.Manufacturers", b =>
                {
                    b.Navigation("TableModels");
                });

            modelBuilder.Entity("EbolaApi.Models.Mechanics", b =>
                {
                    b.Navigation("MechanicsOnServices");
                });

            modelBuilder.Entity("EbolaApi.Models.ServiceBookings", b =>
                {
                    b.Navigation("MechanicsOnServices");
                });

            modelBuilder.Entity("EbolaApi.Models.TableModels", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
