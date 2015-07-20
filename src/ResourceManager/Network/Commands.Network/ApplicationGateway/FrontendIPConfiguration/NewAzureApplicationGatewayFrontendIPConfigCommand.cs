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

using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureApplicationGatewayFrontendIPConfig"), OutputType(typeof(PSApplicationGatewayFrontendIPConfiguration))]
    public class NewAzureApplicationGatewayFrontendIPConfigCommand : AzureApplicationGatewayFrontendIPConfigBase
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            // Get the subnetId and publicIP AddressId from the object if specified
            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                if (Subnet != null)
                {
                    this.SubnetId = this.Subnet.Id;
                }

                if (PublicIPAddress != null)
                {
                    this.PublicIPAddressId = this.PublicIPAddress.Id;
                }
            }

            var frontendIPConfig = new PSApplicationGatewayFrontendIPConfiguration();
            frontendIPConfig.Name = this.Name;

            if (!string.IsNullOrEmpty(this.SubnetId))
            {
                frontendIPConfig.Subnet = new PSResourceId();
                frontendIPConfig.Subnet.Id = this.SubnetId;

                if (!string.IsNullOrEmpty(this.PrivateIPAddress))
                {
                    frontendIPConfig.PrivateIPAddress = this.PrivateIPAddress;
                    frontendIPConfig.PrivateIPAllocationMethod = Management.Network.Models.IpAllocationMethod.Static;
                }
                else
                {
                    frontendIPConfig.PrivateIPAllocationMethod = Management.Network.Models.IpAllocationMethod.Dynamic;
                }
            }

            if (!string.IsNullOrEmpty(this.PublicIPAddressId))
            {
                frontendIPConfig.PublicIPAddress = new PSResourceId();
                frontendIPConfig.PublicIPAddress.Id = this.PublicIPAddressId;
            }

            frontendIPConfig.Id = ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                                    this.NetworkClient.NetworkResourceProviderClient.Credentials.SubscriptionId,
                                    Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayFrontendIpConfigName,
                                    this.Name);

            WriteObject(frontendIPConfig);
        }
    }
}
