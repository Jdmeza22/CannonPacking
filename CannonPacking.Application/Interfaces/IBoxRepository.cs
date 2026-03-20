
using CannonPacking.Domain.Entities;

namespace CannonPacking.Application.Interfaces;

public interface IBoxRepository
{
    Task<List<Box>> GetAllBoxes();
    Task<Box?> GetBoxById(Guid id);
    Task<Box?> GetBoxWithItems(Guid id);
    Task AddBox(Box box);
}
