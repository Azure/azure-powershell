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
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Management.HDInsight.Models;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(
        VerbsCommon.Set,
        Constants.ManagementCommandNames.AzureHDInsightClusterSize),
    OutputType(
        typeof(ClusterGetResponse))]
    public class SetAzureHDInsightClusterSizeCommand : HDInsightCmdletBase
    {
        #region Input Parameter Definitions

        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Gets or sets the name of the resource group.")]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Gets or sets the name of the cluster.")]
        public string ClusterName { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            HelpMessage = "Gets or sets the name of the cluster.")]
        public int TargetInstanceCount { get; set; }

        [Parameter(
            Position = 4,
            HelpMessage = "Gets or sets the name of the cluster.")]
        public int MinInstanceCount { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            var resizeParams = new ClusterResizeParameters
            {
                TargetInstanceCount = this.TargetInstanceCount,
                MinInstanceCount = this.MinInstanceCount
            };
            var cluster = HDInsightManagementClient.ResizeCluster(ResourceGroupName, ClusterName, resizeParams);
        }
    }
}
