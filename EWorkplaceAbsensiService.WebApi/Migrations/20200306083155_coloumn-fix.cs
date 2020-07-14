using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EWorkplaceAbsensiService.WebApi.Migrations
{
    public partial class coloumnfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Absensis");

            migrationBuilder.AddColumn<string>(
                name: "Approval",
                table: "Absensis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovalByAdmin",
                table: "Absensis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckIn",
                table: "Absensis",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOut",
                table: "Absensis",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "Absensis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Absensis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeadDivision",
                table: "Absensis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Absensis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Absensis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Absensis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "Absensis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Absensis",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approval",
                table: "Absensis");

            migrationBuilder.DropColumn(
                name: "ApprovalByAdmin",
                table: "Absensis");

            migrationBuilder.DropColumn(
                name: "CheckIn",
                table: "Absensis");

            migrationBuilder.DropColumn(
                name: "CheckOut",
                table: "Absensis");

            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "Absensis");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Absensis");

            migrationBuilder.DropColumn(
                name: "HeadDivision",
                table: "Absensis");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Absensis");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Absensis");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Absensis");

            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "Absensis");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Absensis");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Absensis",
                nullable: true);
        }
    }
}
