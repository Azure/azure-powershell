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
    public class AzureApplicationGatewayAdvancedRoutingConditionBase : NetworkBaseCmdlet
    {
        [Parameter(
                Mandatory = true,
                HelpMessage = "The type of request property the condition is evaluated against")]
        [ValidateSet("Header", "QueryString", "Path", "ClientIP", "Method", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string ConditionType { get; set; }

        [Parameter(
                Mandatory = false,
                HelpMessage = "Name of the request property the condition is evaluated against. Required when ConditionType is Header or QueryString, and not applicable when ConditionType is Path, ClientIP or Method")]
        [ValidateNotNullOrEmpty]
        public string PropertyName { get; set; }

        [Parameter(
                ParameterSetName = "MatchByValues",
                Mandatory = true,
                HelpMessage = "Values the request property is matched against")]
        [ValidateNotNullOrEmpty]
        public string[] PropertyValues { get; set; }

        [Parameter(
                ParameterSetName = "MatchByPattern",
                Mandatory = true,
                HelpMessage = "Pattern, either a fixed string or a regular expression, the request property is matched against. Not applicable when ConditionType is ClientIP or Method")]
        [ValidateNotNullOrEmpty]
        public string Pattern { get; set; }

        [Parameter(
                ParameterSetName = "MatchByPattern",
                Mandatory = false,
                HelpMessage = "Set this flag to make the pattern comparison case insensitive")]
        public SwitchParameter IgnoreCase { get; set; }

        [Parameter(
                ParameterSetName = "MatchByPattern",
                Mandatory = false,
                HelpMessage = "Set this flag to negate the condition given by the pattern")]
        public SwitchParameter Negate { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        public PSApplicationGatewayAdvancedRoutingCondition NewObject()
        {
            this.Validate();

            var condition = new PSApplicationGatewayAdvancedRoutingCondition
            {
                ConditionType = this.ConditionType,
                PropertyName = this.PropertyName
            };

            if (this.PropertyValues != null)
            {
                condition.PropertyValues = this.PropertyValues.ToList();
            }
            else
            {
                condition.PropertyValueMatcher = new PSApplicationGatewayAdvancedRoutingPropertyValueMatcher
                {
                    Pattern = this.Pattern,
                    IgnoreCase = this.IgnoreCase.IsPresent,
                    Negate = this.Negate.IsPresent
                };
            }

            return condition;
        }

        private void Validate()
        {
            var supportsPropertyName = IsConditionType("Header") || IsConditionType("QueryString");

            if (supportsPropertyName && string.IsNullOrEmpty(this.PropertyName))
            {
                throw new PSArgumentException($"PropertyName is required when ConditionType is '{this.ConditionType}'.");
            }

            if (!supportsPropertyName && !string.IsNullOrEmpty(this.PropertyName))
            {
                throw new PSArgumentException($"PropertyName is not applicable when ConditionType is '{this.ConditionType}'.");
            }

            if (!string.IsNullOrEmpty(this.Pattern) && (IsConditionType("ClientIP") || IsConditionType("Method")))
            {
                throw new PSArgumentException($"Pattern is not applicable when ConditionType is '{this.ConditionType}'. Use PropertyValues instead.");
            }
        }

        private bool IsConditionType(string conditionType)
        {
            return string.Equals(this.ConditionType, conditionType, StringComparison.OrdinalIgnoreCase);
        }
    }
}
