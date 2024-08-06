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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Cmdlet
{
    /// <summary>
    /// Cmdlet to update Managed Instance Link
    /// </summary>
    [CmdletOutputBreakingChangeWithVersion(typeof(AzureSqlManagedInstanceLinkModel), "13.0.0", "6.0.0",
        DeprecatedOutputProperties = new String[] { "TargetDatabase", "PrimaryAvailabilityGroupName", "SecondaryAvailabilityGroupName",
            "SourceEndpoint", "SourceReplicaId", "TargetReplicaId", "LinkState", "LastHardenedLsn" },
        NewOutputProperties = new String[] { "Databases", "DistributedAvailabilityGroupName ", "InstanceAvailabilityGroupName", "PartnerAvailabilityGroupName",
            "InstanceLinkRole", "PartnerLinkRole", "FailoverMode", "SeedingMode", "PartnerEndpoint" })]
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceLink",
        DefaultParameterSetName = UpdateByNameParameterSet, SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlManagedInstanceLinkModel))]
    [Alias(VerbsCommon.Set + "-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceLink")]

    public class UpdateAzureSqlManagedInstanceLink : AzureSqlManagedInstanceLinkCmdletBase
    {
        private const string UpdateByNameParameterSet = "UpdateByNameParameterSet";
        private const string UpdateByParentObjectParameterSet = "UpdateByParentObjectParameterSet";
        private const string UpdateByInputObjectParameterSet = "UpdateByInputObjectParameterSet";
        private const string UpdateByResourceIdParameterSet = "UpdateByResourceIdParameterSet";

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet, Position = 0, HelpMessage = "Name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of target managed instance
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet, Position = 1, HelpMessage = "Name of Azure SQL Managed Instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the link name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet, Position = 2, HelpMessage = "Name of the instance link.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByParentObjectParameterSet, Position = 1, HelpMessage = "Name of the instance link.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/distributedAvailabilityGroups", nameof(ResourceGroupName), nameof(InstanceName))]
        [ValidateNotNullOrEmpty]
        [Alias("LinkName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the replication mode
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet, Position = 3, HelpMessage = "Replication mode value. Possible values include 'Sync' and 'Async'.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByParentObjectParameterSet, Position = 2, HelpMessage = "Replication mode value. Possible values include 'Sync' and 'Async'.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByInputObjectParameterSet, Position = 1, HelpMessage = "Replication mode value. Possible values include 'Sync' and 'Async'.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByResourceIdParameterSet, Position = 1, HelpMessage = "Replication mode value. Possible values include 'Sync' and 'Async'.")]
        [PSArgumentCompleter("Sync", "Async")]
        [ValidateNotNullOrEmpty]
        public string ReplicationMode { get; set; }

        /// <summary>
        /// Gets or sets the instance link resource Id
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = UpdateByResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "The instance link resource ID.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = UpdateByParentObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Instance input object.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceModel InstanceObject { get; set; }

        /// <summary>
        /// Gets or set the input mi link object
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = UpdateByInputObjectParameterSet, Position = 0, HelpMessage = "Instance link input object.")]
        [ValidateNotNull]
        public AzureSqlManagedInstanceLinkModel InputObject { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> GetEntity()
        {
            return new List<AzureSqlManagedInstanceLinkModel>() { ModelAdapter.GetManagedInstanceLink(ResourceGroupName, InstanceName, Name) };
        }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case UpdateByNameParameterSet:
                    // default case, we're getting RG, MI and MiLink names directly from args
                    break;
                case UpdateByParentObjectParameterSet:
                    // we need to extract RG and MI name from the Instance object, MiLink name received directly from arg
                    ResourceGroupName = InstanceObject.ResourceGroupName;
                    InstanceName = InstanceObject.ManagedInstanceName;
                    break;
                case UpdateByInputObjectParameterSet:
                    // we need to extract RG, MI and MiLink name directly from the MiLink object but replication mode can be either from the object or from arg
                    ResourceGroupName = InputObject.ResourceGroupName;
                    InstanceName = InputObject.InstanceName;
                    Name = InputObject.Name;
                    ReplicationMode = this.IsParameterBound(c => c.ReplicationMode) ? ReplicationMode : InputObject.ReplicationMode;
                    break;
                case UpdateByResourceIdParameterSet:
                    // we need to derive RG, MI and MiLink name from resource id
                    var resourceInfo = new ResourceIdentifier(ResourceId);
                    ResourceGroupName = resourceInfo.ResourceGroupName;
                    InstanceName = resourceInfo.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                    Name = resourceInfo.ResourceName;
                    break;
                default:
                    break;
            }

            // messages describing behavior with -WhatIf and -Confirm flags
            if (ShouldProcess(
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.SetAzureSqlInstanceLinkDescription, ResourceGroupName, InstanceName, Name),
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.SetAzureSqlInstanceLinkWarning, ResourceGroupName, InstanceName, Name),
                Properties.Resources.ShouldProcessCaption))
            {
                base.ExecuteCmdlet();
            }
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> ApplyUserInputToModel(IEnumerable<AzureSqlManagedInstanceLinkModel> model)
        {
            List<AzureSqlManagedInstanceLinkModel> newEntity = new List<AzureSqlManagedInstanceLinkModel> { };
            var updatedModel = model.First();
            updatedModel.ReplicationMode = ReplicationMode;
            newEntity.Add(updatedModel);
            return newEntity;
        }

        /// <summary>
        /// Create the new Failover Group
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> PersistChanges(IEnumerable<AzureSqlManagedInstanceLinkModel> entity)
        {
            return new List<AzureSqlManagedInstanceLinkModel>() {
                ModelAdapter.UpdateManagedInstanceLink(entity.First())
            };
        }
    }
}
