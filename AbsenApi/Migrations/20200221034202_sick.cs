using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenApi.Migrations
{
    public partial class sick : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sicks",
                columns: table => new
                {
                    idSick = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CheckIn = table.Column<DateTime>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    CheckOut = table.Column<DateTime>(nullable: false),
                    Approval = table.Column<string>(nullable: true),
                    HeadDivision = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sicks", x => x.idSick);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sicks");
        }
    }
}
