using Project.Model.Common;

namespace Project.Model;

public class VehicleMake : IVehicleMake
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Abrv { get; set; }
}
