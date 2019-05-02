using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class noran : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "AspNetUsers",
                nullable: true,
                defaultValue: "/images/users/default-user-image.png",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "/users/default-user-image.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "AspNetUsers",
                nullable: true,
                defaultValue: "/users/default-user-image.png",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "/images/users/default-user-image.png");
        }
    }
}
