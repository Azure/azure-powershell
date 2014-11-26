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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.NetworkResourceProvider.Models;
using Microsoft.Azure.Commands.NetworkResourceProvider.Properties;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    [Cmdlet(VerbsCommon.New, "AzureLoadBalancerRuleConfigCmdlet")]
    public class NewAzureLoadBalancerRuleConfigCmdlet : NetworkBaseClient
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
            HelpMessage = "ID of the BackendAddressPool")]
        [ValidateNotNullOrEmpty]
        public string BackendAddressPoolId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "ID of the Probe")]
        [ValidateNotNullOrEmpty]
        public string ProbeId { get; set; }

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
        public SwitchParameter EnableFloatingIP { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var loadBalancingRule = new PSLoadBalancingRule();
            loadBalancingRule.Name = this.Name;
            loadBalancingRule.Properties = new PSLoadBalancingRuleProperties();
            loadBalancingRule.Properties.Protocol = this.Protocol;
            loadBalancingRule.Properties.FrontendPort = this.FrontendPort;
            loadBalancingRule.Properties.BackendPort = this.BackendPort;
            loadBalancingRule.Properties.IdleTimeoutInMinutes = this.IdleTimeoutInSeconds;
            loadBalancingRule.Properties.EnableFloatingIP = this.EnableFloatingIP.IsPresent;
            loadBalancingRule.Properties.BackendAddressPool = new PSResourceId();
            loadBalancingRule.Properties.BackendAddressPool.Id = this.BackendAddressPoolId;
            loadBalancingRule.Properties.Probe = new PSResourceId();
            loadBalancingRule.Properties.Probe.Id = this.ProbeId;

            loadBalancingRule.Properties.FrontendIPConfigurations = new List<PSResourceId>();

            foreach (var frontendIPConfigurationId in this.FrontendIPConfigurationId)
            {
                var resourceId = new PSResourceId();
                resourceId.Id = frontendIPConfigurationId;
                loadBalancingRule.Properties.FrontendIPConfigurations.Add(resourceId);
            }

            loadBalancingRule.Id =
                ChildResourceHelper.GetResourceNotSetId(
                    this.NetworkClient.NetworkResourceProviderClient.Credentials.SubscriptionId,
                    Resources.LoadBalancerRuleName,
                    this.Name);

            WriteObject(loadBalancingRule);
        }
    }
}
