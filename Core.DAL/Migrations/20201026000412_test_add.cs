using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.DAL.Migrations
{
    public partial class test_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Country",
                table: "Brands",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Brands");
        }
    }
}
