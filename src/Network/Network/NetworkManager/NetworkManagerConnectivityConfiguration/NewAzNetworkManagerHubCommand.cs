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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Network.Models.NetworkManager;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerHub"), OutputType(typeof(PSNetworkManagerHub))]
    public class NewAzNetworkManagerHubCommand : NetworkManagerConnectivityConfigurationBaseCmdlet
    {

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Resource Id")]
        public string ResourceId { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Resource Type")]
        public string ResourceType { get; set; }

        public override void Execute()
        {
            base.Execute();
            var psNetworkManagerHub = new PSNetworkManagerHub();
            psNetworkManagerHub.ResourceId = this.ResourceId;
            psNetworkManagerHub.ResourceType = this.ResourceType;

            WriteObject(psNetworkManagerHub);
        }
    }
}
