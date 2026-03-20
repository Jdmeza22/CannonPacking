
using CannonPacking.Application.Interfaces;

namespace CannonPacking.Infrastructure.Persistence;

public  interface IUnitOfWork
{
    ITowelRepository Towels { get; }
    IBoxRepository Boxes { get; }

    Task<int> SaveChangesAsync();
}
