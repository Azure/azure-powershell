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
using Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Cmdlet;
using Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.DistributedAvailabilityGroup.Cmdlet
{
    /// <summary>
    /// Cmdlet to failover Managed Instance Link
    /// </summary>
    [Cmdlet("Start", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceLinkFailover",
        DefaultParameterSetName = FailoverByNameParameterSet, SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlManagedInstanceLinkModel))]
    public class FailoverAzureSqlManagedInstanceLink : AzureSqlManagedInstanceLinkCmdletBase
    {
        private const string FailoverByNameParameterSet = "FailoverByNameParameterSet";
        private const string FailoverByParentObjectParameterSet = "FailoverByParentObjectParameterSet";
        private const string FailoverByInputObjectParameterSet = "FailoverByInputObjectParameterSet";
        private const string FailoverByResourceIdParameterSet = "FailoverByResourceIdParameterSet";

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = FailoverByNameParameterSet, Position = 0, HelpMessage = "Name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of target managed instance
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = FailoverByNameParameterSet, Position = 1, HelpMessage = "Name of the managed instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the link name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = FailoverByNameParameterSet, Position = 2, HelpMessage = "Managed Instance link name.")]
        [Parameter(Mandatory = true, ParameterSetName = FailoverByParentObjectParameterSet, Position = 1, HelpMessage = "Managed Instance link name.")]
        [Parameter(Mandatory = true, ParameterSetName = FailoverByInputObjectParameterSet, Position = 1, HelpMessage = "Managed Instance link name.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/distributedAvailabilityGroups", nameof(ResourceGroupName), nameof(InstanceName))]
        [ValidateNotNullOrEmpty]
        [Alias("LinkName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the link failover type - Can be ForcedAllowDataLoss or Planned.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = FailoverByNameParameterSet, HelpMessage = "The failover type, can be ForcedAllowDataLoss or Planned.")]
        [Parameter(Mandatory = true, ParameterSetName = FailoverByParentObjectParameterSet, HelpMessage = "The failover type, can be ForcedAllowDataLoss or Planned.")]
        [Parameter(Mandatory = true, ParameterSetName = FailoverByInputObjectParameterSet, HelpMessage = "The failover type, can be ForcedAllowDataLoss or Planned.")]
        [Parameter(Mandatory = true, ParameterSetName = FailoverByResourceIdParameterSet, HelpMessage = "The failover type, can be ForcedAllowDataLoss or Planned.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Planned", "ForcedAllowDataLoss")]
        public string FailoverType { get; set; }

        /// <summary>
        /// Gets or sets the instance link resource Id
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = FailoverByResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "The instance link resource ID.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = FailoverByParentObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Instance input object.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceModel InstanceObject { get; set; }

        /// <summary>
        /// Gets or set the input mi link object
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = FailoverByInputObjectParameterSet, Position = 0, HelpMessage = "Instance link input object.")]
        [ValidateNotNull]
        public AzureSqlManagedInstanceLinkModel InputObject { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of failover managed instance link confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

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
                case FailoverByNameParameterSet:
                    // default case, we're getting RG, MI and MiLink names directly from args
                    break;
                case FailoverByParentObjectParameterSet:
                    // we need to extract RG and MI name from the Instance object, MiLink name received directly from arg
                    ResourceGroupName = InstanceObject.ResourceGroupName;
                    InstanceName = InstanceObject.ManagedInstanceName;
                    break;
                case FailoverByInputObjectParameterSet:
                    // we need to extract RG, MI and MiLink name directly from the MiLink object but replication mode can be either from the object or from arg
                    ResourceGroupName = InputObject.ResourceGroupName;
                    InstanceName = InputObject.InstanceName;
                    Name = InputObject.Name;
                    FailoverType = this.IsParameterBound(c => c.FailoverType) ? FailoverType : InputObject.ReplicationMode;
                    break;
                case FailoverByResourceIdParameterSet:
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
                // message prompt requiring the customer to explicitly confirm the delete operation
                if (!FailoverType.Equals("ForcedAllowDataLoss") || Force || (FailoverType.Equals("ForcedAllowDataLoss") &&
                    ShouldContinue("Executing forced failover may result in loss of data which has not yet been replicated to the secondary instance. Do you wish to proceed?",
                    Properties.Resources.ShouldProcessCaption)))
                {
                    // base.ExecuteCmdlet();
                    ModelAdapter = InitModelAdapter();
                    IEnumerable<AzureSqlManagedInstanceLinkModel> model = this.GetEntity();
                    IEnumerable<AzureSqlManagedInstanceLinkModel> updatedModel = ApplyUserInputToModel(model);
                    IEnumerable<AzureSqlManagedInstanceLinkModel> responseModel = default(IEnumerable<AzureSqlManagedInstanceLinkModel>);

                    ConfirmAction(GetConfirmActionProcessMessage(), GetResourceId(updatedModel), () =>
                    {
                        responseModel = PersistChanges(updatedModel);
                    });

                    var link = ModelAdapter.GetManagedInstanceLink(ResourceGroupName, InstanceName, Name);
                    IEnumerable<AzureSqlManagedInstanceLinkModel> response = new List<AzureSqlManagedInstanceLinkModel> { link };

                    if (link != null && responseModel != null)
                    {
                        if (WriteResult())
                        {
                            WriteObject(TransformModelToOutputObject(response), true);
                        }
                    }
                    else
                    {
                        if (WriteResult())
                        {
                            WriteObject(TransformModelToOutputObject(updatedModel));
                        }
                    }
                }
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
            var failoverModel = model.First();
            failoverModel.FailoverMode = FailoverType;
            newEntity.Add(failoverModel);
            return newEntity;
        }

        /// <summary>
        /// Failovers managed instance link
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> PersistChanges(IEnumerable<AzureSqlManagedInstanceLinkModel> entity)
        {
            return new List<AzureSqlManagedInstanceLinkModel>() {
                ModelAdapter.FailoverManagedInstanceLink(entity.First())
            };
        }
    }
}