using Microsoft.EntityFrameworkCore;
using Project.DAL;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;

namespace Project.Repository;

public class VehicleOwnerRepository : IVehicleOwnerRepository
{
    private readonly ProjectDbContext _context;

    public VehicleOwnerRepository(ProjectDbContext context)
    {
        _context = context;
    }

    public async Task<int> InsertAsync(IVehicleOwner entity)
    {
        var model = new VehicleOwner
        {
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            DOB = entity.DOB
        };

        _context.VehicleOwners.Add(model);
        return await _context.SaveChangesAsync();
    }
    
    public async Task<List<IVehicleOwner>> GetAllAsync()
    {
        return await _context.VehicleOwners.ToListAsync<IVehicleOwner>();
    }
    
    public async Task<int> UpdateAsync(IVehicleOwner entity)
    {
        var existing = await _context.VehicleOwners.FindAsync(entity.Id);
        if (existing == null) return 0;
        
        existing.FirstName = entity.FirstName;
        existing.LastName = entity.LastName;
        existing.DOB = entity.DOB;

        return await _context.SaveChangesAsync();
    }
    
    public async Task<int> DeleteAsync(int id)
    {
        var entity = await _context.VehicleOwners.FindAsync(id);
        if (entity == null) return 0;

        _context.VehicleOwners.Remove(entity);
        return await _context.SaveChangesAsync();
    }
}
