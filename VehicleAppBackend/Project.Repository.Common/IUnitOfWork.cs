using Project.Model;

namespace Project.Repository.Common;

public interface IUnitOfWork
{
    IVehicleEngineTypeRepository VehicleEngineTypes { get; }
    IVehicleMakeRepository VehicleMakes { get; }
    IVehicleModelRepository VehicleModels { get; }
    IVehicleOwnerRepository VehicleOwners { get; }
    IVehicleRegistrationRepository VehicleRegistrations { get; }

    Task<int> SaveAsync();
}
