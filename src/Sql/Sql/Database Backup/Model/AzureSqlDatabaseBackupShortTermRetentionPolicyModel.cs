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
    public class AzureSqlDatabaseBackupShortTermRetentionPolicyModel
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
        /// Gets or sets the retention days of this policy.
        /// </summary>
        public int? RetentionDays { get; set; }

        /// <summary>
        /// Gets or sets the differential backup interval of this policy.
        /// </summary>
        public int? DiffBackupIntervalInHours { get; set; }

        /// <summary>
        /// Construct AzureSqlDatabaseBackupShortTermRetentionPolicyModel from Management.Sql.BackupShortTermRetentionPolicy object
        /// </summary>
        /// <param name="resourceGroup"></param>
        /// <param name="serverName"></param>
        /// <param name="databaseName"></param>
        /// <param name="policy"></param>
        public AzureSqlDatabaseBackupShortTermRetentionPolicyModel(string resourceGroup, string serverName, string databaseName, Management.Sql.Models.BackupShortTermRetentionPolicy policy)
        {
            if (policy.RetentionDays == null && policy.DiffBackupIntervalInHours == null)
            {
                throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.SetAzSqlDatabaseBackupShortTermRetentionInvalidParameters, "RetentionDays", "DiffBackupIntervalInHours"));
            }

            ResourceGroupName = resourceGroup;
            ServerName = serverName;
            DatabaseName = databaseName;
            RetentionDays = policy.RetentionDays;
            DiffBackupIntervalInHours = policy.DiffBackupIntervalInHours;
        }
    }
}