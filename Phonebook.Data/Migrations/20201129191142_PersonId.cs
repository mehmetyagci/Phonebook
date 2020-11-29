using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Phonebook.Data.Migrations
{
    public partial class PersonId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunicationInfo_Person_PersonId",
                table: "CommunicationInfo");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                table: "CommunicationInfo",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationInfo_Person_PersonId",
                table: "CommunicationInfo",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunicationInfo_Person_PersonId",
                table: "CommunicationInfo");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                table: "CommunicationInfo",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationInfo_Person_PersonId",
                table: "CommunicationInfo",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
