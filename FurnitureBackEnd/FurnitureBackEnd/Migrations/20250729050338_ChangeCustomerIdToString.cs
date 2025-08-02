using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FurnitureBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCustomerIdToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderBooking_Customers_CustomerId",
                table: "OrderBooking");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "OrderBooking",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderBooking_AspNetUsers_CustomerId",
                table: "OrderBooking",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderBooking_AspNetUsers_CustomerId",
                table: "OrderBooking");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "OrderBooking",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderBooking_Customers_CustomerId",
                table: "OrderBooking",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
