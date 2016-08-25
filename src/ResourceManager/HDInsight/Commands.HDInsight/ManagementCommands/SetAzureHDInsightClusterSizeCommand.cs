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

using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Management.HDInsight.Models;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(
        VerbsCommon.Set,
        Constants.CommandNames.AzureHDInsightClusterSize),
    OutputType(
        typeof(Cluster))]
    public class SetAzureHDInsightClusterSizeCommand : HDInsightCmdletBase
    {
        private ClusterResizeParameters resizeParams;
        #region Input Parameter Definitions

        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Gets or sets the name of the cluster.")]
        public string ClusterName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Gets or sets the name of the cluster.")]
        public int TargetInstanceCount
        {
            get { return resizeParams.TargetInstanceCount; }
            set { resizeParams.TargetInstanceCount = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the name of the resource group.")]
        public string ResourceGroupName { get; set; }

        #endregion

        public SetAzureHDInsightClusterSizeCommand()
        {
            resizeParams = new ClusterResizeParameters();
        }

        public override void ExecuteCmdlet()
        {
            if (ResourceGroupName == null)
            {
                ResourceGroupName = GetResourceGroupByAccountName(ClusterName);
            }

            HDInsightManagementClient.ResizeCluster(ResourceGroupName, ClusterName, resizeParams);

            var cluster = HDInsightManagementClient.GetCluster(ResourceGroupName, ClusterName);
            if (cluster != null)
            {
                WriteObject(new AzureHDInsightCluster(cluster.First()));
            }
        }
    }
}
