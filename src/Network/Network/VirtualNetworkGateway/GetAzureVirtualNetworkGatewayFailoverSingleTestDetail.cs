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
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System.Management.Automation;
using System.Collections.Generic;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using CNM = Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network.VirtualNetworkGateway
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGatewayFailoverSingleTestDetails", DefaultParameterSetName = "ByName"), OutputType(typeof(List<PSExpressRouteFailoverSingleTestDetails>))]
    public class GetAzureVirtualNetworkGatewayFailoverSingleTestDetails : NetworkBaseCmdlet
    {
        private const string ByName = "ByName";

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the virtual network gateway.",
            ParameterSetName = ByName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the virtual network gateway.",
            ParameterSetName = ByName)]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkGatewayName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Peering location of the test.",
            ParameterSetName = ByName)]
        [ValidateNotNullOrEmpty]
        public string PeeringLocation { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The unique Guid value which identifies the test.",
            ParameterSetName = ByName)]
        [ValidateNotNullOrEmpty]
        public string FailoverTestId { get; set; }

        public override void Execute()
        {
            base.Execute();

            // Call the underlying SDK API (the method name may differ slightly depending on SDK version)
            var response = NetworkClient.NetworkManagementClient.VirtualNetworkGateways.GetFailoverSingleTestDetails(
                ResourceGroupName,
                VirtualNetworkGatewayName,
                PeeringLocation,
                FailoverTestId);

            // Map SDK model to PS model
            var psResult = NetworkResourceManagerProfile.Mapper.Map<List<PSExpressRouteFailoverSingleTestDetails>>(response);

            WriteObject(psResult, enumerateCollection: true);
        }
    }
}
