using Project.Model.Common;

namespace Project.Repository.Common;

public interface IVehicleEngineTypeRepository
{
    Task<int> InsertAsync(IVehicleEngineType entity);
    Task<List<IVehicleEngineType>> GetAllAsync();
    Task<int> UpdateAsync(IVehicleEngineType entity);
    Task<int> DeleteAsync(int id);
}
