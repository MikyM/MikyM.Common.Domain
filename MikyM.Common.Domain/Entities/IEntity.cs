using System;

namespace MikyM.Common.Domain.Entities;

/// <summary>
/// Defines a base entity with <see cref="long"/> Id.
/// </summary>
[PublicAPI]
public interface IEntity : IEntity<long>
{
}

/// <summary>
/// Defines a generic base entity.
/// </summary>
[PublicAPI]
public interface IEntity<out TId> where TId : IComparable, IEquatable<TId>, IComparable<TId>
{
    /// <summary>
    /// The Id of the entity.
    /// </summary>
    new TId Id { get; }

    /// <summary>
    /// Creation date of the entity.
    /// </summary>
    DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Last update date of the entity.
    /// </summary>
    DateTime? UpdatedAt { get; set; }
}
