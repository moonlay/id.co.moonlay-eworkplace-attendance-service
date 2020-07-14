using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EWorkplaceAbsensiService.Lib.Migrations
{
    public partial class FixDBV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "TimeSheet");

            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "TimeSheet");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "TimeSheet");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "TimeSheet");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Report",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimesheetId",
                table: "Report",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "TimesheetId",
                table: "Report");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "TimeSheet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
                table: "TimeSheet",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "TimeSheet",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "TimeSheet",
                maxLength: 500,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
