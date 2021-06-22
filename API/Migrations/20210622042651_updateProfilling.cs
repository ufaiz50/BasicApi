using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class updateProfilling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_M_Profilling_tb_M_Education_EducationId",
                table: "tb_M_Profilling");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_M_Profilling_tb_T_Account_NIK",
                table: "tb_M_Profilling");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_M_Profilling",
                table: "tb_M_Profilling");

            migrationBuilder.RenameTable(
                name: "tb_M_Profilling",
                newName: "tb_T_Profilling");

            migrationBuilder.RenameColumn(
                name: "EducationId",
                table: "tb_T_Profilling",
                newName: "educationId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_M_Profilling_EducationId",
                table: "tb_T_Profilling",
                newName: "IX_tb_T_Profilling_educationId");

            migrationBuilder.AlterColumn<int>(
                name: "educationId",
                table: "tb_T_Profilling",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_T_Profilling",
                table: "tb_T_Profilling",
                column: "NIK");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_T_Profilling_tb_M_Education_educationId",
                table: "tb_T_Profilling",
                column: "educationId",
                principalTable: "tb_M_Education",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_T_Profilling_tb_T_Account_NIK",
                table: "tb_T_Profilling",
                column: "NIK",
                principalTable: "tb_T_Account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_T_Profilling_tb_M_Education_educationId",
                table: "tb_T_Profilling");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_T_Profilling_tb_T_Account_NIK",
                table: "tb_T_Profilling");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_T_Profilling",
                table: "tb_T_Profilling");

            migrationBuilder.RenameTable(
                name: "tb_T_Profilling",
                newName: "tb_M_Profilling");

            migrationBuilder.RenameColumn(
                name: "educationId",
                table: "tb_M_Profilling",
                newName: "EducationId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_T_Profilling_educationId",
                table: "tb_M_Profilling",
                newName: "IX_tb_M_Profilling_EducationId");

            migrationBuilder.AlterColumn<int>(
                name: "EducationId",
                table: "tb_M_Profilling",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_M_Profilling",
                table: "tb_M_Profilling",
                column: "NIK");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_M_Profilling_tb_M_Education_EducationId",
                table: "tb_M_Profilling",
                column: "EducationId",
                principalTable: "tb_M_Education",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_M_Profilling_tb_T_Account_NIK",
                table: "tb_M_Profilling",
                column: "NIK",
                principalTable: "tb_T_Account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
