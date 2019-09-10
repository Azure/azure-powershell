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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewayUrlPathMapConfigBase : NetworkBaseCmdlet
    {
        [Parameter(
                Mandatory = true,
                HelpMessage = "Name of the URL path map")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
               Mandatory = true,
               HelpMessage = "List of path rules")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayPathRule[] PathRules { get; set; }

        [Parameter(
                ParameterSetName = "BackendSetByResourceId",
                Mandatory = true,
                HelpMessage = "ID of the application gateway BackendAddressPool")]
        [ValidateNotNullOrEmpty]
        public string DefaultBackendAddressPoolId { get; set; }

        [Parameter(
                ParameterSetName = "BackendSetByResource",
                Mandatory = true,
                HelpMessage = "Application gateway BackendAddressPool")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayBackendAddressPool DefaultBackendAddressPool { get; set; }

        [Parameter(
                ParameterSetName = "BackendSetByResourceId",
                Mandatory = true,
                HelpMessage = "ID of the application gateway BackendHttpSettings")]
        [ValidateNotNullOrEmpty]
        public string DefaultBackendHttpSettingsId { get; set; }

        [Parameter(
                ParameterSetName = "BackendSetByResource",
                Mandatory = true,
                HelpMessage = "Application gateway BackendHttpSettings")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayBackendHttpSettings DefaultBackendHttpSettings { get; set; }

        [Parameter(
                ParameterSetName = "BackendSetByResource",
                Mandatory = false,
                HelpMessage = "Application gateway default rewrite rule set")]
        [Parameter(
                ParameterSetName = "RedirectSetByResource",
                Mandatory = false,
                HelpMessage = "Application gateway default rewrite rule set")]
        public PSApplicationGatewayRewriteRuleSet DefaultRewriteRuleSet { get; set; }

        [Parameter(
                ParameterSetName = "BackendSetByResourceId",
                Mandatory = false,
                HelpMessage = "ID of the application gateway default rewrite rule set")]
        [Parameter(
                ParameterSetName = "RedirectSetByResourceId",
                Mandatory = false,
                HelpMessage = "ID of the application gateway default rewrite rule set")]
        public string DefaultRewriteRuleSetId { get; set; }

        [Parameter(
                ParameterSetName = "RedirectSetByResourceId",
                Mandatory = true,
                HelpMessage = "ID of the application gateway default RedirectConfiguration")]
        [ValidateNotNullOrEmpty]
        public string DefaultRedirectConfigurationId { get; set; }

        [Parameter(
                ParameterSetName = "RedirectSetByResource",
                Mandatory = true,
                HelpMessage = "Application gateway default RedirectConfiguration")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayRedirectConfiguration DefaultRedirectConfiguration { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ParameterSetName.EndsWith(Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                if (DefaultBackendAddressPool != null)
                {
                    this.DefaultBackendAddressPoolId = this.DefaultBackendAddressPool.Id;
                }
                if (DefaultBackendHttpSettings != null)
                {
                    this.DefaultBackendHttpSettingsId = this.DefaultBackendHttpSettings.Id;
                }
                if (DefaultRedirectConfiguration != null)
                {
                    this.DefaultRedirectConfigurationId = this.DefaultRedirectConfiguration.Id;
                }
                if (DefaultRewriteRuleSet != null)
                {
                    this.DefaultRewriteRuleSetId = this.DefaultRewriteRuleSet.Id;
                }
            }
        }

        public PSApplicationGatewayUrlPathMap NewObject()
        {
            var urlPathMap = new PSApplicationGatewayUrlPathMap();

            urlPathMap.Name = this.Name;
            urlPathMap.PathRules = this.PathRules?.ToList();

            if (!string.IsNullOrEmpty(this.DefaultBackendAddressPoolId))
            {
                urlPathMap.DefaultBackendAddressPool = new PSResourceId();
                urlPathMap.DefaultBackendAddressPool.Id = this.DefaultBackendAddressPoolId;
            }

            if (!string.IsNullOrEmpty(this.DefaultBackendHttpSettingsId))
            {
                urlPathMap.DefaultBackendHttpSettings = new PSResourceId();
                urlPathMap.DefaultBackendHttpSettings.Id = this.DefaultBackendHttpSettingsId;
            }

            if (!string.IsNullOrEmpty(this.DefaultRedirectConfigurationId))
            {
                urlPathMap.DefaultRedirectConfiguration = new PSResourceId();
                urlPathMap.DefaultRedirectConfiguration.Id = this.DefaultRedirectConfigurationId;
            }

            if (!string.IsNullOrEmpty(this.DefaultRewriteRuleSetId))
            {
                urlPathMap.DefaultRewriteRuleSet = new PSResourceId();
                urlPathMap.DefaultRewriteRuleSet.Id = this.DefaultRewriteRuleSetId;
            }

            urlPathMap.Id = ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                this.NetworkClient.NetworkManagementClient.SubscriptionId,
                Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayUrlPathMapName,
                this.Name);

            return urlPathMap;
        }
    }
}
