using Project.DAL;
using Project.Model;
using Project.Repository.Common;

namespace Project.Repository;

public class VehicleModelRepository : GenericRepository<VehicleModel>, IVehicleModelRepository
{
    public VehicleModelRepository(ProjectDbContext context) : base(context) {}
}
