using Microsoft.EntityFrameworkCore;
using Project.DAL;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;

namespace Project.Repository;

public class VehicleModelRepository : IVehicleModelRepository
{
    private readonly ProjectDbContext _context;

    public VehicleModelRepository(ProjectDbContext context)
    {
        _context = context;
    }

    public async Task<List<IVehicleModel>> GetAllAsync()
    {
        return await _context.VehicleModels
            .Select(m => new VehicleModel
            {
                Id = m.Id,
                Name = m.Name,
                Abrv = m.Abrv,
                VehicleMakeId = m.VehicleMakeId,
                VehicleEngineTypeId = m.VehicleEngineTypeId 
            })
            .Cast<IVehicleModel>()
            .ToListAsync();
    }

}
