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
    [Cmdlet(VerbsCommon.Add, "AzureRmLoadBalancerInboundNatPoolConfig"), OutputType(typeof(PSLoadBalancer))]
    public class AddAzureLoadBalancerInboundNatPoolConfigCommand : AzureLoadBalancerInboundNatPoolConfigBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Inbound NAT pool")]
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
            var existingInboundNatPool = this.LoadBalancer.InboundNatPools.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (existingInboundNatPool != null)
            {
                throw new ArgumentException("InboundNatPool with the specified name already exists");
            }

            var inboundNatPool = new PSInboundNatPool();
            inboundNatPool.Name = this.Name;
            inboundNatPool.Protocol = this.Protocol;
            inboundNatPool.FrontendPortRangeStart = this.FrontendPortRangeStart;
            inboundNatPool.FrontendPortRangeEnd = this.FrontendPortRangeEnd;
            inboundNatPool.BackendPort = this.BackendPort;

            if (!string.IsNullOrEmpty(this.FrontendIpConfigurationId))
            {
                inboundNatPool.FrontendIPConfiguration = new PSResourceId() { Id = this.FrontendIpConfigurationId };
            }

            inboundNatPool.Id =
                ChildResourceHelper.GetResourceId(
                    this.NetworkClient.NetworkManagementClient.SubscriptionId,
                    this.LoadBalancer.ResourceGroupName,
                    this.LoadBalancer.Name,
                    Microsoft.Azure.Commands.Network.Properties.Resources.LoadBalancerInboundNatPoolName,
                    this.Name);

            this.LoadBalancer.InboundNatPools.Add(inboundNatPool);

            WriteObject(this.LoadBalancer);
        }
    }
}
