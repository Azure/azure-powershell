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

using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureApplicationGatewayRequestRoutingRule"), OutputType(typeof(PSApplicationGatewayRequestRoutingRule))]
    public class NewAzureApplicationGatewayRequestRoutingRuleCommand : AzureApplicationGatewayRequestRoutingRuleBase
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

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

            requestRoutingRule.Id = ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                                this.NetworkClient.NetworkResourceProviderClient.Credentials.SubscriptionId,
                                Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayRequestRoutingRuleName,
                                this.Name);            

            WriteObject(requestRoutingRule);
        }
    }
}
