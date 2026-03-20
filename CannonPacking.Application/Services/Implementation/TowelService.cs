
using CannonPacking.Application.Dtos;
using CannonPacking.Application.Exceptions;
using CannonPacking.Application.Services.Interfaces;
using CannonPacking.Domain.Entities;
using CannonPacking.Domain.Enums;
using CannonPacking.Infrastructure.Persistence;

namespace CannonPacking.Application.Services.Implementation;

public class TowelService(IUnitOfWork _uow) : ITowelService
{
    public async Task<List<TowelResponseDto>> GetAllTowels()
    {
        List<Towel> towels = await _uow.Towels.GetAllTowels();

        return towels.Select(x => new TowelResponseDto
        {
            Id = x.Id,
            ItemCode = x.ItemCode,
            ProductCode = x.ProductCode,
            Status = x.Status.ToString(),
            BoxId = x.BoxId
        }).ToList();
    }

    public async Task CreateTowel(CreateTowelRequest request)
    {
        Towel exists = await _uow.Towels.GetTowelByCode(request.ItemCode);
        if (exists != null) throw new AppException("Ya existe una unidad con ese código");

        Towel towel = new Towel( request.ItemCode, request.ProductCode);

        await _uow.Towels.AddTowel(towel);
        await _uow.SaveChangesAsync();
    }

    public async Task DisableTowel(Guid id)
    {
        Towel towel = await _uow.Towels.GetTowelById(id);

        if (towel == null)
            throw new AppException("La unidad no existe");

        if (towel.Status == ETowelStatus.PACKED)
            throw new AppException("No se puede deshabilitar una unidad empacada");

        towel.IsActive = false;

        await _uow.SaveChangesAsync();
    }
}
