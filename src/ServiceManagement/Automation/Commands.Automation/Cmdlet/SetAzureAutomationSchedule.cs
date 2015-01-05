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
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Model;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Sets an azure automation schedule.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureAutomationSchedule", DefaultParameterSetName = AutomationCmdletParameterSets.ByName)]
    [OutputType(typeof(Schedule))]
    public class SetAzureAutomationSchedule : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the schedule name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The schedule name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the indicator whether the schedule is enabled.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies whether the schedule is enabled. If a schedule is disabled, any runbooks using it will not run on the schedule until it is enabled.")]
        public bool? IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the schedule description.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The schedule description.")]
        public string Description { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            Schedule schedule = this.AutomationClient.UpdateSchedule(
                this.AutomationAccountName, this.Name, this.IsEnabled, this.Description);
            this.WriteObject(schedule);
        }
    }
}