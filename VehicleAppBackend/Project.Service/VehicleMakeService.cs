using Project.Model;
using Project.Model.DTO;
using Project.Repository.Common;
using Project.Service.Common;

namespace Project.Service;

public class VehicleMakeService : IVehicleMakeService
{
    private readonly IUnitOfWork _unitOfWork;

    public VehicleMakeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PagedList<VehicleMakeDTO>> GetAllAsync(int page, int pageSize)
    {
        var paged = await _unitOfWork.VehicleMakes.GetFilteredPagedAsync(
            null, q => q.OrderBy(x => x.Name), page, pageSize
        );

        return new PagedList<VehicleMakeDTO>(
            paged.Items.Select(m => new VehicleMakeDTO { Id = m.Id, Name = m.Name, Abrv = m.Abrv }).ToList(),
            paged.TotalCount,
            paged.PageNumber,
            paged.PageSize
        );
    }

    public async Task<VehicleMakeDTO?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.VehicleMakes.GetByIdAsync(id);
        return entity == null ? null : new VehicleMakeDTO { Id = entity.Id, Name = entity.Name, Abrv = entity.Abrv };
    }

    public async Task<VehicleMakeDTO> CreateAsync(VehicleMakeDTO dto)
    {
        var entity = new VehicleMake { Name = dto.Name, Abrv = dto.Abrv };
        await _unitOfWork.VehicleMakes.InsertAsync(entity);
        await _unitOfWork.SaveAsync();
        dto.Id = entity.Id;
        return dto;
    }

    public async Task<bool> UpdateAsync(int id, VehicleMakeDTO dto)
    {
        var existing = await _unitOfWork.VehicleMakes.GetByIdAsync(id);
        if (existing == null) return false;

        existing.Name = dto.Name;
        existing.Abrv = dto.Abrv;

        await _unitOfWork.VehicleMakes.UpdateAsync(existing);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _unitOfWork.VehicleMakes.GetByIdAsync(id);
        if (existing == null) return false;

        await _unitOfWork.VehicleMakes.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return true;
    }
}
