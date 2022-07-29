using System;

namespace MikyM.Common.Domain.Entities.Base;

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
public interface IEntity<out TId> : IEntityBase where TId : IComparable, IEquatable<TId>, IComparable<TId>
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

/// <summary>
/// Defines a base entity. <b>Shouldn't be implemented manually, implement <see cref="IEntity"/> or <see cref="IEntity{TId}"/> instead.</b>
/// </summary>
[PublicAPI]
public interface IEntityBase
{
    /// <summary>
    /// The Id of the entity.
    /// </summary>
    object Id { get; }
}
