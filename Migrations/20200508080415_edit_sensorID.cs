using Microsoft.EntityFrameworkCore.Migrations;

namespace GL_Sensors_v0._2.Migrations
{
    public partial class edit_sensorID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurement_Sensor_SensorId",
                table: "Measurement");

            migrationBuilder.DropColumn(
                name: "CzujnikId",
                table: "Measurement");

            migrationBuilder.AlterColumn<int>(
                name: "SensorId",
                table: "Measurement",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurement_Sensor_SensorId",
                table: "Measurement",
                column: "SensorId",
                principalTable: "Sensor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurement_Sensor_SensorId",
                table: "Measurement");

            migrationBuilder.AlterColumn<int>(
                name: "SensorId",
                table: "Measurement",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CzujnikId",
                table: "Measurement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurement_Sensor_SensorId",
                table: "Measurement",
                column: "SensorId",
                principalTable: "Sensor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
