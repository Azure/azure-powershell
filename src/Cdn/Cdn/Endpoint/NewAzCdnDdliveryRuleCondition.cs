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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.Cdn.Helpers;
using Microsoft.Azure.Commands.Cdn.Models.Endpoint;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Cdn.Endpoint
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnDeliveryRuleCondition"), OutputType(typeof(PSDeliveryRuleCondition))]
    public class NewAzCdnDeliveryRuleCondition : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Match variable of the condition.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("RemoteAddress", "RequestMethod", "QueryString", "PostArgs", "RequestUri",
            "RequestHeader", "RequestBody", "RequestScheme", "UrlPath", "UrlFileExtension", "UrlFileName", "IsDevice")]
        public string MatchVariable { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Describes operator to be matched")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Any", "IPMatch", "GeoMatch", "Equal", "Contains","LessThan", "GreaterThan",
            "LessThanOrEqual", "GreaterThanOrEqual", "BeginsWith", "EndsWith", "Wildcard")]
        public string Operator { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "List of possible match values.")]
        public string[] MatchValue { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Transform to apply before matching. Possible values are Lowercase and Uppercase")]
        [PSArgumentCompleter("Uppercase", "Lowercase")]
        public string Transform { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Describes if the result of this condition should be negated.")]
        public SwitchParameter NegateCondition { get; set; }

        public override void ExecuteCmdlet()
        {
            var deliveryRuleCondition = new PSDeliveryRuleCondition
            {
                MatchVariable = MatchVariable,
                Operator = Operator,
                MatchValue = MatchValue,
                NegateCondition = NegateCondition,
                Transfroms = Transform == null? null : new List<string> { Transform }
            };

            deliveryRuleCondition.ValidateDeliveryRuleCondition();
            WriteObject(deliveryRuleCondition);
        }
    }
}
