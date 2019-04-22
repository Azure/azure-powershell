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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Sql.VirtualCluster.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.VirtualCluster.Services
{
    /// <summary>
    /// Adapter for Managed instance operations
    /// </summary>
    public class AzureSqlVirtualClusterAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlVirtualClusterCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a Virtual Cluster adapter
        /// </summary>
        /// <param name="context">The current azure profile</param>
        public AzureSqlVirtualClusterAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlVirtualClusterCommunicator(Context);
        }

        /// <summary>
        /// Gets a Virtual Cluster in a resource group
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="virtualClusterName">The name of the managed instance</param>
        /// <returns>The managed instance</returns>
        public AzureSqlVirtualClusterModel GetVirtualCluster(string resourceGroupName, string virtualClusterName)
        {
            var resp = Communicator.Get(resourceGroupName, virtualClusterName);
            return CreateVirtualClusterModelFromResponse(resp);
        }

        /// <summary>
        /// Gets a list of all virtual clusters in a subscription
        /// </summary>
        /// <returns>A list of all virtual clusters</returns>
        public List<AzureSqlVirtualClusterModel> ListVirtualClusters()
        {
            var resp = Communicator.List();

            return resp.Select(s => CreateVirtualClusterModelFromResponse(s)).ToList();
        }

        /// <summary>
        /// Gets a list of virtual clusters in a resource group
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <returns>A list of all virtual clusters</returns>
        public List<AzureSqlVirtualClusterModel> ListVirtualClustersByResourceGroup(string resourceGroupName)
        {
            var resp = Communicator.ListByResourceGroup(resourceGroupName);
            return resp.Select(s => CreateVirtualClusterModelFromResponse(s)).ToList();
        }

        /// <summary>
        /// Deletes a virtual cluster
        /// </summary>
        /// <param name="resourceGroupName">The resource group the virtual cluster is in</param>
        /// <param name="virtualClusterName">The name of the virtual cluster to delete</param>
        public void RemoveVirtualCluster(string resourceGroupName, string virtualClusterName)
        {
            Communicator.Remove(resourceGroupName, virtualClusterName);
        }

        /// <summary>
        /// Convert a Management.Sql.Models.VirtualCluster to AzureSqlVirtualClusterModel
        /// </summary>
        /// <param name="resp">The management client Virtual Cluster response to convert</param>
        /// <returns>The converted Virtual Cluster model</returns>
        private static AzureSqlVirtualClusterModel CreateVirtualClusterModelFromResponse(Management.Sql.Models.VirtualCluster resp)
        {
            AzureSqlVirtualClusterModel virtualCluster = new AzureSqlVirtualClusterModel();

            // Extract the resource group name from the ID.
            ResourceIdentifier resourceIdentifier = new ResourceIdentifier(resp.Id);
            virtualCluster.ResourceGroupName = resourceIdentifier.ResourceGroupName;

            virtualCluster.VirtualClusterName = resp.Name;
            virtualCluster.Id = resp.Id;
            virtualCluster.Location = resp.Location;
            virtualCluster.Tags = TagsConversionHelper.CreateTagDictionary(TagsConversionHelper.CreateTagHashtable(resp.Tags), false);
            virtualCluster.SubnetId = resp.SubnetId;

            return virtualCluster;
        }
    }
}
