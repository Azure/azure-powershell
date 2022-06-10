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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityAdminRule", SupportsShouldProcess = true, DefaultParameterSetName = "Custom"), OutputType(typeof(PSNetworkManagerSecurityBaseAdminRule))]
    public class NewAzNetworkManagerSecurityAdminRuleCommand : NetworkManagerSecurityAdminRuleBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager security admin rule collection name.")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string RuleCollectionName { get; set; }

        [Alias("ConfigName")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager security admin configuration name.")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string SecurityAdminConfigurationName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager name.")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "Description.",
             ParameterSetName = "Custom")]
        public virtual string Description { get; set; }

        [Parameter(
             Mandatory = true,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "Default Flag Type.",
             ParameterSetName = "Default")]
        public virtual string Flag { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Protocol of Rule.",
            ParameterSetName = "Custom")]
        public string Protocol { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Direction of Rule.",
            ParameterSetName = "Custom")]
        public string Direction { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Access of Rule.",
            ParameterSetName = "Custom")]
        public string Access { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Source Address Prefixes.",
           ParameterSetName = "Custom")]
        public List<PSNetworkManagerAddressPrefixItem> Source { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Destination Address Prefixes.",
           ParameterSetName = "Custom")]
        public List<PSNetworkManagerAddressPrefixItem> Destination { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Source Port Ranges.",
           ParameterSetName = "Custom")]
        public List<string> SourcePortRange { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Destination Port Ranges.",
           ParameterSetName = "Custom")]
        public List<string> DestinationPortRange { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Priority of Rule.",
            ParameterSetName = "Custom")]
        public int Priority { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            var present = this.IsNetworkManagerSecurityAdminRulePresent(this.ResourceGroupName, this.NetworkManagerName, this.SecurityAdminConfigurationName, this.RuleCollectionName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var networkManagerSecurityAdminRule = this.CreateNetworkManagerSecurityAdminRule();
                    WriteObject(networkManagerSecurityAdminRule);
                },
                () => present);
        }

        private PSNetworkManagerSecurityBaseAdminRule CreateNetworkManagerSecurityAdminRule()
        {
            if (!string.IsNullOrEmpty(this.Flag))
            {
                var securityDefaultAdminRule = new PSNetworkManagerSecurityDefaultAdminRule();
                securityDefaultAdminRule.Flag = this.Flag;
                var securityDefaultAdminRuleModel = NetworkResourceManagerProfile.Mapper.Map<MNM.DefaultAdminRule>(securityDefaultAdminRule);
                this.NullifySecurityAdminRuleIfAbsent(securityDefaultAdminRuleModel);
                var adminRuleResponse = this.NetworkManagerSecurityAdminRuleOperationClient.CreateOrUpdate(securityDefaultAdminRuleModel, this.ResourceGroupName, this.NetworkManagerName, this.SecurityAdminConfigurationName, this.RuleCollectionName, this.Name);
                var psDefaultAdminRule = this.ToPSSecurityAdminRule(adminRuleResponse);
                return psDefaultAdminRule;
            }
            else
            {
                var securityAdminRule = new PSNetworkManagerSecurityAdminRule();

                securityAdminRule.Protocol = this.Protocol;
                securityAdminRule.Access = this.Access;
                securityAdminRule.Direction = this.Direction;
                securityAdminRule.Priority = this.Priority;
                if (this.SourcePortRange != null)
                {
                    securityAdminRule.SourcePortRanges = this.SourcePortRange;
                }
                if (this.DestinationPortRange != null)
                {
                    securityAdminRule.DestinationPortRanges = this.DestinationPortRange;
                }
                if (this.Source != null)
                {
                    securityAdminRule.Sources = this.Source;
                }
                if (this.Destination != null)
                {
                    securityAdminRule.Destinations = this.Destination;
                }
                if (!string.IsNullOrEmpty(this.Description))
                {
                    securityAdminRule.Description = this.Description;
                }
                // Map to the sdk object
                var adminRuleModel = NetworkResourceManagerProfile.Mapper.Map<MNM.AdminRule>(securityAdminRule);
                var adminRuleResponse = this.NetworkManagerSecurityAdminRuleOperationClient.CreateOrUpdate(adminRuleModel, this.ResourceGroupName, this.NetworkManagerName, this.SecurityAdminConfigurationName, this.RuleCollectionName, this.Name);
                var psAdminRule = this.ToPSSecurityAdminRule(adminRuleResponse);
                return psAdminRule;
            }
        }
    }
}
