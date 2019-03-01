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
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayUrlPathMapConfig", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSApplicationGateway))]
    public class UpdateAzureApplicationGatewayUrlPathMapConfigCommand : AzureApplicationGatewayUrlPathMapConfigBase
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The applicationGateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }

        [Parameter(
               Mandatory = false,
               HelpMessage = "List of path rules")]
        [ValidateNotNullOrEmpty]
        public override PSApplicationGatewayPathRule[] PathRules { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var urlPathMap = this.ApplicationGateway.UrlPathMaps.SingleOrDefault
                (resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (urlPathMap == null)
            {
                throw new ArgumentException("Url Path Map with the specified name does not exist");
            }

            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
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

            if (this.PathRules != null && this.PathRules.Length > 0)
            {
                urlPathMap.PathRules = this.PathRules?.ToList();
            }

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

            WriteObject(this.ApplicationGateway);
        }
    }
}
