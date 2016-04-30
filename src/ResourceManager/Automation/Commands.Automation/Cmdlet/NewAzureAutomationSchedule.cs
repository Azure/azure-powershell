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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Model;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Creates an azure automation Schedule.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmAutomationSchedule", DefaultParameterSetName = AutomationCmdletParameterSets.ByDaily)]
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
        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The schedule name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the schedule start time.
        /// </summary>
        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The schedule start time.")]
        [ValidateNotNull]
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// Gets or sets the schedule description.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The schedule description.")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the schedule days of the week.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The list of days of the week for weekly schedule.")]
        public DayOfWeek[] WeekDays { get; set; }

        /// <summary>
        /// Gets or sets the schedule days of the month.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The list of days of the month for monthly schedule.")]
        public int[] MonthDays { get; set; }

        /// <summary>
        /// Gets or sets the schedule day of the week.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The day of week for monthly occurrence.")]
        public DayOfWeek? DayOfWeek { get; set; }

        /// <summary>
        /// Gets or sets the schedule day of the week.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Occurrence of the week within the month.")]
        public int? Occurrence { get; set; }

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
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByWeekly, Mandatory = false, HelpMessage = "The schedule expiry time.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthly, Mandatory = false, HelpMessage = "The schedule expiry time.")]
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
        /// Gets or sets the weekly schedule week interval.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByWeekly, Mandatory = true, HelpMessage = "The weekly schedule hour interval.")]
        [ValidateRange(1, byte.MaxValue)]
        public byte WeekInterval { get; set; }

        /// <summary>
        /// Gets or sets the weekly schedule week interval.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthly, Mandatory = true, HelpMessage = "The monthly schedule hour interval.")]
        [ValidateRange(1, byte.MaxValue)]
        public byte MonthInterval { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            var schedule = new Schedule
            {
                Name = this.Name,
                StartTime = this.StartTime,
                Description = this.Description,
                ExpiryTime = this.ExpiryTime
            };

            switch (this.ParameterSetName)
            {
                case AutomationCmdletParameterSets.ByOneTime:
                    schedule.Frequency = ScheduleFrequency.Onetime;
                    break;
                case AutomationCmdletParameterSets.ByDaily:
                    schedule.Frequency = ScheduleFrequency.Day;
                    schedule.Interval = this.DayInterval;
                    break;
                case AutomationCmdletParameterSets.ByHourly:
                    schedule.Frequency = ScheduleFrequency.Hour;
                    schedule.Interval = this.HourInterval;
                    break;
                case AutomationCmdletParameterSets.ByWeekly:
                    schedule.Frequency = ScheduleFrequency.Week;
                    schedule.Interval = this.WeekInterval;
                    schedule.WeekDays = this.WeekDays == null
                        ? null
                        : this.WeekDays.Select(day => day.ToString()).ToList();
                    break;
                case AutomationCmdletParameterSets.ByMonthly:
                    schedule = this.CreateMonthlyScheduleModel(
                        schedule,
                        this.MonthDays,
                        this.DayOfWeek.ToString(),
                        this.Occurrence);
                   
                    break;
            }

            Schedule createdSchedule = this.AutomationClient.CreateSchedule(this.ResourceGroupName, this.AutomationAccountName, schedule);
            this.WriteObject(createdSchedule);
        }

        /// <summary>
        /// The validate.
        /// </summary>
        /// <param name="schedule">
        /// The schedule.
        /// </param>
        /// <param name="monthDays">
        /// The month days.
        /// </param>
        /// <param name="day">
        /// The day.
        /// </param>
        /// <param name="occurrence">
        /// The occurrence.
        /// </param>
        /// <returns>
        /// The <see cref="Schedule"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// throws exception
        /// </exception>
        private Schedule CreateMonthlyScheduleModel(Schedule schedule, IList<int> monthDays, string day, int? occurrence)
        {
            if (monthDays != null && (!string.IsNullOrWhiteSpace(day) || occurrence != null))
            {
                throw new Exception("Both month days and monthly occurrence can not be selected at the same time.");
            }
            else if ((!string.IsNullOrWhiteSpace(day) && occurrence == null) || (string.IsNullOrWhiteSpace(day) && occurrence != null))
            {
                throw new Exception("for monthly occurrence, both day and occurrence need to be specified");
            }

            var newSchedule = schedule;
            newSchedule.Frequency = ScheduleFrequency.Month;
            newSchedule.Interval = this.MonthInterval;
            newSchedule.MonthDays = monthDays == null ? null : monthDays.ToList();
            newSchedule.DayOfWeek = day;
            newSchedule.Occurrence = occurrence;

            return newSchedule;
        }
    }
}
