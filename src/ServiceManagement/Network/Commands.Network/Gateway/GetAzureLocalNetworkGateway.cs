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
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Gateway
{
    [Cmdlet(VerbsCommon.Get, "AzureLocalNetworkGateway"), OutputType(typeof(GetLocalNetworkGatewayContext))]
    public class GetAzureLocalNetworkGateway : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = false, HelpMessage = "Local network gateway Id.")]
        [ValidateGuid]
        [ValidateNotNullOrEmpty]
        public string GatewayId
        {
            get;
            set;
        }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(GatewayId))
            {
                WriteObject(Client.GetLocalNetworkGateway(GatewayId));
            }
            else
            {
                WriteObject(Client.ListLocalNetworkGateways());
            }
        }
    }
}