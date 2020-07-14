using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EWorkplaceAbsensiService.Lib.Migrations
{
    public partial class Activity3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_ActivityCategoriy_ActivityCategoryId",
                table: "Activity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityCategoriy",
                table: "ActivityCategoriy");

            migrationBuilder.RenameTable(
                name: "ActivityCategoriy",
                newName: "ActivityCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityCategory",
                table: "ActivityCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_ActivityCategory_ActivityCategoryId",
                table: "Activity",
                column: "ActivityCategoryId",
                principalTable: "ActivityCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_ActivityCategory_ActivityCategoryId",
                table: "Activity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityCategory",
                table: "ActivityCategory");

            migrationBuilder.RenameTable(
                name: "ActivityCategory",
                newName: "ActivityCategoriy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityCategoriy",
                table: "ActivityCategoriy",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_ActivityCategoriy_ActivityCategoryId",
                table: "Activity",
                column: "ActivityCategoryId",
                principalTable: "ActivityCategoriy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
