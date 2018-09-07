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

namespace Microsoft.Azure.Commands.Network
{
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;
    using System.Linq;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    
    [Cmdlet(VerbsCommon.New, "AzureRmVirtualHubRoute"),
        OutputType(typeof(PSVirtualHubRoute))]
    public class NewAzureRmVirtualHubRouteCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "List of Address Prefixes.")]
        [ValidateNotNullOrEmpty]
        public List<string> AddressPrefix { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The Next Hop IpAddress.")]
        [ValidateNotNullOrEmpty]
        public string NextHopIpAddress { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The hub virtual network connections associated with this Virtual Hub.")]
        public List<PSHubVirtualNetworkConnection> HubVnetConnection { get; set; }
        
        public override void Execute()
        {
            base.Execute();
            WriteWarning("The output object type of this cmdlet will be modified in a future release.");

            var virtualHubRoute = new PSVirtualHubRoute
            {
                AddressPrefixes = this.AddressPrefix,
                NextHopIpAddress = this.NextHopIpAddress
            };

            WriteObject(virtualHubRoute);
        }
    }
}
