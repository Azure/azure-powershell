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

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    public class AzureRmRecoveryServicesLongTermRetentionPolicy : AzureRmRecoveryServicesRetentionPolicyBase
    {
        public DailyRetentionSchedule DailySchedule { get; set; }
        public WeeklyRetentionSchedule WeeklySchedule { get; set; }        
        public MonthlyRetentionSchedule MonthlySchedule { get; set; }
        public YearlyRetentionSchedule YearlySchedule { get; set; }

        public override void Validate()
        {
            if (DailySchedule == null && WeeklySchedule == null &&
                MonthlySchedule == null && YearlySchedule == null)
            {
                throw new ArgumentException("All schedules Daily/Weekly/Monthly/yearly are null");
            }

            if (DailySchedule != null)
            {
                DailySchedule.Validate();
            }

            if (WeeklySchedule != null)
            {
                WeeklySchedule.Validate();
            }

            if (MonthlySchedule != null)
            {
                MonthlySchedule.Validate();
            }

            if (YearlySchedule != null)
            {
                YearlySchedule.Validate();
            }
        }       

        public override string ToString()
        {
            return string.Format("DailySchedule: {0}, WeeklySchedule: {1}, MonthlySchedule:{2}, YearlySchedule:{3}",
                                  DailySchedule == null ? "NULL" : DailySchedule.ToString(),
                                  WeeklySchedule == null ? "NULL" : WeeklySchedule.ToString(),
                                  MonthlySchedule == null ? "NULL" : MonthlySchedule.ToString(),
                                  YearlySchedule == null ? "NULL" : YearlySchedule.ToString());
        }
    }
       
    public class RetentionDuration
    {     
        public int Count { get; set; }    
        public string DurationType { get; set; }

        public RetentionDuration()
        {
            this.Count = 0;
            this.DurationType = RetentionDurationType.Invalid.ToString();
        }

        public void Validate()
        {
            RetentionDurationType durationType;
            if (!Enum.TryParse<RetentionDurationType>(DurationType, out durationType) || durationType == RetentionDurationType.Invalid)
            {
                throw new ArgumentException("DurationType is set to Invalid");
            }

            if (Count <= 0 || Count > PolicyConstants.MaxAllowedRetentionDurationCount)
            {
                throw new ArgumentException(string.Format("Allowed Count for RetentionDuration is 1 - {0} for Type: {1}",
                                            PolicyConstants.MaxAllowedRetentionDurationCount, DurationType.ToString()));
            }
        }

        public override string ToString()
        {
            return string.Format("Count: {0}, DurationType: {1}",
                                  Count, DurationType.ToString());
        }
    }
  
    public abstract class RetentionScheduleBase
    {
        public List<DateTime> RetentionTimes { get; set; }
        public RetentionDuration RetentionDuration { get; set; }

        public virtual void Validate()
        {
            if (RetentionTimes == null || RetentionTimes.Count == 0)
            {
                throw new ArgumentException("RetentionTime is NULL/Empty");
            }
            if (RetentionTimes.Count != 1)
            {
                throw new ArgumentException("Only one RetentionTime is Allowed");
            }

            if (RetentionDuration == null)
            {
                throw new ArgumentException("RetentionDuration is NULL");
            }

            RetentionDuration.Validate();
        }

        public virtual void ValidateWithBackupScheduleTimes(List<DateTime> backupTimes)
        {
            //Currently supported BackupTimes  & retentionTimes is 1
            //Need to change it once we support multiple values
            if (RetentionTimes.Count != 1)
            {
                throw new ArgumentException("Only one RetentionTime is Allowed");
            }
            if (backupTimes.Count != 1)
            {
                throw new ArgumentException("Only one BackupTime is Allowed");
            }
            if (backupTimes[0] != RetentionTimes[0])
            {
                throw new ArgumentException("RetentionTime in retention schedule should be same as backup time");
            }
        }

        public override string ToString()
        {
            return string.Format("RetentionTime: {0}, RetentionDuration:{1}",
                                  TraceUtils.GetString(RetentionTimes),
                                  RetentionDuration.ToString());
        }
    }
      
    public class DailyRetentionSchedule : RetentionScheduleBase
    {
        // no extra fields
        public override void Validate()
        {
            base.Validate();
        }

        public override void ValidateWithBackupScheduleTimes(List<DateTime> backupTimes)
        {
            base.ValidateWithBackupScheduleTimes(backupTimes);
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
   
    public class WeeklyRetentionSchedule : RetentionScheduleBase
    {
        public List<string> DaysOfTheWeek { get; set; }

        public override void Validate()
        {
            if (DaysOfTheWeek == null || DaysOfTheWeek.Count == 0)
            {
                throw new ArgumentException("DaysOfTheWeek is NULL/Empty");
            }

            // validate if daysOfWeek strings are correct
            foreach (string day in DaysOfTheWeek)
            {
                DayOfWeek weekDay;
                if (!Enum.TryParse<DayOfWeek>(day, out weekDay))
                {
                    throw new ArgumentException("DaysOfTheWeek content is Invalid");
                }
            }

            base.Validate();
        }

        //Verify That List of Days Of Week is same as schedule DOW
        public void ValidateWithBackupScheduleDOW(List<string> backupDOWList)
        {
            if (backupDOWList.Count != DaysOfTheWeek.Count)
            {
                throw new ArgumentException("DaysOfTheWeek of retention schedule  must be same of backup schedule DaysOfTheWeek");
            }
            foreach (var day in DaysOfTheWeek)
            {
                if (!backupDOWList.Contains(day))
                {
                    throw new ArgumentException("DaysOfTheWeek of retention schedule  must be same of backup schedule DaysOfTheWeek");
                }

            }
        }

        public override void ValidateWithBackupScheduleTimes(List<DateTime> backupTimes)
        {
            base.ValidateWithBackupScheduleTimes(backupTimes);
        }

        public override string ToString()
        {
            return string.Format("DaysOfTheWeek: {0}, {1}",
                                  TraceUtils.GetString(DaysOfTheWeek),
                                  base.ToString());
        }
    }
  
    public class MonthlyRetentionSchedule : RetentionScheduleBase
    {
        public string RetentionScheduleFormatType { get; set; }

        public DailyRetentionFormat RetentionScheduleDaily { get; set; }
        public WeeklyRetentionFormat RetentionScheduleWeekly { get; set; }

        public MonthlyRetentionSchedule()
            : base()
        {
            this.RetentionScheduleFormatType = RetentionScheduleFormat.Invalid.ToString();
        }

        public override void Validate()
        {
            base.Validate();

            RetentionScheduleFormat retSchFormat;
            if (!Enum.TryParse<RetentionScheduleFormat>(RetentionScheduleFormatType, out retSchFormat))
            {
                throw new ArgumentException("RetentionScheduleType content is Invalid");
            }

            if (retSchFormat == RetentionScheduleFormat.Invalid)
            {
                throw new ArgumentException("RetentionScheduleType is set to Invalid");
            }

            if (retSchFormat == RetentionScheduleFormat.Daily)
            {
                if (RetentionScheduleDaily == null)
                {
                    throw new ArgumentException("RetentionScheduleDaily is set to NULL");
                }

                RetentionScheduleDaily.Validate();
            }

            if (retSchFormat == RetentionScheduleFormat.Weekly)
            {
                if (RetentionScheduleWeekly == null)
                {
                    throw new ArgumentException("RetentionScheduleWeekly is set to NULL");
                }

                RetentionScheduleWeekly.Validate();
            }
        }

        public override void ValidateWithBackupScheduleTimes(List<DateTime> backupTimes)
        {
            base.ValidateWithBackupScheduleTimes(backupTimes);
        }

        public void ValidateForWeeklyBackupSchedule(List<string> backupScheduleRunDays)
        {
            if (RetentionScheduleFormatType == RetentionScheduleFormat.Daily.ToString())
            {
                throw new ArgumentException("Days of the month is not allowed for weekly backup Schedules ");
            }
            foreach (var day in RetentionScheduleWeekly.DaysOfTheWeek)
            {
                if (!backupScheduleRunDays.Contains(day))
                {
                    throw new ArgumentException("Days of the week list in Monthly Schedule should subset of Day of week list in Backup Schedule");
                }
            }
        }

        public override string ToString()
        {
            return string.Format("RetentionScheduleType:{0}, {1}, RetentionScheduleDaily:{2}," +
                                 "RetentionScheduleWeekly:{3}", RetentionScheduleFormatType, base.ToString(),
                                 RetentionScheduleDaily == null ? "NULL" : RetentionScheduleDaily.ToString(),
                                 RetentionScheduleWeekly == null ? "NULL" : RetentionScheduleWeekly.ToString());
        }
    }
  
    public class YearlyRetentionSchedule : RetentionScheduleBase
    {
  
        public string RetentionScheduleFormatType { get; set; }

        public List<string> MonthsOfYear { get; set; }
        public DailyRetentionFormat RetentionScheduleDaily { get; set; }
    
        public WeeklyRetentionFormat RetentionScheduleWeekly { get; set; }

        public YearlyRetentionSchedule()
            : base()
        {
            this.RetentionScheduleFormatType = RetentionScheduleFormat.Invalid.ToString();
        }

        public override void Validate()
        {
            base.Validate();

            RetentionScheduleFormat retSchFormat;
            if (!Enum.TryParse<RetentionScheduleFormat>(RetentionScheduleFormatType, out retSchFormat))
            {
                throw new ArgumentException("RetentionScheduleType content is Invalid");
            }

            if (retSchFormat == RetentionScheduleFormat.Invalid)
            {
                throw new ArgumentException("RetentionScheduleType is set to Invalid");
            }

            if (MonthsOfYear == null || MonthsOfYear.Count == 0)
            {
                throw new ArgumentException("MonthsOfYear is set to NULL/Empty");
            }

            // validate if MonthsOfYear strings are correct
            foreach (string month in MonthsOfYear)
            {
                Month enumMonth;
                if (!Enum.TryParse<Month>(month, out enumMonth))
                {
                    throw new ArgumentException("MonthsOfYear content is Invalid");
                }
            }

            if (retSchFormat == RetentionScheduleFormat.Daily)
            {
                if (RetentionScheduleDaily == null)
                {
                    throw new ArgumentException("RetentionScheduleDaily is set to NULL");
                }

                RetentionScheduleDaily.Validate();
            }

            if (retSchFormat == RetentionScheduleFormat.Weekly)
            {
                if (RetentionScheduleWeekly == null)
                {
                    throw new ArgumentException("RetentionScheduleWeekly is set to NULL");
                }

                RetentionScheduleWeekly.Validate();
            }
        }

        public void ValidateForWeeklyBackupSchedule(List<string> backupScheduleRunDays)
        {
            if (RetentionScheduleFormatType == RetentionScheduleFormat.Daily.ToString())
            {
                throw new ArgumentException("Days of the Month is not allowed for weekly backup Schedules ");
            }
            foreach (var day in RetentionScheduleWeekly.DaysOfTheWeek)
            {
                if (!backupScheduleRunDays.Contains(day))
                {
                    throw new ArgumentException("Days of the week list  in Yearly Schedule should subset of Day of week list in Backup Schedule");
                }
            }
        }

        public override string ToString()
        {
            return string.Format("RetentionScheduleType:{0}, {1}, RetentionScheduleDaily:{2}," +
                                 "RetentionScheduleWeekly:{3}, MonthsOfYear: {4}",
                                 RetentionScheduleFormatType.ToString(),
                                 base.ToString(),
                                 RetentionScheduleDaily == null ? "NULL" : RetentionScheduleDaily.ToString(),
                                 RetentionScheduleWeekly == null ? "NULL" : RetentionScheduleWeekly.ToString(),
                                  TraceUtils.GetString(MonthsOfYear));
        }
    }
        
    public class DailyRetentionFormat
    {
        public List<Day> DaysOfTheMonth { get; set; }

        public void Validate()
        {
            if (DaysOfTheMonth == null || DaysOfTheMonth.Count == 0)
            {
                throw new ArgumentException("DaysOfThe Month is set to NULL/Empty");
            }
        }

        public override string ToString()
        {
            return string.Format("DaysOfTheMonth:{0}", TraceUtils.GetString(DaysOfTheMonth));
        }
    }
      
    public class WeeklyRetentionFormat
    {
        public List<string> DaysOfTheWeek { get; set; }

        public List<string> WeeksOfTheMonth { get; set; }

        public void Validate()
        {
            if (DaysOfTheWeek == null || DaysOfTheWeek.Count == 0)
            {
                throw new ArgumentException(" DaysOfTheWeek is set to NULL/Empty");
            }

            // validate if daysOfWeek strings are correct
            foreach (string day in DaysOfTheWeek)
            {
                DayOfWeek weekDay;
                if (!Enum.TryParse<DayOfWeek>(day, out weekDay))
                {
                    throw new ArgumentException("DaysOfTheWeek content is Invalid");
                }
            }

            if (WeeksOfTheMonth == null || WeeksOfTheMonth.Count == 0)
            {
                throw new ArgumentException("WeeksOfTheMonth is set to NULL/Empty");
            }

            // validate if WeeksOfTheMonth strings are correct
            foreach (string week in WeeksOfTheMonth)
            {
                WeekNumber weekNumber;
                if (!Enum.TryParse<WeekNumber>(week, out weekNumber))
                {
                    throw new ArgumentException("WeeksOfTheMonth content is Invalid");
                }
            }
        }

        public override string ToString()
        {
            return string.Format("DaysOfTheWeek:{0}, WeeksOfTheMonth:{1}",
                                  TraceUtils.GetString(DaysOfTheWeek),
                                  TraceUtils.GetString(WeeksOfTheMonth));
        }
    }

    public class Day
    {
        public int Date { get; set; }

        public bool IsLast { get; set; }

        public Day()
        {
            this.Date = 1;
            this.IsLast = false;
        }
        public void Validate()
        {
            if (IsLast == false && (Date <= 0 || Date > 28))
            {
                throw new ArgumentException("Days in DaysOfTheMonth should have IsLast = true  or date should be 1-28");
            }
        }

        public override string ToString()
        {
            return string.Format("Date:{0}, IsLast:{1}", Date, IsLast);
        }
    }   
}
