using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenApi.Migrations
{
    public partial class EFCoreCodeFirstSampleModelsUpdateColoumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "CheckIn",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckOut",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAttendece",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckIn",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CheckOut",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DateAttendece",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
