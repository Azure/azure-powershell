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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Model
{
    /// <summary>
    /// Represents an Azure Sql Managed Database geoBackup
    /// </summary>
    public class AzureSqlRecoverableManagedDatabaseModel
    {
        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the managed instance
        /// </summary>
        public string ManagedInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the unique ID of the managed database
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the managed database
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets last availabe backup of the managed database
        /// </summary>
        public string LastAvailableBackupDate { get; set; }

        /// <summary>
        /// Gets or sets recoverable database Id
        /// </summary>
        public string RecoverableDatabaseId { get; set; }

        /// <summary>
        /// Construct AzureSqlManagedDatabaseModel
        /// </summary>
        public AzureSqlRecoverableManagedDatabaseModel()
        {
        }

        /// <summary>
        /// Construct AzureSqlRecoverableManagedDatabaseModel object
        /// </summary>
        /// <param name="resourceGroup">Resource group</param>
        /// <param name="managedInstanceName">Managed Instance name</param>
        /// <param name="database">Recoverable Managed Database object</param>
        public AzureSqlRecoverableManagedDatabaseModel(string resourceGroup, string managedInstanceName, Management.Sql.Models.RecoverableManagedDatabase database)
        {
            ResourceGroupName = resourceGroup;
            ManagedInstanceName = managedInstanceName;
            Id = database.Id;
            RecoverableDatabaseId = database.Id;
            Name = database.Name;
            LastAvailableBackupDate = database.LastAvailableBackupDate;
        }
    }
}
