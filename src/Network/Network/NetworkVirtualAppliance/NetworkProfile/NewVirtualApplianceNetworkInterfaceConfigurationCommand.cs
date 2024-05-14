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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using System.Linq;
using Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualApplianceNetworkInterfaceConfiguration",
        SupportsShouldProcess = true),
        OutputType(typeof(PSVirtualApplianceNetworkInterfaceConfiguration))]
    public class NewVirtualApplianceNetworkInterfaceConfigurationCommand : VirtualApplianceNetworkProfileBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "The type of the network interface e.g., PublicNic or PrivateNic")]
        [ValidateNotNullOrEmpty]
        public string NicType { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "The IP configurations of the network interface configuration.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualApplianceIpConfiguration[] IpConfiguration { get; set; }

        public override void ExecuteCmdlet()
        {
            var networkInterfaceConfiguration = new PSVirtualApplianceNetworkInterfaceConfiguration
            {
                NicType = this.NicType,
                Properties = new PSVirtualApplianceNetworkInterfaceConfigurationProperties
                {
                    IpConfigurations = this.IpConfiguration.ToList()
                }
            };

            WriteObject(networkInterfaceConfiguration);
        }
    }
}