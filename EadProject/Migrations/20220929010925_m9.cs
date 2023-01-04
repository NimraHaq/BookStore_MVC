using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EadProject.Migrations
{
    public partial class m9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookQuantity",
                table: "OrderTable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookQuantity",
                table: "OrderTable",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
