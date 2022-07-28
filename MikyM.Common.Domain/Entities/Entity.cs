// This file is part of Lisbeth.Bot project
//
// Copyright (C) 2021 Krzysztof Kupisz - MikyM
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using System;
using MikyM.Common.Domain.Entities.Base;

namespace MikyM.Common.Domain.Entities;

/// <summary>
/// Base entity with <see cref="long"/> as Id.
/// </summary>
[PublicAPI]
public abstract class Entity : Entity<long>, IEntity
{
    /// <summary>
    /// Base entity constructor.
    /// </summary>
    protected Entity()
    {
    }

    /// <summary>
    /// Base entity constructor.
    /// </summary>
    protected Entity(long id)
        : base(id)
    {
    }
}

/// <summary>
/// Base entity.
/// </summary>
public abstract class Entity<TId> : IEntity<TId>
{
    /// <summary>
    /// Base entity constructor.
    /// </summary>
    protected Entity()
    {
        CreatedAt ??= DateTime.UtcNow;
        UpdatedAt ??= CreatedAt;
    }

    /// <summary>
    /// Base entity constructor.
    /// </summary>
    protected Entity(TId id)
    {
        CreatedAt ??= DateTime.UtcNow;
        UpdatedAt ??= CreatedAt;
        Id = id;
    }


    /// <inheritdoc />
    public virtual TId Id { get; protected set; }

    /// <inheritdoc />
    public virtual DateTime? CreatedAt { get; set; }

    /// <inheritdoc />
    public virtual DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Returns the string representation of the Id of this entity.
    /// </summary>
    /// <returns>The string representation of the Id of this entity.</returns>
    public override string ToString()
        => Id.ToString();

    /// <inheritdoc />
    public override bool Equals(object obj)
    {
        if (obj is not Entity<TId> other)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetUnproxiedType(this) != GetUnproxiedType(other))
            return false;

        if (Id.Equals(default) || other.Id.Equals(default))
            return false;

        return Id.Equals(other.Id);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator ==(Entity<TId> a, Entity<TId> b)
    {
        if (a  is null && b  is null)
            return true;

        if (a  is null || b  is null)
            return false;

        return a.Equals(b);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator !=(Entity<TId> a, Entity<TId> b)
    {
        return !(a == b);
    }

    /// <inheritdoc />
    public override int GetHashCode()
        // ReSharper disable once NonReadonlyMemberInGetHashCode
        => (GetUnproxiedType(this).ToString() + Id).GetHashCode();

    
    internal static Type GetUnproxiedType(object obj)
    {
        const string efCoreProxyPrefix = "Castle.Proxies.";
        const string nHibernateProxyPostfix = "Proxy";

        var type = obj.GetType();
        var typeString = type.ToString();

        if (typeString.Contains(efCoreProxyPrefix) || typeString.EndsWith(nHibernateProxyPostfix))
            return type.BaseType;

        return type;
    }
}
