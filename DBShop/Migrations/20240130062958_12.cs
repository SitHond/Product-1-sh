using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBShop.Migrations
{
    /// <inheritdoc />
    public partial class _12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roles",
                table: "users");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsGuest",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsManager",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "users");

            migrationBuilder.DropColumn(
                name: "IsGuest",
                table: "users");

            migrationBuilder.DropColumn(
                name: "IsManager",
                table: "users");

            migrationBuilder.AddColumn<string>(
                name: "Roles",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
