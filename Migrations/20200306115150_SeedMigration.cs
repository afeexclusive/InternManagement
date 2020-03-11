using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagment.Migrations
{
    public partial class SeedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "AdmissionBatch", "AdmissionType", "AdmissionYear", "DateOfBirth", "Email", "FirstName", "Gender", "HealthCondition", "Identification", "LastName", "MaritalStatus", "Nationalty", "NextOFKinName", "NextOfKinAddress", "NextOfKinDocuments", "NextOfKinNumber", "OtherName", "PhoneNumber", "Photo", "Status" },
                values: new object[] { 20, "dfdsdsf", 0, 1, 0, new DateTime(2020, 3, 6, 3, 51, 47, 531, DateTimeKind.Local).AddTicks(124), "maryjane@me.com", "Mary", 1, "No allegies", "num", "Jane", 0, 77, "ayo", "jkfdfdhj", "hjgfdjh", "09087655", "", "576757677", null, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 20);
        }
    }
}
