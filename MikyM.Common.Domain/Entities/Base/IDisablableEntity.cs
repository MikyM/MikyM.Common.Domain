namespace MikyM.Common.Domain.Entities.Base;

/// <summary>
/// Defines an entity that is soft deleted.
/// </summary>
[PublicAPI]
public interface IDisableableEntity : IEntity
{
    /// <summary>
    /// Whether the entity is currently disabled.
    /// </summary>
    bool IsDisabled { get; set; }
}
