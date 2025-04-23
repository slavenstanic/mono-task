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

    public async Task<int> InsertAsync(IVehicleRegistration entity)
    {
        var model = new VehicleRegistration
        {
            RegistrationNumber = entity.RegistrationNumber,
            VehicleModelId = entity.VehicleModelId,
            VehicleOwnerId = entity.VehicleOwnerId
        };

        _context.VehicleRegistrations.Add(model);
        return await _context.SaveChangesAsync();
    }
    
    public async Task<List<IVehicleRegistration>> GetAllAsync()
    {
        return await _context.VehicleRegistrations.ToListAsync<IVehicleRegistration>();
    }
    
    public async Task<int> UpdateAsync(IVehicleRegistration entity)
    {
        var existing = await _context.VehicleRegistrations.FindAsync(entity.Id);
        if (existing == null) return 0;
        
        existing.RegistrationNumber = entity.RegistrationNumber;
        existing.VehicleModelId = entity.VehicleModelId;
        existing.VehicleOwnerId = entity.VehicleOwnerId;

        return await _context.SaveChangesAsync();
    }
    
    public async Task<int> DeleteAsync(int id)
    {
        var entity = await _context.VehicleRegistrations.FindAsync(id);
        if (entity == null) return 0;

        _context.VehicleRegistrations.Remove(entity);
        return await _context.SaveChangesAsync();
    }
}
