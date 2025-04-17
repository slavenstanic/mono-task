using Project.Model.Common;

namespace Project.Repository.Common;

public interface IVehicleModelRepository
{
    Task<List<IVehicleModel>> GetAllAsync();
}
