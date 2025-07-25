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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Add, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "LoadBalancerOutboundRuleConfig", DefaultParameterSetName = "SetByResource", SupportsShouldProcess = true), OutputType(typeof(PSLoadBalancer))]
    public partial class AddAzureRmLoadBalancerOutboundRuleConfigCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The reference of the load balancer resource.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public PSLoadBalancer LoadBalancer { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of the outbound rule.")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The number of outbound ports to be used for NAT.",
            ValueFromPipelineByPropertyName = true)]
        public int AllocatedOutboundPort { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Protocol - TCP, UDP or All",
            ValueFromPipelineByPropertyName = true)]
        [PSArgumentCompleter(
            "Tcp",
            "Udp",
            "All"
        )]
        public string Protocol { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP.")]
        public SwitchParameter EnableTcpReset { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The timeout for the TCP idle connection",
            ValueFromPipelineByPropertyName = true)]
        public int IdleTimeoutInMinutes { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The Frontend IP addresses of the load balancer.",
            ValueFromPipelineByPropertyName = true)]
        public PSResourceId[] FrontendIpConfiguration { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "A reference to a pool of DIPs. Outbound traffic is randomly load balanced across IPs in the backend IPs.",
            ValueFromPipelineByPropertyName = true)]
        public string BackendAddressPoolId { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "A reference to a pool of DIPs. Outbound traffic is randomly load balanced across IPs in the backend IPs.",
            ValueFromPipelineByPropertyName = true)]
        public PSBackendAddressPool BackendAddressPool { get; set; }


        public override void Execute()
        {

            var existingOutboundRule = this.LoadBalancer.OutboundRules.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));
            if (existingOutboundRule != null)
            {
                throw new ArgumentException("OutboundRule with the specified name already exists");
            }

            // OutboundRules
            if (this.LoadBalancer.OutboundRules == null)
            {
                this.LoadBalancer.OutboundRules = new List<PSOutboundRule>();
            }

            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                if (this.BackendAddressPool != null)
                {
                    this.BackendAddressPoolId = this.BackendAddressPool.Id;
                }
            }

            var vOutboundRules = new PSOutboundRule();

            vOutboundRules.AllocatedOutboundPorts = this.AllocatedOutboundPort;
            vOutboundRules.Protocol = this.Protocol;
            vOutboundRules.EnableTcpReset = this.EnableTcpReset;
            vOutboundRules.IdleTimeoutInMinutes = this.MyInvocation.BoundParameters.ContainsKey("IdleTimeoutInMinutes") ? this.IdleTimeoutInMinutes : 4;
            vOutboundRules.Name = this.Name;
            if(this.FrontendIpConfiguration?.ToList() != null && this.FrontendIpConfiguration?.ToList().Count > 0)
            {
                vOutboundRules.FrontendIpConfigurations = new List<PSResourceId>();
                foreach (var resource in this.FrontendIpConfiguration?.ToList())
                {
                    vOutboundRules.FrontendIpConfigurations.Add(
                        new PSResourceId()
                        {
                            Id = resource.Id
                        });
                }
            }
            if(!string.IsNullOrEmpty(this.BackendAddressPoolId))
            {
                // BackendAddressPool
                if (vOutboundRules.BackendAddressPool == null)
                {
                    vOutboundRules.BackendAddressPool = new PSResourceId();
                }
                vOutboundRules.BackendAddressPool.Id = this.BackendAddressPoolId;
            }
            var generatedId = string.Format(
                "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/loadBalancers/{2}/{3}/{4}",
                this.NetworkClient.NetworkManagementClient.SubscriptionId,
                this.LoadBalancer.ResourceGroupName,
                this.LoadBalancer.Name,
                "OutboundRules",
                this.Name);
            vOutboundRules.Id = generatedId;

            this.LoadBalancer.OutboundRules.Add(vOutboundRules);
            WriteObject(this.LoadBalancer, true);
        }
    }
}
