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

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyApplicationRuleCustomHttpHeader",
        SupportsShouldProcess = true),
        OutputType(typeof(PSAzureFirewallPolicyApplicationRuleCustomHttpHeader))]
    
    public class NewAzFirewallPolicyApplicationRuleCustomHttpHeaderCommand : NetworkBaseCmdlet
    {
        private const int HttpHeaderValueMaxLength = 512;
        private const int HttpHeaderNameMaxLength = 100;

        [Parameter(
             Mandatory = true,
             HelpMessage = "Http header name."
         )]
        [ValidateNotNullOrEmpty]
        public string HeaderName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Http header value."
         )]
        [ValidateNotNullOrEmpty]
        public string HeaderValue { get; set; }

        public override void Execute()
        {
            base.Execute();

            Validate();

            var customHttpHeader = new PSAzureFirewallPolicyApplicationRuleCustomHttpHeader
            {
                HeaderName = this.HeaderName,
                HeaderValue = this.HeaderValue
            };

            WriteObject(customHttpHeader);
        }

        private void Validate()
        {
            // validate name length
            if (this.HeaderName.Length > HttpHeaderNameMaxLength)
            {
                throw new ArgumentException($"Header Name length is limited to {HttpHeaderNameMaxLength} characters.");
            }

            // validate value length
            if (this.HeaderValue.Length > HttpHeaderValueMaxLength)
            {
                throw new ArgumentException($"Header value length is limited to {HttpHeaderValueMaxLength} characters.");
            }
        }
    }
}
