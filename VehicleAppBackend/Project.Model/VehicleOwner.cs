using Project.Model.Common;

namespace Project.Model;

public class VehicleOwner : IVehicleOwner
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DOB { get; set; }
    
    public virtual ICollection<VehicleRegistration> VehicleRegistrations { get; set; }
}
