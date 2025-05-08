using Project.DAL;
using Project.Model;
using Project.Repository.Common;

namespace Project.Repository;

public class VehicleMakeRepository : GenericRepository<VehicleMake>, IVehicleMakeRepository
{
    public VehicleMakeRepository(ProjectDbContext context) : base(context) { }
}
