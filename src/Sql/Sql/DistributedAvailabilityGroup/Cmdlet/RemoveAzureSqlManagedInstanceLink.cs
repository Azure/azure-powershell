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
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Cmdlet
{
    /// <summary>
    /// Cmdlet to remove a Managed Instance Link
    /// </summary>
    [CmdletOutputBreakingChangeWithVersion(typeof(AzureSqlManagedInstanceLinkModel), "13.0.0", "6.0.0",
        DeprecatedOutputProperties = new String[] { "TargetDatabase", "PrimaryAvailabilityGroupName", "SecondaryAvailabilityGroupName",
            "SourceEndpoint", "SourceReplicaId", "TargetReplicaId", "LinkState", "LastHardenedLsn" },
        NewOutputProperties = new String[] { "Databases", "DistributedAvailabilityGroupName ", "InstanceAvailabilityGroupName", "PartnerAvailabilityGroupName",
            "InstanceLinkRole", "PartnerLinkRole", "FailoverMode", "SeedingMode", "PartnerEndpoint" })]
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceLink",
        DefaultParameterSetName = DeleteByNameParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlManagedInstanceLinkModel))]
    public class RemoveAzureSqlManagedInstanceLink : AzureSqlManagedInstanceLinkCmdletBase
    {
        private const string DeleteByNameParameterSet = "DeleteByNameParameterSet";
        private const string DeleteByParentObjectParameterSet = "DeleteByParentObjectParameterSet";
        private const string DeleteByInputObjectParameterSet = "DeleteByInputObjectParameterSet";
        private const string DeleteByResourceIdParameterSet = "DeleteByResourceIdParameterSet";

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet, Position = 0, HelpMessage = "Name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of target managed instance
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet, Position = 1, HelpMessage = "Name of Azure SQL Managed Instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the link name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet, Position = 2, HelpMessage = "Name of the instance link.")]
        [Parameter(Mandatory = true, ParameterSetName = DeleteByParentObjectParameterSet, Position = 1, HelpMessage = "Name of the instance link.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/distributedAvailabilityGroups", nameof(ResourceGroupName), nameof(InstanceName))]
        [ValidateNotNullOrEmpty]
        [Alias("LinkName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DeleteByParentObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Instance input object.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceModel InstanceObject { get; set; }

        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DeleteByInputObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Instance link input object.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceLinkModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the MI Link Resource Id
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DeleteByResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "The instance link resource ID.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action.")]
        [Alias("AllowDataLoss")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Defines whether the cmdlets will output the model object at the end of its execution.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Defines whether to return the removed instance link.")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Returns true if the model object that was constructed by this cmdlet should be written out.
        /// </summary>
        protected override bool WriteResult()
        { 
            return PassThru.IsPresent;
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {

            switch (ParameterSetName)
            {
                case DeleteByNameParameterSet:
                    // default case, we're getting RG, MI and Link names directly from args
                    break;
                case DeleteByParentObjectParameterSet:
                    // we need to extract RG and MI name from the Instance object, Link name received directly from arg
                    ResourceGroupName = InstanceObject.ResourceGroupName;
                    InstanceName = InstanceObject.ManagedInstanceName;
                    break;
                case DeleteByInputObjectParameterSet:
                    // we need to extract RG, MI and MiLink name directly from the MiLink object
                    ResourceGroupName = InputObject.ResourceGroupName;
                    InstanceName = InputObject.InstanceName;
                    Name = InputObject.Name;
                    break;
                case DeleteByResourceIdParameterSet:
                    // we need to derive RG, MI and Link name from resource id
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
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveAzureSqlInstanceLinkDescription, ResourceGroupName, InstanceName, Name),
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveAzureSqlInstanceLinkWarning, ResourceGroupName, InstanceName, Name),
                Properties.Resources.ShouldProcessCaption))
            {
                // message prompt requiring the customer to explicitly confirm the delete operation
                if (Force || ShouldContinue(Properties.Resources.RemoveAzureSqlInstanceLinkAllowDataLoss, Properties.Resources.ShouldProcessCaption))
                {
                    base.ExecuteCmdlet();
                }
            }            
        }


        /// <summary>
        /// Gets the entity to delete
        /// </summary>
        /// <returns>The entity going to be deleted</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> GetEntity()
        {
            return new List<AzureSqlManagedInstanceLinkModel>() {
                ModelAdapter.GetManagedInstanceLink(ResourceGroupName, InstanceName, Name)
            };
        }

        /// <summary>
        /// Apply user input. Here nothing to apply
        /// </summary>
        /// <param name="model">The result of GetEntity</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> ApplyUserInputToModel(IEnumerable<AzureSqlManagedInstanceLinkModel> model)
        {
            return model;
        }

        /// <summary>
        /// Deletes the mi link.
        /// </summary>
        /// <param name="entity">The link being deleted</param>
        /// <returns>The instance that was deleted</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> PersistChanges(IEnumerable<AzureSqlManagedInstanceLinkModel> entity)
        {
            ModelAdapter.RemoveManagedInstanceLink(ResourceGroupName, InstanceName, Name);
            return entity;
        }

    }
}
