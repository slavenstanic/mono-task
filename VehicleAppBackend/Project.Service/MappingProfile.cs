using AutoMapper;
using Project.Model;
using Project.Model.DTO;

namespace Project.Service;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<VehicleMake, VehicleMakeDTO>().ReverseMap();
        CreateMap<VehicleModel, VehicleModelDTO>().ReverseMap();
        CreateMap<VehicleOwner, VehicleOwnerDTO>().ReverseMap();
        CreateMap<VehicleRegistration, VehicleRegistrationDTO>().ReverseMap();
        CreateMap<VehicleEngineType, VehicleEngineTypeDTO>().ReverseMap();
    }
}
