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

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Set, CmdletNoun.AzureRmServiceFabricUpgradeType), OutputType(typeof(PsCluster))]
    public class SetAzureRmServiceFabricUpgradeType : ServiceFabricClusterCmdlet
    {
        private const string AutomaticSet = "Automatic";
        private const string ManualSet = "Manual";

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = AutomaticSet,
                   HelpMessage = "ClusterUpgradeMode")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ManualSet,
                   HelpMessage = "Cluster upgrade mode, e.g. Automatic or Manual")]
        [ValidateNotNullOrEmpty()]
        public ClusterUpgradeMode UpgradeMode { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ManualSet,
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
            var cluster = SendPatchRequest(patchRequest, true);
            WriteObject(cluster, true);
        }
    }
}