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

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.CosmosDB.Models;

    public class PSGarnetClusterResourceProperties
    {
        public PSGarnetClusterResourceProperties()
        {
        }

        public PSGarnetClusterResourceProperties(GarnetClusterResourceProperties properties)
        {
            if (properties == null)
                return;

            ProvisioningState = properties.ProvisioningState;
            SubnetId = properties.SubnetId;
            ReplicationFactor = properties.ReplicationFactor;
            ShardCount = properties.ShardCount;
            NodeSku = properties.NodeSku;
            AvailabilityZone = properties.AvailabilityZone;
            AuthenticationMethod = properties.AuthenticationMethod;
            Persistence = properties.Persistence;
            AllocationState = properties.AllocationState;
            ClusterType = properties.ClusterType;
            Extensions = properties.Extensions;
        }

        /// <summary>
        /// Gets the provisioning state of the resource.
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets resource id of the subnet for the cluster's management service.
        /// </summary>
        public string SubnetId { get; set; }

        /// <summary>
        /// Gets or sets number of copies of data maintained by the cluster.
        /// </summary>
        public int? ReplicationFactor { get; set; }

        /// <summary>
        /// Gets or sets number of shards in the cluster.
        /// </summary>
        public int? ShardCount { get; set; }

        /// <summary>
        /// Gets or sets Virtual Machine SKU used for clusters.
        /// </summary>
        public string NodeSku { get; set; }

        /// <summary>
        /// Gets or sets whether Availability Zone support is enabled.
        /// </summary>
        public bool? AvailabilityZone { get; set; }

        /// <summary>
        /// Gets or sets the authentication method used for the Garnet cluster.
        /// </summary>
        public string AuthenticationMethod { get; set; }

        /// <summary>
        /// Gets or sets whether persistence is enabled for the Garnet cluster.
        /// </summary>
        public bool? Persistence { get; set; }

        /// <summary>
        /// Gets or sets the allocation state of the cluster.
        /// </summary>
        public string AllocationState { get; set; }

        /// <summary>
        /// Gets or sets the cluster type.
        /// </summary>
        public string ClusterType { get; set; }

        /// <summary>
        /// Gets or sets extensions for the cluster.
        /// </summary>
        public IList<string> Extensions { get; set; }
    }
}
