using AutoMapper;
using Project.Model;
using Project.Model.DTO;
using Project.Repository.Common;
using Project.Service.Common;

namespace Project.Service;

public class VehicleRegistrationService : IVehicleRegistrationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public VehicleRegistrationService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PagedList<VehicleRegistrationDTO>> GetAllAsync(int page, int pageSize)
    {
        try
        {
            var paged = await _unitOfWork.VehicleRegistrations.GetFilteredPagedAsync(
                null, q => q.OrderBy(x => x.RegistrationNumber), page, pageSize
            );

            return new PagedList<VehicleRegistrationDTO>(
                _mapper.Map<List<VehicleRegistrationDTO>>(paged.Items),
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

    public async Task<VehicleRegistrationDTO?> GetByIdAsync(int id)
    {
        try
        {
            var entity = await _unitOfWork.VehicleRegistrations.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<VehicleRegistrationDTO>(entity);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<VehicleRegistrationDTO> CreateAsync(VehicleRegistrationDTO dto)
    {
        try
        {
            var entity = _mapper.Map<VehicleRegistration>(dto);
            await _unitOfWork.VehicleRegistrations.InsertAsync(entity);
            await _unitOfWork.SaveAsync();
            dto.Id = entity.Id;
            return dto;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> UpdateAsync(int id, VehicleRegistrationDTO dto)
    {
        try
        {
            var existing = await _unitOfWork.VehicleRegistrations.GetByIdAsync(id);
            if (existing == null) return false;

            _mapper.Map(dto, existing);

            await _unitOfWork.VehicleRegistrations.UpdateAsync(existing);
            await _unitOfWork.SaveAsync();
            return true;
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
            var existing = await _unitOfWork.VehicleRegistrations.GetByIdAsync(id);
            if (existing == null) return false;

            await _unitOfWork.VehicleRegistrations.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
