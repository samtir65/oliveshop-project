using Microsoft.EntityFrameworkCore.Migrations;

namespace OliveShop.Migrations
{
    public partial class iniitAddorders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_Users_Userid",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_orderDetails_order_OrderId",
                table: "orderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order",
                table: "order");

            migrationBuilder.RenameTable(
                name: "order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_order_Userid",
                table: "Orders",
                newName: "IX_Orders_Userid");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "orderDetails",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetails_Orders_OrderId",
                table: "orderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_Userid",
                table: "Orders",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "Userid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderDetails_Orders_OrderId",
                table: "orderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_Userid",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "order");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_Userid",
                table: "order",
                newName: "IX_order_Userid");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "orderDetails",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order",
                table: "order",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_order_Users_Userid",
                table: "order",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "Userid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetails_order_OrderId",
                table: "orderDetails",
                column: "OrderId",
                principalTable: "order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
