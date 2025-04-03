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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using BackupManagementType = Microsoft.Azure.Management.RecoveryServices.Backup.Models.BackupManagementType;

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

        /// <summary>
        /// BackupManagement Type associated with the policy
        /// </summary>
        public string BackupManagementType { get; set; }

        public LongTermRetentionPolicy(string backupManagementType = "")
        {
            IsDailyScheduleEnabled = false;
            IsWeeklyScheduleEnabled = false;
            IsMonthlyScheduleEnabled = false;
            IsYearlyScheduleEnabled = false;
            this.BackupManagementType = backupManagementType;
        }

        public override void Validate()
        {
            // redirecting to overloaded method
            Validate(0);
        }

        /// <summary>
        /// Validates null values and other possible combinations
        /// </summary>
        public void Validate(ScheduleRunType ScheduleRunFrequency = 0)
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
                    DailySchedule.BackupManagementType = BackupManagementType;
                    DailySchedule.Validate(ScheduleRunFrequency);
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
                    WeeklySchedule.BackupManagementType = BackupManagementType;
                    WeeklySchedule.Validate(ScheduleRunFrequency);
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
                    MonthlySchedule.BackupManagementType = BackupManagementType;
                    MonthlySchedule.Validate(ScheduleRunFrequency);
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
                    YearlySchedule.BackupManagementType = BackupManagementType;
                    YearlySchedule.Validate(ScheduleRunFrequency);
                }
            }
        }

        public override string ToString()
        {
            return string.Format("IsDailyScheduleEnabled:{0}, IsWeeklyScheduleEnabled:{1}, " +
                                 "IsMonthlyScheduleEnabled:{2}, IsYearlyScheduleEnabled:{3} " +
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
    /// Backup vault retention policy class. 
    /// </summary>
    public class VaultRetentionPolicy : LongTermRetentionPolicy
    {
        /// <summary>
        /// Object defining the retention days for a snapshot
        /// </summary>
        public int SnapshotRetentionInDays { get; set; }

        public VaultRetentionPolicy(string backupManagementType = "")
        {
            SnapshotRetentionInDays = 5;
            IsDailyScheduleEnabled = false;
            IsWeeklyScheduleEnabled = false;
            IsMonthlyScheduleEnabled = false;
            IsYearlyScheduleEnabled = false;
            this.BackupManagementType = backupManagementType;
        }

        public override void Validate()
        {
            // redirecting to overloaded method
            Validate(0);
        }

        /// <summary>
        /// Validates null values and other possible combinations
        /// </summary>
        public new void Validate(ScheduleRunType ScheduleRunFrequency = 0)
        {
            int MinDurationCountInDays = 1, MaxDurationCountInDays = PolicyConstants.AfsSnapshotRetentionDaysMax;
            
            if (SnapshotRetentionInDays < MinDurationCountInDays || SnapshotRetentionInDays > MaxDurationCountInDays) 
            {
                throw new ArgumentException(Resources.SnapshotRetentionInDaysInvalidException);
            }

            if (IsDailyScheduleEnabled)
            {
                if (DailySchedule == null)
                {
                    throw new ArgumentException(Resources.DailyScheduleEnabledButScheduleIsNullException);
                }
                else
                {
                    DailySchedule.BackupManagementType = BackupManagementType;
                    DailySchedule.Validate(ScheduleRunFrequency, PolicyConstants.AfsDailyRetentionDaysMin, PolicyConstants.AfsVaultDailyRetentionDaysMax);
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
                    WeeklySchedule.BackupManagementType = BackupManagementType;
                    WeeklySchedule.Validate(ScheduleRunFrequency, PolicyConstants.AfsWeeklyRetentionMin, PolicyConstants.AfsVaultWeeklyRetentionMax);
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
                    MonthlySchedule.BackupManagementType = BackupManagementType;
                    MonthlySchedule.Validate(ScheduleRunFrequency, PolicyConstants.AfsMonthlyRetentionMin, PolicyConstants.AfsVaultMonthlyRetentionMax);
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
                    YearlySchedule.BackupManagementType = BackupManagementType;
                    YearlySchedule.Validate(ScheduleRunFrequency, PolicyConstants.AfsYearlyRetentionMin, PolicyConstants.AfsVaultYearlyRetentionMax);
                }
            }
        }

        public override string ToString()
        {
            return string.Format("SnapshotRetentionInDays:{0}, IsDailyScheduleEnabled:{1}, IsWeeklyScheduleEnabled:{2}, " +
                                 "IsMonthlyScheduleEnabled:{3}, IsYearlyScheduleEnabled:{4} " +
                                 "DailySchedule: {5}, WeeklySchedule: {6}, MonthlySchedule:{7}, YearlySchedule:{8}",
                                  SnapshotRetentionInDays, IsDailyScheduleEnabled, IsWeeklyScheduleEnabled,
                                  IsMonthlyScheduleEnabled, IsYearlyScheduleEnabled,
                                  DailySchedule == null ? "NULL" : DailySchedule.ToString(),
                                  WeeklySchedule == null ? "NULL" : WeeklySchedule.ToString(),
                                  MonthlySchedule == null ? "NULL" : MonthlySchedule.ToString(),
                                  YearlySchedule == null ? "NULL" : YearlySchedule.ToString());
        }
    }

    public class SQLRetentionPolicy : RetentionPolicyBase
    {
        /// <summary>
        /// Full backup retention policy object
        /// </summary>
        public LongTermRetentionPolicy FullBackupRetentionPolicy { get; set; }

        /// <summary>
        /// Differential backup retention policy object
        /// </summary>
        public SimpleRetentionPolicy DifferentialBackupRetentionPolicy { get; set; }

        /// <summary>
        /// Log backup retention policy object
        /// </summary>
        public SimpleRetentionPolicy LogBackupRetentionPolicy { get; set; }

        public SQLRetentionPolicy()
        {
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

        /// <summary>
        /// BackupManagement Type of the retention policy
        /// </summary>
        public string BackupManagementType { get; set; }

        public virtual void Validate(ScheduleRunType ScheduleRunFrequency = 0)
        {
            if(ScheduleRunFrequency != ScheduleRunType.Hourly) // RetentionTimes are not needed for Hourly policy
            {
                if (RetentionTimes == null || RetentionTimes.Count != 1)
                {
                    throw new ArgumentException(Resources.InvalidRetentionTimesInPolicyException);
                }
            }
        }

        public override string ToString()
        {
            return string.Format("RetentionTimes: {0}", TraceUtils.GetString(RetentionTimes));
        }
    }

    /// <summary>
    /// Daily retention schedule.
    /// </summary>
    public class DailyRetentionSchedule : RetentionScheduleBase
    {
        /// <summary>
        /// Length of duration in days.
        /// </summary>
        public int DurationCountInDays { get; set; }

        // no extra fields
        public void Validate(ScheduleRunType ScheduleRunFrequency = 0, int MinDuration = 0, int MaxDuration = 0)
        {
            int MinDurationCountInDays = 7, MaxDurationCountInDays = PolicyConstants.MaxAllowedRetentionDurationCount;
            if(BackupManagementType == Management.RecoveryServices.Backup.Models.BackupManagementType.AzureStorage)
            {
                if (MinDuration != 0 && MaxDuration != 0)
                {
                    MinDurationCountInDays = MinDuration;
                    MaxDurationCountInDays = MaxDuration;
                }
                else
                {
                    MinDurationCountInDays = PolicyConstants.AfsDailyRetentionDaysMin;
                    MaxDurationCountInDays = PolicyConstants.AfsDailyRetentionDaysMax;
                }     
            }

            if (DurationCountInDays < MinDurationCountInDays || DurationCountInDays > MaxDurationCountInDays)
            {
                throw new ArgumentException(string.Format(Resources.RetentionDurationCountInvalidException, "Days", MinDurationCountInDays, MaxDurationCountInDays));
            }
                        
            base.Validate(ScheduleRunFrequency);
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

        public void Validate(ScheduleRunType ScheduleRunFrequency = 0, int MinDuration = 0, int MaxDuration = 0)
        {
            int MinDurationCountInWeeks = 1, MaxDurationCountInWeeks = PolicyConstants.MaxAllowedRetentionDurationCountWeekly;
            if(BackupManagementType == Management.RecoveryServices.Backup.Models.BackupManagementType.AzureStorage)
            {
                if (MinDuration != 0 && MaxDuration != 0)
                {
                    MinDurationCountInWeeks = MinDuration;
                    MaxDurationCountInWeeks = MaxDuration;
                }
                else
                {
                    MinDurationCountInWeeks = PolicyConstants.AfsWeeklyRetentionMin;
                    MaxDurationCountInWeeks = PolicyConstants.AfsWeeklyRetentionMax;
                }
            }

            if (DurationCountInWeeks < MinDurationCountInWeeks || DurationCountInWeeks > MaxDurationCountInWeeks)
            {
                throw new ArgumentException(string.Format(Resources.RetentionDurationCountInvalidException, "Weeks", MinDurationCountInWeeks, MaxDurationCountInWeeks));
            }

            if (DaysOfTheWeek == null || DaysOfTheWeek.Count == 0 || DaysOfTheWeek.Count != DaysOfTheWeek.Distinct().Count())
            {
                throw new ArgumentException(Resources.WeeklyRetentionScheduleDaysOfWeekException);
            }

            base.Validate(ScheduleRunFrequency);
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

        public void Validate(ScheduleRunType ScheduleRunFrequency = 0, int MinDuration = 0, int MaxDuration = 0)
        {
            base.Validate(ScheduleRunFrequency);

            int MinDurationCountInMonths = 1, MaxDurationCountInMonths = PolicyConstants.MaxAllowedRetentionDurationCountMonthly;
            if (BackupManagementType == Management.RecoveryServices.Backup.Models.BackupManagementType.AzureStorage)
            {
                if (MinDuration != 0 && MaxDuration != 0)
                {
                    MinDurationCountInMonths = MinDuration;
                    MaxDurationCountInMonths = MaxDuration;
                }
                else
                {
                    MinDurationCountInMonths = PolicyConstants.AfsMonthlyRetentionMin;
                    MaxDurationCountInMonths = PolicyConstants.AfsMonthlyRetentionMax;
                }
            }

            if (DurationCountInMonths < MinDurationCountInMonths || DurationCountInMonths > MaxDurationCountInMonths)
            {
                throw new ArgumentException(string.Format(Resources.RetentionDurationCountInvalidException, "Months", MinDurationCountInMonths, MaxDurationCountInMonths));
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

public void Validate(ScheduleRunType ScheduleRunFrequency = 0, int MinDuration = 0, int MaxDuration = 0)
        {
            base.Validate(ScheduleRunFrequency);

            int MinDurationCountInYears = 1, MaxDurationCountInYears = PolicyConstants.MaxAllowedRetentionDurationCountYearly;
            if (BackupManagementType == Management.RecoveryServices.Backup.Models.BackupManagementType.AzureStorage)
            {
                if (MinDuration != 0 && MaxDuration != 0)
                {
                    MinDurationCountInYears = MinDuration;
                    MaxDurationCountInYears = MaxDuration;
                }
                else
                {
                    MinDurationCountInYears = PolicyConstants.AfsYearlyRetentionMin;
                    MaxDurationCountInYears = PolicyConstants.AfsYearlyRetentionMax;
                }
            }

            if (DurationCountInYears < MinDurationCountInYears || DurationCountInYears > MaxDurationCountInYears)
            {
                throw new ArgumentException(string.Format(Resources.RetentionDurationCountInvalidException, "Years", MinDurationCountInYears, MaxDurationCountInYears));
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
                                 TraceUtils.GetString(MonthsOfYear), base.ToString());
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
                                  TraceUtils.GetString(WeeksOfTheMonth));
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
            Date = 1;
            IsLast = false;
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
