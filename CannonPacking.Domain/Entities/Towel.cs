using CannonPacking.Domain.Enums;

namespace CannonPacking.Domain.Entities;

public class Towel : BaseEntity
{
    public string ItemCode { get; set; } 
    public string ProductCode { get; set; } 

    public ETowelStatus Status { get; set; }

    public Guid? BoxId { get; set; }
    public Box? Box { get; set; }

    public Towel(string itemCode, string productCode)
    {
        Id = Guid.NewGuid();
        ItemCode = itemCode;
        ProductCode = productCode;
        Status = ETowelStatus.LOOSE;
    }
}