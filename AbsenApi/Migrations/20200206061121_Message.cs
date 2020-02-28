using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenApi.Migrations
{
    public partial class Message : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Employees");

            migrationBuilder.AddColumn<long>(
                name: "AbsenceId",
                table: "Employees",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "AbsenceId");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "AbsenceId", "CheckIn", "CheckOut", "DateAttendece", "Location", "Message", "Name", "Photo", "State", "Username" },
                values: new object[] { 1L, new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "dummy", null, "dummy", "dummy", "dummt", "dummy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "AbsenceId",
                keyValue: 1L);

            migrationBuilder.DropColumn(
                name: "AbsenceId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Employees");

            migrationBuilder.AddColumn<long>(
                name: "EmployeeId",
                table: "Employees",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeId");
        }
    }
}
