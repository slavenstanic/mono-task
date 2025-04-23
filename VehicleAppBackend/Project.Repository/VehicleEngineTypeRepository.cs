using Microsoft.EntityFrameworkCore;
using Project.DAL;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;

namespace Project.Repository;

public class VehicleEngineTypeRepository : IVehicleEngineTypeRepository
{
    private readonly ProjectDbContext _context;

    public VehicleEngineTypeRepository(ProjectDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<IVehicleEngineType>> GetAllAsync()
    {
        return await _context.VehicleEngineTypes.ToListAsync<IVehicleEngineType>();
    }
}
