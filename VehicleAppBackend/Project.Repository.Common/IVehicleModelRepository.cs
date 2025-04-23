using Project.Model.Common;

namespace Project.Repository.Common;

public interface IVehicleModelRepository
{
    Task<int> InsertAsync(IVehicleModel entity);
    Task<List<IVehicleModel>> GetAllAsync();
    Task<int> UpdateAsync(IVehicleModel entity);
    Task<int> DeleteAsync(int id);
}
