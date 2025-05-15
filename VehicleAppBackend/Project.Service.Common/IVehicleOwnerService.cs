using Project.Model;
using Project.Model.DTO;

namespace Project.Service.Common;

public interface IVehicleOwnerService
{
    Task<PagedList<VehicleOwnerDTO>> GetAllAsync(int page, int pageSize);
    Task<VehicleOwnerDTO?> GetByIdAsync(int id);
    Task<VehicleOwnerDTO> CreateAsync(VehicleOwnerDTO dto);
    Task<bool> UpdateAsync(int id, VehicleOwnerDTO dto);
    Task<bool> DeleteAsync(int id);
}
