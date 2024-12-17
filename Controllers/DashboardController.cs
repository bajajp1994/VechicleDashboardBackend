using Microsoft.AspNetCore.Mvc;
using VehicleDashboardAPI.Data;
using VehicleDashboardAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace VehicleDashboardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public DashboardController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Dashboard
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DashboardData>>> GetDashboardData()
        {
            // Fetch data from the database
            var data = await _context.DashboardData.ToListAsync();

            // Loop through each dashboard entry to set BatteryLow flag
            foreach (var dashboard in data)
            {
                dashboard.BatteryLow = dashboard.BatteryPercentage < 20;
                dashboard.CheckEngine = dashboard.MotorRPM > 600; 
                dashboard.MotorHighSpeed = dashboard.MotorRPM > 800; 
            }

            // Return the updated list of dashboard data
            return Ok(data);
        }

        // GET: api/Dashboard/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DashboardData>> GetDashboardData(int id)
        {
            var data = await _context.DashboardData.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return data;
        }

        // POST: api/Dashboard
        [HttpPost]
        public async Task<ActionResult<DashboardData>> PostDashboardData(DashboardData dashboardData)
        {
            Console.WriteLine( "data= "+dashboardData.Id);

            _context.DashboardData.Add(dashboardData);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDashboardData), new { id = dashboardData.Id }, dashboardData);
        }

        // PUT: api/Dashboard/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDashboardData(int id, DashboardData dashboardData)
        {
            if (id != dashboardData.Id)
            {
                return BadRequest();
            }

            _context.Entry(dashboardData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.DashboardData.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(dashboardData);
        }

        // DELETE: api/Dashboard/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDashboardData(int id)
        {
            var data = await _context.DashboardData.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            _context.DashboardData.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("indicators")]
        public async Task<ActionResult<object>> GetIndicators()
        {
            var data = await _context.DashboardData.FirstOrDefaultAsync();
            if (data == null) return NotFound();

            return new
            {
                ParkingBrakeEngaged = data.ParkingBrakeEngaged,
                CheckEngine = data.CheckEngine,
                MotorHighSpeed = data.MotorHighSpeed,
                BatteryLow = data.BatteryLow
            };
        }
        [HttpGet("gauges")]
        public async Task<ActionResult<object>> GetGauges()
        {
            var data = await _context.DashboardData.FirstOrDefaultAsync();
            if (data == null) return NotFound();

            return new
            {
                Power = data.BatteryPercentage,
                MotorRPM = data.MotorRPM
            };
        }

    }
}

