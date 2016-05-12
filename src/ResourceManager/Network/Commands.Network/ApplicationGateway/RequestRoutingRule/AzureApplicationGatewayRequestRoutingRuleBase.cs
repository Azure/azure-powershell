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
    public class AzureApplicationGatewayRequestRoutingRuleBase : NetworkBaseCmdlet
    {
        [Parameter(
                Mandatory = true,
                HelpMessage = "The name of the Request Routing Rule")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
        Mandatory = true,
        HelpMessage = "The type of rule")]
        [ValidateSet("Basic", "PathBasedRouting", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string RuleType { get; set; }

        [Parameter(
                ParameterSetName = "SetByResourceId",
                HelpMessage = "ID of the application gateway BackendHttpSettings")]
        [ValidateNotNullOrEmpty]
        public string BackendHttpSettingsId { get; set; }

        [Parameter(
                ParameterSetName = "SetByResource",
                HelpMessage = "Application gateway BackendHttpSettings")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayBackendHttpSettings BackendHttpSettings { get; set; }

        [Parameter(
                ParameterSetName = "SetByResourceId",
                HelpMessage = "ID of the application gateway HttpListener")]
        [ValidateNotNullOrEmpty]
        public string HttpListenerId { get; set; }

        [Parameter(
                ParameterSetName = "SetByResource",
                HelpMessage = "Application gateway HttpListener")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayHttpListener HttpListener { get; set; }

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

        [Parameter(
                ParameterSetName = "SetByResourceId",
                HelpMessage = "ID of the application gateway UrlPathMap")]
        [ValidateNotNullOrEmpty]
        public string UrlPathMapId { get; set; }

        [Parameter(
                ParameterSetName = "SetByResource",
                HelpMessage = "Application gateway UrlPathMap")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayUrlPathMap UrlPathMap { get; set; }
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                if (BackendHttpSettings != null)
                {
                    this.BackendHttpSettingsId = this.BackendHttpSettings.Id;
                }
                if (BackendAddressPool != null)
                {
                    this.BackendAddressPoolId = this.BackendAddressPool.Id;
                }
                if (HttpListener != null)
                {
                    this.HttpListenerId = this.HttpListener.Id;
                }
                if (UrlPathMap != null)
                {
                    this.UrlPathMapId = this.UrlPathMap.Id;
                }
            }
        }

        public PSApplicationGatewayRequestRoutingRule NewObject()
        {
            var requestRoutingRule = new PSApplicationGatewayRequestRoutingRule();
            requestRoutingRule.Name = this.Name;
            requestRoutingRule.RuleType = this.RuleType;

            if (!string.IsNullOrEmpty(this.BackendHttpSettingsId))
            {
                requestRoutingRule.BackendHttpSettings = new PSResourceId();
                requestRoutingRule.BackendHttpSettings.Id = this.BackendHttpSettingsId;
            }

            if (!string.IsNullOrEmpty(this.HttpListenerId))
            {
                requestRoutingRule.HttpListener = new PSResourceId();
                requestRoutingRule.HttpListener.Id = this.HttpListenerId;
            }
            if (!string.IsNullOrEmpty(this.BackendAddressPoolId))
            {
                requestRoutingRule.BackendAddressPool = new PSResourceId();
                requestRoutingRule.BackendAddressPool.Id = this.BackendAddressPoolId;
            }
            if (!string.IsNullOrEmpty(this.UrlPathMapId))
            {
                requestRoutingRule.UrlPathMap = new PSResourceId();
                requestRoutingRule.UrlPathMap.Id = this.UrlPathMapId;
            }

            requestRoutingRule.Id = ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                                this.NetworkClient.NetworkManagementClient.SubscriptionId,
                                Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayRequestRoutingRuleName,
                                this.Name);

            return requestRoutingRule;
        }
    }
}
