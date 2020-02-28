using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenApi.Migrations
{
    public partial class wac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "workAtClients",
                columns: table => new
                {
                    idWAC = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CheckIn = table.Column<DateTime>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    CheckOut = table.Column<DateTime>(nullable: false),
                    Approval = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    ClientName = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true),
                    HeadDivision = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workAtClients", x => x.idWAC);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workAtClients");
        }
    }
}
