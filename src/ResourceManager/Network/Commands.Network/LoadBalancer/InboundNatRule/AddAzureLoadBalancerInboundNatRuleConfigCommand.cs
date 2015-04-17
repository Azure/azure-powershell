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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Add, "AzureLoadBalancerInboundNatRuleConfig"), OutputType(typeof(PSFrontendIpConfiguration))]
    public class AddAzureLoadBalancerInboundNatRuleConfigCommand : AzureLoadBalancerInboundNatRuleConfigBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Inbound NAT rule")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The load balancer")]
        public PSLoadBalancer LoadBalancer { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var existingInboundNatRule = this.LoadBalancer.InboundNatRules.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (existingInboundNatRule != null)
            {
                throw new ArgumentException("InboundNatRule with the specified name already exists");
            }

            var inboundNatRule = new PSInboundNatRule();
            inboundNatRule.Name = this.Name;
            inboundNatRule.Protocol = this.Protocol;
            inboundNatRule.FrontendPort = this.FrontendPort;
            inboundNatRule.BackendPort = this.BackendPort;
            if (this.IdleTimeoutInMinutes > 0)
            {
                inboundNatRule.IdleTimeoutInMinutes = this.IdleTimeoutInMinutes;
            }
            inboundNatRule.EnableFloatingIP = this.EnableFloatingIP.IsPresent;
            inboundNatRule.BackendIPConfiguration = new PSResourceId();

            if (!string.IsNullOrEmpty(this.BackendIpConfigurationId))
            {
                inboundNatRule.BackendIPConfiguration.Id = this.BackendIpConfigurationId;
                inboundNatRule.FrontendIPConfigurations = new List<PSResourceId>();
            }

            foreach (var frontendIPConfigurationId in this.FrontendIPConfigurationId)
            {
                var resourceId = new PSResourceId();
                resourceId.Id = frontendIPConfigurationId;
                inboundNatRule.FrontendIPConfigurations.Add(resourceId);
            }

            inboundNatRule.Id =
                ChildResourceHelper.GetResourceId(
                    this.NetworkClient.NetworkResourceProviderClient.Credentials.SubscriptionId,
                    this.LoadBalancer.ResourceGroupName,
                    this.LoadBalancer.Name,
                    Microsoft.Azure.Commands.Network.Properties.Resources.LoadBalancerInBoundNatRuleName,
                    this.Name);

            this.LoadBalancer.InboundNatRules.Add(inboundNatRule);

            WriteObject(this.LoadBalancer);
        }
    }
}
