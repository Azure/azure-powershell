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
using Microsoft.Azure.Commands.Sql.VirtualCluster.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.VirtualCluster.Cmdlet
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlVirtualCluster", DefaultParameterSetName = GetByResourceGroupParameterSet)]
    [OutputType(typeof(AzureSqlVirtualClusterModel))]
    public class GetAzureSqlVirtualCluster : VirtualClusterCmdletBase
    {
        protected const string GetByNameAndResourceGroupParameterSet =
            "GetVirtualClusterByNameAndResourceGroup";

        protected const string GetByResourceGroupParameterSet =
            "GetVirtualClusterByResourceGroup";

        protected const string GetByResourceIdParameterSet =
            "GetVirtualClusterByResourceId";

        /// <summary>
        /// Gets or sets the name of the virtual cluster.
        /// </summary>
        [Parameter(ParameterSetName = GetByNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the virtual cluster.")]
        [Alias("VirtualClusterName")]
        [ResourceNameCompleter("Microsoft.Sql/virtualClusters", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group.
        /// </summary>
        [Parameter(ParameterSetName = GetByNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the resource group.")]
        [Parameter(ParameterSetName = GetByResourceGroupParameterSet,
            Mandatory = false,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the resource id of the virtual cluster
        /// </summary>
        [Parameter(ParameterSetName = GetByResourceIdParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of instance object to get")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets virtual cluster from the service.
        /// </summary>
        /// <returns>A single virtual cluster</returns>
        protected override IEnumerable<AzureSqlVirtualClusterModel> GetEntity()
        {
            ICollection<AzureSqlVirtualClusterModel> results = null;

            if (string.Equals(this.ParameterSetName, GetByResourceIdParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);

                ResourceGroupName = resourceInfo.ResourceGroupName;
                Name = resourceInfo.ResourceName;

                results = new List<AzureSqlVirtualClusterModel>();
                results.Add(ModelAdapter.GetVirtualCluster(this.ResourceGroupName, this.Name));
            }
            else if (string.Equals(this.ParameterSetName, GetByNameAndResourceGroupParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                results = new List<AzureSqlVirtualClusterModel>();
                results.Add(ModelAdapter.GetVirtualCluster(this.ResourceGroupName, this.Name));
            }
            else if (string.Equals(this.ParameterSetName, GetByResourceGroupParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                if (MyInvocation.BoundParameters.ContainsKey("ResourceGroupName"))
                {
                    results = ModelAdapter.ListVirtualClustersByResourceGroup(this.ResourceGroupName);
                }
                else
                {
                    results = ModelAdapter.ListVirtualClusters();
                }
            }

            return results;
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlVirtualClusterModel> PersistChanges(IEnumerable<AzureSqlVirtualClusterModel> entity)
        {
            return entity;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlVirtualClusterModel> ApplyUserInputToModel(IEnumerable<AzureSqlVirtualClusterModel> model)
        {
            return model;
        }
    }
}
