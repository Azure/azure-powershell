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

using System.Management.Automation;
using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the New-AzFrontDoorManagedRuleOverrideObject cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorManagedRuleOverrideObject"), OutputType(typeof(PSAzureManagedRuleOverride))]
    public class NewAzureRmFrontDoorManagedRuleOverrideObject : AzureFrontDoorCmdletBase
    {
        /// <summary>
        /// Rule ID
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Rule ID")]
        public string RuleId { get; set; }

        /// <summary>
        /// Override Action
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Override Action")]
        [PSArgumentCompleter("Allow", "Block", "Log", "Redirect")]
        public string Action { get; set; }

        /// <summary>
        /// Disabled State
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Disabled state")]
        public SwitchParameter Disabled { get; set; }

        public override void ExecuteCmdlet()
        {
            var managedRuleOverride = new PSAzureManagedRuleOverride
            {
                RuleId = RuleId,
                Action = this.IsParameterBound(c => c.Action) ? Action : null,
                EnabledState = (this.IsParameterBound(c => c.Disabled) && Disabled.IsPresent) ? PSEnabledState.Disabled : PSEnabledState.Enabled
            };
            WriteObject(managedRuleOverride);
        }

    }
}
