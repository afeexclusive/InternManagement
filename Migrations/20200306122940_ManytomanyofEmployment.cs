using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagment.Migrations
{
    public partial class ManytomanyofEmployment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 20,
                column: "DateOfBirth",
                value: new DateTime(2020, 3, 6, 4, 29, 38, 624, DateTimeKind.Local).AddTicks(9998));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 20,
                column: "DateOfBirth",
                value: new DateTime(2020, 3, 6, 3, 51, 47, 531, DateTimeKind.Local).AddTicks(124));
        }
    }
}
