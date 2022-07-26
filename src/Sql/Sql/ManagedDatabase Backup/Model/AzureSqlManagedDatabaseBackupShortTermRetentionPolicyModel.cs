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
using System.Collections.Generic;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Model
{
    public class AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel
    {
        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the instance
        /// </summary>
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets deletion Date
        /// </summary>
        public DateTime? DeletionDate { get; set; }

        /// <summary>
        /// Gets or sets the retention value
        /// </summary>
        public int RetentionDays { get; set; }

        /// <summary>
        /// Construct AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel object
        /// </summary>
        /// <param name="resourceGroup">Resource group</param>
        /// <param name="managedInstanceName">Managed Instance name</param>
        /// <param name="managedDatabaseName">Managed Database name</param>
        /// <param name="managedBackupRetentionPolicy">Managed Database object</param>
        /// <param name="deletionDate">Deletion date of the database, if it is deleted</param>
        public AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel(string resourceGroup, string managedInstanceName, string managedDatabaseName, ManagedBackupShortTermRetentionPolicy managedBackupRetentionPolicy, DateTime? deletionDate = null)
        {
            ResourceGroupName = resourceGroup;
            InstanceName = managedInstanceName;
            DatabaseName = managedDatabaseName;
            DeletionDate = deletionDate;
            RetentionDays = managedBackupRetentionPolicy.RetentionDays.Value;
        }
    }
}
