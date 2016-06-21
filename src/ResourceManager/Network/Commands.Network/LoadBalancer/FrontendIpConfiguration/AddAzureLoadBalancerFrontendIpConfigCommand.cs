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
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Add, "AzureRmLoadBalancerFrontendIpConfig"), OutputType(typeof(PSLoadBalancer))]
    public class AddAzureLoadBalancerFrontendIpConfigCommand : AzureLoadBalancerFrontendIpConfigBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the FrontendIpConfiguration")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The load balancer")]
        public PSLoadBalancer LoadBalancer { get; set; }

        public override void Execute()
        {
            base.Execute();

            var existingFrontendIpConfig = this.LoadBalancer.FrontendIpConfigurations.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (existingFrontendIpConfig != null)
            {
                throw new ArgumentException("FrontendIpConfiguration with the specified name already exists");
            }

            var frontendIpConfig = new PSFrontendIPConfiguration();
            frontendIpConfig.Name = this.Name;

            if (!string.IsNullOrEmpty(this.SubnetId))
            {
                frontendIpConfig.Subnet = new PSSubnet();
                frontendIpConfig.Subnet.Id = this.SubnetId;

                if (!string.IsNullOrEmpty(this.PrivateIpAddress))
                {
                    frontendIpConfig.PrivateIpAddress = this.PrivateIpAddress;
                    frontendIpConfig.PrivateIpAllocationMethod = Management.Network.Models.IPAllocationMethod.Static;
                }
                else
                {
                    frontendIpConfig.PrivateIpAllocationMethod = Management.Network.Models.IPAllocationMethod.Dynamic;
                }
            }

            if (!string.IsNullOrEmpty(this.PublicIpAddressId))
            {
                frontendIpConfig.PublicIpAddress = new PSPublicIpAddress();
                frontendIpConfig.PublicIpAddress.Id = this.PublicIpAddressId;
            }

            frontendIpConfig.Id =
                ChildResourceHelper.GetResourceId(
                    this.NetworkClient.NetworkManagementClient.SubscriptionId,
                    this.LoadBalancer.ResourceGroupName,
                    this.LoadBalancer.Name,
                    Microsoft.Azure.Commands.Network.Properties.Resources.LoadBalancerFrontendIpConfigName,
                    this.Name);

            this.LoadBalancer.FrontendIpConfigurations.Add(frontendIpConfig);

            WriteObject(this.LoadBalancer);

        }
    }
}
