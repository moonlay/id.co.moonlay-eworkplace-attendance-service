using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EWorkplaceAbsensiService.Lib.Migrations
{
    public partial class DropActivityCatColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "ActivityCategory");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Activity",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Activity",
                newName: "description");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "ActivityCategory",
                nullable: true);
        }
    }
}
