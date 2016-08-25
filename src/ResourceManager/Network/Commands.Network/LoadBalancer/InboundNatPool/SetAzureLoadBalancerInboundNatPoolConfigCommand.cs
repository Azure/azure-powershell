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
    [Cmdlet(VerbsCommon.Set, "AzureRmLoadBalancerInboundNatPoolConfig"), OutputType(typeof(PSLoadBalancer))]
    public class SetAzureLoadBalancerInboundNatPoolConfigCommand : AzureLoadBalancerInboundNatPoolConfigBase
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
            var inboundNatPool = this.LoadBalancer.InboundNatPools.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (inboundNatPool == null)
            {
                throw new ArgumentException("InboundNatPool with the specified name does not exist");
            }

            inboundNatPool.Name = this.Name;
            inboundNatPool.Protocol = this.Protocol;
            inboundNatPool.FrontendPortRangeStart = this.FrontendPortRangeStart;
            inboundNatPool.FrontendPortRangeEnd = this.FrontendPortRangeEnd;
            inboundNatPool.BackendPort = this.BackendPort;

            inboundNatPool.FrontendIPConfiguration = null;
            if (!string.IsNullOrEmpty(this.FrontendIpConfigurationId))
            {
                inboundNatPool.FrontendIPConfiguration = new PSResourceId() { Id = this.FrontendIpConfigurationId };
            }

            WriteObject(this.LoadBalancer);
        }
    }
}
