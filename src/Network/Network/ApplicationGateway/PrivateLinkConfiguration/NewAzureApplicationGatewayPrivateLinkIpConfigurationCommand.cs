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
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayPrivateLinkIpConfiguration"), OutputType(typeof(PSApplicationGatewayPrivateLinkIpConfiguration))]
    public class NewAzureApplicationGatewayPrivateLinkIpConfigurationCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the IpConfiguration")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
             Mandatory = true,
             HelpMessage = "Subnet")]
        public PSSubnet Subnet { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The ip version of the ip configuration")]
        [ValidateSet(
            MNM.IPVersion.IPv4,
            IgnoreCase = true)]
        public string PrivateIpAddressVersion { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The private ip address of the ipConfiguration " +
                          "if static allocation is desired.")]
        public string PrivateIpAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Indicate the ip configuration is primary.")]
        public SwitchParameter Primary { get; set; }

        public override void Execute()
        {
            base.Execute();

            var ipconfig = new PSApplicationGatewayPrivateLinkIpConfiguration
            {
                Name = Name
            };

            if (this.Subnet != null)
            {
                ipconfig.Subnet = new PSResourceId();
                ipconfig.Subnet.Id = this.Subnet.Id;
            }

            if (!string.IsNullOrEmpty(this.PrivateIpAddress))
            {
                ipconfig.PrivateIPAddress = this.PrivateIpAddress;
                ipconfig.PrivateIPAllocationMethod = MNM.IPAllocationMethod.Static;
            }
            else
            {
                ipconfig.PrivateIPAllocationMethod = MNM.IPAllocationMethod.Dynamic;
            }

            if (!string.IsNullOrEmpty(this.PrivateIpAddressVersion))
            {
                ipconfig.PrivateIPAddressVersion = this.PrivateIpAddressVersion;
            }
            else
            {
                ipconfig.PrivateIPAddressVersion = MNM.IPVersion.IPv4;
            }

            ipconfig.Primary = this.Primary.IsPresent;

            WriteObject(ipconfig);
        }
    }
}
