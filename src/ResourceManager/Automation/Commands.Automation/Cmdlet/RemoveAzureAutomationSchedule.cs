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

using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Properties;
using System.Globalization;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Removes an azure automation Schedule.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmAutomationSchedule", SupportsShouldProcess = true, DefaultParameterSetName = AutomationCmdletParameterSets.ByName)]
    public class RemoveAzureAutomationSchedule : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the schedule name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The schedule name.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the switch parameter not to confirm on removing the schedule.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Forces the command to run without asking for user confirmation.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            this.ConfirmAction(
                this.Force.IsPresent,
                string.Format(CultureInfo.CurrentCulture, Resources.RemoveAzureAutomationScheduleWarning),
                string.Format(CultureInfo.CurrentCulture, Resources.RemoveAzureAutomationScheduleDescription),
                this.Name,
                () =>
                    {
                        this.AutomationClient.DeleteSchedule(this.ResourceGroupName, this.AutomationAccountName, this.Name);
                    });
        }
    }
}
