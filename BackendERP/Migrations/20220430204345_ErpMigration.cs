using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendERP.Migrations
{
    public partial class ErpMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Product_categories",
                columns: table => new
                {
                    Category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_categories", x => x.Category_id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Role_id);
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

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Liter = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    On_action = table.Column<bool>(type: "bit", nullable: false),
                    Discout = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount_price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Product_id);
                    table.ForeignKey(
                        name: "FK_Products_Product_categories_Category_id",
                        column: x => x.Category_id,
                        principalTable: "Product_categories",
                        principalColumn: "Category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    User_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_Role_id",
                        column: x => x.Role_id,
                        principalTable: "Roles",
                        principalColumn: "Role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Delivery_data",
                columns: table => new
                {
                    Delivery_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                name: "Payments",
                columns: table => new
                {
                    Payment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Payment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Newsletters",
                columns: new[] { "Newsletter_id", "Email" },
                values: new object[,]
                {
                    { 1, "milosmilinovic9@gmail.com" },
                    { 2, "nemanjamilunovic@.com" }
                });

            migrationBuilder.InsertData(
                table: "Product_categories",
                columns: new[] { "Category_id", "Category_name" },
                values: new object[,]
                {
                    { 1, "Voda" },
                    { 2, "Pivo" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Role_id", "Role_name" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Kupac" }
                });

            migrationBuilder.InsertData(
                table: "User_services",
                columns: new[] { "Service_id", "Email", "Message" },
                values: new object[,]
                {
                    { 1, "milosmilinovic9@gmail.com", "Stvarno je dobar sajt!" },
                    { 2, "nmilunovic@gmail.com", "Dsdscac csac cac s!" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Product_id", "Category_id", "Discount_price", "Discout", "Image_url", "Liter", "On_action", "Price", "Product_name" },
                values: new object[,]
                {
                    { 1, 1, null, null, "", 0.25, true, 175.0, "Akva viva" },
                    { 2, 2, null, null, "assets/images/Jelen.jfif", 0.25, false, 200.0, "Jelen" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "User_id", "Email", "LastName", "Name", "Password", "Role_id", "User_name" },
                values: new object[,]
                {
                    { 1, "milosmilinovic9@gmail.com", "Milinovic", "Milos", "milos123", 1, "Mili99" },
                    { 2, "nmilunovic@gmail.com", "Milunovic", "Nemanja", "milun123", 2, "Milun" }
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
                table: "Payments",
                columns: new[] { "Payment_id", "Payment_date", "Total", "User_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 445.0, 1 },
                    { 2, new DateTime(2021, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 460.0, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_data_User_id",
                table: "Delivery_data",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_User_id",
                table: "Payments",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Category_id",
                table: "Products",
                column: "Category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Role_id",
                table: "Users",
                column: "Role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Delivery_data");

            migrationBuilder.DropTable(
                name: "Newsletters");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "User_services");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Product_categories");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
