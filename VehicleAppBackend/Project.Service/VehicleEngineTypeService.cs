using Project.Model;
using Project.Model.DTO;
using Project.Repository.Common;
using Project.Service.Common;

namespace Project.Service;

public class VehicleEngineTypeService : IVehicleEngineTypeService
{
    private readonly IUnitOfWork _unitOfWork;

    // vidim kakvu sam glupost ovdje napravio, kasnije cu ovaj servis promijeniti u read-only te zato sad necu upravljat iznimkama
    public VehicleEngineTypeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PagedList<VehicleEngineTypeDTO>> GetAllAsync(int page, int pageSize)
    {
        var paged = await _unitOfWork.VehicleEngineTypes.GetFilteredPagedAsync(
            null, q => q.OrderBy(x => x.Type), page, pageSize
        );

        return new PagedList<VehicleEngineTypeDTO>(
            paged.Items.Select(x => new VehicleEngineTypeDTO
            {
                Id = x.Id,
                Type = x.Type,
                Abrv = x.Abrv
            }).ToList(),
            paged.TotalCount,
            paged.PageNumber,
            paged.PageSize
        );
    }

    public async Task<VehicleEngineTypeDTO?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.VehicleEngineTypes.GetByIdAsync(id);
        if (entity == null) return null;

        return new VehicleEngineTypeDTO
        {
            Id = entity.Id,
            Type = entity.Type,
            Abrv = entity.Abrv
        };
    }

    public async Task<VehicleEngineTypeDTO> CreateAsync(VehicleEngineTypeDTO dto)
    {
        var entity = new VehicleEngineType
        {
            Type = dto.Type,
            Abrv = dto.Abrv
        };

        await _unitOfWork.VehicleEngineTypes.InsertAsync(entity);
        await _unitOfWork.SaveAsync();

        dto.Id = entity.Id;
        return dto;
    }

    public async Task<bool> UpdateAsync(int id, VehicleEngineTypeDTO dto)
    {
        var existing = await _unitOfWork.VehicleEngineTypes.GetByIdAsync(id);
        if (existing == null) return false;

        existing.Type = dto.Type;
        existing.Abrv = dto.Abrv;

        await _unitOfWork.VehicleEngineTypes.UpdateAsync(existing);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _unitOfWork.VehicleEngineTypes.GetByIdAsync(id);
        if (existing == null) return false;

        await _unitOfWork.VehicleEngineTypes.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return true;
    }
}
