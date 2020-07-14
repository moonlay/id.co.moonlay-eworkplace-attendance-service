using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EWorkplaceAbsensiService.Lib.Migrations
{
    public partial class Activity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_ActivityCategoriy_ActivityCategoryIdId",
                table: "Activity");

            migrationBuilder.DropIndex(
                name: "IX_Activity_ActivityCategoryIdId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "ActivityCategoryIdId",
                table: "Activity");

            migrationBuilder.AddColumn<int>(
                name: "ActivityCategoryId",
                table: "Activity",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ActivityCategoryId",
                table: "Activity",
                column: "ActivityCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_ActivityCategoriy_ActivityCategoryId",
                table: "Activity",
                column: "ActivityCategoryId",
                principalTable: "ActivityCategoriy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_ActivityCategoriy_ActivityCategoryId",
                table: "Activity");

            migrationBuilder.DropIndex(
                name: "IX_Activity_ActivityCategoryId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "ActivityCategoryId",
                table: "Activity");

            migrationBuilder.AddColumn<int>(
                name: "ActivityCategoryIdId",
                table: "Activity",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ActivityCategoryIdId",
                table: "Activity",
                column: "ActivityCategoryIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_ActivityCategoriy_ActivityCategoryIdId",
                table: "Activity",
                column: "ActivityCategoryIdId",
                principalTable: "ActivityCategoriy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
