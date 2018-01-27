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
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ServiceFabric.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Set, CmdletNoun.AzureRmServiceFabricUpgradeType, SupportsShouldProcess = true), OutputType(typeof(PSCluster))]
    public class SetAzureRmServiceFabricUpgradeType : ServiceFabricClusterCmdlet
    {
        private const string AutomaticSet = "Automatic";
        private const string ManualSet = "Manual";

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = AutomaticSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ManualSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = AutomaticSet, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ManualSet, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [ValidateNotNullOrEmpty()]
        [Alias("ClusterName")]
        public override string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = AutomaticSet,
                   HelpMessage = "ClusterUpgradeMode")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ManualSet,
                   HelpMessage = "Cluster upgrade mode, e.g. Automatic or Manual")]
        [ValidateNotNullOrEmpty()]
        public ClusterUpgradeMode UpgradeMode { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ManualSet,
                   HelpMessage = "Cluster code version")]
        [ValidateNotNullOrEmpty()]
        [Alias("ClusterCodeVersion")]
        public string Version { get; set; }

        public override void ExecuteCmdlet()
        {
            var patchRequest = new ClusterUpdateParameters();

            if (UpgradeMode == ClusterUpgradeMode.Manual)
            {
                patchRequest.ClusterCodeVersion = this.Version;
            }

            patchRequest.UpgradeMode = UpgradeMode.ToString();

            if (ShouldProcess(target: this.Name, action: string.Format("Set fabric upgrade type to {0} ", this.UpgradeMode)))
            {
                var cluster = SendPatchRequest(patchRequest);
                WriteObject(cluster, true);
            }
        }
    }
}