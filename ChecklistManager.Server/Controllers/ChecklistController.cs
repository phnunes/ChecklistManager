using ChecklistManager.Server.Models;
using ChecklistManager.Server.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChecklistManager.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChecklistController : ControllerBase
    {
        ChecklistService _service = new ChecklistService();

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Checklist>>>> Get()
        {
            return Ok(await _service.GetChecklists());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Checklist>>>> Post(Checklist checklistRequest)
        {
            return Ok(await _service.CreateChecklist(checklistRequest));
        }
    }
}
