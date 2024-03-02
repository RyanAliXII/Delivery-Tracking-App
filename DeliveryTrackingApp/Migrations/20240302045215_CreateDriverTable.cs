using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryTrackingApp.Migrations
{
    /// <inheritdoc />
    public partial class CreateDriverTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {   
            migrationBuilder.CreateTable("Driver", columns: table=> new {
                Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", defaultValueSql: "NEWID()"),
                GivenName = table.Column<string>(type:"NVARCHAR(50)", nullable:false),
                MiddleName = table.Column<string>(type:"NVARCHAR(50)", nullable:false),
                Surname = table.Column<string>(type:"NVARCHAR(50)", nullable:false),
                DateOfBirth = table.Column<DateTime>(type:"DATE", nullable: false),
                Gender = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                Address = table.Column<string>(type: "TEXT", nullable:false),
                LicenseIdNumber = table.Column<string>(type:"NVARCHAR(50)", nullable:false),
                LicenseValidity = table.Column<DateTime>(type: "DATE", nullable: false),
                LicenseImagePath = table.Column<string>(type:"NVARCHAR(100)", nullable: false),
                Email = table.Column<string>(type: "NVARCHAR(50)", nullable: false ),
                MobileNumber = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "DATETIME", defaultValueSql: "GETDATE()"),
                DeletedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
            }, constraints : table => {
                table.PrimaryKey("PK_Driver", row=> row.Id);
                table.UniqueConstraint("UNIQUE_Driver_MobileNumber", row => row.MobileNumber);
                table.UniqueConstraint("UNIQUE_Driver_LicenseIdNumber", row => row.LicenseIdNumber);
            });

        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Driver");
        }
    }
}
