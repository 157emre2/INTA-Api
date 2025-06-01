namespace INTA_Api.EntitySettings;

public abstract class EntityDeleteBase : EntityUpdateBase
{
    public DateTime? DeleteTime { get; set; }
    public string? DeletedBy { get; set; }
    public bool IsDeleted { get; set; } = false;
}
