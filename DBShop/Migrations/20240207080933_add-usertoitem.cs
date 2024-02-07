using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBShop.Migrations
{
    /// <inheritdoc />
    public partial class addusertoitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userToItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ItemListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userToItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userToItems_itemLists_ItemListId",
                        column: x => x.ItemListId,
                        principalTable: "itemLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userToItems_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userToItems_ItemListId",
                table: "userToItems",
                column: "ItemListId");

            migrationBuilder.CreateIndex(
                name: "IX_userToItems_UserId",
                table: "userToItems",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userToItems");
        }
    }
}
