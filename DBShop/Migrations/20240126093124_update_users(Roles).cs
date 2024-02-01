using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBShop.Migrations
{
    /// <inheritdoc />
    public partial class update_usersRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rule",
                table: "users",
                newName: "Roles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Roles",
                table: "users",
                newName: "Rule");
        }
    }
}
