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

namespace Microsoft.Azure.Commands.Network.VirtualNetworkGateway
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using MNM = Microsoft.Azure.Management.Network.Models;

    [Cmdlet(VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzurePrefix + "VirtualNetworkGatewayNatRule",
        DefaultParameterSetName = VirtualNetworkGatewayParameterSets.ByVirtualNetworkGatewayNatRuleName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSVirtualNetworkGatewayNatRule))]
    public class NewAzureVirtualNetworkGatewayNatRule : VirtualNetworkGatewayNatRuleBaseCmdlet
    {
        [Alias("ResourceName", "VirtualNetworkGatewayNatRuleName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.ByVirtualNetworkGatewayNatRuleName,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
        Mandatory = true,
        HelpMessage = "The type of NAT rule for VPN NAT")]
        [ValidateSet(
            MNM.VpnNatRuleType.Static,
            MNM.VpnNatRuleType.Dynamic,
            IgnoreCase = true)]
        public string Type { get; set; }

        [Parameter(
        Mandatory = true,
        HelpMessage = "The Source NAT direction of a VPN NAT")]
        [ValidateSet(
            MNM.VpnNatRuleMode.EgressSnat,
            MNM.VpnNatRuleMode.IngressSnat,
            IgnoreCase = true)]
        public string Mode { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The list of private IP address subnet internal mappings for NAT")]
        public string[] InternalMapping { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The list of private IP address subnet external mappings for NAT")]
        public string[] ExternalMapping { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of internal port range mappings for NAT subnets")]
        public string[] InternalPortRange { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of external port range mappings for NAT subnets")]
        public string[] ExternalPortRange { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The IP Configuration ID this NAT rule applies to")]
        public string IpConfigurationId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            WriteObject(this.CreateVpnGatewayNatRule());
        }

        private PSVirtualNetworkGatewayNatRule CreateVpnGatewayNatRule()
        {
            PSVirtualNetworkGatewayNatRule gatewayNatRule = new PSVirtualNetworkGatewayNatRule
            {
                Name = this.Name,
                Mode = this.Mode,
                VirtualNetworkGatewayNatRulePropertiesType = this.Type,
                InternalMappings = new List<PSVpnNatRuleMapping>(),
                ExternalMappings = new List<PSVpnNatRuleMapping>(),
                IpConfigurationId = this.IpConfigurationId,
            };

            if (this.InternalMapping != null)
            {
                foreach (string internalMappingSubnet in this.InternalMapping)
                {
                    var internalMapping = new PSVpnNatRuleMapping();
                    internalMapping.AddressSpace = internalMappingSubnet;
                    gatewayNatRule.InternalMappings.Add(internalMapping);
                }
            }

            if (this.ExternalMapping != null)
            {
                foreach (string externalMappingSubnet in this.ExternalMapping)
                {
                    var externalMapping = new PSVpnNatRuleMapping();
                    externalMapping.AddressSpace = externalMappingSubnet;
                    gatewayNatRule.ExternalMappings.Add(externalMapping);
                }
            }

            if (this.InternalPortRange != null)
            {
                if (gatewayNatRule.InternalMappings.Count < this.InternalPortRange.Count())
                {
                    throw new PSArgumentException(string.Format(Properties.Resources.VpnNatRuleUnmatchedPortRange, nameof(InternalPortRange), nameof(InternalMapping)));
                }

                for (int i = 0; i < this.InternalPortRange.Count(); i++)
                {
                    gatewayNatRule.InternalMappings[i].PortRange = this.InternalPortRange[i];
                }
            }

            if (this.ExternalPortRange != null)
            {
                if (gatewayNatRule.ExternalMappings.Count < this.ExternalPortRange.Count())
                {
                    throw new PSArgumentException(string.Format(Properties.Resources.VpnNatRuleUnmatchedPortRange, nameof(ExternalPortRange), nameof(ExternalMapping)));

                }

                for (int i = 0; i < this.ExternalPortRange.Count(); i++)
                {
                    gatewayNatRule.ExternalMappings[i].PortRange = this.ExternalPortRange[i];
                }
            }

            return gatewayNatRule;
        }
    }
}
