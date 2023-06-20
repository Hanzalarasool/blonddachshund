using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace deaneverhart.Data.Migrations
{
    public partial class ModifyDateTime01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeFrom",
                table: "Resume",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeTo",
                table: "Resume",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "From1",
                table: "Resume",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "To1",
                table: "Resume",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeFrom",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "DateTimeTo",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "From1",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "To1",
                table: "Resume");
        }
    }
}
