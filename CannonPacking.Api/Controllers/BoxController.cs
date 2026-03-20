using CannonPacking.Application.Dtos;
using CannonPacking.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CannonPacking.Api.Controllers;

[ApiController]
[Route("api/boxes")]
public class BoxesController(IBoxService _service) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _service.GetAllBoxes();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBox([FromBody] CreateBoxRequest request)
    {
        await _service.CreateBox(request);
        return Ok(new { message = "Caja creada correctamente" });
    }

    [HttpPut("{id}/disable")]
    public async Task<IActionResult> DisableBox(Guid id)
    {
        await _service.DisableBox(id);
        return Ok(new { message = "Caja deshabilitada" });
    }

    [HttpPost("{boxId}/pack")]
    public async Task<IActionResult> PackBox(Guid boxId, [FromBody] Guid towelId)
    {
        await _service.PackBox(boxId, towelId);
        return Ok(new { message = "Unidad empacada correctamente" });
    }

    [HttpPost("{boxId}/unpack")]
    public async Task<IActionResult> UnpackBox(Guid boxId, [FromBody] Guid towelId)
    {
        await _service.UnpackBox(boxId, towelId);
        return Ok(new { message = "Unidad retirada correctamente" });
    }
    [HttpPost("{boxId}/close")]
    public async Task<IActionResult> CloseBox(Guid boxId)
    {
        await _service.CloseBox(boxId);
        return Ok(new { message = "Caja cerrada correctamente" });
    }
}