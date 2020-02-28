using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenApi.Migrations
{
    public partial class allinone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sicks");

            migrationBuilder.DropTable(
                name: "workAtClients");

            migrationBuilder.DropTable(
                name: "workFromHomes");

            migrationBuilder.AddColumn<string>(
                name: "Approval",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovalByAdmin",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeadDivision",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approval",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ApprovalByAdmin",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "HeadDivision",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "Employees");

            migrationBuilder.CreateTable(
                name: "sicks",
                columns: table => new
                {
                    idSick = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Approval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalByAdmin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeadDivision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sicks", x => x.idSick);
                });

            migrationBuilder.CreateTable(
                name: "workAtClients",
                columns: table => new
                {
                    idWAC = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Approval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalByAdmin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeadDivision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workAtClients", x => x.idWAC);
                });

            migrationBuilder.CreateTable(
                name: "workFromHomes",
                columns: table => new
                {
                    idWFH = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Approval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalByAdmin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeadDivision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workFromHomes", x => x.idWFH);
                });
        }
    }
}
