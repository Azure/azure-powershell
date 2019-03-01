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
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayRequestRoutingRule", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSApplicationGateway))]
    public class UpdateAzureApplicationGatewayRequestRoutingRuleCommand : AzureApplicationGatewayRequestRoutingRuleBase
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The applicationGateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }

        [Parameter(
        Mandatory = false,
        HelpMessage = "The type of rule")]
        [ValidateSet("Basic", "PathBasedRouting", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public override string RuleType { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var requestRoutingRule = this.ApplicationGateway.RequestRoutingRules.SingleOrDefault
                (resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (requestRoutingRule == null)
            {
                throw new ArgumentException("RequestRoutingRule with the specified name does not exist");
            }

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
                if (RewriteRuleSet != null)
                {
                    this.RewriteRuleSetId = this.RewriteRuleSet.Id;
                }
                if (RedirectConfiguration != null)
                {
                    this.RedirectConfigurationId = this.RedirectConfiguration.Id;
                }
            }

            if (!string.IsNullOrEmpty(this.RuleType))
            {
                requestRoutingRule.RuleType = this.RuleType;
            }

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

            if (!string.IsNullOrEmpty(this.RewriteRuleSetId))
            {
                requestRoutingRule.RewriteRuleSet = new PSResourceId();
                requestRoutingRule.RewriteRuleSet.Id = this.RewriteRuleSetId;
            }

            if (!string.IsNullOrEmpty(this.RedirectConfigurationId))
            {
                requestRoutingRule.RedirectConfiguration = new PSResourceId();
                requestRoutingRule.RedirectConfiguration.Id = this.RedirectConfigurationId;
            }

            WriteObject(this.ApplicationGateway);
        }
    }
}
