using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GL_Sensors_v0._2.Migrations
{
    public partial class some_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CzasPomiaru",
                table: "Measurement");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Measurement",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Measurement");

            migrationBuilder.AddColumn<DateTime>(
                name: "CzasPomiaru",
                table: "Measurement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
