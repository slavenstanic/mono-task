using Project.Model;

namespace Project.Repository.Common;

public interface IUnitOfWork
{
    IGenericRepository<VehicleEngineType> VehicleEngineTypes { get; }
    IGenericRepository<VehicleMake> VehicleMakes { get; }
    IGenericRepository<VehicleModel> VehicleModels { get; }
    IGenericRepository<VehicleOwner> VehicleOwners { get; }
    IGenericRepository<VehicleRegistration> VehicleRegistrations { get; }
    
    Task SaveAsync();
}