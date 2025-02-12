using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Latiendita.Migrations
{
    /// <inheritdoc />
    public partial class AddStockColumnToProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProducDetails_ProductDetailId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProductDetailId",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ProducDetails",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProducDetails_ProductDetailId",
                table: "Products",
                column: "ProductDetailId",
                principalTable: "ProducDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProducDetails_ProductDetailId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProducDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ProductDetailId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProducDetails_ProductDetailId",
                table: "Products",
                column: "ProductDetailId",
                principalTable: "ProducDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
