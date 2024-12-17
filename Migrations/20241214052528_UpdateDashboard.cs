using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleDashboardAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDashboard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BatteryLow",
                table: "DashboardData",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CheckEngine",
                table: "DashboardData",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MotorHighSpeed",
                table: "DashboardData",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ParkingBrakeEngaged",
                table: "DashboardData",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "DashboardData",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BatteryLow", "CheckEngine", "MotorHighSpeed", "ParkingBrakeEngaged" },
                values: new object[] { false, false, false, false });

            migrationBuilder.UpdateData(
                table: "DashboardData",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BatteryLow", "CheckEngine", "MotorHighSpeed", "ParkingBrakeEngaged" },
                values: new object[] { false, false, false, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatteryLow",
                table: "DashboardData");

            migrationBuilder.DropColumn(
                name: "CheckEngine",
                table: "DashboardData");

            migrationBuilder.DropColumn(
                name: "MotorHighSpeed",
                table: "DashboardData");

            migrationBuilder.DropColumn(
                name: "ParkingBrakeEngaged",
                table: "DashboardData");
        }
    }
}
