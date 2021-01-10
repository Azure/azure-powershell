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

namespace Microsoft.Azure.Commands.Network
{
    using AutoMapper;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Security;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using Microsoft.WindowsAzure.Commands.Common;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using System.Linq;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VpnGatewayNatRule",
        DefaultParameterSetName = CortexParameterSetNames.ByVpnGatewayName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSVpnGatewayNatRule))]
    public class NewAzureRmVpnGatewayNatRuleCommand : VpnGatewayNatRuleBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ParentVpnGatewayName", "VpnGatewayName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayName,
            HelpMessage = "The resource group name.")]
        [ResourceNameCompleter("Microsoft.Network/vpnGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ParentResourceName { get; set; }

        [Alias("ParentVpnGateway", "VpnGateway")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayObject,
            HelpMessage = "The parent VpnGateway for this NAT Rule.")]
        [ValidateNotNullOrEmpty]
        public PSVpnGateway ParentObject { get; set; }

        [Alias("ParentVpnGatewayId", "VpnGatewayId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayResourceId,
            HelpMessage = "The resource id of the parent VpnGateway for this NAT Rule.")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/vpnGateways")]
        public string ParentResourceId { get; set; }

        [Alias("ResourceName", "VpnGatewayNatRuleName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
        Mandatory = false,
        HelpMessage = "The type of NAT rule for VPN NAT")]
        [ValidateSet(
            MNM.VpnNatRuleType.Static,
            MNM.VpnNatRuleType.Dynamic,
            IgnoreCase = true)]
        public string Type { get; set; }

        [Parameter(
        Mandatory = false,
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

        private PSVpnGatewayNatRule CreateVpnGatewayNatRule()
        {
            base.Execute();
            PSVpnGateway parentVpnGateway = null;

            //// Resolve the VpnGateway
            if (ParameterSetName.Contains(CortexParameterSetNames.ByVpnGatewayObject))
            {
                this.ResourceGroupName = this.ParentObject.ResourceGroupName;
                this.ParentResourceName = this.ParentObject.Name;
            }
            else if (ParameterSetName.Contains(CortexParameterSetNames.ByVpnGatewayResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.ParentResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentResourceName = parsedResourceId.ResourceName;
            }

            if (string.IsNullOrWhiteSpace(this.ResourceGroupName) || string.IsNullOrWhiteSpace(this.ParentResourceName))
            {
                throw new PSArgumentException(Properties.Resources.VpnGatewayRequiredToCreateVpnNatRule);
            }

            if (this.IsVpnGatewayNatRulePresent(this.ResourceGroupName, this.ParentResourceName, this.Name))
            {
                throw new PSArgumentException(string.Format(Properties.Resources.ChildResourceAlreadyPresentInResourceGroup, this.Name, this.ResourceGroupName, this.ParentResourceName));
            }

            //// At this point, we should have the resource name and the resource group for the parent VpnGateway resolved.
            //// This will throw not found exception if the VpnGateway does not exist
            parentVpnGateway = this.GetVpnGateway(this.ResourceGroupName, this.ParentResourceName);
            if (parentVpnGateway == null)
            {
                throw new PSArgumentException(Properties.Resources.ParentVpnGatewayNotFound);
            }

            if (parentVpnGateway.NatRules == null)
            {
                parentVpnGateway.NatRules = new List<PSVpnGatewayNatRule>();
            }

            PSVpnGatewayNatRule vpnGatewayNatRule = new PSVpnGatewayNatRule
            {
                Name = this.Name,
                IpConfigurationId = this.IpConfigurationId,
                Mode = this.Mode,
                VpnGatewayNatRulePropertiesType = this.Type,
                InternalMappings = new List<PSVpnNatRuleMapping>(),
                ExternalMappings = new List<PSVpnNatRuleMapping>()
            };

            if (this.InternalMapping != null)
            {
                foreach (string internalMappingSubnet in this.InternalMapping)
                {
                    var internalMapping = new PSVpnNatRuleMapping();
                    internalMapping.AddressSpace = internalMappingSubnet;
                    vpnGatewayNatRule.InternalMappings.Add(internalMapping);
                }
            }

            if (this.ExternalMapping != null)
            {
                foreach (string externalMappingSubnet in this.ExternalMapping)
                {
                    var externalMapping = new PSVpnNatRuleMapping();
                    externalMapping.AddressSpace = externalMappingSubnet;
                    vpnGatewayNatRule.ExternalMappings.Add(externalMapping);
                }
            }

            parentVpnGateway.NatRules.Add(vpnGatewayNatRule);
            WriteVerbose(string.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));

            PSVpnGatewayNatRule natRuleToReturn = null;
            ConfirmAction(
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                    this.CreateOrUpdateVpnGateway(this.ResourceGroupName, this.ParentResourceName, parentVpnGateway, parentVpnGateway.Tag);

                    var createdOrUpdatedVpnGateway = this.GetVpnGateway(this.ResourceGroupName, this.ParentResourceName);
                    natRuleToReturn = createdOrUpdatedVpnGateway.NatRules.Where(natRule => natRule.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                });

            return natRuleToReturn;
        }
    }
}
