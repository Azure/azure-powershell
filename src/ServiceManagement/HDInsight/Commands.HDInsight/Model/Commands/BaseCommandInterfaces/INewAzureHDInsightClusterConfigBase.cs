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

using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.BaseCommandInterfaces
{
    internal interface INewAzureHDInsightClusterConfigBase
    {
        /// <summary>
        ///     Gets or sets the size of the cluster in data nodes.
        /// </summary>
        int ClusterSizeInNodes { get; set; }

        /// <summary>
        /// Gets or sets the size of the head node VMs.
        /// </summary>
        /// <value>
        /// The size of the head node VM.
        /// </value>
        string HeadNodeVMSize { get; set; }

        /// <summary>
        /// Gets or sets the size of the data node VMs.
        /// </summary>
        /// <value>
        /// The size of the data node VM.
        /// </value>
        string DataNodeVMSize { get; set; }

        /// <summary>
        /// Gets or sets the size of the zookeeper node VMs.
        /// </summary>
        /// <value>
        /// The size of the zookeeper node VM.
        /// </value>
        string ZookeeperNodeVMSize { get; set; }

        /// <summary>
        /// Gets or sets the type of the cluster.
        /// </summary>
        /// <value>
        /// The type of cluster.
        /// </value>
        ClusterType ClusterType { get; set; }

        /// <summary>
        /// Gets or sets the virtual network id of the cluster.
        /// </summary>
        /// <value>
        /// The GUID of virtual network.
        /// </value>
        string VirtualNetworkId { get; set; }

        /// <summary>
        /// Gets or sets the subnet name of the cluster.
        /// </summary>
        /// <value>
        /// The name of subnet.
        /// </value>
        string SubnetName { get; set; }
    }
}
