using Microsoft.EntityFrameworkCore;
using Project.DAL;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;

namespace Project.Repository;

public class VehicleRegistrationRepository : IVehicleRegistrationRepository
{
    private readonly ProjectDbContext _context;

    public VehicleRegistrationRepository(ProjectDbContext context)
    {
        _context = context;
    }

    public async Task<List<IVehicleRegistration>> GetAllAsync()
    {
        return await _context.VehicleRegistrations.ToListAsync<IVehicleRegistration>();
    }
}
