using Microsoft.EntityFrameworkCore;
using Project.DAL;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;

namespace Project.Repository;

public class VehicleMakeRepository : IVehicleMakeRepository
{
    private readonly ProjectDbContext _context;

    public VehicleMakeRepository(ProjectDbContext context)
    {
        _context = context;
    }

    public async Task<List<IVehicleMake>> GetAllAsync()
    {
        return await _context.VehicleMakes
            .Select(m => new VehicleMake
            {
                Id = m.Id,
                Name = m.Name,
                Abrv = m.Abrv
            })
            .Cast<IVehicleMake>()
            .ToListAsync();
    }
}
