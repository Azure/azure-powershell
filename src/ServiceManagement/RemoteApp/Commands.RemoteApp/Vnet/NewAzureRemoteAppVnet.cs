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

using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "AzureRemoteAppVNet"), OutputType(typeof(TrackingResult))]
    public class NewAzureRemoteAppVNet : VNetDeprecated
    {
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "RemoteApp virtual network name.")]
        [ValidatePattern(VNetNameValidatorString)]
        public string VNetName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Virtual network address space. Must be in private IP address range and cannot overlap the Local network address space.")]
        [ValidatePattern(IPv4CIDR)]
        public string[] VirtualNetworkAddressSpace { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Local network address space. Cannot overlap the virtual network address space.")]
        [ValidatePattern(IPv4CIDR)]
        public string[] LocalNetworkAddressSpace { get; set; }

        [Parameter(Mandatory = true,
             ValueFromPipeline = true,
            HelpMessage = "DNS Server IP addresses. These must be IPv4 addresses")]
        [ValidatePattern(IPv4ValidatorString)]
        public string[] DnsServerIpAddress { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Address of the VPN device. Must be a public-facing address in the private IP address range.)")]
        [ValidatePattern(IPv4ValidatorString)]
        public string VpnDeviceIpAddress { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Virtual network location.")]
        public string Location { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Virtual network gateway type")]
        public GatewayType GatewayType { get; set; }

        public override void ExecuteCmdlet()
        {
            VNetParameter payload = null;
            OperationResultWithTrackingId response = null;

            payload = new VNetParameter()
            {
                Region = Location,
                VnetAddressSpaces = new List<string>(VirtualNetworkAddressSpace),
                LocalAddressSpaces = new List<string>(LocalNetworkAddressSpace),
                DnsServers = new List<string>(DnsServerIpAddress),
                VpnAddress = VpnDeviceIpAddress,
                GatewayType = GatewayType
            };

            RegisterSubscriptionWithRdfeForRemoteApp();

            response = CallClient(() => Client.VNet.CreateOrUpdate(VNetName, payload), Client.VNet);
            if (response != null)
            {
                WriteTrackingId(response);
            }
        }
    }
}
