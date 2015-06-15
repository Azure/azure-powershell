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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Add, "AzureApplicationGatewayFrontendIpConfig"), OutputType(typeof(PSApplicationGateway))]
    public class AddAzureApplicationGatewayFrontendIpConfigCommand : AzureApplicationGatewayFrontendIpConfigBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The application gateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }
        
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var existingFrontendIpConfig = this.ApplicationGateway.FrontendIpConfigurations.SingleOrDefault
                (resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (existingFrontendIpConfig != null)
            {
                throw new ArgumentException("FrontendIpConfiguration with the specified name already exists");
            }


            // Get the subnetId and publicIpAddressId from the object if specified
            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                this.SubnetId = this.Subnet.Id;

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

            frontendIpConfig.Id =
                ChildResourceHelper.GetResourceId(
                    this.NetworkClient.NetworkResourceProviderClient.Credentials.SubscriptionId,
                    this.ApplicationGateway.ResourceGroupName,
                    this.ApplicationGateway.Name,
                    Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayFrontendIpConfigName, 
                    this.Name);

            this.ApplicationGateway.FrontendIpConfigurations.Add(frontendIpConfig);

            WriteObject(this.ApplicationGateway);

        }
    }
}
