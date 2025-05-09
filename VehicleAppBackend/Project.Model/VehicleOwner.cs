using System.ComponentModel.DataAnnotations;
using Project.Model.Common;

namespace Project.Model;

public class VehicleOwner : IVehicleOwner
{
    public int Id { get; set; }
    [Required]
    [StringLength(30)]
    public string FirstName { get; set; }
    [Required]
    [StringLength(30)]
    public string LastName { get; set; }
    [Required] public DateTime DOB { get; set; }
    
    public virtual ICollection<VehicleRegistration> VehicleRegistrations { get; set; }
}
