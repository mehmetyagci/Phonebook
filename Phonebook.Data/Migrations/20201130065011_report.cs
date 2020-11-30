using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Phonebook.Data.Migrations
{
    public partial class report : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<long>(nullable: false),
                    ModifiedDate = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    ReportStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Report");
        }
    }
}
