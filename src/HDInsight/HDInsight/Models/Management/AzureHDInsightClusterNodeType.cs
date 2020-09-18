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

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    /// <summary>
    /// Defines the type of an AzureHDInsight cluster metastore.
    /// </summary>
    public enum AzureHDInsightClusterNodeType
    {
        /// <summary> 
        /// The head nodes of the cluster.
        /// </summary> 
        HeadNode,

        /// <summary> 
        /// The worker nodes of the cluster.
        /// </summary> 
        WorkerNode,

        /// <summary>
        /// The zookeper nodes of the cluster.
        /// </summary>
        ZookeeperNode,

        /// <summary>
        /// The edge nodes of the cluster.
        /// </summary>
        EdgeNode,

        /// <summary>
        /// The idbroker nodes of the cluster
        /// </summary>
        IdBrokerNode
    }
}
