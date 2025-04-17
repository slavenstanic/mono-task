using Project.Model.Common;

namespace Project.Repository.Common;

public interface IVehicleMakeRepository
{
    Task<List<IVehicleMake>> GetAllAsync();
    
}
