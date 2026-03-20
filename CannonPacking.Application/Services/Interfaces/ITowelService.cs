using CannonPacking.Application.Dtos;

namespace CannonPacking.Application.Services.Interfaces;

public interface ITowelService
{
    Task<List<TowelResponseDto>> GetAllTowels();
    Task CreateTowel(CreateTowelRequest request);
    Task DisableTowel(Guid id);
}
