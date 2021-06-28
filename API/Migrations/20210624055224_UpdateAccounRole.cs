using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class UpdateAccounRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_T_AccountRole_tb_M_Account_AccountNIK",
                table: "tb_T_AccountRole");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "tb_T_AccountRole");

            migrationBuilder.AlterColumn<string>(
                name: "AccountNIK",
                table: "tb_T_AccountRole",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_T_AccountRole_tb_M_Account_AccountNIK",
                table: "tb_T_AccountRole",
                column: "AccountNIK",
                principalTable: "tb_M_Account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_T_AccountRole_tb_M_Account_AccountNIK",
                table: "tb_T_AccountRole");

            migrationBuilder.AlterColumn<string>(
                name: "AccountNIK",
                table: "tb_T_AccountRole",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "tb_T_AccountRole",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_T_AccountRole_tb_M_Account_AccountNIK",
                table: "tb_T_AccountRole",
                column: "AccountNIK",
                principalTable: "tb_M_Account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
