using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EWorkplaceAbsensiService.Lib.Migrations
{
    public partial class updateTaskManagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskManangement_Project_ProjectId",
                table: "TaskManangement");

            migrationBuilder.DropIndex(
                name: "IX_TaskManangement_ProjectId",
                table: "TaskManangement");

            migrationBuilder.AlterColumn<int>(
                name: "TaskStatus",
                table: "TaskManangement",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "TaskManangement",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "TaskManangement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StardDate",
                table: "TaskManangement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TaskDescription",
                table: "TaskManangement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaskDifficulty",
                table: "TaskManangement",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "TaskManangement");

            migrationBuilder.DropColumn(
                name: "StardDate",
                table: "TaskManangement");

            migrationBuilder.DropColumn(
                name: "TaskDescription",
                table: "TaskManangement");

            migrationBuilder.DropColumn(
                name: "TaskDifficulty",
                table: "TaskManangement");

            migrationBuilder.AlterColumn<string>(
                name: "TaskStatus",
                table: "TaskManangement",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "TaskManangement",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TaskManangement_ProjectId",
                table: "TaskManangement",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskManangement_Project_ProjectId",
                table: "TaskManangement",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
