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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Linq;

namespace Microsoft.Azure.Commands.Network
{
    [CmdletOutputBreakingChange(typeof(PSPrivateLinkServiceIpConfiguration),
        DeprecatedOutputProperties = new string[] { "PublicIPAddress" },
        NewOutputProperties = new string[] { "Primary" })]
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateLinkServiceIpConfig"), OutputType(typeof(PSPrivateLinkServiceIpConfiguration))]
    public class NewAzurePrivateLinkServiceIpConfiguration : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the IpConfiguration")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The ip version of the ip configuration")]
        [ValidateSet(
            MNM.IPVersion.IPv4,
            MNM.IPVersion.IPv6,
            IgnoreCase = true)] 
        [ValidateNotNullOrEmpty]
        public string PrivateIpAddressVersion { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The private ip address of the ipConfiguration " +
                          "if static allocation is specified.")]
        public string PrivateIpAddress { get; set; }

        [CmdletParameterBreakingChange("PublicIpAddress", ChangeDescription = "Parameter is being deprecated without being replaced")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "PublicIpAddress")]
        public PSPublicIpAddress PublicIpAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Subnet")]
        public PSSubnet Subnet { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Indicate the ip configuration is primary.")]
        public SwitchParameter Primary { get; set; }


        public override void Execute()
        {
            base.Execute();

            var ipconfig = new PSPrivateLinkServiceIpConfiguration
            {
                Name = Name
            };

            if(this.Subnet != null)
            {
                ipconfig.Subnet = this.Subnet;
            }
            
            if (!string.IsNullOrEmpty(this.PrivateIpAddress))
            {
                ipconfig.PrivateIPAddress = this.PrivateIpAddress;
                ipconfig.PrivateIPAllocationMethod = Management.Network.Models.IPAllocationMethod.Static;
            }
            else
            {
                ipconfig.PrivateIPAllocationMethod = Management.Network.Models.IPAllocationMethod.Dynamic;
            }

            if (!string.IsNullOrEmpty(this.PrivateIpAddressVersion))
            {
                ipconfig.PrivateIPAddressVersion = this.PrivateIpAddressVersion;
            }

            ipconfig.Primary = this.Primary.IsPresent;

            WriteObject(ipconfig);
        }
    }
}
