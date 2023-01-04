using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EadProject.Migrations
{
    public partial class m6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTable_BuyerTable_BuyerTableId",
                table: "BookTable");

            migrationBuilder.DropIndex(
                name: "IX_BookTable_BuyerTableId",
                table: "BookTable");

            migrationBuilder.DropColumn(
                name: "BuyerTableId",
                table: "BookTable");

            migrationBuilder.CreateTable(
                name: "BookTableBuyerTable",
                columns: table => new
                {
                    BuyersWithCartId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTableBuyerTable", x => new { x.BuyersWithCartId, x.CartId });
                    table.ForeignKey(
                        name: "FK_BookTableBuyerTable_BookTable_CartId",
                        column: x => x.CartId,
                        principalTable: "BookTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookTableBuyerTable_BuyerTable_BuyersWithCartId",
                        column: x => x.BuyersWithCartId,
                        principalTable: "BuyerTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookTableBuyerTable_CartId",
                table: "BookTableBuyerTable",
                column: "CartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookTableBuyerTable");

            migrationBuilder.AddColumn<int>(
                name: "BuyerTableId",
                table: "BookTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookTable_BuyerTableId",
                table: "BookTable",
                column: "BuyerTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTable_BuyerTable_BuyerTableId",
                table: "BookTable",
                column: "BuyerTableId",
                principalTable: "BuyerTable",
                principalColumn: "Id");
        }
    }
}
