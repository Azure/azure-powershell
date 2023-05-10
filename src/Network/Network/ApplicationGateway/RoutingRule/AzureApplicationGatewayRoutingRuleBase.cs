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
    public class AzureApplicationGatewayRoutingRuleBase : NetworkBaseCmdlet
    {
        [Parameter(
                Mandatory = true,
                HelpMessage = "The name of the Routing Rule")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
                Mandatory = true,
                HelpMessage = "The type of rule")]
        [ValidateSet("Basic", "PathBasedRouting", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string RuleType { get; set; }

        [Parameter(
                Mandatory = true,
                HelpMessage = "The priority of the rule")]
        [ValidateRange(1, 20000)]
        public int? Priority { get; set; }

        [Parameter(
                ParameterSetName = "SetByResourceId",
                HelpMessage = "ID of the application gateway BackendSettings")]
        [ValidateNotNullOrEmpty]
        public string BackendSettingsId { get; set; }

        [Parameter(
                ParameterSetName = "SetByResource",
                HelpMessage = "Application gateway BackendSettings")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayBackendSettings BackendSettings { get; set; }

        [Parameter(
                ParameterSetName = "SetByResourceId",
                HelpMessage = "ID of the application gateway Listener")]
        [ValidateNotNullOrEmpty]
        public string ListenerId { get; set; }

        [Parameter(
                ParameterSetName = "SetByResource",
                HelpMessage = "Application gateway Listener")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayListener Listener { get; set; }

        [Parameter(
                ParameterSetName = "SetByResourceId",
                HelpMessage = "ID of the application gateway BackendAddressPool")]
        [ValidateNotNullOrEmpty]
        public string BackendAddressPoolId { get; set; }

        [Parameter(
                ParameterSetName = "SetByResource",
                HelpMessage = "Application gateway BackendAddressPool")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayBackendAddressPool BackendAddressPool { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                if (BackendSettings != null)
                {
                    this.BackendSettingsId = this.BackendSettings.Id;
                }
                if (BackendAddressPool != null)
                {
                    this.BackendAddressPoolId = this.BackendAddressPool.Id;
                }
                if (Listener != null)
                {
                    this.ListenerId = this.Listener.Id;
                }
            }
        }

        public PSApplicationGatewayRoutingRule NewObject()
        {
            var routingRule = new PSApplicationGatewayRoutingRule();
            routingRule.Name = this.Name;
            routingRule.RuleType = this.RuleType;
            routingRule.Priority = this.Priority;

            if (!string.IsNullOrEmpty(this.BackendSettingsId))
            {
                routingRule.BackendSettings = new PSResourceId();
                routingRule.BackendSettings.Id = this.BackendSettingsId;
            }

            if (!string.IsNullOrEmpty(this.ListenerId))
            {
                routingRule.Listener = new PSResourceId();
                routingRule.Listener.Id = this.ListenerId;
            }
            if (!string.IsNullOrEmpty(this.BackendAddressPoolId))
            {
                routingRule.BackendAddressPool = new PSResourceId();
                routingRule.BackendAddressPool.Id = this.BackendAddressPoolId;
            }            

            routingRule.Id = ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                                this.NetworkClient.NetworkManagementClient.SubscriptionId,
                                Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayRoutingRuleName,
                                this.Name);

            return routingRule;
        }
    }
}
