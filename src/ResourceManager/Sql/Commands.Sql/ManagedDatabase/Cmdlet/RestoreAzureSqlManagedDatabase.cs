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

using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Cmdlet
{
    [Cmdlet(VerbsData.Restore, "AzureRmSqlManagedDatabase",
        SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlManagedDatabaseModel))]
    public class RestoreAzureRmSqlManagedDatabase
        : AzureSqlManagedDatabaseCmdletBase<AzureSqlManagedDatabaseModel>
    {
        protected const string PointInTimeRestoreFromNameAndResourceGroupParameterSet =
            "PointInTimeRestoreManagedDatabaseFromInputParameters";

        protected const string PointInTimeRestoreFropmInputObjectParameterSet =
            "PointInTimeRestoreManagedDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition";

        protected const string PointInTimeRestoreFromResourceIdParameterSet =
            "PointInTimeRestoreManagedDatabaseFromAzureResourceId";

        /// <summary>
        /// Gets or sets flag indicating a restore from a point-in-time backup.
        /// </summary>
        [Parameter(
            ParameterSetName = PointInTimeRestoreFromNameAndResourceGroupParameterSet,
            Mandatory = true,
            HelpMessage = "Restore from a point-in-time backup.")]
        [Parameter(
            ParameterSetName = PointInTimeRestoreFropmInputObjectParameterSet,
            Mandatory = true,
            HelpMessage = "Restore from a point-in-time backup.")]
        [Parameter(
            ParameterSetName = PointInTimeRestoreFromResourceIdParameterSet,
            Mandatory = true,
            HelpMessage = "Restore from a point-in-time backup.")]
        public SwitchParameter FromPointInTimeBackup { get; set; }

        /// <summary> 
        /// Gets or sets the managed database name to restore
        /// </summary>
        [Parameter(ParameterSetName = PointInTimeRestoreFromNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The managed database name to restore.")]
        [Alias("ManagedDatabaseName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the Managed instance to use
        /// </summary>
        [Parameter(ParameterSetName = PointInTimeRestoreFromNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The Managed instance name.")]
        [ValidateNotNullOrEmpty]
        public override string ManagedInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(ParameterSetName = PointInTimeRestoreFromNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 2,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Managed database object to remove
        /// </summary>
        [Parameter(ParameterSetName = PointInTimeRestoreFropmInputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Managed Database object to restore")]
        [ValidateNotNullOrEmpty]
        [Alias("ManagedDatabase")]
        public AzureSqlManagedDatabaseModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the resource id of the Managed database to remove
        /// </summary>
        [Parameter(ParameterSetName = PointInTimeRestoreFromResourceIdParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of Managed Database object to restore")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the point in time to restore the managed database to
        /// </summary>
        [Parameter(ParameterSetName = PointInTimeRestoreFromNameAndResourceGroupParameterSet,
            Mandatory = true,
            HelpMessage = "The point in time to restore the database to.")]
        [Parameter(ParameterSetName = PointInTimeRestoreFropmInputObjectParameterSet,
            Mandatory = true,
            HelpMessage = "The point in time to restore the database to.")]
        [Parameter(ParameterSetName = PointInTimeRestoreFromResourceIdParameterSet,
            Mandatory = true,
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

            if (string.Equals(this.ParameterSetName, PointInTimeRestoreFropmInputObjectParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                ManagedInstanceName = InputObject.ManagedInstanceName;
                Name = InputObject.Name;
            }
            else if (string.Equals(this.ParameterSetName, PointInTimeRestoreFromResourceIdParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);

                ResourceGroupName = resourceInfo.ResourceGroupName;
                ManagedInstanceName = resourceInfo.ParentResource.Split(new[] { '/' })[1];
                Name = resourceInfo.ResourceName;
            }

            model = new AzureSqlManagedDatabaseModel()
            {
                Location = location,
                ResourceGroupName = ResourceGroupName,
                ManagedInstanceName = ManagedInstanceName,
                Name = TargetManagedDatabaseName,
                CreateMode = "PointInTimeRestore",
                RestorePointInTime = PointInTime
            };

            string sourceManagedDatabaseId = ModelAdapter.GetManagedDatabaseResourceId(ResourceGroupName, ManagedInstanceName, Name);

            return ModelAdapter.RestoreManagedDatabase(this.ResourceGroupName, sourceManagedDatabaseId, model);
        }
    }
}
