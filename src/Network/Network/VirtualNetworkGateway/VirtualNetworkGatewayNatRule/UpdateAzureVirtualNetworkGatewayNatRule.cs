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
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network;
    using MNM = Microsoft.Azure.Management.Network.Models;

    [Cmdlet("Update",
        ResourceManager.Common.AzureRMConstants.AzurePrefix + "VirtualNetworkGatewayNatRule",
        DefaultParameterSetName = VirtualNetworkGatewayParameterSets.ByVirtualNetworkGatewayNatRuleName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSVirtualNetworkGatewayNatRule))]
    public class UpdateAzureVirtualNetworkGatewayNatRule : VirtualNetworkGatewayNatRuleBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.ByVirtualNetworkGatewayNatRuleName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ParentVirtualNetworkGatewayName", "VirtualNetworkGatewayName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.ByVirtualNetworkGatewayNatRuleName,
            HelpMessage = "The parent resource name.")]
        [ResourceNameCompleter("Microsoft.Network/virtualNetworkGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ParentResourceName { get; set; }

        [Alias("ResourceName", "VirtualNetworkGatewayNatRuleName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.ByVirtualNetworkGatewayNatRuleName,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/virtualNetworkGateways/natRules", "ResourceGroupName", "ParentResourceName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("VirtualNetworkGatewayNatRuleResourceId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.ByVirtualNetworkGatewayNatRuleResourceId,
            HelpMessage = "The resource id of the VirtualNetworkGatewayNatRule object to update.")]
        public string ResourceId { get; set; }

        [Alias("VirtualNetworkGatewayNatRule")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.ByVirtualNetworkGatewayNatRuleObject,
            HelpMessage = "The VirtualNetworkGatewayNatRule object to update.")]
        public PSVirtualNetworkGatewayNatRule InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of private IP address subnet internal mappings for NAT")]
        public string[] InternalMapping { get; set; }

        [Parameter(
            Mandatory = false,
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

            if (ParameterSetName.Equals(VirtualNetworkGatewayParameterSets.ByVirtualNetworkGatewayNatRuleObject, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceId = this.InputObject.Id;
            }

            if (!string.IsNullOrWhiteSpace(this.ResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentResourceName = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                this.Name = parsedResourceId.ResourceName;
            }

            if (string.IsNullOrWhiteSpace(this.ResourceGroupName) || string.IsNullOrWhiteSpace(this.ParentResourceName) || string.IsNullOrWhiteSpace(this.Name))
            {
                throw new PSArgumentException(Properties.Resources.VirtualNetworkGatewayNatRuleNotFound);
            }

            //// Get the virtualNetworkgateway object - this will throw not found if the object is not found
            PSVirtualNetworkGateway parentGateway = this.GetVirtualNetworkGateway(this.ResourceGroupName, this.ParentResourceName);

            if (parentGateway == null ||
                parentGateway.NatRules == null ||
                !parentGateway.NatRules.Any(natRule => natRule.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new PSArgumentException(Properties.Resources.VirtualNetworkGatewayNatRuleNotFound);
            }

            PSVirtualNetworkGatewayNatRule natRuleToUpdate = null;

            natRuleToUpdate = this.GetVirtualNetworkGatewayNatRule(this.ResourceGroupName, this.ParentResourceName, this.Name);

            if (natRuleToUpdate == null)
            {
                throw new PSArgumentException(Properties.Resources.VirtualNetworkGatewayNatRuleNotFound);
            }


            if (this.IpConfigurationId != null)
            {
                natRuleToUpdate.IpConfigurationId = IpConfigurationId;
            }

            if (this.InternalMapping != null)
            {
                natRuleToUpdate.InternalMappings.Clear();

                foreach (string internalMappingSubnet in this.InternalMapping)
                {
                    var internalMapping = new PSVpnNatRuleMapping();
                    internalMapping.AddressSpace = internalMappingSubnet;
                    natRuleToUpdate.InternalMappings.Add(internalMapping);
                }
            }

            if (this.ExternalMapping != null)
            {
                natRuleToUpdate.ExternalMappings.Clear();

                foreach (string externalMappingSubnet in this.ExternalMapping)
                {
                    var externalMapping = new PSVpnNatRuleMapping();
                    externalMapping.AddressSpace = externalMappingSubnet;
                    natRuleToUpdate.ExternalMappings.Add(externalMapping);
                }
            }

            if (this.InternalPortRange != null)
            {
                if (natRuleToUpdate.InternalMappings.Count < this.InternalPortRange.Count())
                {
                    throw new PSArgumentException(string.Format(Properties.Resources.VpnNatRuleUnmatchedPortRange, nameof(InternalPortRange), nameof(InternalMapping)));
                }

                for (int i = 0; i < this.InternalPortRange.Count(); i++)
                {
                    natRuleToUpdate.InternalMappings[i].PortRange = this.InternalPortRange[i];
                }
            }

            if (this.ExternalPortRange != null)
            {
                if (natRuleToUpdate.ExternalMappings.Count < this.ExternalPortRange.Count())
                {
                    throw new PSArgumentException(string.Format(Properties.Resources.VpnNatRuleUnmatchedPortRange, nameof(ExternalPortRange), nameof(ExternalMapping)));
                }

                for (int i = 0; i < this.ExternalPortRange.Count(); i++)
                {
                    natRuleToUpdate.ExternalMappings[i].PortRange = this.ExternalPortRange[i];
                }
            }

            ConfirmAction(
                    Properties.Resources.SettingResourceMessage,
                    this.Name,
                    () =>
                    {
                        WriteVerbose(String.Format(Properties.Resources.UpdatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                        WriteObject(this.CreateOrUpdateVirtualNetworkGatewayNatRule(this.ResourceGroupName, this.ParentResourceName, this.Name, natRuleToUpdate));
                    });
        }
    }
}
