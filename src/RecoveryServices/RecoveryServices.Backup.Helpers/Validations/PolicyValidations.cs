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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    /// <summary>
    /// Backup policy validation helpers.
    /// </summary>
    public partial class PolicyHelpers
    {
        /// <summary>
        /// Helper function to validate long term rentention policy and simple schedule policy.
        /// </summary>
        public static void ValidateLongTermRetentionPolicyWithSimpleSchedulePolicy(
            LongTermRetentionPolicy ltrPolicy,
            SimpleSchedulePolicy schPolicy)
        {
            // for daily schedule, daily retention policy is required
            if (schPolicy.ScheduleRunFrequency == ScheduleRunType.Daily &&
               (ltrPolicy.DailySchedule == null || ltrPolicy.IsDailyScheduleEnabled == false))
            {
                throw new ArgumentException(Resources.DailyRetentionScheduleNullException);
            }
            
            // for weekly schedule, daily retention policy should be NULL
            // AND weekly retention policy is required
            if (schPolicy.ScheduleRunFrequency == ScheduleRunType.Weekly &&
               (ltrPolicy.IsDailyScheduleEnabled != false || ltrPolicy.WeeklySchedule == null ||
               (ltrPolicy.IsWeeklyScheduleEnabled == false)))
            {
                throw new ArgumentException(Resources.WeeklyRetentionScheduleNullException);
            }

            // validating retention duration counts for hourly AFS policy 
            ValidateDurationCountsForHourlyPolicy(ltrPolicy, schPolicy);  

            // validate daily retention schedule with schPolicy
            if (ltrPolicy.DailySchedule != null && ltrPolicy.IsDailyScheduleEnabled == true)
            {
                ValidateRetentionAndBackupTimes(schPolicy.ScheduleRunTimes, ltrPolicy.DailySchedule.RetentionTimes, schPolicy.ScheduleRunFrequency);                
            }
            
            // validate weekly retention schedule with schPolicy
            if (ltrPolicy.WeeklySchedule != null && ltrPolicy.IsWeeklyScheduleEnabled == true)
            {
                ValidateRetentionAndBackupTimes(schPolicy.ScheduleRunTimes, ltrPolicy.WeeklySchedule.RetentionTimes, schPolicy.ScheduleRunFrequency);
                
                if (schPolicy.ScheduleRunFrequency == ScheduleRunType.Weekly)
                {
                    // count of daysOfWeek should match for weekly schedule
                    if (ltrPolicy.WeeklySchedule.DaysOfTheWeek.Count != schPolicy.ScheduleRunDays.Count)
                    {
                        throw new ArgumentException(Resources.DaysofTheWeekInWeeklyRetentionException);
                    }

                    // validate days of week
                    ValidateRetentionAndScheduleDaysOfWeek(schPolicy.ScheduleRunDays, ltrPolicy.WeeklySchedule.DaysOfTheWeek);
                }
            }
            
            // validate monthly retention schedule with schPolicy
            if (ltrPolicy.MonthlySchedule != null && ltrPolicy.IsMonthlyScheduleEnabled == true)
            {
                ValidateRetentionAndBackupTimes(schPolicy.ScheduleRunTimes, ltrPolicy.MonthlySchedule.RetentionTimes, schPolicy.ScheduleRunFrequency);

                // if backupSchedule is weekly, then user cannot choose 'Daily Retention format' 
                if (schPolicy.ScheduleRunFrequency == ScheduleRunType.Weekly &&
                    ltrPolicy.MonthlySchedule.RetentionScheduleFormatType
                        == RetentionScheduleFormat.Daily)
                {
                    throw new ArgumentException(Resources.MonthlyYearlyInvalidDailyRetentionFormatTypeException);
                }
                
                // for monthly and weeklyFormat, validate days of week
                if (ltrPolicy.MonthlySchedule.RetentionScheduleFormatType
                        == RetentionScheduleFormat.Weekly &&
                   schPolicy.ScheduleRunFrequency == ScheduleRunType.Weekly)
                {
                    ValidateRetentionAndScheduleDaysOfWeek(schPolicy.ScheduleRunDays,
                                                           ltrPolicy.MonthlySchedule.RetentionScheduleWeekly.DaysOfTheWeek);
                }
            }

            // validate yearly retention schedule with schPolicy
            if (ltrPolicy.YearlySchedule != null && ltrPolicy.IsYearlyScheduleEnabled == true)
            {
                ValidateRetentionAndBackupTimes(schPolicy.ScheduleRunTimes, ltrPolicy.YearlySchedule.RetentionTimes, schPolicy.ScheduleRunFrequency);

                // if backupSchedule is weekly, then user cannot choose 'Daily Retention format' 
                if (schPolicy.ScheduleRunFrequency == ScheduleRunType.Weekly &&
                    ltrPolicy.YearlySchedule.RetentionScheduleFormatType
                        == RetentionScheduleFormat.Daily)
                {
                    throw new ArgumentException(Resources.MonthlyYearlyInvalidDailyRetentionFormatTypeException);
                }

                // for yearly and weeklyFormat, validate days of week                 
                if (ltrPolicy.YearlySchedule.RetentionScheduleFormatType
                        == RetentionScheduleFormat.Weekly &&
                    schPolicy.ScheduleRunFrequency == ScheduleRunType.Weekly)
                {
                    ValidateRetentionAndScheduleDaysOfWeek(schPolicy.ScheduleRunDays,
                                                           ltrPolicy.YearlySchedule.RetentionScheduleWeekly.DaysOfTheWeek);
                }
            }
        }

        /// <summary>
        /// Helper function to validate long term rentention policy and simple schedule policy.
        /// </summary>
        public static void ValidateLongTermRetentionPolicyWithSimpleSchedulePolicy(
            LongTermRetentionPolicy ltrPolicy,
            SimpleSchedulePolicyV2 schPolicy)
        {
            // for daily schedule, daily retention policy is required
            if (schPolicy.ScheduleRunFrequency == ScheduleRunType.Daily &&
               (ltrPolicy.DailySchedule == null || ltrPolicy.IsDailyScheduleEnabled == false))
            {
                throw new ArgumentException(Resources.DailyRetentionScheduleNullException);
            }

            // for weekly schedule, daily retention policy should be NULL
            // AND weekly retention policy is required
            if (schPolicy.ScheduleRunFrequency == ScheduleRunType.Weekly &&
               (ltrPolicy.IsDailyScheduleEnabled != false || ltrPolicy.WeeklySchedule == null ||
               (ltrPolicy.IsWeeklyScheduleEnabled == false)))
            {
                throw new ArgumentException(Resources.WeeklyRetentionScheduleNullException);
            }
                        
            // validating retention duration counts for hourly AFS policy
            ValidateDurationCountsForHourlyPolicy(ltrPolicy, schPolicy);            

            // validate daily retention schedule with schPolicy
            if (ltrPolicy.DailySchedule != null && ltrPolicy.IsDailyScheduleEnabled == true)
            {                
                if (schPolicy.ScheduleRunFrequency == ScheduleRunType.Daily)
                {
                    ValidateRetentionAndBackupTimes(schPolicy.DailySchedule.ScheduleRunTimes, ltrPolicy.DailySchedule.RetentionTimes, schPolicy.ScheduleRunFrequency);
                }                
            }

            // validate weekly retention schedule with schPolicy
            if (ltrPolicy.WeeklySchedule != null && ltrPolicy.IsWeeklyScheduleEnabled == true)
            {   
                List<DateTime> scheduleTime = (schPolicy.ScheduleRunFrequency == ScheduleRunType.Daily) ? schPolicy.DailySchedule.ScheduleRunTimes : ((schPolicy.ScheduleRunFrequency == ScheduleRunType.Weekly) ? schPolicy.WeeklySchedule.ScheduleRunTimes : null);                
                                
                ValidateRetentionAndBackupTimes(scheduleTime, ltrPolicy.WeeklySchedule.RetentionTimes, schPolicy.ScheduleRunFrequency);

                if (schPolicy.ScheduleRunFrequency == ScheduleRunType.Weekly)
                {
                    // count of daysOfWeek should match for weekly schedule
                    if (ltrPolicy.WeeklySchedule.DaysOfTheWeek.Count != schPolicy.WeeklySchedule.ScheduleRunDays.Count)
                    {
                        throw new ArgumentException(Resources.DaysofTheWeekInWeeklyRetentionException);
                    }

                    // validate days of week
                    ValidateRetentionAndScheduleDaysOfWeek(schPolicy.WeeklySchedule.ScheduleRunDays, ltrPolicy.WeeklySchedule.DaysOfTheWeek);
                }
            }

            // validate monthly retention schedule with schPolicy
            if (ltrPolicy.MonthlySchedule != null && ltrPolicy.IsMonthlyScheduleEnabled == true)
            {
                List<DateTime> scheduleTime = (schPolicy.ScheduleRunFrequency == ScheduleRunType.Daily) ? schPolicy.DailySchedule.ScheduleRunTimes : ((schPolicy.ScheduleRunFrequency == ScheduleRunType.Weekly) ? schPolicy.WeeklySchedule.ScheduleRunTimes : null);

                ValidateRetentionAndBackupTimes(scheduleTime, ltrPolicy.MonthlySchedule.RetentionTimes, schPolicy.ScheduleRunFrequency); 

                // if backupSchedule is weekly, then user cannot choose 'Daily Retention format' 
                if (schPolicy.ScheduleRunFrequency == ScheduleRunType.Weekly &&
                    ltrPolicy.MonthlySchedule.RetentionScheduleFormatType == RetentionScheduleFormat.Daily)
                {
                    throw new ArgumentException(Resources.MonthlyYearlyInvalidDailyRetentionFormatTypeException);
                }

                // for monthly and weeklyFormat, validate days of week
                if (ltrPolicy.MonthlySchedule.RetentionScheduleFormatType
                        == RetentionScheduleFormat.Weekly &&
                   schPolicy.ScheduleRunFrequency == ScheduleRunType.Weekly)
                {
                    ValidateRetentionAndScheduleDaysOfWeek(schPolicy.WeeklySchedule.ScheduleRunDays,
                                                           ltrPolicy.MonthlySchedule.RetentionScheduleWeekly.DaysOfTheWeek);
                }
            }

            // validate yearly retention schedule with schPolicy
            if (ltrPolicy.YearlySchedule != null && ltrPolicy.IsYearlyScheduleEnabled == true)
            {                
                List<DateTime> scheduleTime = (schPolicy.ScheduleRunFrequency == ScheduleRunType.Daily) ? schPolicy.DailySchedule.ScheduleRunTimes : ((schPolicy.ScheduleRunFrequency == ScheduleRunType.Weekly) ? schPolicy.WeeklySchedule.ScheduleRunTimes : null);

                ValidateRetentionAndBackupTimes(scheduleTime, ltrPolicy.YearlySchedule.RetentionTimes, schPolicy.ScheduleRunFrequency); 

                // if backupSchedule is weekly, then user cannot choose 'Daily Retention format' 
                if (schPolicy.ScheduleRunFrequency == ScheduleRunType.Weekly &&
                    ltrPolicy.YearlySchedule.RetentionScheduleFormatType
                        == RetentionScheduleFormat.Daily)
                {
                    throw new ArgumentException(Resources.MonthlyYearlyInvalidDailyRetentionFormatTypeException);
                }

                // for yearly and weeklyFormat, validate days of week                 
                if (ltrPolicy.YearlySchedule.RetentionScheduleFormatType
                        == RetentionScheduleFormat.Weekly &&
                    schPolicy.ScheduleRunFrequency == ScheduleRunType.Weekly)
                {
                    ValidateRetentionAndScheduleDaysOfWeek(schPolicy.WeeklySchedule.ScheduleRunDays,
                                                           ltrPolicy.YearlySchedule.RetentionScheduleWeekly.DaysOfTheWeek);
                }
            }
        }

        public static void ValidateLongTermRetentionPolicyWithSimpleSchedulePolicy(
            SQLRetentionPolicy ltrPolicy,
            SQLSchedulePolicy schPolicy)
        {
            // for daily schedule, daily retention policy is required
            if (schPolicy.FullBackupSchedulePolicy.ScheduleRunFrequency == ScheduleRunType.Daily &&
               (ltrPolicy.FullBackupRetentionPolicy.DailySchedule == null ||
               ltrPolicy.FullBackupRetentionPolicy.IsDailyScheduleEnabled == false))
            {
                throw new ArgumentException(Resources.DailyRetentionScheduleNullException);
            }

            // for weekly schedule, daily retention policy should be NULL
            // AND weekly retention policy is required
            if (schPolicy.FullBackupSchedulePolicy.ScheduleRunFrequency == ScheduleRunType.Weekly &&
               (ltrPolicy.FullBackupRetentionPolicy.IsDailyScheduleEnabled != false ||
               ltrPolicy.FullBackupRetentionPolicy.WeeklySchedule == null ||
               (ltrPolicy.FullBackupRetentionPolicy.IsWeeklyScheduleEnabled == false)))
            {
                throw new ArgumentException(Resources.WeeklyRetentionScheduleNullException);
            }

            // validate daily retention schedule with schPolicy
            if (ltrPolicy.FullBackupRetentionPolicy.DailySchedule != null &&
                ltrPolicy.FullBackupRetentionPolicy.IsDailyScheduleEnabled == true)
            {
                ValidateRetentionAndBackupTimes(schPolicy.FullBackupSchedulePolicy.ScheduleRunTimes,
                    ltrPolicy.FullBackupRetentionPolicy.DailySchedule.RetentionTimes);
            }

            // validate weekly retention schedule with schPolicy
            if (ltrPolicy.FullBackupRetentionPolicy.WeeklySchedule != null &&
                ltrPolicy.FullBackupRetentionPolicy.IsWeeklyScheduleEnabled == true)
            {
                ValidateRetentionAndBackupTimes(schPolicy.FullBackupSchedulePolicy.ScheduleRunTimes,
                    ltrPolicy.FullBackupRetentionPolicy.WeeklySchedule.RetentionTimes);

                if (schPolicy.FullBackupSchedulePolicy.ScheduleRunFrequency == ScheduleRunType.Weekly)
                {
                    // count of daysOfWeek should match for weekly schedule
                    if (ltrPolicy.FullBackupRetentionPolicy.WeeklySchedule.DaysOfTheWeek.Count !=
                        schPolicy.FullBackupSchedulePolicy.ScheduleRunDays.Count)
                    {
                        throw new ArgumentException(Resources.DaysofTheWeekInWeeklyRetentionException);
                    }

                    // validate days of week
                    ValidateRetentionAndScheduleDaysOfWeek(schPolicy.FullBackupSchedulePolicy.ScheduleRunDays,
                        ltrPolicy.FullBackupRetentionPolicy.WeeklySchedule.DaysOfTheWeek);
                }
            }

            // validate monthly retention schedule with schPolicy
            if (ltrPolicy.FullBackupRetentionPolicy.MonthlySchedule != null &&
                ltrPolicy.FullBackupRetentionPolicy.IsMonthlyScheduleEnabled == true)
            {
                ValidateRetentionAndBackupTimes(schPolicy.FullBackupSchedulePolicy.ScheduleRunTimes,
                    ltrPolicy.FullBackupRetentionPolicy.MonthlySchedule.RetentionTimes);

                // if backupSchedule is weekly, then user cannot choose 'Daily Retention format' 
                if (schPolicy.FullBackupSchedulePolicy.ScheduleRunFrequency == ScheduleRunType.Weekly &&
                    ltrPolicy.FullBackupRetentionPolicy.MonthlySchedule.RetentionScheduleFormatType
                        == RetentionScheduleFormat.Daily)
                {
                    throw new ArgumentException(Resources.MonthlyYearlyInvalidDailyRetentionFormatTypeException);
                }

                // for monthly and weeklyFormat, validate days of week
                if (ltrPolicy.FullBackupRetentionPolicy.MonthlySchedule.RetentionScheduleFormatType
                        == RetentionScheduleFormat.Weekly &&
                   schPolicy.FullBackupSchedulePolicy.ScheduleRunFrequency == ScheduleRunType.Weekly)
                {
                    ValidateRetentionAndScheduleDaysOfWeek(schPolicy.FullBackupSchedulePolicy.ScheduleRunDays,
                                                           ltrPolicy.FullBackupRetentionPolicy.MonthlySchedule.
                                                           RetentionScheduleWeekly.DaysOfTheWeek);
                }
            }

            // validate yearly retention schedule with schPolicy
            if (ltrPolicy.FullBackupRetentionPolicy.YearlySchedule != null &&
                ltrPolicy.FullBackupRetentionPolicy.IsYearlyScheduleEnabled == true)
            {
                ValidateRetentionAndBackupTimes(schPolicy.FullBackupSchedulePolicy.ScheduleRunTimes,
                    ltrPolicy.FullBackupRetentionPolicy.YearlySchedule.RetentionTimes);

                // if backupSchedule is weekly, then user cannot choose 'Daily Retention format' 
                if (schPolicy.FullBackupSchedulePolicy.ScheduleRunFrequency == ScheduleRunType.Weekly &&
                    ltrPolicy.FullBackupRetentionPolicy.YearlySchedule.RetentionScheduleFormatType
                        == RetentionScheduleFormat.Daily)
                {
                    throw new ArgumentException(Resources.MonthlyYearlyInvalidDailyRetentionFormatTypeException);
                }

                // for yearly and weeklyFormat, validate days of week                 
                if (ltrPolicy.FullBackupRetentionPolicy.YearlySchedule.RetentionScheduleFormatType
                        == RetentionScheduleFormat.Weekly &&
                    schPolicy.FullBackupSchedulePolicy.ScheduleRunFrequency == ScheduleRunType.Weekly)
                {
                    ValidateRetentionAndScheduleDaysOfWeek(schPolicy.FullBackupSchedulePolicy.ScheduleRunDays,
                                                           ltrPolicy.FullBackupRetentionPolicy.YearlySchedule.
                                                           RetentionScheduleWeekly.DaysOfTheWeek);
                }
            }
        }

        #region private

        private static void ValidateRetentionAndBackupTimes(List<DateTime> schPolicyTimes, List<DateTime> retPolicyTimes, ScheduleRunType scheduleRunFrequency = 0)
        {
            if(scheduleRunFrequency != ScheduleRunType.Hourly)
            {
                //Currently supported BackupTimes & retentionTimes is 1
                if (retPolicyTimes == null || retPolicyTimes.Count != 1)
                {
                    throw new ArgumentException(Resources.InvalidRetentionTimesInPolicyException);
                }
                if (schPolicyTimes == null || schPolicyTimes.Count != 1)
                {
                    throw new ArgumentException(Resources.InvalidBackupTimesInSchedulePolicyException);
                }
                if (schPolicyTimes[0] != retPolicyTimes[0])
                {
                    throw new ArgumentException(Resources.BackupAndRetentionTimesMismatch);
                }
            }            
        }

        private static void ValidateDurationCountsForHourlyPolicy(LongTermRetentionPolicy ltrPolicy,
            SchedulePolicyBase schPolicyBase)
        {
            if (schPolicyBase.GetType() == typeof(SimpleSchedulePolicy))
            {
                SimpleSchedulePolicy schPolicy = (SimpleSchedulePolicy)schPolicyBase;

                if (ltrPolicy.DailySchedule != null && ltrPolicy.IsDailyScheduleEnabled == true && string.Compare(ltrPolicy.BackupManagementType, "AzureStorage") == 0)
                {
                    if (schPolicy != null && schPolicy.ScheduleRunFrequency == ScheduleRunType.Hourly)
                    {
                        int numberOfPointsPerDay = (int)((schPolicy.ScheduleWindowDuration / schPolicy.ScheduleInterval) + 1);
                        int totalNumberOfScheduledPoints = numberOfPointsPerDay * (ltrPolicy.DailySchedule.DurationCountInDays + 1); //Incorporating GC delays for Hourly schedules

                        if (totalNumberOfScheduledPoints > PolicyConstants.AfsDailyRetentionDaysMax)
                        {
                            throw new ArgumentException(String.Format(Resources.DailyRetentionPointsLimitExceeded, PolicyConstants.AfsDailyRetentionDaysMax));
                        }
                    }
                }
            }
        }

        private static void ValidateRetentionAndScheduleDaysOfWeek(List<DayOfWeek> schList, List<DayOfWeek> retList)
        {
            foreach (var day in retList)
            {
                if (!schList.Contains(day))
                {
                    throw new ArgumentException(Resources.MonthlyYearlyRetentionDaysOfWeekException);
                }
            }
        }

        #endregion
    }
}
