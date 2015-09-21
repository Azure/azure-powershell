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
    /// Creates an azure automation Schedule.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureAutomationSchedule", DefaultParameterSetName = AutomationCmdletParameterSets.ByDaily)]
    [OutputType(typeof(Schedule))]
    public class NewAzureAutomationSchedule : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewAzureAutomationSchedule"/> class.
        /// </summary>
        public NewAzureAutomationSchedule()
        {
            this.ExpiryTime = Constants.DefaultScheduleExpiryTime;
        }

        /// <summary>
        /// Gets or sets the schedule name.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The schedule name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the schedule start time.
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The schedule start time.")]
        [ValidateNotNull]
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// Gets or sets the schedule description.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The schedule description.")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the switch parameter to create a one time schedule.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByOneTime, Mandatory = true, HelpMessage = "To create a one time schedule.")]
        public SwitchParameter OneTime { get; set; }

        /// <summary>
        /// Gets or sets the schedule expiry time.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByDaily, Mandatory = false, HelpMessage = "The schedule expiry time.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByHourly, Mandatory = false, HelpMessage = "The schedule expiry time.")]
        public DateTimeOffset ExpiryTime { get; set; }

        /// <summary>
        /// Gets or sets the daily schedule day interval.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByDaily, Mandatory = true, HelpMessage = "The daily schedule day interval.")]
        [ValidateRange(1, byte.MaxValue)]
        public byte DayInterval { get; set; }

        /// <summary>
        /// Gets or sets the hourly schedule hour interval.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByHourly, Mandatory = true, HelpMessage = "The hourly schedule hour interval.")]
        [ValidateRange(1, byte.MaxValue)]
        public byte HourInterval { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            var schedule = new Schedule
            {
                Name = this.Name,
                StartTime = this.StartTime,
                Description = this.Description,
                ExpiryTime = this.ExpiryTime
            };

            if (this.ParameterSetName == AutomationCmdletParameterSets.ByOneTime)
            {
                schedule.Frequency = ScheduleFrequency.Onetime;
            }
            else if (this.ParameterSetName == AutomationCmdletParameterSets.ByDaily)
            {
                schedule.Frequency = ScheduleFrequency.Day;
                schedule.Interval = this.DayInterval;
            }
            else if (this.ParameterSetName == AutomationCmdletParameterSets.ByHourly)
            {
                schedule.Frequency = ScheduleFrequency.Hour;
                schedule.Interval = this.HourInterval;
            }

            Schedule createdSchedule = this.AutomationClient.CreateSchedule(this.AutomationAccountName, schedule);
            this.WriteObject(createdSchedule);
        }
    }
}
