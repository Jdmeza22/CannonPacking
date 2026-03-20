using CannonPacking.Application.Dtos;

namespace CannonPacking.Application.Services.Interfaces;

public interface IBoxService
{
    Task<List<BoxResponseDto>> GetAllBoxes();
    Task CreateBox(CreateBoxRequest request);
    Task DisableBox(Guid id);

    Task PackBox(Guid boxId, Guid towelId);
    Task UnpackBox(Guid boxId, Guid towelId);
    Task CloseBox(Guid boxId);
}
