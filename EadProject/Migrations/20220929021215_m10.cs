using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EadProject.Migrations
{
    public partial class m10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "BookTable",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "BookTable",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "BookTable",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "BookTable",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BookTable");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "BookTable");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "BookTable");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "BookTable");
        }
    }
}
