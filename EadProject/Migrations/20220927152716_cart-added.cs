using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EadProject.Migrations
{
    public partial class cartadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
