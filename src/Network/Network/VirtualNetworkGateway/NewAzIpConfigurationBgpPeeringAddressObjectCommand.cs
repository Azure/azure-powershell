﻿// Licensed under the Apache License, Version 2.0 (the "License");
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
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network.VirtualNetworkGateway
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IpConfigurationBgpPeeringAddressObject",
       DefaultParameterSetName = "ByName", SupportsShouldProcess = true), OutputType(typeof(PSIpConfigurationBgpPeeringAddress))]

    public class NewAzIpConfigurationBgpPeeringAddressObjectCommand : VirtualNetworkGatewayBaseCmdlet
    {
        [Parameter(
           ParameterSetName = "ByName",
           Mandatory = true,
           HelpMessage = "The virtual network gateway IpConfigurationId for BgpPeeringAddresses.")]
        [ValidateNotNullOrEmpty]
        public string IpConfigurationId { get; set; }

        [Parameter(
           ParameterSetName = "ByName",
           Mandatory = true,
           HelpMessage = "The virtual network gateway CustomAddress List for BgpPeeringAddresses.")]
        [ValidateNotNullOrEmpty]
        public List<string> CustomAddress { get; set; }

        public override void Execute()
        {
            base.Execute();
            var output = new PSIpConfigurationBgpPeeringAddress();
            output.IpconfigurationId = this.IpConfigurationId;
            output.CustomBgpIpAddresses = this.CustomAddress;
            WriteObject(output);
        }
    }
}
