using Project.Model.Common;

namespace Project.Repository.Common;

public interface IVehicleOwnerRepository
{
    Task<List<IVehicleOwner>> GetAllAsync();
}
