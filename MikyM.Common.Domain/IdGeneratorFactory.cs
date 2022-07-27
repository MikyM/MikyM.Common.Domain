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
using System.Collections.Generic;
using IdGen;

namespace MikyM.Common.Domain;

/// <summary>
/// Factory used to generate snowflake Ids using <see cref="IdGenerator"/>.
/// </summary>
[PublicAPI]
public static class IdGeneratorFactory
{
    /// <summary>
    /// The factory used to create an instance of a <see cref="IdGenerator"/>.
    /// </summary>
    private static Dictionary<string, Func<IdGenerator>> _factories = new();
    /// <summary>
    /// Default generator name
    /// </summary>
    public const string DefaultGeneratorName = "__Snowflake_Id_Generator";

    /// <summary>
    /// Initializes the specified creation factory.
    /// </summary>
    /// <param name="creationFactory">The creation factory.</param>
    /// <param name="generatorName">Name for the generator factory</param>
    public static void AddFactoryMethod(Func<IdGenerator> creationFactory, string generatorName = DefaultGeneratorName)
        => _factories.Add(generatorName, creationFactory);

    /// <summary>
    /// Creates a <see cref="IdGenerator"/> instance.
    /// </summary>
    /// <returns>Returns an instance of an <see cref="IdGenerator"/> </returns>
    public static IdGenerator Build()
    {
        if (_factories.Count == 0) throw new InvalidOperationException("You can not create an instance without first adding a factory.");
        if (!_factories.TryGetValue(DefaultGeneratorName, out var df))
            throw new InvalidOperationException("Couldn't find generator factory registered for default generator name.");
        return df();
    }
    
    /// <summary>
    /// Creates a <see cref="IdGenerator"/> instance.
    /// </summary>
    /// <param name="generatorName">Name of the generator</param>
    /// <returns>Returns an instance of an <see cref="IdGenerator"/> </returns>
    public static IdGenerator Build(string generatorName)
    {
        if (!_factories.TryGetValue(generatorName, out var df))
            throw new InvalidOperationException("Couldn't find generator factory registered for default generator name.");
        return df();
    }
}
