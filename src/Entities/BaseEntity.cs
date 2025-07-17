namespace kvandijk.Common.Entities;

/// <summary>
/// The BaseEntity class provides all entities with a unique identifier and timestamps for creation, update, and deletion.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// The unique identifier for the entity.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// The timestamp when the entity was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// The timestamp when the entity was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Indicates whether the entity has been deleted.
    /// </summary>
    public bool IsDeleted { get; set; } = false;

    /// <summary>
    /// The timestamp when the entity was deleted, if applicable.
    /// </summary>
    public DateTime? DeletedAt { get; set; } = null;
}
