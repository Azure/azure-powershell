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
    public class AzureApplicationGatewayRewriteRuleHeaderConfigurationBase : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of the Header to rewrite")]
        [ValidateNotNullOrEmpty]
        public string HeaderName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Header value to set for the given header name. Header will be deleted if this is omitted")]
        public string HeaderValue { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "An optional field under 'Rewrite Action'. It lets you capture and modify the value(s) of a specific header when multiple headers with the same name exist. Currently supported for Set-Cookie Response header only. For more details, visit https://aka.ms/appgwheadercrud")]
        public PSApplicationGatewayHeaderValueMatcher HeaderValueMatcher { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        public PSApplicationGatewayHeaderConfiguration NewObject()
        {
            var headerConfiguration = new PSApplicationGatewayHeaderConfiguration
            {
                HeaderName = this.HeaderName,
                HeaderValue = this.HeaderValue,
                HeaderValueMatcher = this.HeaderValueMatcher
            };

            return headerConfiguration;
        }
    }
}
