namespace Project.Model.Common;

public interface IVehicleModel
{
    int Id { get; set; }
    string Name { get; set; }
    string Abrv { get; set; }
    int VehicleMakeId { get; set; }
    int VehicleEngineTypeId { get; set; }
}
