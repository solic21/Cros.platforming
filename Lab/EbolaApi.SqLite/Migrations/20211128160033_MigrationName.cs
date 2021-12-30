using Microsoft.EntityFrameworkCore.Migrations;

namespace EbolaApi.SqLite.Migrations
{
    public partial class MigrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT COLLATE NOCASE", nullable: false),
                    OtherInformation = table.Column<string>(type: "TEXT COLLATE NOCASE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "MyCustomers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    AddressLine1 = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    AddressLine2 = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    AddressLine3 = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    State = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    OtherCustomerDetails = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyCustomers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "MyManufacturers",
                columns: table => new
                {
                    ManufacturerCode = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManufacturerName = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    OtherManufacturerDetails = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyManufacturers", x => x.ManufacturerCode);
                });

            migrationBuilder.CreateTable(
                name: "MyMechanics",
                columns: table => new
                {
                    MechanicId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MechanicName = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    OtherMechanicDetails = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyMechanics", x => x.MechanicId);
                });

            migrationBuilder.CreateTable(
                name: "MyTableModels",
                columns: table => new
                {
                    ModelCode = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManufacturerCode = table.Column<int>(type: "INTEGER", maxLength: 500, nullable: false),
                    ModelName = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    OtherModelDetails = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyTableModels", x => x.ModelCode);
                    table.ForeignKey(
                        name: "FK_MyTableModels_MyManufacturers_ManufacturerCode",
                        column: x => x.ManufacturerCode,
                        principalTable: "MyManufacturers",
                        principalColumn: "ManufacturerCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyCars",
                columns: table => new
                {
                    LicenceNumber = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModelCode = table.Column<int>(type: "INTEGER", maxLength: 500, nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", maxLength: 500, nullable: false),
                    CurrentMileage = table.Column<int>(type: "INTEGER", maxLength: 500, nullable: false),
                    EngineSize = table.Column<int>(type: "INTEGER", maxLength: 500, nullable: false),
                    OtherCarDetails = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyCars", x => x.LicenceNumber);
                    table.ForeignKey(
                        name: "FK_MyCars_MyCustomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "MyCustomers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyCars_MyTableModels_ModelCode",
                        column: x => x.ModelCode,
                        principalTable: "MyTableModels",
                        principalColumn: "ModelCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyServiceBookings",
                columns: table => new
                {
                    SvcBookingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", maxLength: 500, nullable: false),
                    LicenceNumber = table.Column<int>(type: "INTEGER", maxLength: 500, nullable: false),
                    PaymentReceivedYn = table.Column<bool>(type: "INTEGER", maxLength: 500, nullable: false),
                    DatatimeOfService = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    OtherSvcBookingDetails = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyServiceBookings", x => x.SvcBookingId);
                    table.ForeignKey(
                        name: "FK_MyServiceBookings_MyCars_LicenceNumber",
                        column: x => x.LicenceNumber,
                        principalTable: "MyCars",
                        principalColumn: "LicenceNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyServiceBookings_MyCustomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "MyCustomers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyMechanicsOnServices",
                columns: table => new
                {
                    MechanicsOnServicesId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MechanicId = table.Column<int>(type: "INTEGER", nullable: false),
                    SvcBookingId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyMechanicsOnServices", x => x.MechanicsOnServicesId);
                    table.ForeignKey(
                        name: "FK_MyMechanicsOnServices_MyMechanics_MechanicId",
                        column: x => x.MechanicId,
                        principalTable: "MyMechanics",
                        principalColumn: "MechanicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyMechanicsOnServices_MyServiceBookings_SvcBookingId",
                        column: x => x.SvcBookingId,
                        principalTable: "MyServiceBookings",
                        principalColumn: "SvcBookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyCars_CustomerId",
                table: "MyCars",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MyCars_LicenceNumber",
                table: "MyCars",
                column: "LicenceNumber");

            migrationBuilder.CreateIndex(
                name: "IX_MyCars_ModelCode",
                table: "MyCars",
                column: "ModelCode");

            migrationBuilder.CreateIndex(
                name: "IX_MyCustomers_CustomerId",
                table: "MyCustomers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MyManufacturers_ManufacturerCode",
                table: "MyManufacturers",
                column: "ManufacturerCode");

            migrationBuilder.CreateIndex(
                name: "IX_MyMechanics_MechanicId",
                table: "MyMechanics",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_MyMechanicsOnServices_MechanicId",
                table: "MyMechanicsOnServices",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_MyMechanicsOnServices_MechanicsOnServicesId",
                table: "MyMechanicsOnServices",
                column: "MechanicsOnServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_MyMechanicsOnServices_SvcBookingId",
                table: "MyMechanicsOnServices",
                column: "SvcBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_MyServiceBookings_CustomerId",
                table: "MyServiceBookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MyServiceBookings_LicenceNumber",
                table: "MyServiceBookings",
                column: "LicenceNumber");

            migrationBuilder.CreateIndex(
                name: "IX_MyServiceBookings_SvcBookingId",
                table: "MyServiceBookings",
                column: "SvcBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_MyTableModels_ManufacturerCode",
                table: "MyTableModels",
                column: "ManufacturerCode");

            migrationBuilder.CreateIndex(
                name: "IX_MyTableModels_ModelCode",
                table: "MyTableModels",
                column: "ModelCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "MyMechanicsOnServices");

            migrationBuilder.DropTable(
                name: "MyMechanics");

            migrationBuilder.DropTable(
                name: "MyServiceBookings");

            migrationBuilder.DropTable(
                name: "MyCars");

            migrationBuilder.DropTable(
                name: "MyCustomers");

            migrationBuilder.DropTable(
                name: "MyTableModels");

            migrationBuilder.DropTable(
                name: "MyManufacturers");
        }
    }
}
