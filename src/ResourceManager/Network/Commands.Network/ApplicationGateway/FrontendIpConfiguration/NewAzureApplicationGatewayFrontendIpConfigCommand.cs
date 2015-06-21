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
    [Cmdlet(VerbsCommon.New, "AzureApplicationGatewayFrontendIpConfig"), OutputType(typeof(PSApplicationGatewayFrontendIpConfiguration))]
    public class NewAzureApplicationGatewayFrontendIpConfigCommand : AzureApplicationGatewayFrontendIpConfigBase
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            // Get the subnetId and publicIp AddressId from the object if specified
            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
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

            var frontendIpConfig = new PSApplicationGatewayFrontendIpConfiguration();
            frontendIpConfig.Name = this.Name;

            if (!string.IsNullOrEmpty(this.SubnetId))
            {
                frontendIpConfig.Subnet = new PSResourceId();
                frontendIpConfig.Subnet.Id = this.SubnetId;

                if (!string.IsNullOrEmpty(this.PrivateIpAddress))
                {
                    frontendIpConfig.PrivateIpAddress = this.PrivateIpAddress;
                    frontendIpConfig.PrivateIpAllocationMethod = Management.Network.Models.IpAllocationMethod.Static;
                }
                else
                {
                    frontendIpConfig.PrivateIpAllocationMethod = Management.Network.Models.IpAllocationMethod.Dynamic;
                }
            }

            if (!string.IsNullOrEmpty(this.PublicIpAddressId))
            {
                frontendIpConfig.PublicIpAddress = new PSResourceId();
                frontendIpConfig.PublicIpAddress.Id = this.PublicIpAddressId;
            }

            frontendIpConfig.Id = ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                                    this.NetworkClient.NetworkResourceProviderClient.Credentials.SubscriptionId,
                                    Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayFrontendIpConfigName,
                                    this.Name);

            WriteObject(frontendIpConfig);
        }
    }
}
