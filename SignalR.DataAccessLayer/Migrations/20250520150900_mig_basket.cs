using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_basket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    BasketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasketProductId = table.Column<int>(type: "int", nullable: false),
                    BasketProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasketProductCount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BasketProductUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BasketTotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BasketMenuTableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.BasketId);
                    table.ForeignKey(
                        name: "FK_Baskets_MenuTables_BasketMenuTableId",
                        column: x => x.BasketMenuTableId,
                        principalTable: "MenuTables",
                        principalColumn: "MenuTableId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Baskets_Products_BasketProductId",
                        column: x => x.BasketProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_BasketMenuTableId",
                table: "Baskets",
                column: "BasketMenuTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_BasketProductId",
                table: "Baskets",
                column: "BasketProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Baskets");
        }
    }
}
