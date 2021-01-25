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

    [Cmdlet(VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VpnGatewayNatRule",
        DefaultParameterSetName = CortexParameterSetNames.ByVpnGatewayNatRuleName,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class RemoveVpnGatewayNatRuleCommand : VpnGatewayNatRuleBaseCmdlet
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

        [Alias("VpnGatewayNatRuleId")]
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
            HelpMessage = "Do not ask for confirmation if you want to delete a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Returns an object representing the item on which this operation is being performed.")]
        public SwitchParameter PassThru { get; set; }

        public override void Execute()
        {
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnGatewayNatRuleName, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceGroupName = this.ResourceGroupName;
                this.ParentResourceName = this.ParentResourceName;
                this.Name = this.Name;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnGatewayNatRuleObject, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceId = this.InputObject.Id;

                //// At this point, the resource id should not be null. If it is, customer did not specify a valid resource to delete.
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

            if (parentGateway.NatRules.Any())
            {
                var vpnGatewayNatRuleToRemove = parentGateway.NatRules.FirstOrDefault(natRule => natRule.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase));
                if (vpnGatewayNatRuleToRemove != null)
                {
                    base.Execute();

                    ConfirmAction(
                        Force.IsPresent,
                        string.Format(Properties.Resources.RemovingResource, this.Name),
                        Properties.Resources.RemoveResourceMessage,
                        this.Name,
                        () =>
                        {
                            parentGateway.NatRules.Remove(vpnGatewayNatRuleToRemove);
                            this.CreateOrUpdateVpnGateway(this.ResourceGroupName, this.ParentResourceName, parentGateway, parentGateway.Tag);
                        });
                }
            }

            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}
