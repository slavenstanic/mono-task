using System.ComponentModel.DataAnnotations;
using Project.Model.Common;

namespace Project.Model;

public class VehicleEngineType : IVehicleEngineType
{
    public int Id { get; set; }
    [Required] public string Type { get; set; } // mozda dodati [StringLength()] -> na svim potrebnim mjestima (Type, Abrv, Name, FirstName, LastName)
    [Required] public string Abrv { get; set; }
    
    public virtual ICollection<VehicleModel> VehicleModels { get; set; }
}
