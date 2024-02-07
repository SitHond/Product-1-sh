using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBShop.Migrations
{
    /// <inheritdoc />
    public partial class _32323 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userToItems_itemLists_ItemIdId",
                table: "userToItems");

            migrationBuilder.DropForeignKey(
                name: "FK_userToItems_users_UserIdId",
                table: "userToItems");

            migrationBuilder.RenameColumn(
                name: "UserIdId",
                table: "userToItems",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "ItemIdId",
                table: "userToItems",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_userToItems_UserIdId",
                table: "userToItems",
                newName: "IX_userToItems_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_userToItems_ItemIdId",
                table: "userToItems",
                newName: "IX_userToItems_ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_userToItems_itemLists_ItemId",
                table: "userToItems",
                column: "ItemId",
                principalTable: "itemLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userToItems_users_UsersId",
                table: "userToItems",
                column: "UsersId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userToItems_itemLists_ItemId",
                table: "userToItems");

            migrationBuilder.DropForeignKey(
                name: "FK_userToItems_users_UsersId",
                table: "userToItems");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "userToItems",
                newName: "UserIdId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "userToItems",
                newName: "ItemIdId");

            migrationBuilder.RenameIndex(
                name: "IX_userToItems_UsersId",
                table: "userToItems",
                newName: "IX_userToItems_UserIdId");

            migrationBuilder.RenameIndex(
                name: "IX_userToItems_ItemId",
                table: "userToItems",
                newName: "IX_userToItems_ItemIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_userToItems_itemLists_ItemIdId",
                table: "userToItems",
                column: "ItemIdId",
                principalTable: "itemLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userToItems_users_UserIdId",
                table: "userToItems",
                column: "UserIdId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
