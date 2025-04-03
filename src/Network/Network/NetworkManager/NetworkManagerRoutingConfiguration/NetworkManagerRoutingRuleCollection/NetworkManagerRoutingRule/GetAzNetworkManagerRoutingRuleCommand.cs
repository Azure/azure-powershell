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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;
using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerRoutingRule", DefaultParameterSetName = ListParameterSet), OutputType(typeof(PSNetworkManagerRoutingRule))]
    public class GetAzNetworkManagerRoutingRuleCommand : NetworkManagerRoutingRuleBaseCmdlet
    {
        private const string ListParameterSet = "ByList";
        private const string GetByNameParameterSet = "ByName";
        private const string GetByResourceIdParameterSet = "ByResourceId";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = GetByNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/routingConfigurations/ruleCollections/rules", "ResourceGroupName", "NetworkManagerName", "RoutingConfigurationName", "RuleCollectionName")]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager routing rule collection name.",
           ParameterSetName = ListParameterSet)]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager routing rule collection name.",
           ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/routingConfigurations/ruleCollections", "ResourceGroupName", "NetworkManagerName", "RoutingConfigurationName")]
        [SupportsWildcards]
        public string RuleCollectionName { get; set; }

        [Alias("ConfigName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager routing configuration name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ListParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager routing configuration name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/routingConfigurations", "ResourceGroupName", "NetworkManagerName")]
        [SupportsWildcards]
        public string RoutingConfigurationName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ListParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.")]
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ListParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = GetByResourceIdParameterSet,
            HelpMessage = "The network manager routing rule id.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("RoutingRuleId")]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            try
            {
                if (this.ParameterSetName == GetByResourceIdParameterSet)
                {
                    ProcessByResourceId();
                }
                else if (this.ParameterSetName == GetByNameParameterSet)
                {
                    ProcessByName(expand: true);
                }
                else if (this.ParameterSetName == ListParameterSet)
                {
                    ProcessByName(expand: false);
                }
            }
            catch (Exception ex)
            {
                throw new PSInvalidOperationException($"An error occurred while executing the cmdlet: {ex.Message}", ex);
            }
        }

        private void ProcessByResourceId()
        {
            if (string.IsNullOrEmpty(this.ResourceId))
            {
                throw new PSArgumentNullException(nameof(this.ResourceId), "ResourceId cannot be null or empty.");
            }

            try
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

                var routingRule = this.GetNetworkManagerRoutingRule(this.ResourceGroupName, this.NetworkManagerName, this.RoutingConfigurationName, this.RuleCollectionName, this.Name);
                WriteObject(routingRule);
            }
            catch (Exception ex)
            {
                throw new PSArgumentException($"Failed to parse ResourceId: {ex.Message}", nameof(this.ResourceId));
            }
        }

        private void ProcessByName(bool expand)
        {
            if (expand)
            {
                var routingRule = this.GetNetworkManagerRoutingRule(this.ResourceGroupName, this.NetworkManagerName, this.RoutingConfigurationName, this.RuleCollectionName, this.Name);
                WriteObject(routingRule);
            }
            else
            {
                ProcessAll();
            }
        }

        private void ProcessAll()
        {
            var routingRulePage = this.NetworkManagerRoutingRuleOperationClient.List(this.ResourceGroupName, this.NetworkManagerName, this.RoutingConfigurationName, this.RuleCollectionName);

            // Get all resources by polling on next page link
            var routingRuleCollectionList = ListNextLink<RoutingRule>.GetAllResourcesByPollingNextLink(routingRulePage, this.NetworkManagerRoutingRuleOperationClient.ListNext);

            var pSNetworkManagerRoutingRules = new List<PSNetworkManagerRoutingRule>();
            foreach (var rule in routingRuleCollectionList)
            {
                var psRule = this.ToPSRoutingRule(rule);
                psRule.ResourceGroupName = this.ResourceGroupName;
                pSNetworkManagerRoutingRules.Add(psRule);
            }

            WriteObject(pSNetworkManagerRoutingRules);
        }
    }
}