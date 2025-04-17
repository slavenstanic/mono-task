using Project.Model.Common;

namespace Project.Repository.Common;

public interface IVehicleEngineTypeRepository
{
    Task<List<IVehicleEngineType>> GetAllAsync();
}
