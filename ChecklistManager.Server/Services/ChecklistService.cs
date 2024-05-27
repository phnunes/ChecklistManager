using ChecklistManager.Server.Contexts;
using ChecklistManager.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ChecklistManager.Server.Service
{
    public class ChecklistService
    {
        private readonly DatabaseContext _context = new DatabaseContext();
        
        public async Task<ServiceResponse<List<Checklist>>> GetChecklists()
        {
            ServiceResponse<List<Checklist>> serviceResponse = new ServiceResponse<List<Checklist>>();
            try
            {
                var checklistData = (
                 from c in _context.Checklist
                 join v in _context.Vehicle on c.VehicleID equals v.VehicleID
                 select new Checklist
                 {
                     ChecklistID = c.ChecklistID,
                     Breaks = c.Breaks,
                     Tires = c.Tires,
                     Electric = c.Electric,
                     Engine = c.Engine,
                     Lights = c.Lights,
                     Observation = c.Observation,
                     VehicleID = c.VehicleID,
                     Vehicle = new Vehicle {
                         VehicleID = v.VehicleID,
                         Name = v.Name
                     }
                 }).ToList();

                serviceResponse.Data = checklistData;//_context.Checklist.ToList();


                if (serviceResponse.Data.Count == 0)
                {
                    serviceResponse.Message = "Nenhum checklist disponível!";
                }

            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.InnerException.ToString();
            }
            return serviceResponse;
        }
        


        public async Task<ServiceResponse<List<Checklist>>> CreateChecklist(Checklist checklistRequest)
        {
            ServiceResponse<List<Checklist>> serviceResponse = new ServiceResponse<List<Checklist>>();
            try
            {
                if (checklistRequest == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Nenhum dado enviado!";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                _context.Add(checklistRequest);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Checklist.ToListAsync();

            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.InnerException.ToString();
            }
            return serviceResponse;
        }

    }
}
