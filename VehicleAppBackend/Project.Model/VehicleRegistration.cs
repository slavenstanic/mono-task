using Project.Model.Common;

namespace Project.Model;

public class VehicleRegistration : IVehicleRegistration
{
    public int Id { get; set; }
    public int RegistrationNumber { get; set; }
    public int VehicleModelId { get; set; }
    public int VehicleOwnerId { get; set; }
}
