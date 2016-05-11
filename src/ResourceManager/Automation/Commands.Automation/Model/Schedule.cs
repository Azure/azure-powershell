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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Language;
using Microsoft.Azure.Commands.Automation.Cmdlet;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Properties;
using System;
using Microsoft.Azure.Management.Automation.Models;

namespace Microsoft.Azure.Commands.Automation.Model
{
    /// <summary>
    /// The Schedule.
    /// </summary>
    public class Schedule : BaseProperties
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Schedule"/> class.
        /// </summary>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="automationAccountName">
        /// The automation account name.
        /// </param> 
        /// <param name="schedule">
        /// The schedule.
        /// </param>
        public Schedule(string resourceGroupName, string automationAccountName, Azure.Management.Automation.Models.Schedule schedule)
        {
            Requires.Argument("schedule", schedule).NotNull();
            this.ResourceGroupName = resourceGroupName;
            this.AutomationAccountName = automationAccountName;
            this.Name = schedule.Name;
            this.Description = schedule.Properties.Description;
            this.StartTime = schedule.Properties.StartTime.ToLocalTime();
            this.ExpiryTime = schedule.Properties.ExpiryTime.ToLocalTime();
            this.CreationTime = schedule.Properties.CreationTime.ToLocalTime();
            this.LastModifiedTime = schedule.Properties.LastModifiedTime.ToLocalTime();
            this.IsEnabled = schedule.Properties.IsEnabled;
            this.NextRun = schedule.Properties.NextRun.HasValue
                               ? schedule.Properties.NextRun.Value.ToLocalTime()
                               : this.NextRun;
            this.Interval = schedule.Properties.Interval.HasValue ? schedule.Properties.Interval.Value : this.Interval;
            this.Frequency = (ScheduleFrequency)Enum.Parse(typeof(ScheduleFrequency), schedule.Properties.Frequency, true);
            this.DaysOfWeek = schedule.Properties.AdvancedSchedule == null
                ? null
                : schedule.Properties.AdvancedSchedule.WeekDays;
            this.DaysOfMonth = schedule.Properties.AdvancedSchedule == null
                ? null
                : this.GetDaysOfMonth(schedule.Properties.AdvancedSchedule.MonthDays);
            this.DayOfWeek = this.IsMonthlyOccurrenceNull(schedule.Properties.AdvancedSchedule)
                ? null
                : schedule.Properties.AdvancedSchedule.MonthlyOccurrences.First().Day;
            this.DayOfWeekOccurrence = this.IsMonthlyOccurrenceNull(schedule.Properties.AdvancedSchedule)
                ? null
                : this.GetDayOfWeekOccurrence(schedule.Properties.AdvancedSchedule.MonthlyOccurrences.First().Occurrence);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HourlySchedule"/> class.
        /// </summary>
        public Schedule()
        {
        }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// Gets or sets the expiry time.
        /// </summary>
        public DateTimeOffset ExpiryTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is enabled.
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the next run.
        /// </summary>
        public DateTimeOffset? NextRun { get; set; }

        /// <summary>
        /// Gets or sets the schedule interval.
        /// </summary>
        public byte? Interval { get; set; }

        /// <summary>
        /// Gets or sets the schedule frequency.
        /// </summary>
        public ScheduleFrequency Frequency { get; set; }

        /// <summary>
        /// Gets or sets the schedule days of the week.
        /// </summary>
        public IList<string> DaysOfWeek { get; set; }

        /// <summary>
        /// Gets or sets the schedule days of the month.
        /// </summary>
        public IList<DaysOfMonth> DaysOfMonth { get; set; }

        /// <summary>
        /// Gets or sets the schedule day of the week.
        /// </summary>
        public string DayOfWeek { get; set; }

        /// <summary>
        /// Gets or sets the schedule day of the week occurrence.
        /// </summary>
        public string DayOfWeekOccurrence { get; set; }

        /// <summary>
        /// The create advanced schedule.
        /// </summary>
        /// <returns>
        /// The <see cref="AdvancedSchedule"/>.
        /// </returns>
        public AdvancedSchedule GetAdvancedSchedule()
        {
            if (this.AdvancedScheduleIsNull(this))
            {
                return null;
            }

            var advancedSchedule = new AdvancedSchedule()
            {
                WeekDays = this.DaysOfWeek,
                MonthDays = this.DaysOfMonth == null ? null : this.DaysOfMonth.Select(v => Convert.ToInt32(v)).ToList(),
                MonthlyOccurrences = string.IsNullOrWhiteSpace(this.DayOfWeek) && this.DayOfWeekOccurrence == null
                    ? null
                    : new AdvancedScheduleMonthlyOccurrence[]
                    {
                        new AdvancedScheduleMonthlyOccurrence()
                        {
                            Day = this.DayOfWeek,
                            Occurrence = this.GetDayOfWeekOccurrence(this.DayOfWeekOccurrence)
                        }
                    }
            };

            return advancedSchedule;
        }

        /// <summary>
        /// The is null or empty list.
        /// </summary>
        /// <param name="list">
        /// The list.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsNullOrEmptyList<T>(IList<T> list)
        {
            return list == null || list.Count == 0;
        }

        /// <summary>
        /// The is monthly occurrence null.
        /// </summary>
        /// <param name="advancedSchedule">
        /// The advanced schedule.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsMonthlyOccurrenceNull(Azure.Management.Automation.Models.AdvancedSchedule advancedSchedule)
        {
            return advancedSchedule == null || this.IsNullOrEmptyList(advancedSchedule.MonthlyOccurrences);
        }

        /// <summary>
        /// The advanced schedule is null.
        /// </summary>
        /// <param name="schedule">
        /// The schedule.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool AdvancedScheduleIsNull(Schedule schedule)
        {
            return (schedule.DaysOfWeek == null
                && schedule.DaysOfMonth == null
                && string.IsNullOrWhiteSpace(schedule.DayOfWeek)
                && schedule.DayOfWeekOccurrence == null);
        }

        /// <summary>
        /// The get day of week occurrence.
        /// </summary>
        /// <param name="dayOfWeekOccurrence">
        /// The day of week occurrence.
        /// </param>
        /// <returns>
        /// The <see cref="int?"/>.
        /// </returns>
        private int? GetDayOfWeekOccurrence(string dayOfWeekOccurrence)
        {
            if (string.IsNullOrWhiteSpace(dayOfWeekOccurrence))
            {
                return null;
            }

            return Convert.ToInt32(Enum.Parse(typeof(DayOfWeekOccurrence), dayOfWeekOccurrence));
        }

        /// <summary>
        /// The get day of week occurrence.
        /// </summary>
        /// <param name="dayOfWeekOccurrence">
        /// The day of week occurrence.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetDayOfWeekOccurrence(int? dayOfWeekOccurrence)
        {
            return dayOfWeekOccurrence.HasValue
                ? Enum.GetName(typeof(DayOfWeekOccurrence), dayOfWeekOccurrence)
                : null;
        }

        /// <summary>
        /// The get days of month.
        /// </summary>
        /// <param name="daysOfMonth">
        /// The days of month.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        private IList<DaysOfMonth> GetDaysOfMonth(IList<int> daysOfMonth)
        {
            return daysOfMonth.Select(value => (DaysOfMonth)value).ToList();
        }
    }
}
