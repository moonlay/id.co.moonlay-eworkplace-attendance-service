using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenApi.Migrations
{
    public partial class EmployeeModelsFixColoumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2L);

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "CheckIn", "CheckOut", "DateAttendece", "DateOfBirth", "Email", "FirstName", "LastName", "Location", "Name", "PhoneNumber", "Photo", "State", "Username" },
                values: new object[] { 1L, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "uncle.bob@gmail.com", "Uncle", "Bob", null, null, "999-888-7777", null, null, null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "CheckIn", "CheckOut", "DateAttendece", "DateOfBirth", "Email", "FirstName", "LastName", "Location", "Name", "PhoneNumber", "Photo", "State", "Username" },
                values: new object[] { 2L, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1981, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "jan.kirsten@gmail.com", "Jan", "Kirsten", null, null, "111-222-3333", null, null, null });
        }
    }
}
