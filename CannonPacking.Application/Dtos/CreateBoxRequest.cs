namespace CannonPacking.Application.Dtos;

public class CreateBoxRequest
{
    public string BoxCode { get; set; }
    public string ProductCode { get; set; }
    public int Capacity { get; set; }
}
