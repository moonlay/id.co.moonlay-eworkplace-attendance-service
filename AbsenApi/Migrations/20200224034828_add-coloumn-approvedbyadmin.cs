using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenApi.Migrations
{
    public partial class addcoloumnapprovedbyadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApprovalByAdmin",
                table: "workFromHomes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovalByAdmin",
                table: "workAtClients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovalByAdmin",
                table: "sicks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalByAdmin",
                table: "workFromHomes");

            migrationBuilder.DropColumn(
                name: "ApprovalByAdmin",
                table: "workAtClients");

            migrationBuilder.DropColumn(
                name: "ApprovalByAdmin",
                table: "sicks");
        }
    }
}
