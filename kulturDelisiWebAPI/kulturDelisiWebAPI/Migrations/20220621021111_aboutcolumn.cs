using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kulturDelisiWebAPI.Migrations
{
    public partial class aboutcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "profilePhoto",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userAbout",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "about",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profilePhoto",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userAbout",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "about",
                table: "Contacts");
        }
    }
}
