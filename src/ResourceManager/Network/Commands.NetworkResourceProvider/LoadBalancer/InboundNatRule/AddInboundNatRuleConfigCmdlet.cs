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
    [Cmdlet(VerbsCommon.Add, "AzureLoadBalancerInboundNatRuleConfigCmdlet")]
    public class AddInboundNatRuleConfigCmdlet : NetworkBaseClient
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the Inbound NAT rule")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "IDs of the FrontendIpConfigurations")]
        [ValidateNotNullOrEmpty]
        public List<string> FrontendIPConfigurationId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "IPConfig ID of NetworkInterface")]
        [ValidateNotNullOrEmpty]
        public string BackendIpConfigurationId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The transport protocol for the external endpoint.")]
        [ValidateSet(MNM.TransportProtocol.Tcp, MNM.TransportProtocol.Udp, IgnoreCase = true)]
        public string Protocol { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The frontend port")]
        public int FrontendPort { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The frontend port")]
        public int BackendPort { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "IdleTimeoutInSeconds")]
        public int IdleTimeoutInSeconds { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "EnableFloatingIP")]
        public bool EnableFloatingIP { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The load balancer")]
        public PSLoadBalancer LoadBalancer { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var existingInboundNatRule = this.LoadBalancer.Properties.InboundNatRules.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (existingInboundNatRule != null)
            {
                throw new ArgumentException("InboundNatRule with the specified name already exists");
            }

            var inboundNatRule = new PSInboundNatRule();
            inboundNatRule.Name = this.Name;
            inboundNatRule.Properties = new PSInboundNatRuleProperties();
            inboundNatRule.Properties.Protocol = this.Protocol;
            inboundNatRule.Properties.FrontendPort = this.FrontendPort;
            inboundNatRule.Properties.BackendPort = this.BackendPort;
            inboundNatRule.Properties.IdleTimeoutInMinutes = this.IdleTimeoutInSeconds;
            inboundNatRule.Properties.EnableFloatingIP = this.EnableFloatingIP;
            inboundNatRule.Properties.BackendIPConfiguration = new PSResourceId();
            inboundNatRule.Properties.BackendIPConfiguration.Id = this.BackendIpConfigurationId;
            inboundNatRule.Properties.FrontendIPConfigurations = new List<PSResourceId>();

            foreach (var frontendIPConfigurationId in this.FrontendIPConfigurationId)
            {
                var resourceId = new PSResourceId();
                resourceId.Id = frontendIPConfigurationId;
                inboundNatRule.Properties.FrontendIPConfigurations.Add(resourceId);
            }

            this.LoadBalancer.Properties.InboundNatRules.Add(inboundNatRule);

            WriteObject(this.LoadBalancer);
        }
    }
}
