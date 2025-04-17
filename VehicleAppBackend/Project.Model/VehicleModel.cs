using Project.Model.Common;

namespace Project.Model;

public class VehicleModel : IVehicleModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Abrv { get; set; }
    public int VehicleMakeId { get; set; }
    public int VehicleEngineTypeId { get; set; }
}
