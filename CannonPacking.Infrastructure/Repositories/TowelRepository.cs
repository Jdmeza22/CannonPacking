
using CannonPacking.Application.Interfaces;
using CannonPacking.Domain.Entities;
using CannonPacking.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CannonPacking.Infrastructure.Repositories;

public  class TowelRepository(PackingDbContext _context) : ITowelRepository
{
    public async Task<List<Towel>> GetAllTowels()
            => await _context.Towels.Where(x => x.IsActive).ToListAsync();

    public async Task<Towel?> GetTowelById(Guid id)
        => await _context.Towels.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Towel?> GetTowelByCode(string code)
        => await _context.Towels.FirstOrDefaultAsync(x => x.ItemCode == code);

    public async Task AddTowel(Towel towel)
        => await _context.Towels.AddAsync(towel);
}
