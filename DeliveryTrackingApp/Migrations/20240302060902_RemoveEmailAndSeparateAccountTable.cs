using System;
using DeliveryTrackingApp.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryTrackingApp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEmailAndSeparateAccountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(name: "Account", columns: table => new {
                Id = table.Column<Guid>(type:"UNIQUEIDENTIFIER", defaultValueSql: "NEWID()"),
                Email = table.Column<string>(type: "NVARCHAR(100)", nullable: false ),
                Password = table.Column<string>(type: "TEXT", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "TIMESTAMP", defaultValueSql: "CURRENT_TIMESTAMP")
            },constraints: table=>{
                table.PrimaryKey("PK_Account", row=> row.Id);
            });
            migrationBuilder.DropColumn("Email", "Driver");
            migrationBuilder.AddColumn<Guid>(name:"AccountId", table:"Driver", type:"UNIQUEIDENTIFIER");
            migrationBuilder.AddForeignKey(
                name:"FK_Driver_Account_AccountId", 
                table: "Driver",  
                column:"AccountId",  
                principalTable: "Account", 
                principalColumn: "Id" );
               
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {   
            migrationBuilder.DropForeignKey(name:"FK_Driver_Account_AccountId", table: "Driver");
            migrationBuilder.DropColumn(name:"AccountId", table:"Driver");
            migrationBuilder.DropTable( name: "Account");
            migrationBuilder.AddColumn<string>(name:"Email", type:"NVARCHAR(50)", nullable: false, table: "Driver");
        }
    }
}
