using Project.Model;
using Project.Model.DTO;

namespace Project.Service.Common;

public interface IVehicleMakeService
{
    Task<PagedList<VehicleMakeDTO>> GetAllAsync(int page, int pageSize);
    Task<VehicleMakeDTO?> GetByIdAsync(int id);
    Task<VehicleMakeDTO> CreateAsync(VehicleMakeDTO dto);
    Task<bool> UpdateAsync(int id, VehicleMakeDTO dto);
    Task<bool> DeleteAsync(int id);
}
