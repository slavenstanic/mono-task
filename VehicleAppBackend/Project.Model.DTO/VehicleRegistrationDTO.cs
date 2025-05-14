namespace Project.Model.DTO;

public class VehicleRegistrationDTO
{
    public int Id { get; set; }
    public string RegistrationNumber { get; set; }
    public int VehicleModelId { get; set; }
    public int VehicleOwnerId { get; set; }
}
