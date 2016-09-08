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
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Add, "AzureRmVirtualNetworkGatewayIpConfig", SupportsShouldProcess = true), OutputType(typeof(PSVirtualNetworkGateway))]
    public class AddAzureVirtualNetworkGatewayIpConfigCommand : AzureVirtualNetworkGatewayIpConfigBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual network gateway object to base modifications off of. This can be retrieved using Get-AzureRmVirtualNetworkGateway")]
        public PSVirtualNetworkGateway VirtualNetworkGateway { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the VirtualNetworkGatewayIpConfiguration")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        public override void Execute()
        {

            base.Execute();

            if (ShouldProcess(Name, Properties.Resources.AddingResourceMessage + Properties.Resources.VirtualNetworkGatewayIpConfigName))
            {
                // Get the subnetId and publicIpAddressId from the objects if specified
                if (string.Equals(ParameterSetName, "object"))
                {
                    if (Subnet != null)
                    {
                        this.SubnetId = this.Subnet.Id;
                    }
                    if (PublicIpAddress != null)
                    {
                        this.PublicIpAddressId = this.PublicIpAddress.Id;
                    }
                }

                var vnetGatewayIpConfig = new PSVirtualNetworkGatewayIpConfiguration();
                vnetGatewayIpConfig.Name = this.Name;

                if (!string.IsNullOrEmpty(this.SubnetId))
                {
                    vnetGatewayIpConfig.Subnet = new PSResourceId();
                    vnetGatewayIpConfig.Subnet.Id = this.SubnetId;
                }
                if (!string.IsNullOrEmpty(this.PrivateIpAddress))
                {
                    vnetGatewayIpConfig.PrivateIpAddress = this.PrivateIpAddress;
                    vnetGatewayIpConfig.PrivateIpAllocationMethod = Management.Network.Models.IPAllocationMethod.Static;
                }
                else
                {
                    vnetGatewayIpConfig.PrivateIpAllocationMethod = Management.Network.Models.IPAllocationMethod.Dynamic;
                }

                if (!string.IsNullOrEmpty(this.PublicIpAddressId))
                {
                    vnetGatewayIpConfig.PublicIpAddress = new PSResourceId();
                    vnetGatewayIpConfig.PublicIpAddress.Id = this.PublicIpAddressId;
                }

                vnetGatewayIpConfig.Id =
                    ChildResourceHelp.GetResourceNotSetId(
                        this.NetworkClient.NetworkManagementClient.SubscriptionId,
                        Properties.Resources.VirtualNetworkGatewayIpConfigName,
                        this.Name);

                if (this.VirtualNetworkGateway.IpConfigurations == null)
                {
                    this.VirtualNetworkGateway.IpConfigurations = new List<PSVirtualNetworkGatewayIpConfiguration>();
                }
                this.VirtualNetworkGateway.IpConfigurations.Add(vnetGatewayIpConfig);

                WriteObject(this.VirtualNetworkGateway);
            }
        }
    }
}
