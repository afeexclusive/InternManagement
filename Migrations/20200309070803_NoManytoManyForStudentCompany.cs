using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagment.Migrations
{
    public partial class NoManytoManyForStudentCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeCompany");

            migrationBuilder.CreateTable(
                name: "Employements",
                columns: table => new
                {
                    EmployementId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employements", x => x.EmployementId);
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 20,
                column: "DateOfBirth",
                value: new DateTime(2020, 3, 9, 0, 8, 1, 853, DateTimeKind.Local).AddTicks(3541));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employements");

            migrationBuilder.CreateTable(
                name: "EmployeeCompany",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCompany", x => new { x.CompanyId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_EmployeeCompany_Companys_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companys",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeCompany_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 20,
                column: "DateOfBirth",
                value: new DateTime(2020, 3, 6, 4, 45, 16, 660, DateTimeKind.Local).AddTicks(8194));

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCompany_EmployeeId",
                table: "EmployeeCompany",
                column: "EmployeeId");
        }
    }
}
