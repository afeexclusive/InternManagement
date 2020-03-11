using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagment.Migrations
{
    public partial class NullableMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 20,
                column: "DateOfBirth",
                value: new DateTime(2020, 3, 6, 4, 45, 16, 660, DateTimeKind.Local).AddTicks(8194));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 20,
                column: "DateOfBirth",
                value: new DateTime(2020, 3, 6, 4, 29, 38, 624, DateTimeKind.Local).AddTicks(9998));
        }
    }
}
