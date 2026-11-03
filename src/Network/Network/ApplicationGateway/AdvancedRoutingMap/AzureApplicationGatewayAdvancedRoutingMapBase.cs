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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewayAdvancedRoutingMapBase : NetworkBaseCmdlet
    {
        [Parameter(
                Mandatory = true,
                HelpMessage = "Name of the advanced routing map")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
                Mandatory = true,
                HelpMessage = "List of advanced routing rules")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayAdvancedRoutingRule[] AdvancedRoutingRule { get; set; }

        [Parameter(
                ParameterSetName = "BackendSetByResourceId",
                Mandatory = true,
                HelpMessage = "ID of the application gateway default BackendAddressPool")]
        [ValidateNotNullOrEmpty]
        public string DefaultBackendAddressPoolId { get; set; }

        [Parameter(
                ParameterSetName = "BackendSetByResource",
                Mandatory = true,
                HelpMessage = "Application gateway default BackendAddressPool")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayBackendAddressPool DefaultBackendAddressPool { get; set; }

        [Parameter(
                ParameterSetName = "BackendSetByResourceId",
                Mandatory = true,
                HelpMessage = "ID of the application gateway default BackendHttpSettings")]
        [ValidateNotNullOrEmpty]
        public string DefaultBackendHttpSettingsId { get; set; }

        [Parameter(
                ParameterSetName = "BackendSetByResource",
                Mandatory = true,
                HelpMessage = "Application gateway default BackendHttpSettings")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayBackendHttpSettings DefaultBackendHttpSettings { get; set; }

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

        [Parameter(
                ParameterSetName = "BackendSetByResourceId",
                Mandatory = false,
                HelpMessage = "ID of the application gateway default RewriteRuleSet")]
        [Parameter(
                ParameterSetName = "RedirectSetByResourceId",
                Mandatory = false,
                HelpMessage = "ID of the application gateway default RewriteRuleSet")]
        public string DefaultRewriteRuleSetId { get; set; }

        [Parameter(
                ParameterSetName = "BackendSetByResource",
                Mandatory = false,
                HelpMessage = "Application gateway default RewriteRuleSet")]
        [Parameter(
                ParameterSetName = "RedirectSetByResource",
                Mandatory = false,
                HelpMessage = "Application gateway default RewriteRuleSet")]
        public PSApplicationGatewayRewriteRuleSet DefaultRewriteRuleSet { get; set; }

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

        public PSApplicationGatewayAdvancedRoutingMap NewObject()
        {
            var advancedRoutingMap = new PSApplicationGatewayAdvancedRoutingMap
            {
                Name = this.Name,
                AdvancedRoutingRules = this.AdvancedRoutingRule?.ToList(),
                Id = ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                                this.NetworkClient.NetworkManagementClient.SubscriptionId,
                                Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayAdvancedRoutingMapName,
                                this.Name)
            };

            if (!string.IsNullOrEmpty(this.DefaultBackendAddressPoolId))
            {
                advancedRoutingMap.DefaultBackendAddressPool = new PSResourceId { Id = this.DefaultBackendAddressPoolId };
            }

            if (!string.IsNullOrEmpty(this.DefaultBackendHttpSettingsId))
            {
                advancedRoutingMap.DefaultBackendHttpSettings = new PSResourceId { Id = this.DefaultBackendHttpSettingsId };
            }

            if (!string.IsNullOrEmpty(this.DefaultRedirectConfigurationId))
            {
                advancedRoutingMap.DefaultRedirectConfiguration = new PSResourceId { Id = this.DefaultRedirectConfigurationId };
            }

            if (!string.IsNullOrEmpty(this.DefaultRewriteRuleSetId))
            {
                advancedRoutingMap.DefaultRewriteRuleSet = new PSResourceId { Id = this.DefaultRewriteRuleSetId };
            }

            return advancedRoutingMap;
        }
    }
}
