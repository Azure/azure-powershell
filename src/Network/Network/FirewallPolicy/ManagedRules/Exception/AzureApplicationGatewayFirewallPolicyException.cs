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
    public class AzureApplicationGatewayFirewallPolicyException : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The variable on which we evaluate the exception condition.")]
        [ValidateSet("RequestURI", "RemoteAddr", "RequestHeader", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string MatchVariable { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Allowed values for the matchVariable.")]
        [ValidateNotNullOrEmpty]
        public string[] Value { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Operates on the allowed values for the matchVariable.")]
        [ValidateSet("Equals", "Contains", "StartsWith", "EndsWith", "IPMatch", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string ValueMatchOperator { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "When the matchVariable points to a key-value pair (e.g, RequestHeader), this operates on the selector.")]
        [ValidateSet("Equals", "Contains", "StartsWith", "EndsWith", IgnoreCase = true)]
        public string SelectorMatchOperator { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "When the matchVariable points to a key-value pair (e.g, RequestHeader), this identifies the key.")]
        public string Selector { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The managed rule sets that are associated with the exception.")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayFirewallPolicyExclusionManagedRuleSet[] ExceptionManagedRuleSet { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        protected PSApplicationGatewayFirewallPolicyException NewObject()
        {
            return new PSApplicationGatewayFirewallPolicyException()
            {
                MatchVariable = this.MatchVariable,
                Values = this.Value.ToList(),
                ValueMatchOperator = this.ValueMatchOperator,
                SelectorMatchOperator = this.SelectorMatchOperator,
                Selector = this.Selector,
                ExceptionManagedRuleSets = this.ExceptionManagedRuleSet?.ToList()
            };
        }
    }
}