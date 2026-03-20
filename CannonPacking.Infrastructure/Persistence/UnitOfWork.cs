using CannonPacking.Application.Interfaces;

namespace CannonPacking.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly PackingDbContext _context;
    public ITowelRepository Towels { get; }
    public IBoxRepository Boxes { get; }

    public UnitOfWork(PackingDbContext context,
        ITowelRepository towels,
        IBoxRepository boxes)
    {
        _context = context;
        Towels = towels;
        Boxes = boxes;
    }

    public async Task<int> SaveChangesAsync()
        => await _context.SaveChangesAsync();
}
