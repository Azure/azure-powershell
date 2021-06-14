// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Cdn.AfdModels;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Cdn.AfdRule
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnRuleCondition"), OutputType(typeof(PSAfdRuleCondition))]
    public class NewAzFrontDoorCdnRuleCondition : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRuleMatchVariable)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("RemoteAddress", "RequestMethod", "QueryString", "PostArgs", "RequestUri",
        "RequestHeader", "RequestBody", "RequestScheme", "UrlPath", "UrlFileExtension", "UrlFilename", "HttpVersion", "Cookies", "IsDevice")]
        public string MatchVariable { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRuleMatchValue)]
        public List<string> MatchValue { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRuleOperator)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Any", "Equal", "Contains", "LessThan", "GreaterThan", "LessThanOrEqual", "GreaterThanOrEqual",
         "BeginsWith", "EndsWith", "RegEx", "IPMatch", "GeoMatch")]
        public string Operator { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRuleSelector)]
        public string Selector { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRuleTransform)]
        [PSArgumentCompleter("Uppercase", "Lowercase")]
        public List<string> Transform { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRuleNegateCondition)]
        public SwitchParameter NegateCondition { get; set; }

        public override void ExecuteCmdlet()
        {
            PSAfdRuleCondition afdRuleCondition = new PSAfdRuleCondition
            {
                MatchVariable = this.MatchVariable,
                MatchValue = this.MatchValue,
                Operator = this.Operator,
                Selector = this.Selector,
                Transforms = this.Transform
            };

            WriteObject(afdRuleCondition);
        }
    }
}
