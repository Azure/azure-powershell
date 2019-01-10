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
    [Cmdlet(VerbsData.Restore, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDatabase",
        DefaultParameterSetName = PointInTimeSameInstanceRestoreFromNameAndResourceGroupParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlManagedDatabaseModel))]
    public class RestoreAzureRmSqlManagedDatabase
        : AzureSqlManagedDatabaseCmdletBase<AzureSqlManagedDatabaseModel>
    {
        protected const string PointInTimeSameInstanceRestoreFromNameAndResourceGroupParameterSet =
            "PointInTimeSameInstanceRestoreInstanceDatabaseFromInputParameters";

        protected const string PointInTimeSameInstanceRestoreFromInputObjectParameterSet =
            "PointInTimeSameInstanceRestoreInstanceDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition";

        protected const string PointInTimeSameInstanceRestoreFromResourceIdParameterSet =
            "PointInTimeSameInstanceRestoreInstanceDatabaseFromAzureResourceId";

        protected const string PointInTimeCrossInstanceRestoreFromNameAndResourceGroupParameterSet =
            "PointInTimeCrossInstanceRestoreInstanceDatabaseFromInputParameters";

        protected const string PointInTimeCrossInstanceRestoreFromInputObjectParameterSet =
            "PointInTimeCrossInstanceRestoreInstanceDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition";

        protected const string PointInTimeCrossInstanceRestoreFromResourceIdParameterSet =
            "PointInTimeCrossInstanceRestoreInstanceDatabaseFromAzureResourceId";

        /// <summary>
        /// Gets or sets flag indicating a restore from a point-in-time backup.
        /// </summary>
        [Parameter(
            ParameterSetName = PointInTimeSameInstanceRestoreFromNameAndResourceGroupParameterSet,
            Mandatory = true,
            HelpMessage = "Restore from a point-in-time backup.")]
        [Parameter(
            ParameterSetName = PointInTimeSameInstanceRestoreFromInputObjectParameterSet,
            Mandatory = true,
            HelpMessage = "Restore from a point-in-time backup.")]
        [Parameter(
            ParameterSetName = PointInTimeSameInstanceRestoreFromResourceIdParameterSet,
            Mandatory = true,
            HelpMessage = "Restore from a point-in-time backup.")]
        [Parameter(
            ParameterSetName = PointInTimeCrossInstanceRestoreFromNameAndResourceGroupParameterSet,
            Mandatory = true,
            HelpMessage = "Restore from a point-in-time backup.")]
        [Parameter(
            ParameterSetName = PointInTimeCrossInstanceRestoreFromInputObjectParameterSet,
            Mandatory = true,
            HelpMessage = "Restore from a point-in-time backup.")]
        [Parameter(
            ParameterSetName = PointInTimeCrossInstanceRestoreFromResourceIdParameterSet,
            Mandatory = true,
            HelpMessage = "Restore from a point-in-time backup.")]
        public SwitchParameter FromPointInTimeBackup { get; set; }

        /// <summary> 
        /// Gets or sets the instance database name to restore
        /// </summary>
        [Parameter(ParameterSetName = PointInTimeSameInstanceRestoreFromNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The instance database name to restore.")]
        [Parameter(ParameterSetName = PointInTimeCrossInstanceRestoreFromNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The instance database name to restore.")]
        [Alias("InstanceDatabaseName")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/databases", "ResourceGroupName", "InstanceName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the instance to use
        /// </summary>
        [Parameter(ParameterSetName = PointInTimeSameInstanceRestoreFromNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the instance.")]
        [Parameter(ParameterSetName = PointInTimeCrossInstanceRestoreFromNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(ParameterSetName = PointInTimeSameInstanceRestoreFromNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 2,
            HelpMessage = "The name of the resource group.")]
        [Parameter(ParameterSetName = PointInTimeCrossInstanceRestoreFromNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 2,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Instance database object to remove
        /// </summary>
        [Parameter(ParameterSetName = PointInTimeSameInstanceRestoreFromInputObjectParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The instance database object to restore")]
        [Parameter(ParameterSetName = PointInTimeCrossInstanceRestoreFromInputObjectParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The instance database object to restore")]
        [ValidateNotNullOrEmpty]
        [Alias("InstanceDatabase")]
        public AzureSqlManagedDatabaseModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the resource id of the instance database to remove
        /// </summary>
        [Parameter(ParameterSetName = PointInTimeSameInstanceRestoreFromResourceIdParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of instance database object to restore")]
        [Parameter(ParameterSetName = PointInTimeCrossInstanceRestoreFromResourceIdParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of instance database object to restore")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the point in time to restore the instance database to
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The point in time to restore the database to.")]
        public DateTime PointInTime { get; set; }

        /// <summary>
        /// Gets or sets the name of the target instance database to restore to
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the target instance database to restore to.")]
        public string TargetInstanceDatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the target instance to restore to.
        /// </summary>
        [Parameter(ParameterSetName = PointInTimeCrossInstanceRestoreFromNameAndResourceGroupParameterSet,
            Mandatory = true,
            HelpMessage = "The name of the target instance to restore to. If not specified, the target instance is the same as the source instance.")]
        [Parameter(ParameterSetName = PointInTimeCrossInstanceRestoreFromResourceIdParameterSet,
            Mandatory = true,
            HelpMessage = "The name of the target instance to restore to. If not specified, the target instance is the same as the source instance.")]
        [Parameter(ParameterSetName = PointInTimeCrossInstanceRestoreFromInputObjectParameterSet,
            Mandatory = true,
            HelpMessage = "The name of the target instance to restore to. If not specified, the target instance is the same as the source instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        public string TargetInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the target resource group to restore to.
        /// </summary>
        [Parameter(ParameterSetName = PointInTimeCrossInstanceRestoreFromNameAndResourceGroupParameterSet,
            Mandatory = true,
            HelpMessage = "The name of the target resource group to restore to. If not specified, the target resource group is the same as the source resource group.")]
        [Parameter(ParameterSetName = PointInTimeCrossInstanceRestoreFromResourceIdParameterSet,
            Mandatory = true,
            HelpMessage = "The name of the target resource group to restore to. If not specified, the target resource group is the same as the source resource group.")]
        [Parameter(ParameterSetName = PointInTimeCrossInstanceRestoreFromInputObjectParameterSet,
            Mandatory = true,
            HelpMessage = "The name of the target resource group to restore to. If not specified, the target resource group is the same as the source resource group.")]
        [ResourceGroupCompleter]
        public string TargetResourceGroupName { get; set; }

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
            string location = ModelAdapter.GetManagedInstanceLocation(ResourceGroupName, InstanceName);

            if (string.Equals(this.ParameterSetName, PointInTimeSameInstanceRestoreFromInputObjectParameterSet, System.StringComparison.OrdinalIgnoreCase) ||
                string.Equals(this.ParameterSetName, PointInTimeCrossInstanceRestoreFromInputObjectParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                InstanceName = InputObject.ManagedInstanceName;
                Name = InputObject.Name;
            }
            else if (string.Equals(this.ParameterSetName, PointInTimeSameInstanceRestoreFromResourceIdParameterSet, System.StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(this.ParameterSetName, PointInTimeCrossInstanceRestoreFromResourceIdParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);

                ResourceGroupName = resourceInfo.ResourceGroupName;
                InstanceName = resourceInfo.ParentResource.Split(new[] { '/' })[1];
                Name = resourceInfo.ResourceName;
            }

            if (String.IsNullOrEmpty(TargetInstanceName))
            {
                TargetInstanceName = InstanceName;
            }

            if (String.IsNullOrEmpty(TargetResourceGroupName))
            {
                TargetResourceGroupName = ResourceGroupName;
            }

            model = new AzureSqlManagedDatabaseModel()
            {
                Location = location,
                ResourceGroupName = TargetResourceGroupName,
                ManagedInstanceName = TargetInstanceName,
                Name = TargetInstanceDatabaseName,
                CreateMode = "PointInTimeRestore",
                RestorePointInTime = PointInTime
            };

            string sourceManagedDatabaseId = ModelAdapter.GetManagedDatabaseResourceId(ResourceGroupName, InstanceName, Name);

            return ModelAdapter.RestoreManagedDatabase(sourceManagedDatabaseId, model);
        }
    }
}
