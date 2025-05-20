using Project.Model;
using Project.Model.DTO;
using Project.Repository.Common;
using Project.Service.Common;

namespace Project.Service;

public class VehicleModelService : IVehicleModelService
{
    private readonly IUnitOfWork _unitOfWork;

    public VehicleModelService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PagedList<VehicleModelDTO>> GetAllAsync(int page, int pageSize)
    {
        try
        {
            var paged = await _unitOfWork.VehicleModels.GetFilteredPagedAsync(
                null, q => q.OrderBy(x => x.Name), page, pageSize
            );

            return new PagedList<VehicleModelDTO>(
                paged.Items.Select(x => new VehicleModelDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Abrv = x.Abrv,
                    VehicleMakeId = x.VehicleMakeId,
                    VehicleEngineTypeId = x.VehicleEngineTypeId
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

    public async Task<VehicleModelDTO?> GetByIdAsync(int id)
    {
        try
        {
            var entity = await _unitOfWork.VehicleModels.GetByIdAsync(id);
            if (entity == null) return null;

            return new VehicleModelDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Abrv = entity.Abrv,
                VehicleMakeId = entity.VehicleMakeId,
                VehicleEngineTypeId = entity.VehicleEngineTypeId
            };
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
            var entity = new VehicleModel
            {
                Name = dto.Name,
                Abrv = dto.Abrv,
                VehicleMakeId = dto.VehicleMakeId,
                VehicleEngineTypeId = dto.VehicleEngineTypeId
            };

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

            existing.Name = dto.Name;
            existing.Abrv = dto.Abrv;
            existing.VehicleMakeId = dto.VehicleMakeId;
            existing.VehicleEngineTypeId = dto.VehicleEngineTypeId;

            await _unitOfWork.VehicleModels.UpdateAsync(existing);
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
            var existing = await _unitOfWork.VehicleModels.GetByIdAsync(id);
            if (existing == null) return false;

            await _unitOfWork.VehicleModels.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
            return true;
        }

        catch (Exception)
        {
            throw;
        }

    }
}
