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

using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoor" + "RulesEngineMatchConditionObject"), OutputType(typeof(PSRulesEngineMatchCondition))]
    public class NewFrontDoorRulesEngineMatchConditionObject : AzureFrontDoorCmdletBase
    {
        [Parameter(Mandatory = true,
            HelpMessage = "Match Variable. Possible values are IsMobile, RemoteAddr, RequestMethod, QueryString, PostArg, RequestUri, RequestPath, RequestFileName, RequestfilenameExtension, RequestHeader, RequestBody, RequestScheme")]
        public PSRulesEngineMatchVariable MatchVariable { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Match values to match against. The operator will apply to each value in here with OR semantics. If any of them match the variable with the given operator this match condition is considered a match.")]
        public string[] MatchValue { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Name of selector in RequestHeader or RequestBody to be matched")]
        public string Selector { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Describes operator to apply to the match condition. Possible values are Any, IPMatch, GeoMatch, Equal, Contains, LessThan, GreaterThan, LessThanOrEqual, GreaterThanOrEqual, BeginsWith, EndsWith.")]
        public PSRulesEngineOperator Operator { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Describes if this is negate condition or not")]
        public bool NegateCondition { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "List of what transforms are applied before matching. Possible individual transform values are Lowercase, Uppercase, Trim, UrlDecode, UrlEncode, RemoveNulls.")]
        [PSArgumentCompleter("Lowercase", "Uppercase", "Trim", "UrlDecode", "UrlEncode", "RemoveNulls")]
        public PSTransform[] Transform { get; set; }
        public override void ExecuteCmdlet()
        {
            var matchCondition = new PSRulesEngineMatchCondition
            {
                RulesEngineMatchVariable = MatchVariable,
                RulesEngineMatchValue = MatchValue.ToList(),
                Selector = this.IsParameterBound(c => c.Selector) ? Selector : null,
                RulesEngineOperator = this.IsParameterBound(c => c.Operator) ? Operator : PSRulesEngineOperator.Any,
                NegateCondition = this.IsParameterBound(c => c.NegateCondition) ? NegateCondition : false,
                Transforms = this.IsParameterBound(c => c.Transform) ? Transform.ToList() : new List<PSTransform>()
            };

            WriteObject(matchCondition);
        }
    }
}
