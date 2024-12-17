using Microsoft.AspNetCore.Mvc;

namespace VehicleDashboardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        // GET: api/status
        [HttpGet]
        public IActionResult GetStatus()
        {
            return Content("Service is working", "text/plain");
        }
    }
}

