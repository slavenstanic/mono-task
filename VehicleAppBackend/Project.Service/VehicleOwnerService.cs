using AutoMapper;
using Project.Model;
using Project.Model.DTO;
using Project.Repository.Common;
using Project.Service.Common;

namespace Project.Service;

public class VehicleOwnerService : IVehicleOwnerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public VehicleOwnerService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PagedList<VehicleOwnerDTO>> GetAllAsync(int page, int pageSize)
    {
        try
        {
            var paged = await _unitOfWork.VehicleOwners.GetFilteredPagedAsync(
                null, q => q.OrderBy(x => x.LastName), page, pageSize
            );

            return new PagedList<VehicleOwnerDTO>(
                _mapper.Map<List<VehicleOwnerDTO>>(paged.Items),
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

    public async Task<VehicleOwnerDTO?> GetByIdAsync(int id)
    {
        try
        {
            var entity = await _unitOfWork.VehicleOwners.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<VehicleOwnerDTO>(entity);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<VehicleOwnerDTO> CreateAsync(VehicleOwnerDTO dto)
    {
        try
        {
            var entity = _mapper.Map<VehicleOwner>(dto);
            await _unitOfWork.VehicleOwners.InsertAsync(entity);
            await _unitOfWork.SaveAsync();
            dto.Id = entity.Id;
            return dto;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> UpdateAsync(int id, VehicleOwnerDTO dto)
    {
        try
        {
            var existing = await _unitOfWork.VehicleOwners.GetByIdAsync(id);
            if (existing == null) return false;

            _mapper.Map(dto, existing);

            await _unitOfWork.VehicleOwners.UpdateAsync(existing);
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
            var existing = await _unitOfWork.VehicleOwners.GetByIdAsync(id);
            if (existing == null) return false;

            await _unitOfWork.VehicleOwners.DeleteAsync(id);
            var result = await _unitOfWork.SaveAsync();
            return result > 0;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
