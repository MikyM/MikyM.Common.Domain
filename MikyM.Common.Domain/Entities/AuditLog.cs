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

namespace MikyM.Common.Domain.Entities;

/// <summary>
/// Audit log entity.
/// </summary>
[PublicAPI]
public class AuditLog : EnvironmentSpecificEntity
{
    /// <summary>
    /// Id of the user responsible for the changes.
    /// </summary>
    public string UserId { get; set; }
    /// <summary>
    /// Type of the action.
    /// </summary>
    public string Type { get; set; }
    /// <summary>
    /// Name of the table affected by the changes.
    /// </summary>
    public string TableName { get; set; }
    /// <summary>
    /// Previous values.
    /// </summary>
    public string OldValues { get; set; }
    /// <summary>
    /// New values.
    /// </summary>
    public string NewValues { get; set; }
    /// <summary>
    /// Affected columns.
    /// </summary>
    public string AffectedColumns { get; set; }
    /// <summary>
    /// Primary key.
    /// </summary>
    public string PrimaryKey { get; set; }
}
