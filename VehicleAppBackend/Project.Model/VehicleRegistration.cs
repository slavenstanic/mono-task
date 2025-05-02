using System.ComponentModel.DataAnnotations;
using Project.Model.Common;

namespace Project.Model;

public class VehicleRegistration : IVehicleRegistration
{
    public int Id { get; set; }
    [Required]
    [StringLength(10)]
    public int RegistrationNumber { get; set; }
    public int VehicleModelId { get; set; }
    public virtual VehicleModel VehicleModel { get; set; }
    public int VehicleOwnerId { get; set; }
    public virtual VehicleOwner VehicleOwner { get; set; }
}
