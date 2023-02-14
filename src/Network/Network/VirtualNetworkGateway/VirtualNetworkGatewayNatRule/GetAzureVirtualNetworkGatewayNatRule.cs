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
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzurePrefix + "VirtualNetworkGatewayNatRule",
        DefaultParameterSetName = VirtualNetworkGatewayParameterSets.ByVirtualNetworkGatewayName),
        OutputType(typeof(PSVirtualNetworkGatewayNatRule))]
    public class GetAzureVirtualNetworkGatewayNatRule : VirtualNetworkGatewayNatRuleBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.ByVirtualNetworkGatewayName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ParentVirtualNetworkGatewayName", "VirtualNetworkGatewayName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.ByVirtualNetworkGatewayName,
            HelpMessage = "The parent resource name.")]
        [ResourceNameCompleter("Microsoft.Network/virtualNetworkGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ParentResourceName { get; set; }

        [Alias("ParentVirtualNetworkGateway", "VirtualNetworkGateway")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.ByVirtualNetworkGatewayObject,
            HelpMessage = "The parent VirtualNetworkGateway for this VirtualNetworkGatewayNatRule.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualNetworkGateway ParentObject { get; set; }

        [Alias("ParentVirtualNetworkGatewayId", "VirtualNetworkGatewayId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.ByVirtualNetworkGatewayResourceId,
            HelpMessage = "The resource id of the parent VirtualNetworkGateway for this VirtualNetworkGatewayNatRule.")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/virtualNetworkGateways")]
        public string ParentResourceId { get; set; }

        [Alias("ResourceName", "VirtualNetworkGatewayNatRuleName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/virtualNetworkGateways/natRules", "ResourceGroupName", "ParentResourceName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (ParameterSetName.Equals(VirtualNetworkGatewayParameterSets.ByVirtualNetworkGatewayObject, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceGroupName = this.ParentObject.ResourceGroupName;
                this.ParentResourceName = this.ParentObject.Name;
            }
            else if (ParameterSetName.Equals(VirtualNetworkGatewayParameterSets.ByVirtualNetworkGatewayResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.ParentResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentResourceName = parsedResourceId.ResourceName;
            }

            if (ShouldGetByName(ResourceGroupName, Name))
            {
                WriteObject(this.GetVirtualNetworkGatewayNatRule(this.ResourceGroupName, this.ParentResourceName, this.Name));
            }
            else
            {
                WriteObject(SubResourceWildcardFilter(Name, this.ListVirtualNetworkGatewayNatRules(this.ResourceGroupName, this.ParentResourceName)), true);
            }
        }
    }
}
