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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerRoutingRule", SupportsShouldProcess = true, DefaultParameterSetName = CreateByNameParameterSet), OutputType(typeof(PSNetworkManagerRoutingRule))]
    public class NewAzNetworkManagerRoutingRuleCommand : NetworkManagerRoutingRuleBaseCmdlet
    {
        private const string CreateByNameParameterSet = "ByName";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = CreateByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager routing rule collection name.",
            ParameterSetName = CreateByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string RuleCollectionName { get; set; }

        [Alias("ConfigName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager routing configuration name.",
            ParameterSetName = CreateByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string RoutingConfigurationName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.",
            ParameterSetName = CreateByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = CreateByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The routing rule destination.",
           ParameterSetName = CreateByNameParameterSet)]
        public PSNetworkManagerRoutingRuleDestination Destination { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The routing rule next-hop.",
           ParameterSetName = CreateByNameParameterSet)]
        public PSNetworkManagerRoutingRuleNextHop NextHop { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "Description.",
             ParameterSetName = CreateByNameParameterSet)]
        public string Description { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            var present = this.IsNetworkManagerRoutingRulePresent(this.ResourceGroupName, this.NetworkManagerName, this.RoutingConfigurationName, this.RuleCollectionName, this.Name);

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var networkManagerRoutingRule = this.CreateNetworkManagerRoutingRule();
                    WriteObject(networkManagerRoutingRule);
                },
                () => present);
        }

        private PSNetworkManagerRoutingRule CreateNetworkManagerRoutingRule()
        {
            var routingRule = new PSNetworkManagerRoutingRule
            {
                Destination = this.Destination,
                NextHop = this.NextHop
            };

            if (!string.IsNullOrEmpty(this.Description))
            {
                routingRule.Description = this.Description;
            }

            // Map to the sdk object
            var routingRuleModel = NetworkResourceManagerProfile.Mapper.Map<MNM.RoutingRule>(routingRule);
            
            var routingRuleResponse = this.NetworkManagerRoutingRuleOperationClient.CreateOrUpdate(this.ResourceGroupName, this.NetworkManagerName, this.RoutingConfigurationName, this.RuleCollectionName, this.Name, routingRuleModel);

            var psRoutingRule = this.ToPSRoutingRule(routingRuleResponse);
            psRoutingRule.Name = this.Name;
            psRoutingRule.ResourceGroupName = this.ResourceGroupName;
            psRoutingRule.NetworkManagerName = this.NetworkManagerName;
            psRoutingRule.RoutingConfigurationName = this.RoutingConfigurationName;
            psRoutingRule.RuleCollectionName = this.RuleCollectionName;

            return psRoutingRule;
        }
    }
}
