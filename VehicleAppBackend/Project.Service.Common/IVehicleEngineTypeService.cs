using Project.Model;
using Project.Model.DTO;

namespace Project.Service.Common;

public interface IVehicleEngineTypeService
{
    Task<PagedList<VehicleEngineTypeDTO>> GetAllAsync(int page, int pageSize);
    Task<VehicleEngineTypeDTO?> GetByIdAsync(int id);
    Task<VehicleEngineTypeDTO> CreateAsync(VehicleEngineTypeDTO dto);
    Task<bool> UpdateAsync(int id, VehicleEngineTypeDTO dto);
    Task<bool> DeleteAsync(int id);
}
