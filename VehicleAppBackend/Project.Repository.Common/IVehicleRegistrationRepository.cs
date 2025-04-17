using Project.Model.Common;

namespace Project.Repository.Common;

public interface IVehicleRegistrationRepository
{
    Task<List<IVehicleRegistration>>GetAllAsync();
}
