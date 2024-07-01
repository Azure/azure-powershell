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
    /// <summary>
    /// Defines the New-AzFrontDoorWafCustomRuleObject cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorWafCustomRuleObject"), OutputType(typeof(PSCustomRule))]
    public class NewFrontDoorWafCustomRuleObject : AzureFrontDoorCmdletBase
    {
        /// <summary>
        /// Name of the rule. 
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Name of the rule")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Type of the rule. Possible values include: 'MatchRule', 'RateLimitRule'
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Type of the rule. Possible values include: 'MatchRule', 'RateLimitRule'")]
        [PSArgumentCompleter("RateLimitRule", "MatchRule")]
        public string RuleType { get; set; }

        /// <summary>
        /// List of match conditions.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "List of match conditions.")]
        [ValidateNotNullOrEmpty]
        public PSMatchCondition[] MatchCondition { get; set; }

        /// <summary>
        /// Type of Actions. Possible values include: 'Allow', 'Block', 'Log', 'Redirect'
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Type of Actions. Possible values include: 'Allow', 'Block', 'Log', 'Redirect'.")]
        [PSArgumentCompleter("Allow", "Block", "Log", "Redirect")]
        public string Action { get; set; }

        /// <summary>
        /// Describes priority of the rule. Rules with a lower value will be evaluated before rules with a higher
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Describes priority of the rule.")]
        public int Priority { get; set; }

        /// <summary>
        /// Defines rate limit duration. Default - 1 minute
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Rate limit duration. Default - 1 minute")]
        public int RateLimitDurationInMinutes { get; set; }

        /// <summary>
        /// Defines rate limit threshold. Default - no limit
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Rate limit threshold")]
        public int? RateLimitThreshold { get; set; }

        /// <summary>
        /// Enabled State. Possible values include: 'Enabled', 'Disabled'
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Enabled State. Possible values include: 'Enabled', 'Disabled'.")]
        [PSArgumentCompleter("Enabled", "Disabled")]
        public string EnabledState { get; set; }

        /// <summary>
        /// Gets or sets describes the list of variables to group the rate limit
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Gets or sets describes the list of variables to group the rate limit")]
        public PSFrontDoorWafCustomRuleGroupByVariable[] CustomRule  { get; set; }

        public override void ExecuteCmdlet()
        {
            var customRule = new PSCustomRule
            {
                Name = Name,
                MatchConditions = MatchCondition.ToList(),
                Priority = Priority,
                RuleType = RuleType,
                RateLimitDurationInMinutes = !this.IsParameterBound(c => c.RateLimitDurationInMinutes) ? 1 : RateLimitDurationInMinutes,
                RateLimitThreshold = RateLimitThreshold,
                Action = Action,
                EnabledState = !this.IsParameterBound(c => c.EnabledState) ? "Enabled" : EnabledState,
                CustomRule = CustomRule
            };
            WriteObject(customRule);
        }

    }
}
