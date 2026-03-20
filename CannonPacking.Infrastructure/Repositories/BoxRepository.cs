using CannonPacking.Application.Interfaces;
using CannonPacking.Domain.Entities;
using CannonPacking.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CannonPacking.Infrastructure.Repositories;

public class BoxRepository(PackingDbContext _context) : IBoxRepository
{
    public async Task<List<Box>> GetAllBoxes()
        => await _context.Boxes
            .Where(x => x.IsActive)
            .Include(x => x.Towels)
            .ToListAsync();

    public async Task<Box?> GetBoxById(Guid id)
        => await _context.Boxes.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Box?> GetBoxWithItems(Guid id)
        => await _context.Boxes
            .Include(x => x.Towels)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddBox(Box box)
        => await _context.Boxes.AddAsync(box);
}
