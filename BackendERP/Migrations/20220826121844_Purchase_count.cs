using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendERP.Migrations
{
    public partial class Purchase_count : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Purchase_count",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Purchase_count",
                table: "Users");
        }
    }
}
