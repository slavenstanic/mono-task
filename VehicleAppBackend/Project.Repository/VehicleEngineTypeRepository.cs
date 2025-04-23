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
    
    public async Task<int> InsertAsync(IVehicleEngineType entity)
    {
        var model = new VehicleEngineType
        {
            Type = entity.Type,
            Abrv = entity.Abrv
        };

        _context.VehicleEngineTypes.Add(model);
        return await _context.SaveChangesAsync();
    }
    
    public async Task<List<IVehicleEngineType>> GetAllAsync()
    {
        return await _context.VehicleEngineTypes.ToListAsync<IVehicleEngineType>();
    }
    
    public async Task<int> UpdateAsync(IVehicleEngineType entity)
    {
        var existing = await _context.VehicleEngineTypes.FindAsync(entity.Id);
        if (existing == null) return 0;
        
        existing.Type = entity.Type;
        existing.Abrv = entity.Abrv;

        return await _context.SaveChangesAsync();
    }
    
    public async Task<int> DeleteAsync(int id)
    {
        var entity = await _context.VehicleEngineTypes.FindAsync(id);
        if (entity == null) return 0;

        _context.VehicleEngineTypes.Remove(entity);
        return await _context.SaveChangesAsync();
    }
}
