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
using System.Globalization;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Properties;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Removes an azure automation Schedule.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureAutomationSchedule", SupportsShouldProcess = true, DefaultParameterSetName = ByScheduleName)]
    public class RemoveAzureAutomationSchedule : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// The get schedule by schedule id parameter set.
        /// </summary>
        private const string ByScheduleId = "ByScheduleId";

        /// <summary>
        /// The get schedule by schedule name parameter set.
        /// </summary>
        private const string ByScheduleName = "ByScheduleName";

        /// <summary>
        /// Gets or sets the schedule id.
        /// </summary>
        [Parameter(ParameterSetName = ByScheduleId, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The schedule id.")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the schedule name.
        /// </summary>
        [Parameter(ParameterSetName = ByScheduleName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The schedule name.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the switch parameter not to confirm on removing the schedule.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Do not confirm on removing the schedule.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            this.ConfirmAction(
                this.Force.IsPresent,
                string.Format(CultureInfo.CurrentCulture, Resources.RemoveAzureAutomationScheduleWarning),
                string.Format(CultureInfo.CurrentCulture, Resources.RemoveAzureAutomationScheduleDescription),
                this.Id.HasValue ? this.Id.Value.ToString() : this.Name,
                () =>
                    {
                        if (this.Id.HasValue)
                        {
                            // ByScheduleId
                            this.AutomationClient.DeleteSchedule(this.AutomationAccountName, this.Id.Value);
                        }
                        else
                        {
                            // ByScheduleName
                            this.AutomationClient.DeleteSchedule(this.AutomationAccountName, this.Name);
                        }
                    });
        }
    }
}
