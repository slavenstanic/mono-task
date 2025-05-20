using Project.Model;
using Project.Model.DTO;
using Project.Repository.Common;
using Project.Service.Common;

namespace Project.Service;

public class VehicleOwnerService : IVehicleOwnerService
{
    private readonly IUnitOfWork _unitOfWork;

    public VehicleOwnerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PagedList<VehicleOwnerDTO>> GetAllAsync(int page, int pageSize)
    {
        try
        {
            var paged = await _unitOfWork.VehicleOwners.GetFilteredPagedAsync(
                null, q => q.OrderBy(x => x.LastName), page, pageSize
            );

            return new PagedList<VehicleOwnerDTO>(
                paged.Items.Select(x => new VehicleOwnerDTO
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DOB = x.DOB
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

    public async Task<VehicleOwnerDTO?> GetByIdAsync(int id)
    {
        try
        {
            var entity = await _unitOfWork.VehicleOwners.GetByIdAsync(id);
            if (entity == null) return null;

            return new VehicleOwnerDTO
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                DOB = entity.DOB
            };
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
            var entity = new VehicleOwner
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DOB = dto.DOB
            };

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

            existing.FirstName = dto.FirstName;
            existing.LastName = dto.LastName;
            existing.DOB = dto.DOB;

            await _unitOfWork.VehicleOwners.UpdateAsync(existing);
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
            var existing = await _unitOfWork.VehicleOwners.GetByIdAsync(id);
            if (existing == null) return false;

            await _unitOfWork.VehicleOwners.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
            return true;
        }

        catch (Exception)
        {
            throw;
        }

    }
}
