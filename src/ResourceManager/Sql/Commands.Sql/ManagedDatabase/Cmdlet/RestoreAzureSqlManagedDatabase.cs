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
using Microsoft.Azure.Commands.Sql.Backup.Services;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;
using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Cmdlet
{
    [Cmdlet(VerbsData.Restore, "AzureRmSqlManagedDatabase",
        ConfirmImpact = ConfirmImpact.None)]
    public class RestoreAzureRmSqlDatabase
        : AzureSqlManagedDatabaseCmdletBase<AzureSqlManagedDatabaseModel>
    {
        /// <summary>
        /// Gets or sets flag indicating a restore from a point-in-time backup.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Restore from a point-in-time backup.")]
        public SwitchParameter FromPointInTimeBackup { get; set; }

        /// <summary> 
        /// Gets or sets the managed database name to restore
        /// </summary>
        [Alias("Id")]
        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "The managed database name to restore.")]
        public string ManagedDatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Managed instance to use
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            HelpMessage = "The Managed instance name.")]
        [ValidateNotNullOrEmpty]
        public override string ManagedInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 2,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the point in time to restore the managed database to
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The point in time to restore the database to.")]
        public DateTime PointInTime { get; set; }

        /// <summary>
        /// Gets or sets the name of the target managed database to restore to
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the target managed database to restore to.")]
        public string TargetManagedDatabaseName { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Send the restore request
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override AzureSqlManagedDatabaseModel GetEntity()
        {
            AzureSqlManagedDatabaseModel model;
            DateTime restorePointInTime = DateTime.MinValue;
            string location = ModelAdapter.GetManagedInstanceLocation(ResourceGroupName, ManagedInstanceName);

            model = new AzureSqlManagedDatabaseModel()
            {
                Location = location,
                ResourceGroupName = ResourceGroupName,
                ManagedInstanceName = ManagedInstanceName,
                Name = TargetManagedDatabaseName,
                CreateMode = "PointInTimeRestore",
                RestorePointInTime = PointInTime
            };

            string sourceManagedDatabaseId = ModelAdapter.GetManagedDatabaseResourceId(ResourceGroupName, ManagedInstanceName, ManagedDatabaseName);

            return ModelAdapter.RestoreManagedDatabase(this.ResourceGroupName, sourceManagedDatabaseId, model);
        }
    }
}
