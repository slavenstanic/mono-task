using Microsoft.AspNetCore.Mvc;
using Project.Service.Common;
using Project.Model.DTO;

namespace Project.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleMakeController : ControllerBase
{
    private readonly IVehicleMakeService _service;

    public VehicleMakeController(IVehicleMakeService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _service.GetAllAsync(page, pageSize);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] VehicleMakeDTO dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] VehicleMakeDTO dto)
    {
        var success = await _service.UpdateAsync(id, dto);
        return success ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.DeleteAsync(id);
        return success ? Ok() : NotFound();
    }
}
