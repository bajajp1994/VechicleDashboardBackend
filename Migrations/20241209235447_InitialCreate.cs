using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleDashboardAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DashboardData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotorRPM = table.Column<int>(type: "int", nullable: false),
                    BatteryPercentage = table.Column<int>(type: "int", nullable: false),
                    BatteryTemperature = table.Column<int>(type: "int", nullable: false),
                    ChargingState = table.Column<bool>(type: "bit", nullable: false),
                    GearRatio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DashboardData");
        }
    }
}
