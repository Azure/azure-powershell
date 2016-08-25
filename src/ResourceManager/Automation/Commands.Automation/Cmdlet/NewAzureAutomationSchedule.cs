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
using Microsoft.Azure.Commands.Automation.Properties;
using DayOfWeek = Microsoft.Azure.Commands.Automation.Model.DayOfWeek;

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
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByWeekly, Mandatory = false, HelpMessage = "The list of days of week for the weekly schedule.")]
        public System.DayOfWeek[] DaysOfWeek { get; set; }

        /// <summary>
        /// Gets or sets the schedule days of the month.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDaysOfMonth, Mandatory = false, HelpMessage = "The list of days of month for the monthly schedule.")]
        public DaysOfMonth[] DaysOfMonth { get; set; }

        /// <summary>
        /// Gets or sets the schedule day of the week.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDayOfWeek, Mandatory = false, HelpMessage = "The day of week for the monthly occurrence.")]
        public System.DayOfWeek? DayOfWeek { get; set; }

        /// <summary>
        /// Gets or sets the schedule day of the week.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDayOfWeek, Mandatory = false, HelpMessage = "The Occurrence of the week within the month.")]
        public DayOfWeekOccurrence DayOfWeekOccurrence { get; set; }

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
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDaysOfMonth, Mandatory = false, HelpMessage = "The schedule expiry time.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDayOfWeek, Mandatory = false, HelpMessage = "The schedule expiry time.")]
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
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByWeekly, Mandatory = true, HelpMessage = "The weekly schedule week interval.")]
        [ValidateRange(1, byte.MaxValue)]
        public byte WeekInterval { get; set; }

        /// <summary>
        /// Gets or sets the weekly schedule week interval.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDaysOfMonth, Mandatory = true, HelpMessage = "The monthly schedule month interval.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDayOfWeek, Mandatory = true, HelpMessage = "The monthly schedule month interval.")]
        [ValidateRange(1, byte.MaxValue)]
        public byte MonthInterval { get; set; }

        /// <summary>
        /// Gets or sets the schedule time zone.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The schedule time zone.")]
        public string TimeZone { get; set; }

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
                ExpiryTime = this.ExpiryTime,
                TimeZone = this.TimeZone,
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
                    schedule = this.CreateWeeklyScheduleModel();
                    break;
                case AutomationCmdletParameterSets.ByMonthlyDayOfWeek:
                    schedule = this.CreateMonthlyScheduleModel();
                    break;
                case AutomationCmdletParameterSets.ByMonthlyDaysOfMonth:
                    schedule = this.CreateMonthlyScheduleModel();
                    break;
            }

            Schedule createdSchedule = this.AutomationClient.CreateSchedule(this.ResourceGroupName, this.AutomationAccountName, schedule);
            this.WriteObject(createdSchedule);
        }

        /// <summary>
        /// The validate.
        /// </summary>
        /// <returns>
        /// The <see cref="Schedule"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// throws exception
        /// </exception>
        private Schedule CreateMonthlyScheduleModel()
        {
            var dayOfWeek = this.DayOfWeek.HasValue ? this.DayOfWeek.ToString() : null;
            if ((!string.IsNullOrWhiteSpace(dayOfWeek) && this.DayOfWeekOccurrence == 0) || (string.IsNullOrWhiteSpace(dayOfWeek) && this.DayOfWeekOccurrence != 0))
            {
                throw new ArgumentException(Resources.MonthlyScheduleNeedsDayOfWeekAndOccurrence);
            }

            var newSchedule = new Schedule
            {
                Name = this.Name,
                StartTime = this.StartTime,
                Description = this.Description,
                ExpiryTime = this.ExpiryTime,
                Frequency = ScheduleFrequency.Month,
                Interval = this.MonthInterval,
                MonthlyScheduleOptions = this.IsMonthlyScheduleNull() 
                    ? null
                    : new MonthlyScheduleOptions()
                    {
                        DaysOfMonth = this.DaysOfMonth,
                        DayOfWeek = this.DayOfWeek == null && this.DayOfWeekOccurrence == 0
                            ? null
                            : new DayOfWeek()
                            {
                                Day = dayOfWeek,
                                Occurrence = this.DayOfWeekOccurrence == 0 ? null : this.DayOfWeekOccurrence.ToString()
                            }
                    }
            };

            return newSchedule;
        }

        /// <summary>
        /// The is monthly schedule null.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsMonthlyScheduleNull()
        {
            return this.DaysOfMonth == null && this.DayOfWeek == null && this.DayOfWeekOccurrence == 0;
        }

        /// <summary>
        /// The create weekly schedule model.
        /// </summary>
        /// <returns>
        /// The <see cref="Schedule"/>.
        /// </returns>
        private Schedule CreateWeeklyScheduleModel()
        {
            var newSchedule = new Schedule
            {
                Name = this.Name,
                StartTime = this.StartTime,
                Description = this.Description,
                ExpiryTime = this.ExpiryTime,
                Frequency = ScheduleFrequency.Week,
                Interval = this.WeekInterval,
                WeeklyScheduleOptions = this.DaysOfWeek == null
                    ? null
                    : new WeeklyScheduleOptions()
                    {
                       DaysOfWeek = this.DaysOfWeek.Select(day => day.ToString()).ToList()
                    }
            };

            return newSchedule;
        }
    }

    /// <summary>
    /// The day of week occurrence.
    /// </summary>
    public enum DayOfWeekOccurrence
    {
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4,
        Last = -1
    }

    /// <summary>
    /// The day of week occurrence.
    /// </summary>
    public enum DaysOfMonth
    {
      One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seventh = 7,
        Eighth = 8,
        Ninth = 9,
        Tenth = 10,
        Eleventh =11,
        Twelfth =12,
        Thirteenth = 13,
        Fourteenth = 14,
        Fifteenth = 15,
        Sixteenth = 16,
        Seventeenth = 17,
        Eighteenth = 18,
        Nineteenth = 19,
        Twentieth = 20,
        TwentyFirst = 21,
        TwentySecond = 22,
        TwentyThird = 23,
        TwentyFourth = 24,
        TwentyFifth = 25,
        TwentySixth = 26,
        TwentySeventh = 27,
        TwentyEighth = 28,
        TwentyNinth = 29,
        Thirtieth = 30,
        ThirtyFirst = 31,
        LastDay = -1
    }
}
