using Project.Model;
using Project.Model.DTO;

namespace Project.Service.Common;

public interface IVehicleRegistrationService
{
    Task<PagedList<VehicleRegistrationDTO>> GetAllAsync(int page, int pageSize);
    Task<VehicleRegistrationDTO?> GetByIdAsync(int id);
    Task<VehicleRegistrationDTO> CreateAsync(VehicleRegistrationDTO dto);
    Task<bool> UpdateAsync(int id, VehicleRegistrationDTO dto);
    Task<bool> DeleteAsync(int id);
}
