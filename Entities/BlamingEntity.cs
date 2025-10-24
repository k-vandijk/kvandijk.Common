namespace kvandijk.Common.Entities;

/// <summary>
/// Provides entities with properties for tracking the user responsible for creating, updating, and deleting the entity.
/// </summary>
public abstract class BlamingEntity
{
    /// <summary>
    /// The user who created the entity.
    /// </summary>
    public Guid CreatedBy { get; set; } = Guid.Empty;

    /// <summary>
    /// The user who last updated the entity.
    /// </summary>
    public Guid UpdatedBy { get; set; } = Guid.Empty;

    /// <summary>
    /// The user who deleted the entity, if applicable.
    /// </summary>
    public Guid? DeletedBy { get; set; } = null;
}
