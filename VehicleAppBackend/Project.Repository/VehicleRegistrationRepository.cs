using Project.DAL;
using Project.Model;
using Project.Repository.Common;

namespace Project.Repository;

public class VehicleRegistrationRepository : GenericRepository<VehicleRegistration>, IVehicleRegistrationRepository
{
    public VehicleRegistrationRepository(ProjectDbContext context) : base(context) { }
}
