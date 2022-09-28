using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendERP.Migrations
{
    public partial class MigrationFix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Orders_OrdersOrder_id",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Products_ProductsProduct_id",
                table: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Product_users");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_Product_id",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_User_id",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProduct",
                table: "OrderProduct");

            migrationBuilder.DropIndex(
                name: "IX_OrderProduct_ProductsProduct_id",
                table: "OrderProduct");

            migrationBuilder.RenameColumn(
                name: "ProductsProduct_id",
                table: "OrderProduct",
                newName: "BoughtProducts_amount");

            migrationBuilder.RenameColumn(
                name: "OrdersOrder_id",
                table: "OrderProduct",
                newName: "Product_id");

            migrationBuilder.AddColumn<int>(
                name: "Order_id",
                table: "OrderProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProduct",
                table: "OrderProduct",
                columns: new[] { "Order_id", "Product_id" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Rating_id", "Comment", "Grade", "Product_id", "User_id" },
                values: new object[] { 1, "odlican proizvod!", 9, 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_Product_id",
                table: "Ratings",
                column: "Product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_User_id",
                table: "Ratings",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_Product_id",
                table: "OrderProduct",
                column: "Product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Orders_Order_id",
                table: "OrderProduct",
                column: "Order_id",
                principalTable: "Orders",
                principalColumn: "Order_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Products_Product_id",
                table: "OrderProduct",
                column: "Product_id",
                principalTable: "Products",
                principalColumn: "Product_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Orders_Order_id",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Products_Product_id",
                table: "OrderProduct");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_Product_id",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_User_id",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProduct",
                table: "OrderProduct");

            migrationBuilder.DropIndex(
                name: "IX_OrderProduct_Product_id",
                table: "OrderProduct");

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Rating_id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Order_id",
                table: "OrderProduct");

            migrationBuilder.RenameColumn(
                name: "BoughtProducts_amount",
                table: "OrderProduct",
                newName: "ProductsProduct_id");

            migrationBuilder.RenameColumn(
                name: "Product_id",
                table: "OrderProduct",
                newName: "OrdersOrder_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProduct",
                table: "OrderProduct",
                columns: new[] { "OrdersOrder_id", "ProductsProduct_id" });

            migrationBuilder.CreateTable(
                name: "Product_users",
                columns: table => new
                {
                    Product_user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_id = table.Column<int>(type: "int", nullable: false),
                    QuantityOfBoughtProducts = table.Column<int>(type: "int", nullable: false),
                    User_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_users", x => x.Product_user_id);
                    table.ForeignKey(
                        name: "FK_Product_users_Products_Product_id",
                        column: x => x.Product_id,
                        principalTable: "Products",
                        principalColumn: "Product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_users_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_Product_id",
                table: "Ratings",
                column: "Product_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_User_id",
                table: "Ratings",
                column: "User_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductsProduct_id",
                table: "OrderProduct",
                column: "ProductsProduct_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_users_Product_id",
                table: "Product_users",
                column: "Product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_users_User_id",
                table: "Product_users",
                column: "User_id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Orders_OrdersOrder_id",
                table: "OrderProduct",
                column: "OrdersOrder_id",
                principalTable: "Orders",
                principalColumn: "Order_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Products_ProductsProduct_id",
                table: "OrderProduct",
                column: "ProductsProduct_id",
                principalTable: "Products",
                principalColumn: "Product_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
