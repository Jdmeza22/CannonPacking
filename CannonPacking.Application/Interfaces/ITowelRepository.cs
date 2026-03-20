
using CannonPacking.Domain.Entities;

namespace CannonPacking.Application.Interfaces;

public interface ITowelRepository
{
    Task<List<Towel>> GetAllTowels();
    Task<Towel?> GetTowelById(Guid id);
    Task<Towel?> GetTowelByCode(string code);
    Task AddTowel(Towel towel);
}
