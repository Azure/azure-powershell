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

using Microsoft.Azure.Commands.Network.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewayAdvancedRoutingRuleConfigBase : NetworkBaseCmdlet
    {
        [Parameter(
                Mandatory = true,
                HelpMessage = "Name of the advanced routing rule")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
                Mandatory = true,
                HelpMessage = "The priority of the advanced routing rule. Must be unique within the containing advanced routing map")]
        [ValidateRange(1, 1000)]
        public int Priority { get; set; }

        [Parameter(
                ParameterSetName = "BackendSetByResourceId",
                HelpMessage = "ID of the application gateway AdvancedRoutingConditionSet evaluated by this rule")]
        [Parameter(
                ParameterSetName = "RedirectSetByResourceId",
                HelpMessage = "ID of the application gateway AdvancedRoutingConditionSet evaluated by this rule")]
        [ValidateNotNullOrEmpty]
        public string AdvancedRoutingConditionSetId { get; set; }

        [Parameter(
                ParameterSetName = "BackendSetByResource",
                HelpMessage = "Application gateway AdvancedRoutingConditionSet evaluated by this rule")]
        [Parameter(
                ParameterSetName = "RedirectSetByResource",
                HelpMessage = "Application gateway AdvancedRoutingConditionSet evaluated by this rule")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayAdvancedRoutingConditionSet AdvancedRoutingConditionSet { get; set; }

        [Parameter(
                ParameterSetName = "BackendSetByResourceId",
                Mandatory = true,
                HelpMessage = "ID of the application gateway BackendAddressPool")]
        [ValidateNotNullOrEmpty]
        public string BackendAddressPoolId { get; set; }

        [Parameter(
                ParameterSetName = "BackendSetByResource",
                Mandatory = true,
                HelpMessage = "Application gateway BackendAddressPool")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayBackendAddressPool BackendAddressPool { get; set; }

        [Parameter(
                ParameterSetName = "BackendSetByResourceId",
                Mandatory = true,
                HelpMessage = "ID of the application gateway BackendHttpSettings")]
        [ValidateNotNullOrEmpty]
        public string BackendHttpSettingsId { get; set; }

        [Parameter(
                ParameterSetName = "BackendSetByResource",
                Mandatory = true,
                HelpMessage = "Application gateway BackendHttpSettings")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayBackendHttpSettings BackendHttpSettings { get; set; }

        [Parameter(
                ParameterSetName = "RedirectSetByResourceId",
                Mandatory = true,
                HelpMessage = "ID of the application gateway RedirectConfiguration")]
        [ValidateNotNullOrEmpty]
        public string RedirectConfigurationId { get; set; }

        [Parameter(
                ParameterSetName = "RedirectSetByResource",
                Mandatory = true,
                HelpMessage = "Application gateway RedirectConfiguration")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayRedirectConfiguration RedirectConfiguration { get; set; }

        [Parameter(
                ParameterSetName = "BackendSetByResourceId",
                HelpMessage = "ID of the application gateway RewriteRuleSet")]
        [Parameter(
                ParameterSetName = "RedirectSetByResourceId",
                HelpMessage = "ID of the application gateway RewriteRuleSet")]
        [ValidateNotNullOrEmpty]
        public string RewriteRuleSetId { get; set; }

        [Parameter(
                ParameterSetName = "BackendSetByResource",
                HelpMessage = "Application gateway RewriteRuleSet")]
        [Parameter(
                ParameterSetName = "RedirectSetByResource",
                HelpMessage = "Application gateway RewriteRuleSet")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayRewriteRuleSet RewriteRuleSet { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ParameterSetName.EndsWith(Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                if (AdvancedRoutingConditionSet != null)
                {
                    this.AdvancedRoutingConditionSetId = this.AdvancedRoutingConditionSet.Id;
                }

                if (BackendAddressPool != null)
                {
                    this.BackendAddressPoolId = this.BackendAddressPool.Id;
                }

                if (BackendHttpSettings != null)
                {
                    this.BackendHttpSettingsId = this.BackendHttpSettings.Id;
                }

                if (RedirectConfiguration != null)
                {
                    this.RedirectConfigurationId = this.RedirectConfiguration.Id;
                }

                if (RewriteRuleSet != null)
                {
                    this.RewriteRuleSetId = this.RewriteRuleSet.Id;
                }
            }
        }

        public PSApplicationGatewayAdvancedRoutingRule NewObject()
        {
            var advancedRoutingRule = new PSApplicationGatewayAdvancedRoutingRule
            {
                Name = this.Name,
                Priority = this.Priority
            };

            if (!string.IsNullOrEmpty(this.AdvancedRoutingConditionSetId))
            {
                advancedRoutingRule.AdvancedRoutingConditionSet = new PSResourceId { Id = this.AdvancedRoutingConditionSetId };
            }

            if (!string.IsNullOrEmpty(this.BackendAddressPoolId))
            {
                advancedRoutingRule.BackendAddressPool = new PSResourceId { Id = this.BackendAddressPoolId };
            }

            if (!string.IsNullOrEmpty(this.BackendHttpSettingsId))
            {
                advancedRoutingRule.BackendHttpSettings = new PSResourceId { Id = this.BackendHttpSettingsId };
            }

            if (!string.IsNullOrEmpty(this.RedirectConfigurationId))
            {
                advancedRoutingRule.RedirectConfiguration = new PSResourceId { Id = this.RedirectConfigurationId };
            }

            if (!string.IsNullOrEmpty(this.RewriteRuleSetId))
            {
                advancedRoutingRule.RewriteRuleSet = new PSResourceId { Id = this.RewriteRuleSetId };
            }

            return advancedRoutingRule;
        }
    }
}
