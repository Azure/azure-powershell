﻿// ----------------------------------------------------------------------------------
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
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.FrontDoor;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the New-AzureRmFrontDoorCustomRuleObject cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCustomRuleObject"), OutputType(typeof(PSCustomRule))]
    public class NewAzureRmFrontDoorCustomRuleObject : AzureFrontDoorCmdletBase
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
        public PSCustomRuleType RuleType { get; set; }

        /// <summary>
        /// List of match conditions.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "List of match conditions.")]
        [ValidateNotNullOrEmpty]
        public PSMatchCondition[] MatchCondition { get; set; }

        /// <summary>
        /// Type of Actions. Possible values include: 'Allow', 'Block', 'Log'
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Type of Actions. Possible values include: 'Allow', 'Block', 'Log'. ")]
        public PSAction Action { get; set; }

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
        /// Defines rate limit thresold. Default - no limit
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Rate limit thresold")]
        public int? RateLimitThreshold { get; set; }

        /// <summary>
        /// List of transforms
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "List of transforms")]
        public string[] Transform { get; set; }

        public override void ExecuteCmdlet()
        {
            var CustomRule = new PSCustomRule
            {
               Name = Name,
               MatchConditions = MatchCondition.ToList(),
               Priority = Priority,
               RuleType = RuleType,
               RateLimitDurationInMinutes = !this.IsParameterBound(c => c.RateLimitDurationInMinutes)? 1 : RateLimitDurationInMinutes,
               RateLimitThreshold = RateLimitThreshold,
               Transforms = Transform?.ToList(),
               Action = Action
            };
            WriteObject(CustomRule);
        }
        
    }
}
