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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.HDInsight.Models;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;
using Microsoft.Azure.Commands.HDInsight.Models.Management;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet("Restart", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HDInsightHost", DefaultParameterSetName = SetByNameParameterSet, SupportsShouldProcess = true),OutputType(typeof(bool))]
    public class RestartAzureHDInsightHostCommand : HDInsightCmdletBase
    {
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByAzureHDInsightHostInfoParameterSet = "SetByAzureHDInsightHostInfoParameterSet";

        #region Input Parameter Definitions

        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = SetByNameParameterSet,
            HelpMessage = "Gets or sets the name of the resource group.")]
        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = SetByAzureHDInsightHostInfoParameterSet,
            HelpMessage = "Gets or sets the name of the resource group.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = SetByNameParameterSet,
            HelpMessage = "Gets or sets the name of the cluster.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = SetByAzureHDInsightHostInfoParameterSet,
            HelpMessage = "Gets or sets the name of the cluster.")]
        [ResourceNameCompleter("Microsoft.HDInsight/clusters", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Alias("HostName")]
        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = SetByNameParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Gets or sets the name of the host.")]
        [ValidateNotNullOrEmpty]
        public string[] Name { get; set; }

        [Alias("Host")]
        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = SetByAzureHDInsightHostInfoParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Gets or sets the name of the host.")]
        [ValidateNotNullOrEmpty]
        public AzureHDInsightHostInfo[] AzureHDInsightHostInfo { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru;

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ResourceGroupName == null)
            {
                ResourceGroupName = GetResourceGroupByAccountName(ClusterName);
            }

            switch (ParameterSetName)
            {
                case SetByAzureHDInsightHostInfoParameterSet:
                    {
                        if (this.IsParameterBound(c => c.AzureHDInsightHostInfo))
                        {
                            Name = AzureHDInsightHostInfo.Select(entry => entry.name).ToArray();
                        }
                        break;
                    }
                default:
                    break;
            }

            string hosts = string.Join(",", Name);
            if(ShouldProcess(hosts, "restart host"))
            {
                HDInsightManagementClient.RestartHosts(ResourceGroupName, ClusterName, Name);

                if (PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
