﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    public partial class PolicyHelpers
    {        
        public static void ValidateLongTermRetentionPolicyWithSimpleRetentionPolicy(
            AzureRmRecoveryServicesLongTermRetentionPolicy ltrPolicy,
            AzureRmRecoveryServicesSimpleSchedulePolicy schPolicy)
        {
            // for daily schedule, daily retention policy is required
            if(schPolicy.ScheduleRunFrequency == ScheduleRunType.Daily && 
               ltrPolicy.DailySchedule == null)
            {
                throw new ArgumentException("Daily Retention Schedule can't be null if Daily Backup Schedule is enabled ");
            }

            // for weekly schedule, daily retention policy should be NULL
            // AND weekly retention policy is required
            if (schPolicy.ScheduleRunFrequency == ScheduleRunType.Weekly &&
               (ltrPolicy.DailySchedule != null || ltrPolicy.WeeklySchedule == null))
            {
                throw new ArgumentException("If Weekly backup schedule is enabled, Daily retention schedule should be null &" +
                                            "Weekly retention schedule should not be null");
            }

            // validate daily retention schedule with schPolicy
            if(ltrPolicy.DailySchedule != null)
            {
                ValidateRetentionAndBackupTimes(schPolicy.ScheduleRunTimes, ltrPolicy.DailySchedule.RetentionTimes);               
            }

            // validate weekly retention schedule with schPolicy
            if (ltrPolicy.WeeklySchedule != null)
            {
                ValidateRetentionAndBackupTimes(schPolicy.ScheduleRunTimes, ltrPolicy.WeeklySchedule.RetentionTimes);

                // count of daysOfWeek should match for weekly schedule
                if(ltrPolicy.WeeklySchedule.DaysOfTheWeek.Count != schPolicy.ScheduleRunDays.Count)
                {
                    throw new ArgumentException(
                        "DaysOfTheWeek in WeeklySchedule of retention policy must be same as ScheduleRunDays in SchedulePolicy");
                }

                // validate days of week
                ValidateRetentionAndScheduleDaysOfWeek(schPolicy.ScheduleRunDays, ltrPolicy.WeeklySchedule.DaysOfTheWeek);
            }

            // validate monthly retention schedule with schPolicy
            if (ltrPolicy.MonthlySchedule != null)
            {
                ValidateRetentionAndBackupTimes(schPolicy.ScheduleRunTimes, ltrPolicy.MonthlySchedule.RetentionTimes);

                // if backupSchedule is weekly, then user cannot choose 'Daily Retention format' 
                if(schPolicy.ScheduleRunFrequency == ScheduleRunType.Weekly &&
                    ltrPolicy.MonthlySchedule.RetentionScheduleFormatType == Cmdlets.Models.RetentionScheduleFormat.Daily)
                {
                    throw new ArgumentException("DailyRetentionFormat cannot be chosen if Weekly BackupSchedule is selected");
                }

                // for monthly and weeklyFormat, validate days of week
                if(ltrPolicy.MonthlySchedule.RetentionScheduleFormatType == Cmdlets.Models.RetentionScheduleFormat.Weekly)
                {
                    ValidateRetentionAndScheduleDaysOfWeek(schPolicy.ScheduleRunDays, 
                                                           ltrPolicy.MonthlySchedule.RetentionScheduleWeekly.DaysOfTheWeek);
                }
            }

            // validate yearly retention schedule with schPolicy
            if (ltrPolicy.YearlySchedule != null)
            {
                ValidateRetentionAndBackupTimes(schPolicy.ScheduleRunTimes, ltrPolicy.YearlySchedule.RetentionTimes);

                // if backupSchedule is weekly, then user cannot choose 'Daily Retention format' 
                if (schPolicy.ScheduleRunFrequency == ScheduleRunType.Weekly &&
                    ltrPolicy.YearlySchedule.RetentionScheduleFormatType == Cmdlets.Models.RetentionScheduleFormat.Daily)
                {
                    throw new ArgumentException("DailyRetentionFormat cannot be chosen if Weekly BackupSchedule is selected");
                }

                // for yearly and weeklyFormat, validate days of week                 
                if (ltrPolicy.YearlySchedule.RetentionScheduleFormatType == Cmdlets.Models.RetentionScheduleFormat.Weekly)
                {
                    ValidateRetentionAndScheduleDaysOfWeek(schPolicy.ScheduleRunDays,
                                                           ltrPolicy.YearlySchedule.RetentionScheduleWeekly.DaysOfTheWeek);
                }
            }
        }

        #region private

        private static void ValidateRetentionAndBackupTimes(List<DateTime> schPolicyTimes, List<DateTime> retPolicyTimes)
        {
            //Currently supported BackupTimes  & retentionTimes is 1
            if (retPolicyTimes == null || retPolicyTimes.Count != 1)
            {
                throw new ArgumentException("Only one RetentionTime is Allowed in RententionSchedules");
            }
            if (schPolicyTimes == null || schPolicyTimes.Count != 1)
            {
                throw new ArgumentException("Only one BackupTime is Allowed in SchedulePolicy");
            }
            if (schPolicyTimes[0] != retPolicyTimes[0])
            {
                throw new ArgumentException("RetentionTime in retention schedule should be same as backup time in SchedulePolicy");
            }
        }

        private static void ValidateRetentionAndScheduleDaysOfWeek(List<DayOfWeek> schList, List<DayOfWeek> retList)
        {
            foreach (var day in retList)
            {
                if (!schList.Contains(day))
                {
                    throw new ArgumentException(
                        "DaysOfTheWeek in retention schedule should be subset of ScheduleRunDays of SchedulePolicy");
                }
            }
        }
                
        #endregion
    }
}
