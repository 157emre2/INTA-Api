using INTA_Api.Core;

namespace INTA_Api.EntitySettings;

public abstract class EntityBase : IEntity
{
    public int Id { get; set; }
    public Guid ContentId { get; set; } = Guid.NewGuid();
    public LanguageEnum Language { get; set; }
}
