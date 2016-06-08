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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Gateway.Model;
using Microsoft.WindowsAzure.Management.Network.Models;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Gateway
{
    [Cmdlet(VerbsCommon.Resize, "AzureVirtualNetworkGateway"), OutputType(typeof(GatewayGetOperationStatusResponse))]
    public class ResizeAzureVirtualNetworkGateway : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Virtual network gateway Id.")]
        [ValidateGuid]
        [ValidateNotNullOrEmpty]
        public string GatewayId
        {
            get; set;
        }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The SKU that the existing gateway will be resized to: Default/HighPerformance/Standard")]
        [ValidateNotNullOrEmpty]
        public string GatewaySKU
        {
            get; set;
        }

        public override void ExecuteCmdlet()
        {
            WriteObject(Client.ResizeVirtualNetworkGateway(GatewayId, GatewaySKU));
        }
    }
}
