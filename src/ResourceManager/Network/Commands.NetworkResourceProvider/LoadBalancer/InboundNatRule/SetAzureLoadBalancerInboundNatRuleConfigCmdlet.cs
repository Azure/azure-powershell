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
using Microsoft.Azure.Commands.NetworkResourceProvider.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    [Cmdlet(VerbsCommon.Set, "AzureLoadBalancerInboundNatRuleConfig"), OutputType(typeof(PSFrontendIpConfiguration))]
    public class SetAzureLoadBalancerInboundNatRuleConfigCmdlet : CommonAzureLoadBalancerInboundNatRuleConfig
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The load balancer")]
        public PSLoadBalancer LoadBalancer { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var inboundNatRule = this.LoadBalancer.Properties.InboundNatRules.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (inboundNatRule == null)
            {
                throw new ArgumentException("InboundNatRule with the specified name does not exist");
            }

            inboundNatRule.Name = this.Name;
            inboundNatRule.Properties = new PSInboundNatRuleProperties();
            inboundNatRule.Properties.Protocol = this.Protocol;
            inboundNatRule.Properties.FrontendPort = this.FrontendPort;
            inboundNatRule.Properties.BackendPort = this.BackendPort;
            if (this.IdleTimeoutInMinutes > 0)
            {
                inboundNatRule.Properties.IdleTimeoutInMinutes = this.IdleTimeoutInMinutes;
            }
            inboundNatRule.Properties.EnableFloatingIP = this.EnableFloatingIP.IsPresent;
            inboundNatRule.Properties.BackendIPConfiguration = new PSResourceId();
            inboundNatRule.Properties.BackendIPConfiguration.Id = this.BackendIpConfigurationId;
            inboundNatRule.Properties.FrontendIPConfigurations = new List<PSResourceId>();

            foreach (var frontendIPConfigurationId in this.FrontendIPConfigurationId)
            {
                var resourceId = new PSResourceId();
                resourceId.Id = frontendIPConfigurationId;
                inboundNatRule.Properties.FrontendIPConfigurations.Add(resourceId);
            }

            WriteObject(this.LoadBalancer);
        }
    }
}
