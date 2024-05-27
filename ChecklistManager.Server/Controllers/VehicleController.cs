using ChecklistManager.Server.Models;
using ChecklistManager.Server.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChecklistManager.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        VehicleService _service = new VehicleService();

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Checklist>>>> Get()
        {
            return Ok(await _service.GetVehicles());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Checklist>>>> Post(Vehicle vehicleRequest)
        {
            return Ok(await _service.CreateVehicle(vehicleRequest));
        }
    }
}
