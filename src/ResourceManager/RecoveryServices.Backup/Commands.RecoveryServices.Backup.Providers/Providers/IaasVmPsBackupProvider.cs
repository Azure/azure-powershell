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
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel
{
    public class IaasVmPsBackupProvider : IPsBackupProvider
    {
        public void Initialize(ProviderData providerData, HydraAdapter.HydraAdapter hydraAdapter)
        {
            throw new NotImplementedException();
        }

        public BaseRecoveryServicesJobResponse EnableProtection()
        {
            throw new NotImplementedException();
        }

        public BaseRecoveryServicesJobResponse DisableProtection()
        {
            throw new NotImplementedException();
        }

        public BaseRecoveryServicesJobResponse TriggerBackup()
        {
            throw new NotImplementedException();
        }

        public BaseRecoveryServicesJobResponse TriggerRestore()
        {
            throw new NotImplementedException();
        }

        public ProtectedItemResponse GetProtectedItem()
        {
            throw new NotImplementedException();
        }

        public RecoveryPointResponse GetRecoveryPoint()
        {
            throw new NotImplementedException();
        }

        public ProtectionPolicyResponse CreatePolicy()
        {
            throw new NotImplementedException();
        }

        public ProtectionPolicyResponse ModifyPolicy()
        {
            throw new NotImplementedException();
        }

        public ProtectionPolicyResponse GetPolicy()
        {
            throw new NotImplementedException();
        }

        public void DeletePolicy()
        {
            throw new NotImplementedException();
        }


        public AzureRmRecoveryServicesSchedulePolicyBase GetDefaultSchedulePolicyObject()
        {
            AzureRmRecoveryServicesSimpleSchedulePolicy defaultSchedule = new AzureRmRecoveryServicesSimpleSchedulePolicy();
            //Default is daily scedule at 10:30 AM local time
            defaultSchedule.ScheduleRunFrequency = ScheduleRunType.Daily;

            DateTime scheduleTime = GenerateRandomTime();
            defaultSchedule.ScheduleRunTimes = new List<DateTime>();
            defaultSchedule.ScheduleRunTimes.Add(scheduleTime);

            defaultSchedule.ScheduleRunDays = new List<DayOfWeek>();
            defaultSchedule.ScheduleRunDays.Add(DayOfWeek.Sunday);

            //TimeSpan triggerTime = new TimeSpan(10, 30, 00);
            //TimeSpan timeToGo = triggerTime - DateTime.Now.TimeOfDay;
            //if(timeToGo < TimeSpan.Zero)
            //{
            //    //Schedule time will be the next day
            //}
            //else
            //{
            //    //Schedule time will be today 10:30
            //}

            return defaultSchedule;
        }

        public AzureRmRecoveryServicesLongTermRetentionPolicy GetDefaultRetentionPolicyObject()
        {
            AzureRmRecoveryServicesLongTermRetentionPolicy defaultRetention = new AzureRmRecoveryServicesLongTermRetentionPolicy();
            
            //Default time is 10:30 local time
            DateTime retentionTime = GenerateRandomTime(); 

            //Daily Retention policy
            defaultRetention.IsDailyScheduleEnabled = true;
            defaultRetention.DailySchedule = new Models.DailyRetentionSchedule();
            defaultRetention.DailySchedule.RetentionTimes = new List<DateTime>();
            defaultRetention.DailySchedule.RetentionTimes.Add(retentionTime);
            defaultRetention.DailySchedule.DurationCountInDays = 180; //TBD make it const

            //Weekly Retention policy
            defaultRetention.IsWeeklyScheduleEnabled = true;
            defaultRetention.WeeklySchedule = new Models.WeeklyRetentionSchedule();
            defaultRetention.WeeklySchedule.DaysOfTheWeek = new List<DayOfWeek>();
            defaultRetention.WeeklySchedule.DaysOfTheWeek.Add(DayOfWeek.Sunday);
            defaultRetention.WeeklySchedule.DurationCountInWeeks = 104; //TBD make it const
            defaultRetention.WeeklySchedule.RetentionTimes = new List<DateTime>();
            defaultRetention.WeeklySchedule.RetentionTimes.Add(retentionTime);

            //Monthly retention policy
            defaultRetention.IsMonthlyScheduleEnabled = true;
            defaultRetention.MonthlySchedule = new Models.MonthlyRetentionSchedule();
            defaultRetention.MonthlySchedule.DurationCountInMonths = 60; //tbd: make it const
            defaultRetention.MonthlySchedule.RetentionScheduleFormatType = Models.RetentionScheduleFormat.Weekly;

            //Initialize day based schedule
            defaultRetention.MonthlySchedule.RetentionScheduleDaily = GetDailyRetentionFormat();  

            //Initialize Week based schedule
            defaultRetention.MonthlySchedule.RetentionScheduleWeekly = GetWeeklyRetentionFormat();

            //Yearly retention policy
            defaultRetention.IsYearlyScheduleEnabled = true;
            defaultRetention.YearlySchedule = new Models.YearlyRetentionSchedule();
            defaultRetention.YearlySchedule.DurationCountInYears = 10;
            defaultRetention.YearlySchedule.RetentionScheduleFormatType = Models.RetentionScheduleFormat.Weekly;
            defaultRetention.YearlySchedule.MonthsOfYear = new List<Models.Month>();
            defaultRetention.YearlySchedule.MonthsOfYear.Add(Models.Month.January);
            defaultRetention.YearlySchedule.RetentionScheduleDaily = GetDailyRetentionFormat();
            defaultRetention.YearlySchedule.RetentionScheduleWeekly = GetWeeklyRetentionFormat();
            return defaultRetention;

        }

        private static Models.DailyRetentionFormat GetDailyRetentionFormat()
        {
            Models.DailyRetentionFormat dailyRetention = new Models.DailyRetentionFormat();
            dailyRetention.DaysOfTheMonth = new List<Models.Day>();
            Models.Day dayBasedRetention = new Models.Day();
            dayBasedRetention.IsLast = false;
            dayBasedRetention.Date = 1;
            dailyRetention.DaysOfTheMonth.Add(dayBasedRetention);
            return dailyRetention;
        }

        private static Models.WeeklyRetentionFormat GetWeeklyRetentionFormat()
        {
            Models.WeeklyRetentionFormat weeklyRetention = new Models.WeeklyRetentionFormat();
            weeklyRetention.DaysOfTheWeek = new List<DayOfWeek>();
            weeklyRetention.DaysOfTheWeek.Add(DayOfWeek.Sunday);

            weeklyRetention.WeeksOfTheMonth = new List<WeekOfMonth>();
            weeklyRetention.WeeksOfTheMonth.Add(WeekOfMonth.First);
            return weeklyRetention;
        }

        private static DateTime GenerateRandomTime()
        {
            //Schedule time will be random to avoid the load in service (same is in portal as well)
            Random rand = new Random();
            int hour = rand.Next(0, 24);
            int minute = (rand.Next(0, 2) == 0) ? 0 : 30;
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, 00);
        }

    }
}
