using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EadProject.Migrations
{
    public partial class m7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SellerTable",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BuyerTable",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SellerTable");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BuyerTable");
        }
    }
}
