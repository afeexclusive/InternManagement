using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagment.Migrations
{
    public partial class FixAcademyProg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramCourses");

            migrationBuilder.CreateTable(
                name: "ProgramAndCourses",
                columns: table => new
                {
                    ProgrammeCourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademyProgramId = table.Column<int>(nullable: true),
                    CoursesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramAndCourses", x => x.ProgrammeCourseId);
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 20,
                column: "DateOfBirth",
                value: new DateTime(2020, 3, 9, 13, 45, 50, 238, DateTimeKind.Local).AddTicks(4003));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramAndCourses");

            migrationBuilder.CreateTable(
                name: "ProgramCourses",
                columns: table => new
                {
                    AcademyProgramId = table.Column<int>(type: "int", nullable: false),
                    CoursesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramCourses", x => new { x.AcademyProgramId, x.CoursesId });
                    table.ForeignKey(
                        name: "FK_ProgramCourses_AcademyPrograms_AcademyProgramId",
                        column: x => x.AcademyProgramId,
                        principalTable: "AcademyPrograms",
                        principalColumn: "AcademyProgramId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramCourses_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "CoursesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 20,
                column: "DateOfBirth",
                value: new DateTime(2020, 3, 9, 0, 8, 1, 853, DateTimeKind.Local).AddTicks(3541));

            migrationBuilder.CreateIndex(
                name: "IX_ProgramCourses_CoursesId",
                table: "ProgramCourses",
                column: "CoursesId");
        }
    }
}
