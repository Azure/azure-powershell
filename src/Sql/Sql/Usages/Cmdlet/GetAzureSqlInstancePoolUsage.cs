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
using Microsoft.Azure.Commands.Sql.Usages.Cmdlet;
using Microsoft.Azure.Commands.Sql.Usages.Models;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.Instance_Pools.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Sql.Usages
{
    /// <summary>
    /// Defines the Get-AzSqlInstancePoolUsage cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstancePoolUsage",
         DefaultParameterSetName = InstancePoolUsageDefaultParameterSet)]
    [OutputType(typeof(AzureSqlUsageModel))]
    public class GetAzureSqlInstancePoolUsage : UsageCmdletBase
    {
        protected const string InstancePoolUsageParentObjectParameterSet = "InstancePoolUsageParentObjectParameterSet";
        protected const string InstancePoolUsageResourceIdParameterSet = "InstancePoolUsageResourceIdParameterSet";
        protected const string InstancePoolUsageDefaultParameterSet = "InstancePoolUsageDefaultParameterSet";

        /// <summary>
        /// Gets or sets the instance pool parent object
        /// </summary>
        [Parameter(
            ParameterSetName = InstancePoolUsageParentObjectParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The parent instance pool object.")]
        public AzureSqlInstancePoolModel InstancePool { get; set; }

        /// <summary>
        /// Gets or sets the instance pool resource id
        /// </summary>
        [Parameter(
            ParameterSetName = InstancePoolUsageResourceIdParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The parent resource id.")]
        [Alias("InstancePoolResourceId")]
        [ResourceIdCompleter("Microsoft.Sql/instancePools")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        [Parameter(
            ParameterSetName = InstancePoolUsageDefaultParameterSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the instance pool name
        /// </summary>
        [Parameter(
            ParameterSetName = InstancePoolUsageDefaultParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The managed instance pool name.")]
        [Alias("InstancePoolName")]
        [ResourceNameCompleter("Microsoft.Sql/instancePools")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the expand children switch flag
        /// </summary>
        [Parameter(HelpMessage = "Flag indicating whether to expand this instance pool's usage with its children's usage.")]
        public SwitchParameter ExpandChildren { get; set; }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (this.InstancePool != null)
            {
                this.ResourceGroupName = this.InstancePool.ResourceGroupName;
                this.Name = this.InstancePool.InstancePoolName;
            }
            else if (this.ResourceId != null)
            {
                var resourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceId.ResourceGroupName;
                this.Name = resourceId.ResourceName;
            }

            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Returns a list of instance pool usages
        /// </summary>
        /// <returns>A list of instance pool usages</returns>
        protected override IEnumerable<AzureSqlUsageModel> GetEntity()
        {
            return ModelAdapter.ListInstancePoolUsages(ResourceGroupName, Name, this.ExpandChildren.IsPresent);
        }

        /// <summary>
        /// No changes, nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlUsageModel> PersistChanges(IEnumerable<AzureSqlUsageModel> entity)
        {
            return entity;
        }

        /// <summary>
        /// No user input to apply to the model
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlUsageModel> ApplyUserInputToModel(IEnumerable<AzureSqlUsageModel> model)
        {
            return model;
        }
    }
}
