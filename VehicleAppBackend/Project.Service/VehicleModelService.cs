using AutoMapper;
using Project.Model;
using Project.Model.DTO;
using Project.Repository.Common;
using Project.Service.Common;

namespace Project.Service;

public class VehicleModelService : IVehicleModelService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public VehicleModelService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PagedList<VehicleModelDTO>> GetAllAsync(int page, int pageSize)
    {
        try
        {
            var paged = await _unitOfWork.VehicleModels.GetFilteredPagedAsync(
                null, q => q.OrderBy(x => x.Name), page, pageSize
            );

            return new PagedList<VehicleModelDTO>(
                _mapper.Map<List<VehicleModelDTO>>(paged.Items),
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

    public async Task<VehicleModelDTO?> GetByIdAsync(int id)
    {
        try
        {
            var entity = await _unitOfWork.VehicleModels.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<VehicleModelDTO>(entity);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<VehicleModelDTO> CreateAsync(VehicleModelDTO dto)
    {
        try
        {
            var entity = _mapper.Map<VehicleModel>(dto);
            await _unitOfWork.VehicleModels.InsertAsync(entity);
            await _unitOfWork.SaveAsync();
            dto.Id = entity.Id;
            return dto;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> UpdateAsync(int id, VehicleModelDTO dto)
    {
        try
        {
            var existing = await _unitOfWork.VehicleModels.GetByIdAsync(id);
            if (existing == null) return false;

            _mapper.Map(dto, existing);

            await _unitOfWork.VehicleModels.UpdateAsync(existing);
            var result = await _unitOfWork.SaveAsync();
            return result > 0;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var existing = await _unitOfWork.VehicleModels.GetByIdAsync(id);
            if (existing == null) return false;

            await _unitOfWork.VehicleModels.DeleteAsync(id);
            var result = await _unitOfWork.SaveAsync();
            return result > 0;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
