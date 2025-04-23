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

    public async Task<int> InsertAsync(IVehicleModel entity)
    {
        var model = new VehicleModel
        {
            Name = entity.Name,
            Abrv = entity.Abrv,
            VehicleMakeId = entity.VehicleMakeId,
            VehicleEngineTypeId = entity.VehicleEngineTypeId
        };

        _context.VehicleModels.Add(model);
        return await _context.SaveChangesAsync();
    }
    
    public async Task<List<IVehicleModel>> GetAllAsync()
    {
        return await _context.VehicleModels.ToListAsync<IVehicleModel>();
    }
    
    public async Task<int> UpdateAsync(IVehicleModel entity)
    {
        var existing = await _context.VehicleModels.FindAsync(entity.Id);
        if (existing == null) return 0;
        
        existing.Name = entity.Name;
        existing.Abrv = entity.Abrv;
        existing.VehicleMakeId = entity.VehicleMakeId;
        existing.VehicleEngineTypeId = entity.VehicleEngineTypeId;

        return await _context.SaveChangesAsync();
    }
    
    public async Task<int> DeleteAsync(int id)
    {
        var entity = await _context.VehicleModels.FindAsync(id);
        if (entity == null) return 0;

        _context.VehicleModels.Remove(entity);
        return await _context.SaveChangesAsync();
    }

}
