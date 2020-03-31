using Microsoft.EntityFrameworkCore.Migrations;

namespace Donatello2020.Migrations
{
    public partial class changecolumnname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundColor",
                table: "Boards");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Boards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Boards");

            migrationBuilder.AddColumn<string>(
                name: "BackgroundColor",
                table: "Boards",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
