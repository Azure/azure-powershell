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

namespace Microsoft.Azure.Commands.Network.VirtualNetworkGateway.VirtualNetworkGatewayNatRule
{
    using AutoMapper;
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Management.Network;
    using Microsoft.WindowsAzure.Commands.Common;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using System.Linq;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(VerbsCommon.Remove,
    ResourceManager.Common.AzureRMConstants.AzurePrefix + "VirtualNetworkGatewayNatRule",
    DefaultParameterSetName = VirtualNetworkGatewayParameterSets.ByVirtualNetworkGatewayNatRuleName,
    SupportsShouldProcess = true),
    OutputType(typeof(bool))]
    public class RemoveAzureVirtualNetworkGatewayNatRuleCommand : VirtualNetworkGatewayNatRuleBaseCmdlet
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

        [Alias("VirtualNetworkGatewayNatRuleId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.ByVirtualNetworkGatewayNatRuleResourceId,
            HelpMessage = "The resource id of the VirtualNetworkGatewayNatRule object to delete.")]
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
            HelpMessage = "Do not ask for confirmation if you want to delete a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Returns an object representing the item on which this operation is being performed.")]
        public SwitchParameter PassThru { get; set; }

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

            base.Execute();
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, Name),
                Properties.Resources.RemoveResourceMessage,
                Name,
                () =>
                {
                    this.NatRuleClient.Delete(this.ResourceGroupName, this.ParentResourceName, this.Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });

            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}
