using Project.Model;
using Project.Model.DTO;
using Project.Repository.Common;
using Project.Service.Common;

namespace Project.Service;

public class VehicleRegistrationService : IVehicleRegistrationService
{
    private readonly IUnitOfWork _unitOfWork;

    public VehicleRegistrationService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PagedList<VehicleRegistrationDTO>> GetAllAsync(int page, int pageSize)
    {
        try
        {
            var paged = await _unitOfWork.VehicleRegistrations.GetFilteredPagedAsync(
                null, q => q.OrderBy(x => x.RegistrationNumber), page, pageSize
            );

            return new PagedList<VehicleRegistrationDTO>(
                paged.Items.Select(x => new VehicleRegistrationDTO
                {
                    Id = x.Id,
                    RegistrationNumber = x.RegistrationNumber,
                    VehicleModelId = x.VehicleModelId,
                    VehicleOwnerId = x.VehicleOwnerId
                }).ToList(),
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
            if (entity == null) return null;

            return new VehicleRegistrationDTO
            {
                Id = entity.Id,
                RegistrationNumber = entity.RegistrationNumber,
                VehicleModelId = entity.VehicleModelId,
                VehicleOwnerId = entity.VehicleOwnerId
            };
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
            var entity = new VehicleRegistration
            {
                RegistrationNumber = dto.RegistrationNumber,
                VehicleModelId = dto.VehicleModelId,
                VehicleOwnerId = dto.VehicleOwnerId
            };

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

            existing.RegistrationNumber = dto.RegistrationNumber;
            existing.VehicleModelId = dto.VehicleModelId;
            existing.VehicleOwnerId = dto.VehicleOwnerId;

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
