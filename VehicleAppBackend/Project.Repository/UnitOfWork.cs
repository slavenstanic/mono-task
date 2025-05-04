using Project.DAL;
using Project.Model;
using Project.Repository.Common;

namespace Project.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProjectDbContext _context;

    public UnitOfWork(ProjectDbContext context)
    {
        _context = context;
    }

    public IVehicleEngineTypeRepository VehicleEngineTypes => new VehicleEngineTypeRepository(_context);
    public IVehicleMakeRepository VehicleMakes => new VehicleMakeRepository(_context);
    public IVehicleModelRepository VehicleModels => new VehicleModelRepository(_context);
    public IVehicleOwnerRepository VehicleOwners => new VehicleOwnerRepository(_context);
    public IVehicleRegistrationRepository VehicleRegistrations => new VehicleRegistrationRepository(_context);

    public async Task SaveAsync() => await _context.SaveChangesAsync();
}
