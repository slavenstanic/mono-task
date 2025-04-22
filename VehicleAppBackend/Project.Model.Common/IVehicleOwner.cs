namespace Project.Model.Common;

public interface IVehicleOwner
{
    int Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    DateTime DOB { get; set; } // -> DateOnly?
}
