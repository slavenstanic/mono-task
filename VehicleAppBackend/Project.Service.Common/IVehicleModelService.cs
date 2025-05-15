using Project.Model;
using Project.Model.DTO;

namespace Project.Service.Common;

public interface IVehicleModelService
{
    Task<PagedList<VehicleModelDTO>> GetAllAsync(int page, int pageSize);
    Task<VehicleModelDTO?> GetByIdAsync(int id);
    Task<VehicleModelDTO> CreateAsync(VehicleModelDTO dto);
    Task<bool> UpdateAsync(int id, VehicleModelDTO dto);
    Task<bool> DeleteAsync(int id);
}
