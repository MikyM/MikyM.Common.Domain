using System;

namespace MikyM.Common.Domain.Entities.Base;

/// <summary>
/// Defines an entity.
/// </summary>
public interface IEntity : IEntity<long>
{
}

/// <summary>
/// Defines a generic base entity.
/// </summary>
public interface IEntity<out TId>
{
    /// <summary>
    /// Id of the entity.
    /// </summary>
    TId Id { get; }
    /// <summary>
    /// Creation date of the entity.
    /// </summary>
    DateTime? CreatedAt { get; set; }
    /// <summary>
    /// Last update date of the entity.
    /// </summary>
    DateTime? UpdatedAt { get; set; }
}
