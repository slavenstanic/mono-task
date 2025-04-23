using Project.Model.Common;

namespace Project.Repository.Common;

public interface IVehicleMakeRepository
{
    Task<int> InsertAsync(IVehicleMake entity);
    Task<List<IVehicleMake>> GetAllAsync();
    Task<int> UpdateAsync(IVehicleMake entity);
    Task<int> DeleteAsync(int id);
}
