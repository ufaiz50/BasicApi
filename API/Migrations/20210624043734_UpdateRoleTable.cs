using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class UpdateRoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_M_Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_M_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "tb_T_AccountRole",
                columns: table => new
                {
                    AccountRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    AccountNIK = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_T_AccountRole", x => x.AccountRoleId);
                    table.ForeignKey(
                        name: "FK_tb_T_AccountRole_tb_M_Account_AccountNIK",
                        column: x => x.AccountNIK,
                        principalTable: "tb_M_Account",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_T_AccountRole_tb_M_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tb_M_Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_T_AccountRole_AccountNIK",
                table: "tb_T_AccountRole",
                column: "AccountNIK");

            migrationBuilder.CreateIndex(
                name: "IX_tb_T_AccountRole_RoleId",
                table: "tb_T_AccountRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_T_AccountRole");

            migrationBuilder.DropTable(
                name: "tb_M_Role");
        }
    }
}
