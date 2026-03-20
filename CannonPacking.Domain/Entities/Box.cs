using CannonPacking.Domain.Enums;

namespace CannonPacking.Domain.Entities;

public class Box : BaseEntity
{
    public string BoxCode { get; set; }
    public string ProductCode { get; set; } 

    public int Capacity { get; set; }

    public EBoxStatus Status { get; set; }

    public ICollection<Towel> Towels { get; set; } = new List<Towel>();

    private Box() { }
    public Box(string boxCode, string productCode, int capacity)
    {
        Id = Guid.NewGuid();
        BoxCode = boxCode;
        ProductCode = productCode;
        Capacity = capacity;
        Status = EBoxStatus.OPEN;
    }
}