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
        public List<PSApplicationGatewayPathRule> PathRules { get; set; }

        [Parameter(
        ParameterSetName = "SetByResourceId",
        HelpMessage = "ID of the application gateway BackendAddressPool")]
        [ValidateNotNullOrEmpty]
        public string DefaultBackendAddressPoolId { get; set; }

        [Parameter(
                ParameterSetName = "SetByResource",
                HelpMessage = "Application gateway BackendAddressPool")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayBackendAddressPool DefaultBackendAddressPool { get; set; }

        [Parameter(
                ParameterSetName = "SetByResourceId",
                HelpMessage = "ID of the application gateway BackendHttpSettings")]
        [ValidateNotNullOrEmpty]
        public string DefaultBackendHttpSettingsId { get; set; }

        [Parameter(
                ParameterSetName = "SetByResource",
                HelpMessage = "Application gateway BackendHttpSettings")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayBackendHttpSettings DefaultBackendHttpSettings { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

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
            }
        }

        public PSApplicationGatewayUrlPathMap NewObject()
        {
            var urlPathMap = new PSApplicationGatewayUrlPathMap();

            urlPathMap.Name = this.Name;
            urlPathMap.PathRules = this.PathRules;

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

            urlPathMap.Id = ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                this.NetworkClient.NetworkManagementClient.SubscriptionId,
                Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayUrlPathMapName,
                this.Name);

            return urlPathMap;
        }
    }
}
