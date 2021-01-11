using Microsoft.EntityFrameworkCore.Migrations;

namespace QLGT_API.Migrations
{
    public partial class UpdateKH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "KHACH_HANG",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "KHACH_HANG",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "KHACH_HANG",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "KHACH_HANG");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "KHACH_HANG");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "KHACH_HANG");
        }
    }
}
