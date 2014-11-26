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
using Microsoft.Azure.Commands.NetworkResourceProvider.Models;
using Microsoft.Azure.Commands.NetworkResourceProvider.Properties;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    [Cmdlet(VerbsCommon.Add, "AzureLoadBalancerFrontendIpConfig")]
    public class AddAzureLoadBalancerFrontendIpConfigCmdlet : CommonAzureLoadBalancerFrontendIpConfig
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The load balancer")]
        public PSLoadBalancer LoadBalancer { get; set; }
        
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var existingFrontendIpConfig = this.LoadBalancer.Properties.FrontendIpConfigurations.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (existingFrontendIpConfig != null)
            {
                throw new ArgumentException("FrontendIpConfiguration with the specified name already exists");
            }


            // Get the subnetId and publicIpAddressId from the object if specified
            if (string.Equals(ParameterSetName, "id"))
            {
                this.SubnetId = this.Subnet.Id;

                if (PublicIpAddress != null)
                {
                    this.PublicIpAddressId = this.PublicIpAddress.Id;
                }
            }

            var frontendIpConfig = new PSFrontendIpConfiguration();
            frontendIpConfig.Name = this.Name;
            frontendIpConfig.Properties = new PSFrontendIpConfigurationProperties();
            frontendIpConfig.Properties.PrivateIpAllocationMethod = this.AllocationMethod;
            frontendIpConfig.Properties.Subnet = new PSResourceId();
            frontendIpConfig.Properties.Subnet.Id = this.SubnetId;

            if (!string.IsNullOrEmpty(this.PublicIpAddressId))
            {
                frontendIpConfig.Properties.PublicIpAddress = new PSResourceId();
                frontendIpConfig.Properties.PublicIpAddress.Id = this.PublicIpAddressId;
            }

            frontendIpConfig.Id =
                ChildResourceHelper.GetResourceId(
                    this.NetworkClient.NetworkResourceProviderClient.Credentials.SubscriptionId,
                    this.LoadBalancer.ResourceGroupName, 
                    this.LoadBalancer.Name,
                    Resources.LoadBalancerFrontendIpConfigName, 
                    this.Name);

            this.LoadBalancer.Properties.FrontendIpConfigurations.Add(frontendIpConfig);

            WriteObject(this.LoadBalancer);

        }
    }
}
