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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    /// <summary>
    /// Cmdlet to set a Network Manager Routing Rule.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerRoutingRule", SupportsShouldProcess = true, DefaultParameterSetName = SetByInputObjectParameterSet), OutputType(typeof(PSNetworkManagerRoutingRule))]
    public class SetAzNetworkManagerRoutingRuleCommand : NetworkManagerRoutingRuleBaseCmdlet
    {
        private const string SetByNameParameterSet = "ByNameParameters";
        private const string SetByResourceIdParameterSet = "ByResourceId";
        private const string SetByInputObjectParameterSet = "ByInputObject";

        [Alias("ResourceName")]
        [Parameter(
           ParameterSetName = SetByNameParameterSet,
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/routingConfigurations/ruleCollections/rules", "ResourceGroupName", "NetworkManagerName", "RoutingConfigurationName", "RuleCollectionName")]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = SetByInputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The network manager routing rule.")]
        public PSNetworkManagerRoutingRule InputObject { get; set; }

        [Parameter(
            ParameterSetName = SetByResourceIdParameterSet,
            Mandatory = true,
            HelpMessage = "The network manager routing rule id.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("RoutingRuleId")]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = SetByNameParameterSet,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = SetByNameParameterSet,
            Mandatory = true,
            HelpMessage = "The network manager name.")]
        [ValidateNotNullOrEmpty]
        public string NetworkManagerName { get; set; }

        [Alias("ConfigName")]
        [Parameter(
            ParameterSetName = SetByNameParameterSet,
            Mandatory = true,
            HelpMessage = "The routing configuration name.")]
        [ValidateNotNullOrEmpty]
        public string RoutingConfigurationName { get; set; }

        [Parameter(
            ParameterSetName = SetByNameParameterSet,
            Mandatory = true,
            HelpMessage = "The rule collection name.")]
        [ValidateNotNullOrEmpty]
        public string RuleCollectionName { get; set; }

        [Parameter(
            ParameterSetName = SetByNameParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The routing rule destination address.")]
        [Parameter(
            ParameterSetName = SetByResourceIdParameterSet,
            Mandatory = true,
            HelpMessage = "The routing rule destination address.")]
        public string DestinationAddress { get; set; }

        [Parameter(
            ParameterSetName = SetByNameParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The routing rule destination type.")]
        [Parameter(
            ParameterSetName = SetByResourceIdParameterSet,
            Mandatory = true,
            HelpMessage = "The routing rule destination type.")]
        public string DestinationType { get; set; }

        [Parameter(
            ParameterSetName = SetByNameParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The routing rule next hop address.")]
        [Parameter(
            ParameterSetName = SetByResourceIdParameterSet,
            Mandatory = false,
            HelpMessage = "The routing rule next hop address.")]
        public string NextHopAddress { get; set; }

        [Parameter(
            ParameterSetName = SetByNameParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The routing rule next hop type.")]
        [Parameter(
            ParameterSetName = SetByResourceIdParameterSet,
            Mandatory = true,
            HelpMessage = "The routing rule next hop type.")]
        public string NextHopType { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "Description.",
             ParameterSetName = SetByNameParameterSet)]
        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "Description.",
             ParameterSetName = SetByResourceIdParameterSet)]
        public string Description { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            if (this.ShouldProcess(this.InputObject?.Name ?? this.Name, VerbsLifecycle.Restart))
            {
                base.Execute();

                var (resourceGroupName, networkManagerName, routingConfigurationName, ruleCollectionName, ruleName) = ExtractResourceDetails();

                var routingRuleModel = MapToSdkObject();

                var routingRuleResponse = this.NetworkManagerRoutingRuleOperationClient.CreateOrUpdate(
                    resourceGroupName,
                    networkManagerName,
                    routingConfigurationName,
                    ruleCollectionName,
                    ruleName,
                    routingRuleModel);

                var psRoutingRule = this.ToPSRoutingRule(routingRuleResponse);
                WriteObject(psRoutingRule);
            }
        }

        private (string resourceGroupName, string networkManagerName, string routingConfigurationName, string ruleCollectionName, string ruleName) ExtractResourceDetails()
        {
            if (!string.IsNullOrEmpty(this.ResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);

                // Validate the format of the ResourceId
                var segments = parsedResourceId.ParentResource.Split('/');
                if (segments.Length < 6)
                {
                    throw new PSArgumentException("Invalid ResourceId format. Ensure the ResourceId is in the correct format.");
                }

                this.Name = parsedResourceId.ResourceName;
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.NetworkManagerName = segments[1];
                this.RoutingConfigurationName = segments[3];
                this.RuleCollectionName = segments[5];

                return (this.ResourceGroupName, this.NetworkManagerName, this.RoutingConfigurationName, this.RuleCollectionName, this.Name);
            }
            else if (this.InputObject != null)
            {
                return (
                    this.InputObject.ResourceGroupName,
                    this.InputObject.NetworkManagerName,
                    this.InputObject.RoutingConfigurationName,
                    this.InputObject.RuleCollectionName,
                    this.InputObject.Name
                );
            }
            else
            {
                return (
                    this.ResourceGroupName,
                    this.NetworkManagerName,
                    this.RoutingConfigurationName,
                    this.RuleCollectionName,
                    this.Name
                );
            }
        }

        private RoutingRule MapToSdkObject()
        {
            if (this.InputObject != null)
            {
                if (this.InputObject is PSNetworkManagerRoutingRule)
                {
                    return NetworkResourceManagerProfile.Mapper.Map<RoutingRule>(InputObject);
                }
                else
                {
                    throw new PSArgumentException("Invalid InputObject type. Expected type is PSNetworkManagerRoutingRule.");
                }
            }
            else
            {
                var routingRule = new RoutingRule
                {
                    Destination = new RoutingRuleRouteDestination
                    {
                        DestinationAddress = this.DestinationAddress,
                        Type = this.DestinationType
                    },
                    NextHop = new RoutingRuleNextHop
                    {
                        NextHopAddress = this.NextHopAddress,
                        NextHopType = this.NextHopType
                    }
                };

                if (!string.IsNullOrEmpty(this.Description))
                {
                    routingRule.Description = this.Description;
                }

                return routingRule;
            }
        }
    }
}