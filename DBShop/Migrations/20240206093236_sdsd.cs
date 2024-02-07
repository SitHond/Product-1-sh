using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBShop.Migrations
{
    /// <inheritdoc />
    public partial class sdsd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "itemLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Img = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListOrders = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOrders = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTrasit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Punkt = table.Column<int>(type: "int", nullable: false),
                    UsernameClients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeP = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsGuest = table.Column<bool>(type: "bit", nullable: false),
                    IsManager = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pp",
                columns: table => new
                {
                    Id_pp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemListId = table.Column<int>(type: "int", nullable: false),
                    ordersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pp", x => x.Id_pp);
                    table.ForeignKey(
                        name: "FK_pp_itemLists_itemListId",
                        column: x => x.itemListId,
                        principalTable: "itemLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pp_orders_ordersId",
                        column: x => x.ordersId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pp_itemListId",
                table: "pp",
                column: "itemListId");

            migrationBuilder.CreateIndex(
                name: "IX_pp_ordersId",
                table: "pp",
                column: "ordersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pp");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "itemLists");

            migrationBuilder.DropTable(
                name: "orders");
        }
    }
}
