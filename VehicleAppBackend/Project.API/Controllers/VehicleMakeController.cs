using Microsoft.AspNetCore.Mvc;
using Project.Model;
using Project.Repository.Common;

namespace Project.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleMakeController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public VehicleMakeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _unitOfWork.VehicleMakes.GetFilteredPagedAsync(
            filter: null,
            orderBy: q => q.OrderBy(x => x.Name),
            pageNumber: page,
            pageSize: pageSize
        );

        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _unitOfWork.VehicleMakes.GetByIdAsync(id);
        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] VehicleMake make)
    {
        await _unitOfWork.VehicleMakes.InsertAsync(make);
        var result = await _unitOfWork.SaveAsync();

        return CreatedAtAction(nameof(GetById), new { id = make.Id }, make);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] VehicleMake make)
    {
        if (id != make.Id) return BadRequest();

        var success = await _unitOfWork.VehicleMakes.UpdateAsync(make);
        var saved = await _unitOfWork.SaveAsync();

        return success > 0 && saved > 0 ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _unitOfWork.VehicleMakes.GetByIdAsync(id);
        if (existing == null) return NotFound();

        await _unitOfWork.VehicleMakes.DeleteAsync(id);
        var saved = await _unitOfWork.SaveAsync();
        return saved > 0 ? Ok() : BadRequest();
    }
    
    [HttpGet("paged")]
    public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
    {
        var result = await _unitOfWork.VehicleMakes.GetFilteredPagedAsync(
            filter: null,
            orderBy: q => q.OrderBy(x => x.Name),
            pageNumber: page,
            pageSize: pageSize
        );

        return Ok(result);
    }

}
