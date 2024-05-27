using ChecklistManager.Server.Contexts;
using ChecklistManager.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ChecklistManager.Server.Service
{
    public class VehicleService
    {
        private readonly DatabaseContext _context = new DatabaseContext();
        
        public async Task<ServiceResponse<List<Vehicle>>> GetVehicles()
        {
            ServiceResponse<List<Vehicle>> serviceResponse = new ServiceResponse<List<Vehicle>>();
            try
            {
                serviceResponse.Data = _context.Vehicle.ToList();


                if (serviceResponse.Data.Count == 0)
                {
                    serviceResponse.Message = "Nenhum veículo disponível!";
                }

            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.InnerException.ToString();
            }
            return serviceResponse;
        }
        


        public async Task<ServiceResponse<List<Vehicle>>> CreateVehicle(Vehicle checklistRequest)
        {
            ServiceResponse<List<Vehicle>> serviceResponse = new ServiceResponse<List<Vehicle>>();
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

                serviceResponse.Data = await _context.Vehicle.ToListAsync();

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
