
namespace CannonPacking.Application.Dtos;

public class BoxResponseDto
{
    public Guid Id { get; set; }
    public string BoxCode { get; set; }
    public string ProductCode { get; set; }
    public int Capacity { get; set; }
    public int CurrentCount { get; set; }
    public string Status { get; set; }
}
