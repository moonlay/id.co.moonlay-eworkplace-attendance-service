using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EWorkplaceAbsensiService.Lib.Migrations
{
    public partial class ChangeAttributeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_ActivityCategory_ActivityCategoryId",
                table: "Activity");

            migrationBuilder.DropIndex(
                name: "IX_Activity_ActivityCategoryId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "ActivityCategoryId",
                table: "Activity");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Activity",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Activity");

            migrationBuilder.AddColumn<int>(
                name: "ActivityCategoryId",
                table: "Activity",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ActivityCategoryId",
                table: "Activity",
                column: "ActivityCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_ActivityCategory_ActivityCategoryId",
                table: "Activity",
                column: "ActivityCategoryId",
                principalTable: "ActivityCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
