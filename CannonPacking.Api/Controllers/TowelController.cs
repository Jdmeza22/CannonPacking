using CannonPacking.Application.Dtos;
using CannonPacking.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/towels")]
public class TowelsController(ITowelService _service) : ControllerBase
{ 
    [HttpGet]
    public async Task<IActionResult> Get()
        => Ok(await _service.GetAllTowels());

    [HttpPost]
    public async Task<IActionResult> Create(CreateTowelRequest request)
    {
        await _service.CreateTowel(request);
        return Ok();
    }

    [HttpPut("{id}/disable")]
    public async Task<IActionResult> Disable(Guid id)
    {
        await _service.DisableTowel(id);
        return Ok();
    }
}