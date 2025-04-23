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

    public async Task<int> InsertAsync(IVehicleMake entity)
    {
        var model = new VehicleMake
        {
            Name = entity.Name,
            Abrv = entity.Abrv
        };

        _context.VehicleMakes.Add(model);
        return await _context.SaveChangesAsync();
    }
    
    public async Task<List<IVehicleMake>> GetAllAsync()
    {
        return await _context.VehicleMakes.ToListAsync<IVehicleMake>();
    }
    
    public async Task<int> UpdateAsync(IVehicleMake entity)
    {
        var existing = await _context.VehicleMakes.FindAsync(entity.Id);
        if (existing == null) return 0;
        
        existing.Name = entity.Name;
        existing.Abrv = entity.Abrv;

        return await _context.SaveChangesAsync();
    }
    
    public async Task<int> DeleteAsync(int id)
    {
        var entity = await _context.VehicleMakes.FindAsync(id);
        if (entity == null) return 0;

        _context.VehicleMakes.Remove(entity);
        return await _context.SaveChangesAsync();
    }
}
