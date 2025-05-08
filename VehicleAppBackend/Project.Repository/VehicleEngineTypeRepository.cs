using Project.DAL;
using Project.Model;
using Project.Repository.Common;

namespace Project.Repository;

public class VehicleEngineTypeRepository : GenericRepository<VehicleEngineType>, IVehicleEngineTypeRepository
{
    public VehicleEngineTypeRepository(ProjectDbContext context) : base(context) { }
}
