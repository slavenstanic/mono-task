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

    public async Task<List<IVehicleOwner>> GetAllAsync()
    {
        return await _context.VehicleOwners
            .Select(m => new VehicleOwner
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                DOB = m.DOB,
            })
            .Cast<IVehicleOwner>()
            .ToListAsync();
    }
}
