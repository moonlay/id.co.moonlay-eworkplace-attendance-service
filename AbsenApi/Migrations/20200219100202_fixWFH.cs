using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenApi.Migrations
{
    public partial class fixWFH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "workFromHomes");

            migrationBuilder.AddColumn<string>(
                name: "Approval",
                table: "workFromHomes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckIn",
                table: "workFromHomes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOut",
                table: "workFromHomes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "HeadDivision",
                table: "workFromHomes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "workFromHomes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "workFromHomes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "workFromHomes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "workFromHomes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "workFromHomes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "workFromHomes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approval",
                table: "workFromHomes");

            migrationBuilder.DropColumn(
                name: "CheckIn",
                table: "workFromHomes");

            migrationBuilder.DropColumn(
                name: "CheckOut",
                table: "workFromHomes");

            migrationBuilder.DropColumn(
                name: "HeadDivision",
                table: "workFromHomes");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "workFromHomes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "workFromHomes");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "workFromHomes");

            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "workFromHomes");

            migrationBuilder.DropColumn(
                name: "State",
                table: "workFromHomes");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "workFromHomes");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "workFromHomes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
