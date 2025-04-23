using System.ComponentModel.DataAnnotations;
using Project.Model.Common;

namespace Project.Model;

public class VehicleMake : IVehicleMake
{
    public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string Abrv { get; set; }
    
    public virtual ICollection<VehicleModel> VehicleModels { get; set; }
}
