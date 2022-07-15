using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kulturDelisiWebAPI.Migrations
{
    public partial class articleNewColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "metaDescription",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "metaTitle",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "metaDescription",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "metaTitle",
                table: "Articles");
        }
    }
}
