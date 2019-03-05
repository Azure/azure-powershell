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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Model;
using Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Services;
using Microsoft.Azure.Commands.Sql.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Cmdlet
{
    public abstract class AzureSqlDeletedManagedDatabaseBackupCmdletBase
        : AzureSqlCmdletBase<IEnumerable<AzureSqlDeletedManagedDatabaseBackupModel>, AzureSqlManagedDatabaseBackupAdapter>
    {

        /// <summary>
        /// Parameter set for using a Database Input Object.
        /// </summary>
        protected const string DeletedDatabaseList = "DeletedDatabaseList";

        /// <summary>
        /// Parameter set for using a resource Id.
        /// </summary>
        protected const string DeletedDatabaseByNameAndDeletedTime = "DeletedDatabaseByNameAndDeletedTime";

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database server to use.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the Azure SQL Managed Instance the database is in.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database to use.
        /// </summary>
        [Parameter(ParameterSetName = DeletedDatabaseList,
            Mandatory = false,
            HelpMessage = "The name of the Azure SQL Instance Database to retrieve backups for.")]
        [Parameter(ParameterSetName = DeletedDatabaseByNameAndDeletedTime,
            Mandatory = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Instance Database to retrieve backups for.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/databases", "ResourceGroupName", "InstanceName")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the deletion date of the database to use.
        /// </summary>
        [Parameter(ParameterSetName = DeletedDatabaseByNameAndDeletedTime, 
            Mandatory = true,
            Position = 3,
            HelpMessage = "The deletion date of the Azure SQL Instance Database to retrieve backups for, with millisecond precision (e.g. 2016-02-23T00:21:22.847Z)")]
        [ValidateNotNullOrEmpty]
        public DateTime? DeletionDate { get; set; }

        /// <summary>
        /// Initializes the adapter
        /// </summary>
        /// <returns></returns>
        protected override AzureSqlManagedDatabaseBackupAdapter InitModelAdapter()
        {
            return new AzureSqlManagedDatabaseBackupAdapter(DefaultProfile.DefaultContext);
        }
    }
}
