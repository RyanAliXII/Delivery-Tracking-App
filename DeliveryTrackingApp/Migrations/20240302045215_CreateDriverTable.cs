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
                LicenseIdNumber = table.Column<string>(type:"NVARCHAR(50)", nullable:false),
                LicenseValidity = table.Column<DateTime>(type: "DATE", nullable: true),
                Email = table.Column<string>(type: "NVARCHAR(50)", nullable: false ),
                MobileNumber = table.Column<string>(type: "NVARCHAR(50)", nullable: false)
            }, constraints : table => {
                table.PrimaryKey("PK_Driver", row=> row.Id);
            });

        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Driver");
        }
    }
}
