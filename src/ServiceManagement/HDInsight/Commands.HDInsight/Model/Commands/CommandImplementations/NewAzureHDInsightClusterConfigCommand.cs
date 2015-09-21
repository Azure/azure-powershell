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

using System.Threading.Tasks;
using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations
{
    internal class NewAzureHDInsightClusterConfigCommand : AzureHDInsightCommand<AzureHDInsightConfig>, INewAzureHDInsightClusterConfigCommand
    {
        private readonly AzureHDInsightConfig config = new AzureHDInsightConfig();

        /// <summary>
        ///     Gets or sets the size of the cluster in worker nodes.
        /// </summary>
        public int ClusterSizeInNodes
        {
            get { return this.config.ClusterSizeInNodes; }
            set { this.config.ClusterSizeInNodes = value; }
        }

        public string HeadNodeVMSize
        {
            get { return this.config.HeadNodeVMSize; }
            set { this.config.HeadNodeVMSize = value; }
        }

        public string DataNodeVMSize
        {
            get { return this.config.DataNodeVMSize; }
            set { this.config.DataNodeVMSize = value; }
        }

        public string ZookeeperNodeVMSize
        {
            get { return this.config.ZookeeperNodeVMSize; }
            set { this.config.ZookeeperNodeVMSize = value; }
        }

        public ClusterType ClusterType
        {
            get { return this.config.ClusterType; }
            set { this.config.ClusterType = value; }
        }

        public string VirtualNetworkId
        {
            get { return this.config.VirtualNetworkId; }
            set { this.config.VirtualNetworkId = value; }
        }

        public string SubnetName
        {
            get { return this.config.SubnetName; }
            set { this.config.SubnetName = value; }
        }

        public override Task EndProcessing()
        {
            this.Output.Add(this.config);
            return TaskEx.FromResult(0);
        }
    }
}
