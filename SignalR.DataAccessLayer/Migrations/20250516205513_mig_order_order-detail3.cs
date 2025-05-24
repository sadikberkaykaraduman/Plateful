using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_order_orderdetail3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderDetails",
                newName: "OrderDetailOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderDetailOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderDetailOrderId",
                table: "OrderDetails",
                column: "OrderDetailOrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderDetailOrderId",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "OrderDetailOrderId",
                table: "OrderDetails",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderDetailOrderId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
