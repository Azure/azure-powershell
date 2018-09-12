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

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewayFrontendIPConfigBase : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the FrontendIPConfiguration")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The private ip address of the frontendIPConfiguration " +
                          "if static allocation is specified.")]
        [Parameter(ParameterSetName = "SetByResourceId")]
        [Parameter(ParameterSetName = "SetByResource")]
        public string PrivateIPAddress { get; set; }

        [Parameter(
            ParameterSetName = "SetByResourceId",
            HelpMessage = "SubnetId")]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        [Parameter(
            ParameterSetName = "SetByResource",
            HelpMessage = "Subnet")]
        public PSSubnet Subnet { get; set; }

        [Parameter(
            ParameterSetName = "SetByResourceId",
            HelpMessage = "PublicIPAddressId")]
        public string PublicIPAddressId { get; set; }

        [Parameter(
            ParameterSetName = "SetByResource",
            HelpMessage = "PublicIPAddress")]
        public PSPublicIpAddress PublicIPAddress { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                if (this.Subnet != null)
                {
                    this.SubnetId = this.Subnet.Id;
                }

                if (this.PublicIPAddress != null)
                {
                    this.PublicIPAddressId = this.PublicIPAddress.Id;
                }
            }
        }

        public PSApplicationGatewayFrontendIPConfiguration NewObject()
        {
            var frontendIPConfig = new PSApplicationGatewayFrontendIPConfiguration();
            frontendIPConfig.Name = this.Name;

            if (!string.IsNullOrEmpty(this.SubnetId))
            {
                frontendIPConfig.Subnet = new PSResourceId();
                frontendIPConfig.Subnet.Id = this.SubnetId;

                if (!string.IsNullOrEmpty(this.PrivateIPAddress))
                {
                    frontendIPConfig.PrivateIPAddress = this.PrivateIPAddress;
                    frontendIPConfig.PrivateIPAllocationMethod = Management.Network.Models.IPAllocationMethod.Static;
                }
                else
                {
                    frontendIPConfig.PrivateIPAllocationMethod = Management.Network.Models.IPAllocationMethod.Dynamic;
                }
            }

            if (!string.IsNullOrEmpty(this.PublicIPAddressId))
            {
                frontendIPConfig.PublicIPAddress = new PSResourceId();
                frontendIPConfig.PublicIPAddress.Id = this.PublicIPAddressId;
            }

            frontendIPConfig.Id = ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                                    this.NetworkClient.NetworkManagementClient.SubscriptionId,
                                    Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayFrontendIPConfigName,
                                    this.Name);
            return frontendIPConfig;
        }
    }
}
