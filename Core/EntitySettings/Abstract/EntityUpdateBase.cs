namespace INTA_Api.EntitySettings;

public abstract class EntityUpdateBase : EntityCreateBase
{
    public DateTime? UpdateTime { get; set; } = DateTime.UtcNow;
    public string? UpdatedBy { get; set; }
}
