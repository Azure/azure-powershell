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
            this.StartTime = AdjustOffset(schedule.Properties.StartTime, schedule.Properties.StartTimeOffsetMinutes);
            this.ExpiryTime = AdjustOffset(schedule.Properties.ExpiryTime, schedule.Properties.ExpiryTimeOffsetMinutes);
            this.CreationTime = schedule.Properties.CreationTime.ToLocalTime();
            this.LastModifiedTime = schedule.Properties.LastModifiedTime.ToLocalTime();
            this.IsEnabled = schedule.Properties.IsEnabled;
            this.NextRun = AdjustOffset(schedule.Properties.NextRun, schedule.Properties.NextRunOffsetMinutes);
            this.Interval = schedule.Properties.Interval ?? this.Interval;
            this.Frequency = (ScheduleFrequency)Enum.Parse(typeof(ScheduleFrequency), schedule.Properties.Frequency, true);
            this.WeeklyScheduleOptions = this.CreateWeeklyScheduleOptions(schedule);
            this.MonthlyScheduleOptions = this.CreateMonthlyScheduleOptions(schedule);
            this.TimeZone = schedule.Properties.TimeZone;
        }

        #region Public Properties

        /// <summary>
        /// Initializes a new instance of the <see cref="Schedule"/> class.
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
        /// Gets or sets the monthly schedule options.
        /// </summary>
        public MonthlyScheduleOptions MonthlyScheduleOptions { get; set; }

        /// <summary>
        /// Gets or sets the weekly schedule options.
        /// </summary>
        public WeeklyScheduleOptions WeeklyScheduleOptions { get; set; }

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
                WeekDays = this.WeeklyScheduleOptions == null ? null : this.WeeklyScheduleOptions.DaysOfWeek,
                MonthDays = (this.MonthlyScheduleOptions == null || this.MonthlyScheduleOptions.DaysOfMonth == null) ? null : this.MonthlyScheduleOptions.DaysOfMonth.Select(v => Convert.ToInt32(v)).ToList(),
                MonthlyOccurrences = (this.MonthlyScheduleOptions == null || this.MonthlyScheduleOptions.DayOfWeek == null)
                    ? null
                    : new AdvancedScheduleMonthlyOccurrence[]
                    {
                        new AdvancedScheduleMonthlyOccurrence()
                        {
                            Day = this.MonthlyScheduleOptions.DayOfWeek.Day,
                            Occurrence = this.GetDayOfWeekOccurrence(this.MonthlyScheduleOptions.DayOfWeek.Occurrence)
                        }
                    }
            };

            return advancedSchedule;
        }

        /// <summary>
        /// Gets or sets the schedule time zone.
        /// </summary>
        public string TimeZone { get; set; }

        #endregion Public Properties

        #region Private Methods

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
            return schedule.WeeklyScheduleOptions == null
                && schedule.MonthlyScheduleOptions == null;
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
        /// The create weekly schedule options.
        /// </summary>
        /// <param name="schedule">
        /// The schedule.
        /// </param>
        /// <returns>
        /// The <see cref="WeeklyScheduleOptions"/>.
        /// </returns>
        private WeeklyScheduleOptions CreateWeeklyScheduleOptions(Microsoft.Azure.Management.Automation.Models.Schedule schedule)
        {
            return schedule.Properties.AdvancedSchedule == null
                ? null
                : new WeeklyScheduleOptions()
                {
                    DaysOfWeek = schedule.Properties.AdvancedSchedule.WeekDays
                };
        }

        /// <summary>
        /// The create monthly schedule options.
        /// </summary>
        /// <param name="schedule">
        /// The schedule.
        /// </param>
        /// <returns>
        /// The <see cref="MonthlyScheduleOptions"/>.
        /// </returns>
        private MonthlyScheduleOptions CreateMonthlyScheduleOptions(
            Microsoft.Azure.Management.Automation.Models.Schedule schedule)
        {
            return schedule.Properties.AdvancedSchedule == null
                || (schedule.Properties.AdvancedSchedule.MonthDays == null && schedule.Properties.AdvancedSchedule.MonthlyOccurrences == null)
                ? null
                : new MonthlyScheduleOptions()
                {
                    DaysOfMonth = this.GetDaysOfMonth(schedule.Properties.AdvancedSchedule.MonthDays),
                    DayOfWeek = this.IsMonthlyOccurrenceNull(schedule.Properties.AdvancedSchedule)
                        ? null
                        : new DayOfWeek()
                        {
                            Day = schedule.Properties.AdvancedSchedule.MonthlyOccurrences.First().Day,
                            Occurrence = this.GetDayOfWeekOccurrence(schedule.Properties.AdvancedSchedule.MonthlyOccurrences.First().Occurrence)
                        }
                };
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

        private static DateTimeOffset? AdjustOffset(DateTimeOffset? dateTimeOffset, double offsetMinutes)
        {
            if (dateTimeOffset.HasValue)
            {
                return AdjustOffset(dateTimeOffset.Value, offsetMinutes);
            }

            return null;
        }

        private static DateTimeOffset AdjustOffset(DateTimeOffset dateTimeOffset, double offsetMinutes)
        {
            var timeSpan = TimeSpan.FromMinutes(offsetMinutes);
            return dateTimeOffset.ToOffset(timeSpan);
        }

        #endregion Private Methods
    }
}
