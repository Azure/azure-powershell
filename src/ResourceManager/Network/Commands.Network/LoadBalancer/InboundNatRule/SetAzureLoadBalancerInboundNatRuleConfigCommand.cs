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
    [Cmdlet(VerbsCommon.Set, "AzureRmLoadBalancerInboundNatRuleConfig"), OutputType(typeof(PSLoadBalancer))]
    public class SetAzureLoadBalancerInboundNatRuleConfigCommand : AzureLoadBalancerInboundNatRuleConfigBase
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

        public override void Execute()
        {

            base.Execute();
            var inboundNatRule = this.LoadBalancer.InboundNatRules.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (inboundNatRule == null)
            {
                throw new ArgumentException("InboundNatRule with the specified name does not exist");
            }

            inboundNatRule.Name = this.Name;
            inboundNatRule.Protocol = this.Protocol;
            inboundNatRule.FrontendPort = this.FrontendPort;
            inboundNatRule.BackendPort = this.BackendPort;
            if (this.IdleTimeoutInMinutes > 0)
            {
                inboundNatRule.IdleTimeoutInMinutes = this.IdleTimeoutInMinutes;
            }
            inboundNatRule.EnableFloatingIP = this.EnableFloatingIP.IsPresent;

            inboundNatRule.FrontendIPConfiguration = null;
            if (!string.IsNullOrEmpty(this.FrontendIpConfigurationId))
            {
                inboundNatRule.FrontendIPConfiguration = new PSResourceId() { Id = this.FrontendIpConfigurationId };
            }

            WriteObject(this.LoadBalancer);
        }
    }
}
