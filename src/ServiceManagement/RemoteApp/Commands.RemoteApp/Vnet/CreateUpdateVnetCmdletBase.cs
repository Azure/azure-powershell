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

using Microsoft.Azure.Management.RemoteApp;
using Microsoft.Azure.Management.RemoteApp.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Management.RemoteApp.Cmdlets
{
    public class CreateUpdateVnetCmdletBase : RdsCmdlet
    {
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "RemoteApp virtual network name.")]
        [ValidatePattern(VNetNameValidatorString)]

        public string VnetName { get; set; }

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
            HelpMessage = "Address of the VPN device. Must be a public facing address in the private IP address range.)")]
        [ValidatePattern(IPv4ValidatorString)]

        public string VpnDeviceIpAddress { get; set; }

        protected void WriteVNet(VNetParameter payload)
        {
            OperationResultWithTrackingId response = null;

            response = CallClient(() => Client.VNet.CreateOrUpdate(VnetName, payload), Client.VNet);
            if (response != null)
            {
                TrackingResult trackingId = new TrackingResult(response);
                WriteObject(trackingId);
            }
        }
    }
}
