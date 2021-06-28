using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class updateTableAccounLagi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountRoleId",
                table: "tb_M_Account");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountRoleId",
                table: "tb_M_Account",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
