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
using System.Linq;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewayFirewallConditionBase : NetworkBaseCmdlet
    {

        [Parameter(
            Mandatory = true,
            HelpMessage = "List of match variables.")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayFirewallMatchVariable[] MatchVariable { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Describes operator to be matched.")]
        [ValidateSet("IPMatch", "Equal", "Contains", "LessThan", "GreaterThan", "LessThanOrEqual", "GreaterThanOrEqual", "BeginsWith", "EndsWith", "Regex", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Operator { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Describes if this is negate condition or not.")]
        [ValidateNotNullOrEmpty]
        public bool NegationCondition { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Match value.")]
        [ValidateNotNullOrEmpty]
        public string[] MatchValue { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "List of transforms.")]
        [ValidateSet("Lowercase", "Trim", "UrlDecode", "UrlEncode", "RemoveNulls", "HtmlEntityDecode", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string[] Transform { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        protected PSApplicationGatewayFirewallCondition NewObject()
        {
            return new PSApplicationGatewayFirewallCondition()
            {
                MatchVariables = this.MatchVariable?.ToList(),
                OperatorProperty = this.Operator,
                NegationConditon = this.NegationCondition,
                MatchValues = this.MatchValue?.ToList(),
                Transforms = this.Transform?.ToList()
            };
        }
    }
}
