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

namespace Microsoft.Azure.Commands.Network.Cortex.VpnGateway
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

    [Cmdlet("Update",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VpnGatewayNatRule",
        DefaultParameterSetName = CortexParameterSetNames.ByVpnGatewayNatRuleName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSVpnGatewayNatRule))]
    public class UpdateAzureRmVpnGatewayNatRuleCommand : VpnGatewayNatRuleBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayNatRuleName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ParentVpnGatewayName", "VpnGatewayName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayNatRuleName,
            HelpMessage = "The parent resource name.")]
        [ResourceNameCompleter("Microsoft.Network/vpnGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ParentResourceName { get; set; }

        [Alias("ResourceName", "VpnGatewayNatRuleName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayNatRuleName,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/vpnGateways/natRules", "ResourceGroupName", "ParentResourceName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("VpnGatewayNatRuleResourceId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayNatRuleResourceId,
            HelpMessage = "The resource id of the VpnGatewayNatRule object to delete.")]
        public string ResourceId { get; set; }

        [Alias("VpnGatewayNatRule")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayNatRuleObject,
            HelpMessage = "The VpnGatewayNatRule object to update.")]
        public PSVpnGatewayNatRule InputObject { get; set; }

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
            Mandatory = false,
            HelpMessage = "The list of private IP address subnet internal mappings for NAT")]
        public string[] InternalMapping { get; set; }

        [Parameter(
            Mandatory = false,
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

            if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnGatewayNatRuleName, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceGroupName = this.ResourceGroupName;
                this.ParentResourceName = this.ParentResourceName;
                this.Name = this.Name;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnGatewayNatRuleObject, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceId = this.InputObject.Id;

                if (string.IsNullOrWhiteSpace(this.ResourceId))
                {
                    throw new PSArgumentException(Properties.Resources.VpnGatewayNatRuleNotFound);
                }

                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentResourceName = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                this.Name = parsedResourceId.ResourceName;
            }

            //// Get the vpngateway object - this will throw not found if the object is not found
            PSVpnGateway parentGateway = this.GetVpnGateway(this.ResourceGroupName, this.ParentResourceName);

            if (parentGateway == null ||
                parentGateway.NatRules == null ||
                !parentGateway.NatRules.Any(natRule => natRule.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new PSArgumentException(Properties.Resources.VpnGatewayNatRuleNotFound);
            }

            var vpnGatewayNatRuleToModify = parentGateway.NatRules.FirstOrDefault(natRule => natRule.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase));
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnGatewayNatRuleObject, StringComparison.OrdinalIgnoreCase))
            {
                vpnGatewayNatRuleToModify = this.InputObject;
            }

            if (this.IpConfigurationId != null)
            {
                vpnGatewayNatRuleToModify.IpConfigurationId = IpConfigurationId;
            }

            if (this.Mode != null)
            {
                vpnGatewayNatRuleToModify.Mode = Mode;
            }

            if (this.Type != null)
            {
                vpnGatewayNatRuleToModify.VpnGatewayNatRulePropertiesType = Type;
            }

            if (this.InternalMapping != null)
            {
                vpnGatewayNatRuleToModify.InternalMappings.Clear();

                foreach (string internalMappingSubnet in this.InternalMapping)
                {
                    var internalMapping = new PSVpnNatRuleMapping();
                    internalMapping.AddressSpace = internalMappingSubnet;
                    vpnGatewayNatRuleToModify.InternalMappings.Add(internalMapping);
                }
            }

            if (this.ExternalMapping != null)
            {
                vpnGatewayNatRuleToModify.ExternalMappings.Clear();

                foreach (string externalMappingSubnet in this.ExternalMapping)
                {
                    var externalMapping = new PSVpnNatRuleMapping();
                    externalMapping.AddressSpace = externalMappingSubnet;
                    vpnGatewayNatRuleToModify.ExternalMappings.Add(externalMapping);
                }
            }

            ConfirmAction(
                    Properties.Resources.SettingResourceMessage,
                    this.Name,
                    () =>
                    {
                        WriteVerbose(String.Format(Properties.Resources.UpdatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                        this.CreateOrUpdateVpnGateway(this.ResourceGroupName, this.ParentResourceName, parentGateway, parentGateway.Tag);

                        var createdOrUpdatedVpnGateway = this.GetVpnGateway(this.ResourceGroupName, this.ParentResourceName);
                        WriteObject(createdOrUpdatedVpnGateway.NatRules.Where(natRule => natRule.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault());
                    });
        }
    }
}
