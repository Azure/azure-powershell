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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Network.Models.NetworkManager;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityUserRule", SupportsShouldProcess = true, DefaultParameterSetName = ByName), OutputType(typeof(PSNetworkManagerSecurityUserRule))]
    public class NewAzNetworkManagerSecurityUserRuleCommand : NetworkManagerSecurityUserRuleBaseCmdlet
    {
        private const string ByName = "ByName";
        private const string ByInputObject = "ByInputObject";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = ByName)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager security user rule collection name.",
            ParameterSetName = ByName)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string RuleCollectionName { get; set; }

        [Alias("ConfigName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager security user configuration name.",
            ParameterSetName = ByName)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string SecurityUserConfigurationName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.",
            ParameterSetName = ByName)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = ByName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "Description.",
             ParameterSetName = ByName)]
        public virtual string Description { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
            HelpMessage = "Protocol of Rule. Valid values include 'Tcp', 'Udp', 'Icmp', 'Esp', 'Any', and 'Ah'.",
            ParameterSetName = ByName)]
        [ValidateSet("Tcp", "Udp", "Icmp", "Esp", "Any", "Ah", IgnoreCase = true)]
        public string Protocol { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
            HelpMessage = "Direction of Rule. Valid values include 'Inbound' and 'Outbound'.",
            ParameterSetName = ByName)]
        [ValidateSet("Inbound", "Outbound", IgnoreCase = true)]
        public string Direction { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Source Address Prefixes.",
           ParameterSetName = ByName)]
        public PSNetworkManagerAddressPrefixItem[] SourceAddressPrefix { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Destination Address Prefixes.",
           ParameterSetName = ByName)]
        public PSNetworkManagerAddressPrefixItem[] DestinationAddressPrefix { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Source Port Ranges.",
           ParameterSetName = ByName)]
        public string[] SourcePortRange { get; set; }

        [Parameter(
            Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Destination Port Ranges.",
           ParameterSetName = ByName)]
        public string[] DestinationPortRange { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The input object representing the routing rule.",
            ParameterSetName = ByInputObject)]
        public PSNetworkManagerSecurityUserRule InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.ParameterSetName == ByInputObject)
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.NetworkManagerName = this.InputObject.NetworkManagerName;
                this.SecurityUserConfigurationName = this.InputObject.SecurityUserConfigurationName;
                this.RuleCollectionName = this.InputObject.RuleCollectionName;
                this.Name = this.InputObject.Name;
            }

            var present = this.IsNetworkManagerSecurityUserRulePresent(this.ResourceGroupName, this.NetworkManagerName, this.SecurityUserConfigurationName, this.RuleCollectionName, this.Name);

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var networkManagerSecurityUserRule = this.CreateNetworkManagerSecurityUserRule();
                    WriteObject(networkManagerSecurityUserRule);
                },
                () => present);
        }

        private PSNetworkManagerSecurityUserRule CreateNetworkManagerSecurityUserRule()
        {
            PSNetworkManagerSecurityUserRule securityUserRule;

            if (this.ParameterSetName == ByInputObject)
            {
                securityUserRule = this.InputObject;
            }
            else
            {
                securityUserRule = new PSNetworkManagerSecurityUserRule
                {
                    Protocol = this.Protocol,
                    Direction = this.Direction
                };

                if (this.SourcePortRange != null)
                {
                    securityUserRule.SourcePortRanges = this.SourcePortRange.ToList();
                }

                if (this.DestinationPortRange != null)
                {
                    securityUserRule.DestinationPortRanges = this.DestinationPortRange.ToList();
                }

                if (this.SourceAddressPrefix != null)
                {
                    securityUserRule.Sources = this.SourceAddressPrefix.ToList();
                }

                if (this.DestinationAddressPrefix != null)
                {
                    securityUserRule.Destinations = this.DestinationAddressPrefix.ToList();
                }

                if (!string.IsNullOrEmpty(this.Description))
                {
                    securityUserRule.Description = this.Description;
                }
            }

            // Map to the sdk object
            var userRuleModel = NetworkResourceManagerProfile.Mapper.Map<MNM.SecurityUserRule>(securityUserRule);
            var userRuleResponse = this.NetworkManagerSecurityUserRuleOperationClient.CreateOrUpdate(this.ResourceGroupName, this.NetworkManagerName, this.SecurityUserConfigurationName, this.RuleCollectionName, this.Name, userRuleModel);

            var psUserRule = this.ToPSSecurityUserRule(userRuleResponse);
            psUserRule.Name = this.Name;
            psUserRule.ResourceGroupName = this.ResourceGroupName;
            psUserRule.NetworkManagerName = this.NetworkManagerName;
            psUserRule.SecurityUserConfigurationName = this.SecurityUserConfigurationName;
            psUserRule.RuleCollectionName = this.RuleCollectionName;
            return psUserRule;
        }
    }
}
