namespace kvandijk.Common.Interfaces;

/// <summary>
/// The Base interface for a repository pattern implementation.
/// </summary>
/// <typeparam name="TEntity">The entity type for the repository.</typeparam>
public interface IRepository<TEntity>
    where TEntity : class
{
    /// <summary>
    /// Gets all entities of type TEntity.
    /// </summary>
    /// <returns>All entities of type TEntity.</returns>
    Task<IEnumerable<TEntity>> GetAllAsync();

    /// <summary>
    /// Gets an entity by its identifier.
    /// </summary>
    /// <param name="id">The entity's unique identifier.</param>
    /// <returns>The entity found by the unique identifier.</returns>
    Task<TEntity?> GetByIdAsync(Guid id);

    /// <summary>
    /// Adds a new entity to the repository.
    /// </summary>
    /// <param name="entity">The entity of type TEntity.</param>
    /// <returns>Nothing.</returns>
    Task AddAsync(TEntity entity);

    /// <summary>
    /// Updates an existing entity in the repository.
    /// </summary>
    /// <param name="entity">The entity of type TEntity that will be updated.</param>
    /// <returns>Nothing.</returns>
    Task UpdateAsync(TEntity entity);

    /// <summary>
    /// Removes an entity from the repository.
    /// </summary>
    /// <param name="entity">The entity of type TEntity that will be removed.</param>
    /// <returns>Nothing.</returns>
    Task RemoveAsync(TEntity entity);

    /// <summary>
    /// Gets a queryable collection of entities of type TEntity.
    /// </summary>
    /// <returns>A queryable collection of entities of type TEntity.</returns>
    IQueryable<TEntity> GetQueryable();
}
