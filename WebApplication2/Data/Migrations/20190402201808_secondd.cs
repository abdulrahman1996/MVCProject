using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Data.Migrations
{
    public partial class secondd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlockState",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlockState",
                table: "AspNetUsers");
        }
    }
}
