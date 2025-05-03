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
    
    public IGenericRepository<VehicleEngineType> VehicleEngineTypes => new GenericRepository<VehicleEngineType>(_context);
    
    public IGenericRepository<VehicleMake> VehicleMakes => new GenericRepository<VehicleMake>(_context);
    
    public IGenericRepository<VehicleModel> VehicleModels => new GenericRepository<VehicleModel>(_context);
    
    public IGenericRepository<VehicleOwner> VehicleOwners => new GenericRepository<VehicleOwner>(_context);
    
    public IGenericRepository<VehicleRegistration> VehicleRegistrations => new GenericRepository<VehicleRegistration>(_context);
    
    public async Task SaveAsync() => await _context.SaveChangesAsync();
}
