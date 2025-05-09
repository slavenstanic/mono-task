using System.ComponentModel.DataAnnotations;
using Project.Model.Common;

namespace Project.Model;

public class VehicleMake : IVehicleMake
{
    public int Id { get; set; }
    [Required]
    [StringLength(30)]
    public string Name { get; set; }
    [Required]
    [StringLength(10)]
    public string Abrv { get; set; }
    
    public virtual ICollection<VehicleModel> VehicleModels { get; set; }
}
