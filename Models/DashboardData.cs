namespace VehicleDashboardAPI.Models
{
    public class DashboardData
    {
        public int Id { get; set; }
        public int MotorRPM { get; set; }
        public int BatteryPercentage { get; set; }
        public int BatteryTemperature { get; set; }
        public bool ChargingState { get; set; }
        public string? GearRatio { get; set; }
        public bool ParkingBrakeEngaged { get; set; }
        public bool CheckEngine { get; set; }
        public bool MotorHighSpeed { get; set; }
        public bool BatteryLow { get; set; }
    }
}
