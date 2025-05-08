using Project.DAL;
using Project.Model;
using Project.Repository.Common;

namespace Project.Repository;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ProjectDbContext _context;

    public UnitOfWork(ProjectDbContext context)
    {
        _context = context;
    }
    
    private IVehicleEngineTypeRepository _vehicleEngineTypes;
    
    private IVehicleMakeRepository _vehicleMakes;
    
    private IVehicleModelRepository _vehicleModels;
    
    private IVehicleOwnerRepository _vehicleOwners;
    
    private IVehicleRegistrationRepository _vehicleRegistrations;
    
    public IVehicleEngineTypeRepository VehicleEngineTypes => _vehicleEngineTypes ??= new VehicleEngineTypeRepository(_context);
    public IVehicleMakeRepository VehicleMakes => _vehicleMakes ??= new VehicleMakeRepository(_context);
    public IVehicleModelRepository VehicleModels => _vehicleModels ??= new VehicleModelRepository(_context);
    public IVehicleOwnerRepository VehicleOwners => _vehicleOwners ??= new VehicleOwnerRepository(_context);
    public IVehicleRegistrationRepository VehicleRegistrations => _vehicleRegistrations ??= new VehicleRegistrationRepository(_context);

    public async Task SaveAsync() => await _context.SaveChangesAsync();
    
    public void Dispose()
    {
        _context.Dispose();
    }
}
