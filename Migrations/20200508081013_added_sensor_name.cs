using Microsoft.EntityFrameworkCore.Migrations;

namespace GL_Sensors_v0._2.Migrations
{
    public partial class added_sensor_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Sensor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "Sensor");
        }
    }
}
