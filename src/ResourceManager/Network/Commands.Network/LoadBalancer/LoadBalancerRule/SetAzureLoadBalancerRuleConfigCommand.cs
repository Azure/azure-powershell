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
    [Cmdlet(VerbsCommon.Set, "AzureRmLoadBalancerRuleConfig"), OutputType(typeof(PSLoadBalancer))]
    public class SetAzureLoadBalancerRuleConfigCommand : AzureLoadBalancerRuleConfigBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the load balancer rule")]
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

            var loadBalancingRule = this.LoadBalancer.LoadBalancingRules.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (loadBalancingRule == null)
            {
                throw new ArgumentException("LoadBalancingRule with the specified name does not exist");
            }

            loadBalancingRule.Name = this.Name;
            loadBalancingRule.Protocol = this.Protocol;
            loadBalancingRule.FrontendPort = this.FrontendPort;
            loadBalancingRule.BackendPort = this.BackendPort;
            if (this.IdleTimeoutInMinutes > 0)
            {
                loadBalancingRule.IdleTimeoutInMinutes = this.IdleTimeoutInMinutes;
            }

            loadBalancingRule.LoadDistribution = string.IsNullOrEmpty(this.LoadDistribution) ? "Default" : this.LoadDistribution;

            loadBalancingRule.EnableFloatingIP = this.EnableFloatingIP.IsPresent;

            loadBalancingRule.BackendAddressPool = null;
            if (!string.IsNullOrEmpty(this.BackendAddressPoolId))
            {
                loadBalancingRule.BackendAddressPool = new PSResourceId();
                loadBalancingRule.BackendAddressPool.Id = this.BackendAddressPoolId;
            }

            loadBalancingRule.Probe = null;
            if (!string.IsNullOrEmpty(this.ProbeId))
            {
                loadBalancingRule.Probe = new PSResourceId();
                loadBalancingRule.Probe.Id = this.ProbeId;
            }

            loadBalancingRule.FrontendIPConfiguration = null;
            if (!string.IsNullOrEmpty(this.FrontendIpConfigurationId))
            {
                loadBalancingRule.FrontendIPConfiguration = new PSResourceId() { Id = this.FrontendIpConfigurationId };
            }

            WriteObject(this.LoadBalancer);
        }
    }
}
