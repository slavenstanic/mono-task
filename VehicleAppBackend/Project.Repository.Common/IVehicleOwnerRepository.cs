using Project.Model.Common;

namespace Project.Repository.Common;

public interface IVehicleOwnerRepository
{
    Task<int> InsertAsync(IVehicleOwner entity);
    Task<List<IVehicleOwner>> GetAllAsync();
    Task<int> UpdateAsync(IVehicleOwner entity);
    Task<int> DeleteAsync(int id);
}
