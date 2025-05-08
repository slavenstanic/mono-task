using Project.DAL;
using Project.Model;
using Project.Repository.Common;

namespace Project.Repository;

public class VehicleOwnerRepository : GenericRepository<VehicleOwner>, IVehicleOwnerRepository
{
    public VehicleOwnerRepository(ProjectDbContext context) : base(context) { }
}
