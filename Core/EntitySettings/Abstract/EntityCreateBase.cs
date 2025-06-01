namespace INTA_Api.EntitySettings;

public abstract class EntityCreateBase : EntityBase
{
    public DateTime? CreateTime { get; set; } = DateTime.UtcNow;
    public string? CreatedBy { get; set; }
}
