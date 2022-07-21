using System;

namespace MikyM.Common.Domain.Entities.Base;

public interface IEntity : IEntity<long>
{
}

public interface IEntity<TId>
{
    TId Id { get; }
    DateTime? CreatedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
    bool IsDisabled { get; set; }
}
