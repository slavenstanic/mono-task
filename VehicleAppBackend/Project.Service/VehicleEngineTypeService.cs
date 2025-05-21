using AutoMapper;
using Project.Model;
using Project.Model.DTO;
using Project.Repository.Common;
using Project.Service.Common;

namespace Project.Service;

public class VehicleEngineTypeService : IVehicleEngineTypeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public VehicleEngineTypeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PagedList<VehicleEngineTypeDTO>> GetAllAsync(int page, int pageSize)
    {
        try
        {
            var paged = await _unitOfWork.VehicleEngineTypes.GetFilteredPagedAsync(
                null, q => q.OrderBy(x => x.Type), page, pageSize
            );

            return new PagedList<VehicleEngineTypeDTO>(
                _mapper.Map<List<VehicleEngineTypeDTO>>(paged.Items),
                paged.TotalCount,
                paged.PageNumber,
                paged.PageSize
            );
        }

        catch (Exception)
        {
            throw;
        }
    }

    public async Task<VehicleEngineTypeDTO?> GetByIdAsync(int id)
    {
        try
        {
            var entity = await _unitOfWork.VehicleEngineTypes.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<VehicleEngineTypeDTO>(entity);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
