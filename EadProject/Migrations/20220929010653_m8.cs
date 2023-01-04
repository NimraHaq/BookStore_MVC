using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EadProject.Migrations
{
    public partial class m8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuyerID = table.Column<int>(type: "int", nullable: false),
                    BookQuantity = table.Column<int>(type: "int", nullable: false),
                    OrderDelivered = table.Column<bool>(type: "bit", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BooksToOrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTable_BookTable_BooksToOrderId",
                        column: x => x.BooksToOrderId,
                        principalTable: "BookTable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderTable_BooksToOrderId",
                table: "OrderTable",
                column: "BooksToOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderTable");
        }
    }
}
