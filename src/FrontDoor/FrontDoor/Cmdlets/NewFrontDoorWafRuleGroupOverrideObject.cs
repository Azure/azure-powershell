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
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the New-AzFrontDoorWafRuleGroupOverrideObject cmdlet.
    /// </summary>
    [CmdletOutputBreakingChangeWithVersion(typeof(PSAzureRuleGroupOverride), "15.0.0", "6.0.0", ReplacementCmdletOutputTypeName = "Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ManagedRuleGroupOverride", ChangeDescription = "no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSAzureRuleGroupOverride'.")]
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorWafRuleGroupOverrideObject"), OutputType(typeof(PSAzureRuleGroupOverride))]
    public class NewFrontDoorWafRuleGroupOverrideObject : AzureFrontDoorCmdletBase
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
        [CmdletParameterBreakingChangeWithVersion("ManagedRuleOverride", "15.0.0", "6.0.0", NewParameterTypeName = "Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleOverride[]", ChangeDescription = "parameter 'ManagedRuleOverride' is changing from type 'Microsoft.Azure.Commands.FrontDoor.Models.PSAzureManagedRuleOverride[]' to type 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleOverride[]'.")]
        public PSAzureManagedRuleOverride[] ManagedRuleOverride { get; set; }

        /// <summary>
        /// Exclusions
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Exclusions")]
        [CmdletParameterBreakingChangeWithVersion("Exclusion", "15.0.0", "6.0.0", NewParameterTypeName = "Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleExclusion[]", ChangeDescription = "parameter 'Exclusion' is changing from type 'Microsoft.Azure.Commands.FrontDoor.Models.PSManagedRuleExclusion[]' to type 'Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleExclusion[]'.")]
        public PSManagedRuleExclusion[] Exclusion { get; set; }

        public override void ExecuteCmdlet()
        {
            var ruleGroupOverride = new PSAzureRuleGroupOverride
            {
                ManagedRuleOverrides = ManagedRuleOverride?.ToList(),
                RuleGroupName = RuleGroupName,
                Exclusions = Exclusion?.ToList()
            };
            WriteObject(ruleGroupOverride);
        }

    }
}
