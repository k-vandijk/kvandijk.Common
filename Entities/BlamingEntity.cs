namespace kvandijk.Common.Entities;

public abstract class BlamingEntity
{
    public Guid CreatedBy { get; set; } = Guid.Empty;
    public Guid UpdatedBy { get; set; } = Guid.Empty;
    public Guid? DeletedBy { get; set; } = null;
}
