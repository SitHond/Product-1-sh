using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBShop.Migrations
{
    /// <inheritdoc />
    public partial class _555 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userToItems_itemLists_ItemListId",
                table: "userToItems");

            migrationBuilder.DropForeignKey(
                name: "FK_userToItems_users_UserId",
                table: "userToItems");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "userToItems",
                newName: "UserIdId");

            migrationBuilder.RenameColumn(
                name: "ItemListId",
                table: "userToItems",
                newName: "ItemIdId");

            migrationBuilder.RenameIndex(
                name: "IX_userToItems_UserId",
                table: "userToItems",
                newName: "IX_userToItems_UserIdId");

            migrationBuilder.RenameIndex(
                name: "IX_userToItems_ItemListId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ItemIdId",
                table: "userToItems",
                newName: "ItemListId");

            migrationBuilder.RenameIndex(
                name: "IX_userToItems_UserIdId",
                table: "userToItems",
                newName: "IX_userToItems_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_userToItems_ItemIdId",
                table: "userToItems",
                newName: "IX_userToItems_ItemListId");

            migrationBuilder.AddForeignKey(
                name: "FK_userToItems_itemLists_ItemListId",
                table: "userToItems",
                column: "ItemListId",
                principalTable: "itemLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userToItems_users_UserId",
                table: "userToItems",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
