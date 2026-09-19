using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperShop.Migrations
{
    public partial class FixProductColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastSaleDate",
                table: "Products",
                newName: "LastSale");

            migrationBuilder.RenameColumn(
                name: "LastPurchaseDate",
                table: "Products",
                newName: "LastPurchase");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastSale",
                table: "Products",
                newName: "LastSaleDate");

            migrationBuilder.RenameColumn(
                name: "LastPurchase",
                table: "Products",
                newName: "LastPurchaseDate");
        }
    }
}
