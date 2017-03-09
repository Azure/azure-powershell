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
    /// Represents an Azure Sql Database restorable deleted database
    /// </summary>
    public class AzureSqlDeletedDatabaseBackupModel
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
        /// Gets or sets the edition of the backup
        /// </summary>
        public string Edition { get; set; }

        /// <summary>
        /// Gets or sets maxSize in bytes
        /// </summary>
        public long MaxSizeBytes { get; set; }

        /// <summary>
        /// Gets or sets the current service level objective name for the database.
        /// </summary>
        public string ServiceLevelObjective { get; set; }

        /// <summary>
        /// Gets or sets the elastic pool name for the database.
        /// </summary>
        public string ElasticPoolName { get; set; }

        /// <summary>
        /// Gets or sets creation Date
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets deletion Date
        /// </summary>
        public DateTime DeletionDate { get; set; }

        /// <summary>
        /// Gets or sets earliestRestoreDate
        /// </summary>
        public DateTime? RecoveryPeriodStartDate { get; set; }

        /// <summary>
        /// Gets or sets a unique ID incorporating name and deletion date
        /// </summary>
        public string EntityId { get; set; }

        /// <summary>
        /// Gets or sets the resource ID
        /// </summary>
        public string ResourceId { get; set; }
    }
}
