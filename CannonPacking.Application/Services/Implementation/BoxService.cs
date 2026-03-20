
using CannonPacking.Application.Dtos;
using CannonPacking.Application.Exceptions;
using CannonPacking.Application.Services.Interfaces;
using CannonPacking.Domain.Entities;
using CannonPacking.Domain.Enums;
using CannonPacking.Infrastructure.Persistence;

namespace CannonPacking.Application.Services.Implementation;

public  class BoxService (IUnitOfWork _uow) : IBoxService
{
    public async Task<List<BoxResponseDto>> GetAllBoxes()
    {
        List<Box> boxes = await _uow.Boxes.GetAllBoxes();

        return boxes.Select(b => new BoxResponseDto
        {
            Id = b.Id,
            BoxCode = b.BoxCode,
            ProductCode = b.ProductCode,
            Capacity = b.Capacity,
            CurrentCount = b.Towels.Count,
            Status = b.Status.ToString()
        }).ToList();
    }

    public async Task CreateBox(CreateBoxRequest request)
    {
        if (request.Capacity <= 0)
            throw new AppException("La capacidad debe ser mayor a 0");

        Box box = new Box(request.BoxCode, request.ProductCode,request.Capacity);

        await _uow.Boxes.AddBox(box);
        await _uow.SaveChangesAsync();
    }

    public async Task DisableBox(Guid id)
    {
        Box box = await _uow.Boxes.GetBoxWithItems(id);

        if (box == null) throw new AppException("La caja no existe");

        if (box.Towels.Any())
            throw new AppException("No se puede deshabilitar una caja con unidades");

        box.IsActive = false;

        await _uow.SaveChangesAsync();
    }

    public async Task PackBox(Guid boxId, Guid towelId)
    {
        Box box = await _uow.Boxes.GetBoxWithItems(boxId);

        if (box == null || box.Status != EBoxStatus.OPEN) throw new AppException("La caja no está disponible");

        Towel towel = await _uow.Towels.GetTowelById(towelId);

        if (towel == null || towel.Status != ETowelStatus.LOOSE) throw new AppException("La unidad no está disponible");

        if (towel.ProductCode != box.ProductCode)throw new AppException("El producto no coincide con la caja");

        if (box.Towels.Count >= box.Capacity) throw new AppException("Capacidad máxima alcanzada");

        towel.Status = ETowelStatus.PACKED;
        towel.BoxId = box.Id;

        await _uow.SaveChangesAsync();
    }

    public async Task UnpackBox(Guid boxId, Guid towelId)
    {
        Box box = await _uow.Boxes.GetBoxById(boxId);

        if (box == null || box.Status != EBoxStatus.OPEN) throw new AppException("La caja no permite esta operación");

        Towel towel = await _uow.Towels.GetTowelById(towelId);

        if (towel == null || towel.BoxId != boxId) throw new AppException("La unidad no pertenece a esta caja");

        towel.Status = ETowelStatus.LOOSE;
        towel.BoxId = null;

        await _uow.SaveChangesAsync();
    }

    public async Task CloseBox(Guid boxId)
    {
        Box box = await _uow.Boxes.GetBoxById(boxId);

        if (box == null || box.Status != EBoxStatus.OPEN)
            throw new AppException("La caja no se puede cerrar");

        box.Status = EBoxStatus.CLOSED;

        await _uow.SaveChangesAsync();
    }
}
