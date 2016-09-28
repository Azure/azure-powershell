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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Backup simple retention policy class.
    /// </summary>
    public class SimpleRetentionPolicy : RetentionPolicyBase
    {
        public RetentionDurationType RetentionDurationType { get; set; }

        public int RetentionCount { get; set; }

        public override string ToString()
        {
            return string.Format("RetentionDurationType: {0}, Retention Count : {1}",
                        RetentionDurationType.ToString(),
                        RetentionCount);
        }

        public override void Validate()
        {
            base.Validate();

            int weeklyLimit = PolicyConstants.MaxAllowedRetentionDurationCountWeeklySql;
            int monthlyLimit = PolicyConstants.MaxAllowedRetentionDurationCountMonthlySql;
            int yearlyLimit = PolicyConstants.MaxAllowedRetentionDurationCountYearlySql;

            if ((RetentionDurationType == RetentionDurationType.Days) ||
                (RetentionDurationType == RetentionDurationType.Weeks &&
                    (RetentionCount <= 0 || RetentionCount > weeklyLimit)) ||
                (RetentionDurationType == RetentionDurationType.Months &&
                    (RetentionCount <= 0 || RetentionCount > monthlyLimit)) ||
                (RetentionDurationType == RetentionDurationType.Years &&
                    (RetentionCount <= 0 || RetentionCount > yearlyLimit)))
            {
                throw new ArgumentException(Resources.AllowedSqlRetentionRange);
            }
        }
    }

    /// <summary>
    /// Backup long term retention policy class. 
    /// </summary>
    public class LongTermRetentionPolicy : RetentionPolicyBase
    {
        /// <summary>
        /// Specifies if daily schedule is enabled.
        /// </summary>
        public bool IsDailyScheduleEnabled { get; set; }

        /// <summary>
        /// Specifies if weekly schedule is enabled.
        /// </summary>
        public bool IsWeeklyScheduleEnabled { get; set; }

        /// <summary>
        /// Specifies if monthly schedule is enabled.
        /// </summary>
        public bool IsMonthlyScheduleEnabled { get; set; }

        /// <summary>
        /// Specifies if yearly schedule is enabled.
        /// </summary>
        public bool IsYearlyScheduleEnabled { get; set; }

        /// <summary>
        /// Specifies the daily schedule object
        /// </summary>
        public DailyRetentionSchedule DailySchedule { get; set; }

        /// <summary>
        /// Specifies the weekly schedule object
        /// </summary>
        public WeeklyRetentionSchedule WeeklySchedule { get; set; }

        /// <summary>
        /// Specifies the monthly schedule object
        /// </summary>
        public MonthlyRetentionSchedule MonthlySchedule { get; set; }

        /// <summary>
        /// Specifies the yearly schedule object
        /// </summary>
        public YearlyRetentionSchedule YearlySchedule { get; set; }

        public LongTermRetentionPolicy()
        {
            IsDailyScheduleEnabled = false;
            IsWeeklyScheduleEnabled = false;
            IsMonthlyScheduleEnabled = false;
            IsYearlyScheduleEnabled = false;
        }

        /// <summary>
        /// Validates null values and other possible combinations
        /// </summary>
        public override void Validate()
        {
            base.Validate();

            if (IsDailyScheduleEnabled == false && IsWeeklyScheduleEnabled == false &&
                IsMonthlyScheduleEnabled == false && IsYearlyScheduleEnabled == false)
            {
                throw new ArgumentException(Resources.AllRetentionSchedulesEmptyException);
            }

            if (IsDailyScheduleEnabled)
            {
                if (DailySchedule == null)
                {
                    throw new ArgumentException(Resources.DailyScheduleEnabledButScheduleIsNullException);
                }
                else
                {
                    DailySchedule.Validate();
                }
            }

            if (IsWeeklyScheduleEnabled)
            {
                if (WeeklySchedule == null)
                {
                    throw new ArgumentException(Resources.WeeklyScheduleEnabledButScheduleIsNullException);
                }
                else
                {
                    WeeklySchedule.Validate();
                }
            }

            if (IsMonthlyScheduleEnabled)
            {
                if (MonthlySchedule == null)
                {
                    throw new ArgumentException(Resources.MonthlyScheduleEnabledButScheduleIsNullException);
                }
                else
                {
                    MonthlySchedule.Validate();
                }
            }

            if (IsYearlyScheduleEnabled)
            {
                if (YearlySchedule == null)
                {
                    throw new ArgumentException(Resources.YearlyScheduleEnabledButScheduleIsNullException);
                }
                else
                {
                    YearlySchedule.Validate();
                }
            }
        }

        public override string ToString()
        {
            return string.Format("IsDailyScheduleEnabled:{0}, IsWeeklyScheduleEnabled:{1}, " +
                                 "IsMonthlyScheduleEnabled:{2}, IsYearlyScheduleEnabled:{3}" +
                                 "DailySchedule: {4}, WeeklySchedule: {5}, MonthlySchedule:{6}, YearlySchedule:{7}",
                                  IsDailyScheduleEnabled, IsWeeklyScheduleEnabled,
                                  IsMonthlyScheduleEnabled, IsYearlyScheduleEnabled,
                                  DailySchedule == null ? "NULL" : DailySchedule.ToString(),
                                  WeeklySchedule == null ? "NULL" : WeeklySchedule.ToString(),
                                  MonthlySchedule == null ? "NULL" : MonthlySchedule.ToString(),
                                  YearlySchedule == null ? "NULL" : YearlySchedule.ToString());
        }
    }

    /// <summary>
    /// Base class for retention schedule.
    /// </summary>
    public abstract class RetentionScheduleBase
    {
        /// <summary>
        /// List of the days and times representing the retention times
        /// </summary>
        public List<DateTime> RetentionTimes { get; set; }

        public virtual void Validate()
        {
            if (RetentionTimes == null || RetentionTimes.Count == 0 || RetentionTimes.Count != 1)
            {
                throw new ArgumentException(Resources.InvalidRetentionTimesInPolicyException);
            }
        }

        public override string ToString()
        {
            return string.Format("RetentionTimes: {0}", TraceUtils.GetString(RetentionTimes));
        }
    }

    /// <summary>
    /// Daily rentention schedule.
    /// </summary>
    public class DailyRetentionSchedule : RetentionScheduleBase
    {
        /// <summary>
        /// Length of duration in days.
        /// </summary>
        public int DurationCountInDays { get; set; }

        // no extra fields
        public override void Validate()
        {
            if (DurationCountInDays <= 0 || DurationCountInDays > PolicyConstants.MaxAllowedRetentionDurationCount)
            {
                throw new ArgumentException(Resources.RetentionDurationCountInvalidException);
            }

            base.Validate();
        }

        public override string ToString()
        {
            return string.Format("DurationCountInDays: {0}, {1}", DurationCountInDays, base.ToString());
        }
    }

    /// <summary>
    /// Weekly rentention schedule.
    /// </summary>
    public class WeeklyRetentionSchedule : RetentionScheduleBase
    {
        /// <summary>
        /// Length of duration in weeks.
        /// </summary>
        public int DurationCountInWeeks { get; set; }

        /// <summary>
        /// List of the days of the week.
        /// </summary>
        public List<DayOfWeek> DaysOfTheWeek { get; set; }

        public override void Validate()
        {
            if (DurationCountInWeeks <= 0 || DurationCountInWeeks > PolicyConstants.MaxAllowedRetentionDurationCount)
            {
                throw new ArgumentException(Resources.RetentionDurationCountInvalidException);
            }

            if (DaysOfTheWeek == null || DaysOfTheWeek.Count == 0 || DaysOfTheWeek.Count != DaysOfTheWeek.Distinct().Count())
            {
                throw new ArgumentException(Resources.WeeklyRetentionScheduleDaysOfWeekException);
            }

            base.Validate();
        }

        public override string ToString()
        {
            return string.Format("DurationCountInWeeks: {0}, DaysOfTheWeek: {1}, {2}",
                                  DurationCountInWeeks, TraceUtils.GetString(DaysOfTheWeek), base.ToString());
        }
    }

    /// <summary>
    /// Monthly rentention schedule.
    /// </summary>
    public class MonthlyRetentionSchedule : RetentionScheduleBase
    {
        /// <summary>
        /// Length of duration in months.
        /// </summary>
        public int DurationCountInMonths { get; set; }

        /// <summary>
        /// Format type of the retention schedule.
        /// </summary>
        public RetentionScheduleFormat RetentionScheduleFormatType { get; set; }

        /// <summary>
        /// Daily retention schedule object.
        /// </summary>
        public DailyRetentionFormat RetentionScheduleDaily { get; set; }

        /// <summary>
        /// Weekly retention schedule object.
        /// </summary>
        public WeeklyRetentionFormat RetentionScheduleWeekly { get; set; }

        public MonthlyRetentionSchedule()
            : base()
        {
        }

        public override void Validate()
        {
            base.Validate();

            if (DurationCountInMonths <= 0 || DurationCountInMonths > PolicyConstants.MaxAllowedRetentionDurationCount)
            {
                throw new ArgumentException(Resources.RetentionDurationCountInvalidException);
            }

            if (RetentionScheduleFormatType == RetentionScheduleFormat.Daily)
            {
                if (RetentionScheduleDaily == null)
                {
                    throw new ArgumentException(Resources.MonthlyYearlyRetentionDailySchedulePolicyNULLException);
                }

                RetentionScheduleDaily.Validate();
            }

            if (RetentionScheduleFormatType == RetentionScheduleFormat.Weekly)
            {
                if (RetentionScheduleWeekly == null)
                {
                    throw new ArgumentException(Resources.MonthlyYearlyRetentionWeeklySchedulePolicyNULLException);
                }

                RetentionScheduleWeekly.Validate();
            }
        }

        public override string ToString()
        {
            return string.Format("DurationCountInMonths:{0}, RetentionScheduleType:{1}, {2}, RetentionScheduleDaily:{3}," +
                                 "RetentionScheduleWeekly:{4}, {5}",
                                 DurationCountInMonths, RetentionScheduleFormatType, base.ToString(),
                                 RetentionScheduleDaily == null ? "NULL" : RetentionScheduleDaily.ToString(),
                                 RetentionScheduleWeekly == null ? "NULL" : RetentionScheduleWeekly.ToString(),
                                 base.ToString());
        }
    }

    /// <summary>
    /// Yearly rentention schedule.
    /// </summary>
    public class YearlyRetentionSchedule : RetentionScheduleBase
    {
        /// <summary>
        /// Length of duration in years
        /// </summary>
        public int DurationCountInYears { get; set; }

        /// <summary>
        /// Format type of the retention schedule.
        /// </summary>
        public RetentionScheduleFormat RetentionScheduleFormatType { get; set; }

        /// <summary>
        /// List of the months of the year.
        /// </summary>
        public List<Month> MonthsOfYear { get; set; }

        /// <summary>
        /// Daily retention schedule object.
        /// </summary>
        public DailyRetentionFormat RetentionScheduleDaily { get; set; }

        /// <summary>
        /// Weekly retention schedule object.
        /// </summary>
        public WeeklyRetentionFormat RetentionScheduleWeekly { get; set; }

        public YearlyRetentionSchedule()
            : base()
        {

        }

        public override void Validate()
        {
            base.Validate();

            if (DurationCountInYears <= 0 || DurationCountInYears > PolicyConstants.MaxAllowedRetentionDurationCount)
            {
                throw new ArgumentException(Resources.RetentionDurationCountInvalidException);
            }

            if (MonthsOfYear == null || MonthsOfYear.Count == 0 || MonthsOfYear.Count != MonthsOfYear.Distinct().Count())
            {
                throw new ArgumentException(Resources.YearlyScheduleMonthsOfYearException);
            }

            if (RetentionScheduleFormatType == RetentionScheduleFormat.Daily)
            {
                if (RetentionScheduleDaily == null)
                {
                    throw new ArgumentException(Resources.MonthlyYearlyRetentionDailySchedulePolicyNULLException);
                }

                RetentionScheduleDaily.Validate();
            }

            if (RetentionScheduleFormatType == RetentionScheduleFormat.Weekly)
            {
                if (RetentionScheduleWeekly == null)
                {
                    throw new ArgumentException(Resources.MonthlyYearlyRetentionWeeklySchedulePolicyNULLException);
                }

                RetentionScheduleWeekly.Validate();
            }
        }

        public override string ToString()
        {
            return string.Format("DurationCountInYears:{0}, RetentionScheduleType:{1}, {2}, RetentionScheduleDaily:{3}," +
                                 "RetentionScheduleWeekly:{4}, MonthsOfYear: {5}, {6}",
                                 DurationCountInYears, RetentionScheduleFormatType.ToString(), base.ToString(),
                                 RetentionScheduleDaily == null ? "NULL" : RetentionScheduleDaily.ToString(),
                                 RetentionScheduleWeekly == null ? "NULL" : RetentionScheduleWeekly.ToString(),
                                 TraceUtils.GetString<Month>(MonthsOfYear), base.ToString());
        }
    }

    /// <summary>
    /// Daily rentention format.
    /// </summary>
    public class DailyRetentionFormat
    {
        /// <summary>
        /// List of days in the month.
        /// </summary>
        public List<Day> DaysOfTheMonth { get; set; }

        public void Validate()
        {
            if (DaysOfTheMonth == null || DaysOfTheMonth.Count == 0)
            {
                throw new ArgumentException(Resources.InvalidDaysOfMonthInMonthlyYearlyRetentionPolicyException);
            }

            // check if all the days are unique or not
            List<Day> distinctDays = DaysOfTheMonth.GroupBy(x => new { x.Date, x.IsLast }).Select(g => g.First()).ToList();
            if (DaysOfTheMonth.Count != distinctDays.Count)
            {
                throw new ArgumentException(Resources.InvalidDaysOfMonthInMonthlyYearlyRetentionPolicyException);
            }

            // also check if there exists more than one 'IsLast=true'
            int countOfIsLast = 0;
            foreach (Day day in DaysOfTheMonth)
            {
                day.Validate();
                if (day.IsLast)
                {
                    countOfIsLast++;
                }
            }

            if (countOfIsLast > 1)
            {
                throw new ArgumentException(Resources.InvalidDayInDaysOfMonthOfMonthlyYearlyRetentionPolicyException);
            }
        }

        public override string ToString()
        {
            return string.Format("DaysOfTheMonth:{0}", TraceUtils.GetString(DaysOfTheMonth));
        }
    }

    /// <summary>
    /// Weekly rentention format.
    /// </summary>
    public class WeeklyRetentionFormat
    {
        /// <summary>
        /// List of days of the week.
        /// </summary>
        public List<DayOfWeek> DaysOfTheWeek { get; set; }

        /// <summary>
        /// List of weeks of the month.
        /// </summary>
        public List<WeekOfMonth> WeeksOfTheMonth { get; set; }

        public void Validate()
        {
            if (DaysOfTheWeek == null || DaysOfTheWeek.Count == 0 ||
                DaysOfTheWeek.Count != DaysOfTheWeek.Distinct().Count())
            {
                throw new ArgumentException(Resources.InvalidDaysOfWeekInMonthlyYearlyRetentionPolicyException);
            }

            if (WeeksOfTheMonth == null || WeeksOfTheMonth.Count == 0 ||
                WeeksOfTheMonth.Count != WeeksOfTheMonth.Distinct().Count())
            {
                throw new ArgumentException(Resources.InvalidWeeksOfMonthInMonthlyYearlyRetentionPolicyException);
            }
        }

        public override string ToString()
        {
            return string.Format("DaysOfTheWeek:{0}, WeeksOfTheMonth:{1}",
                                  TraceUtils.GetString(DaysOfTheWeek),
                                  TraceUtils.GetString<WeekOfMonth>(WeeksOfTheMonth));
        }
    }

    /// <summary>
    /// Day class to be used by retention policy.
    /// </summary>
    public class Day
    {
        /// <summary>
        /// Date component of the day.
        /// </summary>
        public int Date { get; set; }

        /// <summary>
        /// Specifies if this is the last date in the month.
        /// </summary>
        public bool IsLast { get; set; }

        public Day()
        {
            this.Date = 1;
            this.IsLast = false;
        }
        public void Validate()
        {
            if (IsLast == false && (Date <= 0 || Date > PolicyConstants.MaxAllowedDateInMonth))
            {
                throw new ArgumentException(Resources.InvalidDayInDaysOfMonthOfMonthlyYearlyRetentionPolicyException);
            }
        }

        public override string ToString()
        {
            return string.Format("Date:{0}, IsLast:{1}", Date, IsLast);
        }
    }

    public class RetentionDuration
    {
        public RetentionDurationType RetentionDurationType { get; set; }

        public int RetentionCount { get; set; }

        public void Validate()
        {
            if (RetentionCount <= 0 || 
                RetentionCount > PolicyConstants.MaxAllowedRetentionDurationCount)
            {
                throw new ArgumentException(Resources.RetentionDurationCountInvalidException);
            }
        }
    }
}
