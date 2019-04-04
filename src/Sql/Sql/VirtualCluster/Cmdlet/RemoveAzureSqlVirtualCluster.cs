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

using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.VirtualCluster.Model;

namespace Microsoft.Azure.Commands.Sql.VirtualCluster.Cmdlet
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlVirtualCluster",
        DefaultParameterSetName = RemoveByNameAndResourceGroupParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlVirtualClusterModel))]
    public class RemoveAzureSqlManagedInstance : VirtualClusterCmdletBase
    {
        protected const string RemoveByNameAndResourceGroupParameterSet =
            "RemoveVirtualClusterFromInputParameters";

        protected const string RemoveByInputObjectParameterSet =
            "RemoveVirtualClusterFromAzureSqlVirtualClusterModelDefinition";

        protected const string RemoveByResourceIdParameterSet =
            "RemoveVirtualClusterFromAzureResourceId";

        /// <summary>
        /// Gets or sets the name of the Virtual Cluster.
        /// </summary>
        [Parameter(
            ParameterSetName = RemoveByNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the virtual cluster.")]
        [Alias("VirtualClusterName")]
        [ResourceNameCompleter("Microsoft.Sql/virtualClusters", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(ParameterSetName = RemoveByNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Instance object to remove
        /// </summary>
        [Parameter(ParameterSetName = RemoveByInputObjectParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The instance object to remove")]
        [ValidateNotNullOrEmpty]
        [Alias("VirtualCluster")]
        public AzureSqlVirtualClusterModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the resource id of the virtual cluster
        /// </summary>
        [Parameter(ParameterSetName = RemoveByResourceIdParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of instance object to remove")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Gets the entity to delete
        /// </summary>
        /// <returns>The entity going to be deleted</returns>
        protected override IEnumerable<AzureSqlVirtualClusterModel> GetEntity()
        {
            return new List<AzureSqlVirtualClusterModel>() {
                ModelAdapter.GetVirtualCluster(this.ResourceGroupName, this.Name)
            };
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The result of GetEntity</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlVirtualClusterModel> ApplyUserInputToModel(IEnumerable<AzureSqlVirtualClusterModel> model)
        {
            return model;
        }

        /// <summary>
        /// Deletes the Virtual Cluster.
        /// </summary>
        /// <param name="entity">The Virtual Cluster being deleted</param>
        /// <returns>The Virtual Cluster that was deleted</returns>
        protected override IEnumerable<AzureSqlVirtualClusterModel> PersistChanges(IEnumerable<AzureSqlVirtualClusterModel> entity)
        {
            ModelAdapter.RemoveVirtualCluster(this.ResourceGroupName, this.Name);
            return entity;
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (string.Equals(this.ParameterSetName, RemoveByInputObjectParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                Name = InputObject.VirtualClusterName;
            }
            else if (string.Equals(this.ParameterSetName, RemoveByResourceIdParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);

                ResourceGroupName = resourceInfo.ResourceGroupName;
                Name = resourceInfo.ResourceName;
            }

            base.ExecuteCmdlet();
        }
    }
}
