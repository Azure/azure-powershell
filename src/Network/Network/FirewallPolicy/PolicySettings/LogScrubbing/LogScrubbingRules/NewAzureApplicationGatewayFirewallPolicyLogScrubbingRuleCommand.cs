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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayFirewallPolicyLogScrubbingRule"), OutputType(typeof(PSApplicationGatewayFirewallPolicyLogScrubbingRule))]
    public class NewAzureApplicationGatewayFirewallPolicyLogScrubbingRuleCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "State of the log scrubbing rule. Default value is Enabled")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Enabled", "Disabled", IgnoreCase = true)]
        public string State { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The variable to be scrubbed from the logs.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("RequestHeaderNames", "RequestCookieNames", "RequestArgNames", "RequestPostArgNames", "RequestJSONArgNames", "RequestIPAddress", IgnoreCase = true)]
        public string MatchVariable { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "When matchVariable is a collection, operate on the selector to specify which elements in the collection this rule applies to.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Equals", "EqualsAny", IgnoreCase = true)]
        public string SelectorMatchOperator { get; set; }

        [Parameter(
         Mandatory = false,
         HelpMessage = "When matchVariable is a collection, operator used to specify which elements in the collection this rule applies to.")]
        [ValidateNotNullOrEmpty]
        public string Selector { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!this.MyInvocation.BoundParameters.ContainsKey("State"))
            {
                this.State = "Enabled";
            }

            WriteObject(NewObject());
        }

        protected PSApplicationGatewayFirewallPolicyLogScrubbingRule NewObject()
        {
            return new PSApplicationGatewayFirewallPolicyLogScrubbingRule()
            {
                State = this.State,
                MatchVariable = this.MatchVariable,
                SelectorMatchOperator = this.SelectorMatchOperator,
                Selector = this.Selector
            };
        }
    }
}