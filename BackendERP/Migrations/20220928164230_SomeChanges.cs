using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendERP.Migrations
{
    public partial class SomeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Delivery_data");

            migrationBuilder.DropTable(
                name: "Newsletters");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "User_services");

            migrationBuilder.AddColumn<int>(
                name: "Product_quantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Order_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    User_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Order_id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_users",
                columns: table => new
                {
                    Product_user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_id = table.Column<int>(type: "int", nullable: false),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    QuantityOfBoughtProducts = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Rating_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Product_id = table.Column<int>(type: "int", nullable: false),
                    User_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Rating_id);
                    table.ForeignKey(
                        name: "FK_Ratings_Products_Product_id",
                        column: x => x.Product_id,
                        principalTable: "Products",
                        principalColumn: "Product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    Delivery_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Order_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.Delivery_id);
                    table.ForeignKey(
                        name: "FK_Delivery_Orders_Order_id",
                        column: x => x.Order_id,
                        principalTable: "Orders",
                        principalColumn: "Order_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrdersOrder_id = table.Column<int>(type: "int", nullable: false),
                    ProductsProduct_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrdersOrder_id, x.ProductsProduct_id });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_OrdersOrder_id",
                        column: x => x.OrdersOrder_id,
                        principalTable: "Orders",
                        principalColumn: "Order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_ProductsProduct_id",
                        column: x => x.ProductsProduct_id,
                        principalTable: "Products",
                        principalColumn: "Product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Order_id", "Order_date", "Total", "User_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 445.0, 1 },
                    { 2, new DateTime(2021, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 460.0, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Product_id",
                keyValue: 1,
                column: "Product_quantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Product_id",
                keyValue: 2,
                column: "Product_quantity",
                value: 100);

            migrationBuilder.InsertData(
                table: "Delivery",
                columns: new[] { "Delivery_id", "Address", "City", "Order_id", "Phone_number" },
                values: new object[] { 1, "Stefana Stefanovica 5", "Novi Sad", 1, "+381 62 839 1 075" });

            migrationBuilder.InsertData(
                table: "Delivery",
                columns: new[] { "Delivery_id", "Address", "City", "Order_id", "Phone_number" },
                values: new object[] { 2, "Valentina Vodnika 17", "Novi Sad", 2, "0654005831" });

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_Order_id",
                table: "Delivery",
                column: "Order_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductsProduct_id",
                table: "OrderProduct",
                column: "ProductsProduct_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_User_id",
                table: "Orders",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_users_Product_id",
                table: "Product_users",
                column: "Product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_users_User_id",
                table: "Product_users",
                column: "User_id");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Product_users");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropColumn(
                name: "Product_quantity",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Delivery_data",
                columns: table => new
                {
                    Delivery_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery_data", x => x.Delivery_id);
                    table.ForeignKey(
                        name: "FK_Delivery_data_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Newsletters",
                columns: table => new
                {
                    Newsletter_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newsletters", x => x.Newsletter_id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Payment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Payment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    User_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Payment_id);
                    table.ForeignKey(
                        name: "FK_Payments_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_services",
                columns: table => new
                {
                    Service_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_services", x => x.Service_id);
                });

            migrationBuilder.InsertData(
                table: "Delivery_data",
                columns: new[] { "Delivery_id", "Address", "City", "Phone_number", "User_id" },
                values: new object[,]
                {
                    { 1, "Stefana Stefanovica 5", "Novi Sad", "+381 62 839 1 075", 1 },
                    { 2, "Valentina Vodnika 17", "Novi Sad", "0654005831", 2 }
                });

            migrationBuilder.InsertData(
                table: "Newsletters",
                columns: new[] { "Newsletter_id", "Email" },
                values: new object[,]
                {
                    { 1, "milosmilinovic9@gmail.com" },
                    { 2, "nemanjamilunovic@.com" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Payment_id", "Payment_date", "Total", "User_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 445.0, 1 },
                    { 2, new DateTime(2021, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 460.0, 2 }
                });

            migrationBuilder.InsertData(
                table: "User_services",
                columns: new[] { "Service_id", "Email", "Message" },
                values: new object[,]
                {
                    { 1, "milosmilinovic9@gmail.com", "Stvarno je dobar sajt!" },
                    { 2, "nmilunovic@gmail.com", "Dsdscac csac cac s!" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_data_User_id",
                table: "Delivery_data",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_User_id",
                table: "Payments",
                column: "User_id");
        }
    }
}
