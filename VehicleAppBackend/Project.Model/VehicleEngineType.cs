using Project.Model.Common;

namespace Project.Model;

public class VehicleEngineType : IVehicleEngineType
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Abrv { get; set; }
}
