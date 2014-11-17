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
    [Cmdlet(VerbsCommon.New, "AzureAutomationSchedule", DefaultParameterSetName = ByDaily)]
    [OutputType(typeof(Schedule))]
    public class NewAzureAutomationSchedule : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// The one time schedule parameter set.
        /// </summary>
        private const string ByOneTime = "ByOneTime";

        /// <summary>
        /// The daily schedule parameter set.
        /// </summary>
        private const string ByDaily = "ByDaily";

        /// <summary>
        /// The hourly schedule parameter set.
        /// </summary>
        private const string ByHourly = "ByHourly";

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
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the schedule description.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The schedule description.")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the switch parameter to create a one time schedule.
        /// </summary>
        [Parameter(ParameterSetName = ByOneTime, Mandatory = true, HelpMessage = "To create a one time schedule.")]
        public SwitchParameter OneTime { get; set; }

        /// <summary>
        /// Gets or sets the schedule expiry time.
        /// </summary>
        [Parameter(ParameterSetName = ByDaily, Mandatory = false, HelpMessage = "The schedule expiry time.")]
        [Parameter(ParameterSetName = ByHourly, Mandatory = false, HelpMessage = "The schedule expiry time.")]
        public DateTime ExpiryTime { get; set; }

        /// <summary>
        /// Gets or sets the daily schedule day interval.
        /// </summary>
        [Parameter(ParameterSetName = ByDaily, Mandatory = true, HelpMessage = "The daily schedule day interval.")]
        [ValidateRange(1, int.MaxValue)]
        public int DayInterval { get; set; }

        /// <summary>
        /// Gets or sets the hourly schedule hour interval.
        /// </summary>
        [Parameter(ParameterSetName = ByHourly, Mandatory = true, HelpMessage = "The hourly schedule hour interval.")]
        [ValidateRange(1, int.MaxValue)]
        public int HourInterval { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            // Assume local time if DateTimeKind.Unspecified
            if (this.StartTime.Kind == DateTimeKind.Unspecified)
            {
                this.StartTime = DateTime.SpecifyKind(this.StartTime, DateTimeKind.Local);
            }

            if (this.ExpiryTime.Kind == DateTimeKind.Unspecified)
            {
                this.ExpiryTime = DateTime.SpecifyKind(this.ExpiryTime, DateTimeKind.Local);
            }

            if (this.OneTime.IsPresent)
            {
                // ByOneTime
                var oneTimeSchedule = new OneTimeSchedule
                {
                    Name = this.Name,
                    StartTime = this.StartTime,
                    Description = this.Description,
                    ExpiryTime = this.ExpiryTime
                };

                Schedule schedule = this.AutomationClient.CreateSchedule(this.AutomationAccountName, oneTimeSchedule);
                this.WriteObject(schedule);
            }
            else if (this.DayInterval >= 1)
            {
                // ByDaily
                var dailySchedule = new DailySchedule
                {
                    Name = this.Name,
                    StartTime = this.StartTime,
                    DayInterval = this.DayInterval,
                    Description = this.Description,
                    ExpiryTime = this.ExpiryTime
                };

                Schedule schedule = this.AutomationClient.CreateSchedule(this.AutomationAccountName, dailySchedule);
                this.WriteObject(schedule);
            }
            else if (this.HourInterval >= 1)
            {
                // ByHourly
                var hourlySchedule = new HourlySchedule
                {
                    Name = this.Name,
                    StartTime = this.StartTime,
                    HourInterval = this.HourInterval,
                    Description = this.Description,
                    ExpiryTime = this.ExpiryTime
                };

                Schedule schedule = this.AutomationClient.CreateSchedule(this.AutomationAccountName, hourlySchedule);
                this.WriteObject(schedule);
            }
        }
    }
}
