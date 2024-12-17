using Microsoft.EntityFrameworkCore;
using VehicleDashboardAPI.Models;

namespace VehicleDashboardAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<DashboardData> DashboardData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DashboardData>().HasData(
                new DashboardData
                {
                    Id = 1,
                    MotorRPM = 1500,
                    BatteryPercentage = 80,
                    BatteryTemperature = 30,
                    ChargingState = true,
                    GearRatio = "3.2"
                },
                new DashboardData
                {
                    Id = 2,
                    MotorRPM = 2000,
                    BatteryPercentage = 60,
                    BatteryTemperature = 35,
                    ChargingState = false,
                    GearRatio = "3.5"
                }
            );
        }
    }
}
