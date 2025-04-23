using Project.Model.Common;

namespace Project.Repository.Common;

public interface IVehicleRegistrationRepository
{
    Task<int> InsertAsync(IVehicleRegistration entity);
    Task<List<IVehicleRegistration>>GetAllAsync();
    Task<int> UpdateAsync(IVehicleRegistration entity);
    Task<int> DeleteAsync(int id);
}
