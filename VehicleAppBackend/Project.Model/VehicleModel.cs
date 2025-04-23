using System.ComponentModel.DataAnnotations;
using Project.Model.Common;

namespace Project.Model;

public class VehicleModel : IVehicleModel
{
    public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string Abrv { get; set; }
    public int VehicleMakeId { get; set; }
    public virtual VehicleMake VehicleMake { get; set; }
    public int VehicleEngineTypeId { get; set; }
    public virtual VehicleEngineType VehicleEngineType { get; set; }
    
    public virtual ICollection<VehicleRegistration> VehicleRegistrations { get; set; }
}
