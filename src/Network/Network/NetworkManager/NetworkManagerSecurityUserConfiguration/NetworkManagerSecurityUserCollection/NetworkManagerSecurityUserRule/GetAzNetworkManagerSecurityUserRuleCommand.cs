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

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerSecurityUserRule", DefaultParameterSetName = ByListParameterSet), OutputType(typeof(PSNetworkManagerSecurityUserRule))]
    public class GetAzNetworkManagerSecurityUserRuleCommand : NetworkManagerSecurityUserRuleBaseCmdlet
    {
        private const string ByListParameterSet = "ByList";
        private const string ByNameParameterSet = "ByName";
        private const string ByResourceIdParameterSet = "ByResourceId";
        private const string ByInputObjectParameterSet = "ByInputObject";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = ByNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityUserConfigurations/ruleCollections/rules", "ResourceGroupName", "NetworkManagerName", "SecurityUserConfigurationName", "RuleCollectionName")]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager securityUser rule collection name.",
           ParameterSetName = ByListParameterSet)]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager securityUser rule collection name.",
           ParameterSetName = ByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityUserConfigurations/ruleCollections", "ResourceGroupName", "NetworkManagerName", "SecurityUserConfigurationName")]
        [SupportsWildcards]
        public virtual string RuleCollectionName { get; set; }

        [Alias("ConfigName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager securityUser configuration name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ByListParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager securityUser configuration name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/securityUserConfigurations", "ResourceGroupName", "NetworkManagerName")]
        [SupportsWildcards]
        public virtual string SecurityUserConfigurationName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ByListParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.")]
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ByListParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ByResourceIdParameterSet,
            HelpMessage = "NetworkManager SecurityUserRule Id",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("SecurityUserRuleId")]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The input object containing the necessary properties.",
            ParameterSetName = ByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSNetworkManagerSecurityUserRule InputObject { get; set; }


        public override void Execute()
        {
            base.Execute();

            try
            {
                if (this.ParameterSetName == ByResourceIdParameterSet)
                {
                    ProcessByResourceId();
                }
                else if (this.ParameterSetName == ByInputObjectParameterSet)
                {
                    ProcessByInputObject();
                }
                else if (this.ParameterSetName == ByNameParameterSet)
                {
                    ProcessByName(expand: true);
                }
                else if (this.ParameterSetName == ByListParameterSet)
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
                this.SecurityUserConfigurationName = segments[3];
                this.RuleCollectionName = segments[5];

                var securityUserRule = this.GetNetworkManagerSecurityUserRule(this.ResourceGroupName, this.NetworkManagerName, this.SecurityUserConfigurationName, this.RuleCollectionName, this.Name);
                WriteObject(securityUserRule);
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
                var securityUserRule = this.GetNetworkManagerSecurityUserRule(this.ResourceGroupName, this.NetworkManagerName, this.SecurityUserConfigurationName, this.RuleCollectionName, this.Name);
                WriteObject(securityUserRule);
            }
            else
            {
                ProcessAll();
            }
        }

        private void ProcessAll()
        {
            var securityUserRulePage = this.NetworkManagerSecurityUserRuleOperationClient.List(this.ResourceGroupName, this.NetworkManagerName, this.SecurityUserConfigurationName, this.RuleCollectionName);

            // Get all resources by polling on next page link
            var securityUserRuleCollectionList = ListNextLink<SecurityUserRule>.GetAllResourcesByPollingNextLink(securityUserRulePage, this.NetworkManagerSecurityUserRuleOperationClient.ListNext);

            var pSNetworkManagerSecurityUserRules = new List<PSNetworkManagerSecurityUserRule>();
            foreach (var rule in securityUserRuleCollectionList)
            {
                var psRule = this.ToPSSecurityUserRule(rule);
                psRule.ResourceGroupName = this.ResourceGroupName;
                pSNetworkManagerSecurityUserRules.Add(psRule);
            }

            WriteObject(pSNetworkManagerSecurityUserRules);
        }

        private void ProcessByInputObject()
        {
            if (InputObject == null)
            {
                throw new PSArgumentNullException(nameof(InputObject));
            }

            // Extract properties from InputObject
            string resourceGroupName = InputObject.ResourceGroupName;
            string networkManagerName = InputObject.NetworkManagerName;
            string securityUserConfigurationName = InputObject.SecurityUserConfigurationName;
            string ruleCollectionName = InputObject.RuleCollectionName;
            string name = InputObject.Name;

            var securityUserRule = GetNetworkManagerSecurityUserRule(resourceGroupName, networkManagerName, securityUserConfigurationName, ruleCollectionName, name);

            WriteObject(securityUserRule);
        }
    }
}