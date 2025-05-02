namespace Project.Model.Common;

public interface IVehicleRegistration
{
    int Id { get; set; }
    string RegistrationNumber { get; set; }
    int VehicleModelId { get; set; }
    int VehicleOwnerId { get; set; }
}
