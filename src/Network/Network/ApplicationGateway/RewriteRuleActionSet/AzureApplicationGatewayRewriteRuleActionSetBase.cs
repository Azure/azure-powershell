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
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewayRewriteRuleActionSetBase : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "List of request header configurations")]
        [ValidateNotNullOrEmpty]
        public List<PSApplicationGatewayHeaderConfiguration> RequestHeaderConfiguration { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "List of response header configurations")]
        [ValidateNotNullOrEmpty]
        public List<PSApplicationGatewayHeaderConfiguration> ResponseHeaderConfiguration { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Url configuration.")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayUrlConfiguration UrlConfiguration { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        public PSApplicationGatewayRewriteRuleActionSet NewObject()
        {

            var rewriteRuleActionSet = new PSApplicationGatewayRewriteRuleActionSet
            {
                RequestHeaderConfigurations = this.RequestHeaderConfiguration,
                ResponseHeaderConfigurations = this.ResponseHeaderConfiguration,
                UrlConfiguration = this.UrlConfiguration
            };

            return rewriteRuleActionSet;
        }
    }
}
