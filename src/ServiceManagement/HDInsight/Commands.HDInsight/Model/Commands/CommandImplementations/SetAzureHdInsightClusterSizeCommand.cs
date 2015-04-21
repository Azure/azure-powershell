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

using System.Management.Automation;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations
{
    /// <summary>
    ///     Command referenced by the cmdlet that allows a user to change the size of a cluster.
    /// </summary>
    internal class SetAzureHdInsightClusterSizeCommand : AzureHDInsightClusterCommand<AzureHDInsightCluster>,
        ISetAzureHDInsightClusterSizeCommand
    {
        private SwitchParameter force;

        public SwitchParameter Force
        {
            get { return force; }
            set { force = value; }
        }
        
        public string Location { get; set; }

        public AzureHDInsightCluster Cluster { get; set; }

        public int ClusterSizeInNodes { get; set; }

        public override async Task EndProcessing()
        {
            Name.ArgumentNotNull("Name");
            Location.ArgumentNotNull("Location");
            var client = GetClient(IgnoreSslErrors);
            var cluster = await client.ChangeClusterSizeAsync(Name, Location, ClusterSizeInNodes);
            if (cluster != null)
            {
                Output.Add(new AzureHDInsightCluster(cluster));
            }
        }
    }
}
