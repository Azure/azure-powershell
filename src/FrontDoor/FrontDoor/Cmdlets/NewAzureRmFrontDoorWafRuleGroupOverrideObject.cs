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

using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.Azure.Commands.FrontDoor.Models;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the New-AzFrontDoorWafRuleGroupOverrideObject cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorWafRuleGroupOverrideObject"), OutputType(typeof(PSAzureRuleGroupOverride))]
    public class NewAzureRmFrontDoorWafRuleGroupOverrideObject : AzureFrontDoorCmdletBase
    {
        /// <summary>
        /// Rule Group Name
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Rule Group Name for which these overrides apply")]
        public string RuleGroupName { get; set; }

        /// <summary>
        /// Rule override list
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Rule override list")]
        public PSAzureManagedRuleOverride[] ManagedRuleOverride { get; set; }

        public override void ExecuteCmdlet()
        {
            var ruleGroupOverride = new PSAzureRuleGroupOverride 
            {
               ManagedRuleOverrides = ManagedRuleOverride?.ToList(),
               RuleGroupName = RuleGroupName
            };
            WriteObject(ruleGroupOverride);
        }
        
    }
}
