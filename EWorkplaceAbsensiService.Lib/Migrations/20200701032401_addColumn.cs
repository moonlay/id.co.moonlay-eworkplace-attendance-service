using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EWorkplaceAbsensiService.Lib.Migrations
{
    public partial class addColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End",
                table: "Timer");

            migrationBuilder.DropColumn(
                name: "date",
                table: "Timer");

            migrationBuilder.DropColumn(
                name: "start",
                table: "Timer");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Timer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                table: "Timer",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Timer",
                type: "datetime2",
                maxLength: 500,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "Timer",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Timer");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Timer");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Timer");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Timer");

            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "Project");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "End",
                table: "Timer",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Timer",
                maxLength: 500,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "start",
                table: "Timer",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
