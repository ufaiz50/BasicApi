using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddRoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_T_Account_tb_M_Employee_NIK",
                table: "tb_T_Account");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_T_Profilling_tb_T_Account_NIK",
                table: "tb_T_Profilling");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_T_Account",
                table: "tb_T_Account");

            migrationBuilder.RenameTable(
                name: "tb_T_Account",
                newName: "tb_M_Account");

            migrationBuilder.AddColumn<int>(
                name: "AccountRoleId",
                table: "tb_M_Account",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_M_Account",
                table: "tb_M_Account",
                column: "NIK");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_M_Account_tb_M_Employee_NIK",
                table: "tb_M_Account",
                column: "NIK",
                principalTable: "tb_M_Employee",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_T_Profilling_tb_M_Account_NIK",
                table: "tb_T_Profilling",
                column: "NIK",
                principalTable: "tb_M_Account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_M_Account_tb_M_Employee_NIK",
                table: "tb_M_Account");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_T_Profilling_tb_M_Account_NIK",
                table: "tb_T_Profilling");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_M_Account",
                table: "tb_M_Account");

            migrationBuilder.DropColumn(
                name: "AccountRoleId",
                table: "tb_M_Account");

            migrationBuilder.RenameTable(
                name: "tb_M_Account",
                newName: "tb_T_Account");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_T_Account",
                table: "tb_T_Account",
                column: "NIK");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_T_Account_tb_M_Employee_NIK",
                table: "tb_T_Account",
                column: "NIK",
                principalTable: "tb_M_Employee",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_T_Profilling_tb_T_Account_NIK",
                table: "tb_T_Profilling",
                column: "NIK",
                principalTable: "tb_T_Account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
