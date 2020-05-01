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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoor" + "RulesEngineRuleObject"), OutputType(typeof(PSRulesEngineRule))]
    public class NewFrontDoorRulesEngineRuleObject : AzureFrontDoorCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "A name to refer to this specific rule.")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "A priority assigned to this rule. Cannot be negative.")]
        [ValidateRange(0, int.MaxValue)]
        public int Priority { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Actions to perform on the request and response if all of the match conditions are met.")]
        public PSRulesEngineAction Action { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "If this rule is a match should the rules engine continue running the remaining rules or stop. Possible values are Continue and Stop. If not present, defaults to Continue.")]
        public PSMatchProcessingBehavior MatchProcessingBehavior { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "A list of match conditions that must meet in order for the actions of this rule to run. Having no match conditions means the actions will always run.")]
        public PSRulesEngineMatchCondition[] MatchCondition { get; set; }

        public override void ExecuteCmdlet()
        {
            // Validations
            // Priority >= 0

            var rule = new PSRulesEngineRule
            {
                Name = Name,
                Priority = Priority,
                Action = Action,
            };

            if (this.IsParameterBound(c => c.MatchProcessingBehavior))
            {
                rule.MatchProcessingBehavior = MatchProcessingBehavior;
            }

            if (this.IsParameterBound(c => c.MatchCondition))
            {
                rule.MatchConditions = MatchCondition.ToList();
            }

            WriteObject(rule);
        }
    }
}
