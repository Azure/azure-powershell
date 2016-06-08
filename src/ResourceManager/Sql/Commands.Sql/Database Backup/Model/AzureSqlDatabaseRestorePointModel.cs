// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;

namespace Microsoft.Azure.Commands.Sql.Backup.Model
{
    /// <summary>
    /// Represents an Azure Sql Database restore point
    /// </summary>
    public class AzureSqlDatabaseRestorePointModel
    {
        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the location of the database
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        ///  Gets the restore point type of the Azure SQL Database restore point. Possible values are: DISCRETE and CONTINUOUS.
        /// </summary>
        public string RestorePointType { get; set; }

        /// <summary>
        /// Earliest restore time. Populated when restorePointType = CONTINUOUS. Null otherwise.
        /// </summary>
        public DateTime? RestorePointCreationDate { get; set; }

        /// <summary>
        /// Earliest restore time. Populated when restorePointType = DISCRETE. Null otherwise.
        /// </summary>
        public DateTime? EarliestRestoreDate { get; set; }
    }
}
