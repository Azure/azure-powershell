
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
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualApplianceInboundSecurityRule",
        SupportsShouldProcess = true,
        DefaultParameterSetName = ResourceNameParameterSet),
        OutputType(typeof(PSInboundSecurityRule))]
    public class UpdateVirtualApplianceInboundSecurityRuleCommand : VirtualApplianceInboundSecurityRuleBaseCmdlet
    {
        private const string ResourceNameParameterSet = "ResourceNameParameterSet";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";
        private const string ResourceObjectParameterSet = "ResourceObjectParameterSet";

        [Parameter(
            Mandatory = true,
            ParameterSetName = ResourceNameParameterSet,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ParentNvaName", "NetworkVirtualApplianceName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ResourceNameParameterSet,
            HelpMessage = "The parent Network Virtual Appliance name.")]
        [ResourceNameCompleter("Microsoft.Network/networkVirtualAppliances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VirtualApplianceName { get; set; }

        [Alias("ParentNva", "NetworkVirtualAppliance")]
        [Parameter(
           Mandatory = true,
           ValueFromPipeline = true,
           ParameterSetName = ResourceObjectParameterSet,
           HelpMessage = "The parent Network Virtual Appliance object for this connection.")]
        [ValidateNotNullOrEmpty]
        public PSNetworkVirtualAppliance VirtualAppliance { get; set; }

        [Alias("ParentNvaId", "NetworkVirtualApplianceId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "The resource id of the parent Network Virtual Appliance for this connection.")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/networkVirtualAppliances")]
        public string VirtualApplianceResourceId { get; set; }

        [Alias("ResourceName", "InboundSecurityRuleCollectionName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/networkVirtualAppliances/inboundSecurityRules", "ResourceGroupName", "ParentResourceName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "The Inbound Security Rule Type: AutoExpire or Permanent")]
        public string RuleType { get; set; }

        [Parameter(
           Mandatory = true,
           HelpMessage = "Individual rules of the Inbound Security")]
        public List<PSInboundSecurityRulesProperty> Rule { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (ParameterSetName.Equals(ResourceObjectParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceGroupName = this.VirtualAppliance.ResourceGroupName;
                this.VirtualApplianceName = this.VirtualAppliance.Name;
            }
            else if (ParameterSetName.Equals(ResourceIdParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.VirtualApplianceResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.VirtualApplianceName = parsedResourceId.ResourceName;
            }

            var inboundSecurityRuleParameters = new InboundSecurityRule();

            inboundSecurityRuleParameters.RuleType = this.RuleType;
            inboundSecurityRuleParameters.Rules = new List<InboundSecurityRules>();

            foreach(var rule in this.Rule)
            {
                inboundSecurityRuleParameters.Rules.Add(NetworkResourceManagerProfile.Mapper.Map<InboundSecurityRules>(rule));
            }

            ConfirmAction(
                    Properties.Resources.CreatingResourceMessage,
                    Name,
                    () =>
                    {

                        WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                        WriteObject(this.CreateOrUpdateInboundSecurityRule(this.ResourceGroupName, this.VirtualApplianceName, this.Name, inboundSecurityRuleParameters));
                    }
                );
        }

    }
}
