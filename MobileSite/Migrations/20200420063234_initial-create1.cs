using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileSite.Migrations
{
    public partial class initialcreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "MobileItem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MobileItem",
                table: "MobileItem",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MobileItem",
                table: "MobileItem");

            migrationBuilder.RenameTable(
                name: "MobileItem",
                newName: "Employees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "ItemId");
        }
    }
}
