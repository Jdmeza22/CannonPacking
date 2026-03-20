
namespace CannonPacking.Application.Dtos;

public class TowelResponseDto
{
    public Guid Id { get; set; }
    public string ItemCode { get; set; }
    public string ProductCode { get; set; }
    public string Status { get; set; }
    public Guid? BoxId { get; set; }
}
