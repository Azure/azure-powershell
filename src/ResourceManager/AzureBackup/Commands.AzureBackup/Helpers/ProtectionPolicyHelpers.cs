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
using System.Management.Automation;
using System.Collections.Generic;
using System.Xml;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using System.Threading;
using Hyak.Common;
using Microsoft.Azure.Commands.AzureBackup.Properties;
using System.Net;
using Microsoft.Azure.Management.BackupServices.Models;
using Microsoft.Azure.Commands.AzureBackup.Cmdlets;
using System.Linq;
using Microsoft.Azure.Commands.AzureBackup.Models;
using CmdletModel = Microsoft.Azure.Commands.AzureBackup.Models;
using System.Collections.Specialized;
using System.Web;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.AzureBackup.Helpers
{
    public static class ProtectionPolicyHelpers
    {
        public const int MinRetentionInDays = 7;
        public const int MaxRetentionInDays = 366;
        public const int MinRetention = 1;
        public const int MaxRetentionInWeeks = 260;
        public const int MaxRetentionInMonths = 120;
        public const int MaxRetentionInYears = 99;
        public const int MinPolicyNameLength = 3;
        public const int MaxPolicyNameLength = 150;
        public static Regex rgx = new Regex(@"^[A-Za-z][-A-Za-z0-9]*[A-Za-z0-9]$");

        public static AzureBackupProtectionPolicy GetCmdletPolicy(CmdletModel.AzurePSBackupVault vault, CSMProtectionPolicyResponse sourcePolicy)
        {
            if (sourcePolicy == null)
            {
                return null;
            }

            return new AzureBackupProtectionPolicy(vault, sourcePolicy.Properties, sourcePolicy.Id);
        }

        public static IEnumerable<AzureBackupProtectionPolicy> GetCmdletPolicies(CmdletModel.AzurePSBackupVault vault, IEnumerable<CSMProtectionPolicyResponse> sourcePolicyList)
        {
            if (sourcePolicyList == null)
            {
                return null;
            }

            List<AzureBackupProtectionPolicy> targetList = new List<AzureBackupProtectionPolicy>();

            foreach (var sourcePolicy in sourcePolicyList)
            {
                targetList.Add(GetCmdletPolicy(vault, sourcePolicy));
            }

            return targetList;
        }

        public static CSMBackupSchedule FillCSMBackupSchedule(string scheduleType, DateTime scheduleStartTime,
            string[] scheduleRunDays)
        {
            var backupSchedule = new CSMBackupSchedule();

            backupSchedule.BackupType = BackupType.Full.ToString();
            
            scheduleType = FillScheduleType(scheduleType, scheduleRunDays);
            backupSchedule.ScheduleRun = scheduleType;

            if (string.Compare(scheduleType, ScheduleType.Weekly.ToString(), true) == 0)
            {
                backupSchedule.ScheduleRunDays = ParseScheduleRunDays(scheduleRunDays);
            }

            DateTime scheduleRunTime = ParseScheduleRunTime(scheduleStartTime);

            backupSchedule.ScheduleRunTimes = new List<DateTime> { scheduleRunTime };

            return backupSchedule;
        }

        public static void ValidateProtectionPolicyName(string policyName)
        {
            if(policyName.Length < MinPolicyNameLength || policyName.Length > MaxPolicyNameLength)
            {
                var exception = new ArgumentException("The protection policy name must contain between 3 and 150 characters.");
                throw exception;
            }
           
            if(!rgx.IsMatch(policyName))
            {
                var exception = new ArgumentException("The protection policy name should contain alphanumeric characters and cannot start with a number.");
                throw exception;
            }
        }

        public static string GetScheduleType(string[] ScheduleRunDays, string parameterSetName,
            string dailyParameterSet, string weeklyParameterSet)
        {
            if (ScheduleRunDays != null && ScheduleRunDays.Length > 0)
            {
                if (parameterSetName == dailyParameterSet)
                {
                    throw new ArgumentException("For daily schedule, protection policy cannot have scheduleRundays");
                }
                else
                {
                    return ScheduleType.Weekly.ToString();
                }
            }
            else
            {
                if (parameterSetName == weeklyParameterSet)
                {
                    throw new ArgumentException("For weekly schedule, ScheduleRundays param cannot be empty");
                }
                else
                {
                    return ScheduleType.Daily.ToString();
                }                
            }  
        }

        public static void ValidateRetentionPolicy(IList<AzureBackupRetentionPolicy> retentionPolicyList, CSMBackupSchedule backupSchedule = null)
        {
            bool validateDailyRetention = false;
            bool validateWeeklyRetention = false;

            if(retentionPolicyList.Count == 0 )
            {
                var exception = new ArgumentException("Please pass atlease one retention policy");
                throw exception;
            }

            foreach (AzureBackupRetentionPolicy retentionPolicy in retentionPolicyList)
            {
                if(retentionPolicy.RetentionType == "Daily")
                {
                    ValidateDailyRetention((AzureBackupDailyRetentionPolicy)retentionPolicy);
                    validateDailyRetention = true;
                }
                else if (retentionPolicy.RetentionType == "Weekly")
                {
                    ValidateWeeklyRetention((AzureBackupWeeklyRetentionPolicy)retentionPolicy);
                    validateWeeklyRetention = true;
                    if (backupSchedule != null)
                    {
                        var weeklyRetention = (AzureBackupWeeklyRetentionPolicy)retentionPolicy;
                        ValidateForWeeklyBackupSchedule(RetentionFormat.Weekly, backupSchedule.BackupType, backupSchedule.ScheduleRunDays, weeklyRetention.DaysOfWeek);
                    }
                }
                else if (retentionPolicy.RetentionType == "Monthly")
                {
                    ValidateMonthlyRetention((AzureBackupMonthlyRetentionPolicy)retentionPolicy);
                    if (backupSchedule != null)
                    {
                        var monthlyRetention = (AzureBackupMonthlyRetentionPolicy)retentionPolicy;
                        ValidateForWeeklyBackupSchedule(monthlyRetention.RetentionFormat, backupSchedule.BackupType, backupSchedule.ScheduleRunDays, monthlyRetention.DaysOfWeek);
                    }
                }
                else if (retentionPolicy.RetentionType == "Yearly")
                {
                    ValidateYearlyRetention((AzureBackupYearlyRetentionPolicy)retentionPolicy);
                    if (backupSchedule != null)
                    {
                        var yearlyRetention = (AzureBackupYearlyRetentionPolicy)retentionPolicy;
                        ValidateForWeeklyBackupSchedule(yearlyRetention.RetentionFormat, backupSchedule.BackupType, backupSchedule.ScheduleRunDays, yearlyRetention.DaysOfWeek);
                    }
                }
            }

            if (backupSchedule != null)
                {
                    string scheduleType = backupSchedule.BackupType;
                    if (scheduleType == ScheduleType.Daily.ToString() && validateDailyRetention == false)
                    {
                        var exception = new ArgumentException("For Daily Schedule, please pass AzureBackupDailyRetentionPolicy in RetentionPolicies param.");
                        throw exception;
                    }

                    if (scheduleType == ScheduleType.Weekly.ToString() && validateWeeklyRetention == false)
                    {
                        var exception = new ArgumentException("For Weekly Schedule, please pass AzureBackupWeeklyRetentionPolicy in RetentionPolicies param.");
                        throw exception;
                    }

                    if (scheduleType == ScheduleType.Weekly.ToString() && validateDailyRetention == true)
                    {
                        var exception = new ArgumentException("For Weekly Schedule, you cannot pass AzureBackupDailyRetentionPolicy in RetentionPolicies param.");
                        throw exception;
                    }
               }
        }

        private static string FillScheduleType(string scheduleType, string[] scheduleRunDays)
        {
            if (scheduleType == ScheduleType.Daily.ToString() && scheduleRunDays != null && scheduleRunDays.Length > 0)
            {
                return ScheduleType.Weekly.ToString();
            }

            else
            {
                return Enum.Parse(typeof(ScheduleType), scheduleType, true).ToString();
            }
        }

        private static IList<DayOfWeek> ParseScheduleRunDays(string[] scheduleRunDays)
        {
            if (scheduleRunDays == null || scheduleRunDays.Length <= 0)
            {
                var exception = new ArgumentException("For weekly scheduletype , ScheduleRunDays should not be empty.");
                throw exception;
            }

            IList<DayOfWeek> ListofWeekDays = new List<DayOfWeek>();

            foreach (var dayOfWeek in scheduleRunDays)
            {
                DayOfWeek item = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayOfWeek, true);
                if (!ListofWeekDays.Contains(item))
                {
                    ListofWeekDays.Add(item);
                }
            }

            return ListofWeekDays;
        }

        private static DateTime ParseScheduleRunTime(DateTime scheduleStartTime)
        {
            if (scheduleStartTime.Kind == DateTimeKind.Local)
            {
                scheduleStartTime = scheduleStartTime.ToUniversalTime();
            }
            DateTime scheduleRunTime = new DateTime(scheduleStartTime.Year, scheduleStartTime.Month,
                scheduleStartTime.Day, scheduleStartTime.Hour, scheduleStartTime.Minute - (scheduleStartTime.Minute % 30), 0);
            return scheduleRunTime;
        }

        private static void ValidateDailyRetention(AzureBackupDailyRetentionPolicy dailyRetention)
        {
            if (dailyRetention.Retention < MinRetentionInDays || dailyRetention.Retention > MaxRetentionInDays)
            {
                var exception = new ArgumentException(string.Format("For DailyRetentionPolicy , valid values of retention are {0} to {1}.", MinRetentionInDays, MaxRetentionInDays));
                throw exception;
            }            
        }

        private static void ValidateWeeklyRetention(AzureBackupWeeklyRetentionPolicy weeklyRetention)
        {
            if (weeklyRetention.Retention < MinRetention || weeklyRetention.Retention > MaxRetentionInWeeks)
            {
                var exception = new ArgumentException(string.Format("For WeeklyRetentionPolicy , valid values of retention are {0} to {1}.", MinRetention, MaxRetentionInWeeks));
                throw exception;
            }

            if(weeklyRetention.DaysOfWeek == null || weeklyRetention.DaysOfWeek.Count == 0)
            {
                var exception = new ArgumentException("For WeeklyRetentionPolicy , pass atleast one value for DaysOfWeek param.");
                throw exception;
            }
        }

        private static void ValidateMonthlyRetention(AzureBackupMonthlyRetentionPolicy monthlyRetention)
        {
            if (monthlyRetention.Retention < MinRetention || monthlyRetention.Retention > MaxRetentionInMonths)
            {
                var exception = new ArgumentException(string.Format("For MonthlyRetentionPolicy , valid values of retention are {0} to {1}.", MinRetention, MaxRetentionInMonths));
                throw exception;
            }

            if(monthlyRetention.RetentionFormat == RetentionFormat.Daily)
            {
                if(monthlyRetention.DaysOfMonth == null || monthlyRetention.DaysOfMonth.Count == 0)
                {
                    var exception = new ArgumentException("For MonthlyRetentionPolicy and RetentionFormat in Days, pass atleast one value for DaysOfMonth param.");
                    throw exception;
                }

                if(monthlyRetention.DaysOfWeek != null || monthlyRetention.WeekNumber != null)
                {
                    var exception = new ArgumentException("For MonthlyRetentionPolicy and RetentionFormat in Days, DaysOfWeek or WeekNumber params are not allowed.");
                    throw exception;
                }
            }

            if (monthlyRetention.RetentionFormat == RetentionFormat.Weekly)
            {
                if (monthlyRetention.DaysOfWeek == null || monthlyRetention.DaysOfWeek.Count == 0)
                {
                    var exception = new ArgumentException("For MonthlyRetentionPolicy and RetentionFormat in Weeks, pass atleast one value for DaysOfWeek param.");
                    throw exception;
                }

                if (monthlyRetention.WeekNumber == null || monthlyRetention.WeekNumber.Count == 0)
                {
                    var exception = new ArgumentException("For MonthlyRetentionPolicy and RetentionFormat in Weeks, pass atleast one value for WeekNumber param.");
                    throw exception;
                }

                if (monthlyRetention.DaysOfMonth != null)
                {
                    var exception = new ArgumentException("For MonthlyRetentionPolicy and RetentionFormat in Weeks, DaysOfMonth param is not allowed.");
                    throw exception;
                }
            }
        }

        private static void ValidateYearlyRetention(AzureBackupYearlyRetentionPolicy yearlyRetention)
        {
            if (yearlyRetention.Retention < MinRetention || yearlyRetention.Retention > MaxRetentionInYears)
            {
                var exception = new ArgumentException(string.Format("For YearlyRetentionPolicy , valid values of retention are {0} to {1}.", MinRetention, MaxRetentionInYears));
                throw exception;
            }

            if(yearlyRetention.MonthsOfYear == null || yearlyRetention.MonthsOfYear.Count == 0)
            {
                var exception = new ArgumentException("For YearlyRetentionPolicy and RetentionFormat in days,pass atleast one value for MonthsOfYear param.");
                throw exception;
            }

            if (yearlyRetention.RetentionFormat == RetentionFormat.Daily)
            {
                if (yearlyRetention.DaysOfMonth == null || yearlyRetention.DaysOfMonth.Count == 0)
                {
                    var exception = new ArgumentException("For YearlyRetentionPolicy and RetentionFormat in Days, pass atleast one value for DaysOfMonth param.");
                    throw exception;
                }

                if (yearlyRetention.DaysOfWeek != null || yearlyRetention.WeekNumber != null)
                {
                    var exception = new ArgumentException("For YearlyRetentionPolicy and RetentionFormat in Days, DaysOfWeek or WeekNumber params are not allowed.");
                    throw exception;
                }
            }

            if (yearlyRetention.RetentionFormat == RetentionFormat.Weekly)
            {
                if (yearlyRetention.DaysOfWeek == null || yearlyRetention.DaysOfWeek.Count == 0)
                {
                    var exception = new ArgumentException("For YearlyRetentionPolicy and RetentionFormat in Weeks,pass atleast one value for DaysOfWeek param.");
                    throw exception;
                }

                if (yearlyRetention.WeekNumber == null || yearlyRetention.WeekNumber.Count == 0)
                {
                    var exception = new ArgumentException("For YearlyRetentionPolicy and RetentionFormat in Weeks, pass atleast one value for WeekNumber param.");
                    throw exception;
                }

                if (yearlyRetention.DaysOfMonth != null)
                {
                    var exception = new ArgumentException("For YearlyRetentionPolicy and RetentionFormat in Weeks, DaysOfMonth param is not allowed.");
                    throw exception;
                }
            }
        }

        private static void ValidateForWeeklyBackupSchedule(RetentionFormat RetentionScheduleType, string backupScheduleType, IList<DayOfWeek> backupScheduleRunDays, List<DayOfWeek> retentionScheduleRunDays)
        {
            if (string.Compare(backupScheduleType, ScheduleType.Weekly.ToString(), true) == 0)
            {
                if (RetentionScheduleType == RetentionFormat.Daily)
                {
                    throw new ArgumentException("Days of  the month in Monthly/Yearly retention is not allowed for weekly backup Schedules ");
                }
                foreach (var day in retentionScheduleRunDays)
                {
                    if (!backupScheduleRunDays.Contains(day))
                    {
                        throw new ArgumentException(" Days of the week list  in Weekly/Monthly/Yearly retention schedule should be subset of  Day of week list in Backup Schedule ");
                    }
                }
            }

        }

        # region Conversion Helper Functions

        public static IList<AzureBackupRetentionPolicy> ConvertCSMRetentionPolicyListToPowershell(CSMLongTermRetentionPolicy LTRRetentionPolicy)
        {
            IList<AzureBackupRetentionPolicy> retentionPolicyList = new List<AzureBackupRetentionPolicy>();
            AzureBackupDailyRetentionPolicy dailyRetentionPolicy = ConvertToPowershellDailyRetentionObject(LTRRetentionPolicy.DailySchedule);
            AzureBackupWeeklyRetentionPolicy weeklyRetentionPolicy = ConvertToPowershellWeeklyRetentionObject(LTRRetentionPolicy.WeeklySchedule);
            AzureBackupMonthlyRetentionPolicy monthlyRetentionPolicy = ConvertToPowershellMonthlyRetentionObject(LTRRetentionPolicy.MonthlySchedule);
            AzureBackupYearlyRetentionPolicy yearlyRetentionPolicy = ConvertToPowershellYearlyRetentionObject(LTRRetentionPolicy.YearlySchedule);

            if (dailyRetentionPolicy != null)
            {
                retentionPolicyList.Add(dailyRetentionPolicy);
            }
            if (weeklyRetentionPolicy != null)
            {
                retentionPolicyList.Add(weeklyRetentionPolicy);
            }
            if (monthlyRetentionPolicy != null)
            {
                retentionPolicyList.Add(monthlyRetentionPolicy);
            }
            if (yearlyRetentionPolicy != null)
            {
                retentionPolicyList.Add(yearlyRetentionPolicy);
            }

            return retentionPolicyList;
        }

        public static List<string> ConvertToPowershellScheduleRunDays(IList<DayOfWeek> weekDaysList)
        {
            List<string> scheduelRunDays = new List<string>();

            foreach (object item in weekDaysList)
            {
                scheduelRunDays.Add(item.ToString());
            }

            return scheduelRunDays;
        }

        public static DateTime ConvertToPowershellScheduleRunTimes(IList<DateTime> scheduleRunTimeList)
        {
            IEnumerator<DateTime> scheduleEnumerator = scheduleRunTimeList.GetEnumerator();
            scheduleEnumerator.MoveNext();
            return scheduleEnumerator.Current;
        }

        public static CSMLongTermRetentionPolicy ConvertToCSMRetentionPolicyObject(IList<AzureBackupRetentionPolicy> retentionPolicyList, CSMBackupSchedule backupSchedule)
        {
            CSMLongTermRetentionPolicy csmLongTermRetentionPolicy = new CSMLongTermRetentionPolicy();
            foreach (AzureBackupRetentionPolicy retentionPolicy in retentionPolicyList)
            {
                if (retentionPolicy.RetentionType == "Daily")
                {
                    csmLongTermRetentionPolicy.DailySchedule = ConvertToCSMDailyRetentionObject((AzureBackupDailyRetentionPolicy)retentionPolicy,
                        backupSchedule.ScheduleRunTimes);
                }
                if (retentionPolicy.RetentionType == "Weekly")
                {
                    csmLongTermRetentionPolicy.WeeklySchedule = ConvertToCSMWeeklyRetentionObject((AzureBackupWeeklyRetentionPolicy)retentionPolicy,
                        backupSchedule.ScheduleRunTimes);
                }
                if (retentionPolicy.RetentionType == "Monthly")
                {
                    csmLongTermRetentionPolicy.MonthlySchedule = ConvertToGetCSMMonthlyRetentionObject((AzureBackupMonthlyRetentionPolicy)retentionPolicy,
                        backupSchedule.ScheduleRunTimes);
                }
                if (retentionPolicy.RetentionType == "Yearly")
                {
                    csmLongTermRetentionPolicy.YearlySchedule = ConvertToCSMYearlyRetentionObject((AzureBackupYearlyRetentionPolicy)retentionPolicy,
                        backupSchedule.ScheduleRunTimes);
                }
            }

            return csmLongTermRetentionPolicy;
        }

        private static AzureBackupDailyRetentionPolicy ConvertToPowershellDailyRetentionObject(CSMDailyRetentionSchedule DailySchedule)
        {
            if (DailySchedule == null)
                return null;
            AzureBackupDailyRetentionPolicy dailyRetention = new AzureBackupDailyRetentionPolicy("Daily", DailySchedule.CSMRetentionDuration.Count);

            return dailyRetention;
        }

        private static AzureBackupWeeklyRetentionPolicy ConvertToPowershellWeeklyRetentionObject(CSMWeeklyRetentionSchedule WeeklySchedule)
        {
            if (WeeklySchedule == null)
                return null;
            AzureBackupWeeklyRetentionPolicy weeklyRetention = new AzureBackupWeeklyRetentionPolicy("Weekly", WeeklySchedule.CSMRetentionDuration.Count,
                WeeklySchedule.DaysOfTheWeek);

            return weeklyRetention;
        }

        private static AzureBackupMonthlyRetentionPolicy ConvertToPowershellMonthlyRetentionObject(CSMMonthlyRetentionSchedule MonthlySchedule)
        {
            if (MonthlySchedule == null)
                return null;
            AzureBackupMonthlyRetentionPolicy monthlyRetention = null;

            RetentionFormat retentionFormat = (RetentionFormat)Enum.Parse(typeof(RetentionFormat), MonthlySchedule.RetentionScheduleType.ToString(), true);
            if (retentionFormat == RetentionFormat.Daily)
            {
                List<string> dayList = ConvertToPowershellDayList(MonthlySchedule.RetentionScheduleDaily.DaysOfTheMonth);
                monthlyRetention = new AzureBackupMonthlyRetentionPolicy("Monthly", MonthlySchedule.CSMRetentionDuration.Count,
                retentionFormat, dayList, null, null);
            }
            else if (retentionFormat == RetentionFormat.Weekly)
            {
                List<WeekNumber> weekNumberList = ConvertToPowershellWeekNumberList(MonthlySchedule.RetentionScheduleWeekly);
                List<DayOfWeek> dayOfWeekList = ConvertToPowershellWeekDaysList(MonthlySchedule.RetentionScheduleWeekly);
                monthlyRetention = new AzureBackupMonthlyRetentionPolicy("Monthly", MonthlySchedule.CSMRetentionDuration.Count,
                retentionFormat, null, weekNumberList, dayOfWeekList);
            }

            return monthlyRetention;
        }

        private static AzureBackupYearlyRetentionPolicy ConvertToPowershellYearlyRetentionObject(CSMYearlyRetentionSchedule YearlySchedule)
        {
            if (YearlySchedule == null)
                return null;
            AzureBackupYearlyRetentionPolicy yearlyRetention = null;

            List<Month> monthOfTheYearList = ConvertToPowershellMonthsOfYearList(YearlySchedule.MonthsOfYear);

            RetentionFormat retentionFormat = (RetentionFormat)Enum.Parse(typeof(RetentionFormat), YearlySchedule.RetentionScheduleType.ToString(), true);
            if (retentionFormat == RetentionFormat.Daily)
            {
                List<string> dayList = ConvertToPowershellDayList(YearlySchedule.RetentionScheduleDaily.DaysOfTheMonth);
                yearlyRetention = new AzureBackupYearlyRetentionPolicy("Yearly", YearlySchedule.CSMRetentionDuration.Count,
                monthOfTheYearList, retentionFormat, dayList, null, null);
            }
            else if (retentionFormat == RetentionFormat.Weekly)
            {
                List<WeekNumber> weekNumberList = ConvertToPowershellWeekNumberList(YearlySchedule.RetentionScheduleWeekly);
                List<DayOfWeek> dayOfWeekList = ConvertToPowershellWeekDaysList(YearlySchedule.RetentionScheduleWeekly);
                yearlyRetention = new AzureBackupYearlyRetentionPolicy("Yearly", YearlySchedule.CSMRetentionDuration.Count,
                 monthOfTheYearList, retentionFormat, null, weekNumberList, dayOfWeekList);
            }

            return yearlyRetention;
        }

        private static List<string> ConvertToPowershellDayList(IList<Day> daysOfTheMonthList)
        {
            string lastDayOfTheMonth = "IsLast";
            List<string> dayList = new List<string>();
            foreach (Day day in daysOfTheMonthList)
            {
                dayList.Add(day.Date.ToString());
                if (day.IsLast)
                {
                    dayList.Add(lastDayOfTheMonth);
                }
            }

            return dayList;
        }

        private static List<WeekNumber> ConvertToPowershellWeekNumberList(CSMWeeklyRetentionFormat csmWeekNumberList)
        {
            List<WeekNumber> weekNumberList = new List<WeekNumber>();
            foreach (WeekNumber weekNumber in csmWeekNumberList.WeeksOfTheMonth)
            {
                weekNumberList.Add(weekNumber);
            }
            return weekNumberList;
        }

        private static List<DayOfWeek> ConvertToPowershellWeekDaysList(CSMWeeklyRetentionFormat csmWeekNumberList)
        {
            List<DayOfWeek> dayOfWeekList = new List<DayOfWeek>();
            foreach (DayOfWeek dayOfWeek in csmWeekNumberList.DaysOfTheWeek)
            {
                dayOfWeekList.Add(dayOfWeek);
            }
            return dayOfWeekList;
        }

        private static List<Month> ConvertToPowershellMonthsOfYearList(IList<Month> MonthsOfYear)
        {
            List<Month> monthOfTheYearList = new List<Month>();
            foreach (Month monthOfTheYear in MonthsOfYear)
            {
                monthOfTheYearList.Add(monthOfTheYear);
            }
            return monthOfTheYearList;
        }

        private static CSMDailyRetentionSchedule ConvertToCSMDailyRetentionObject(AzureBackupDailyRetentionPolicy retentionPolicy, IList<DateTime> RetentionTimes)
        {
            CSMDailyRetentionSchedule csmDailyRetention = new CSMDailyRetentionSchedule();
            csmDailyRetention.CSMRetentionDuration = new CSMRetentionDuration();
            csmDailyRetention.CSMRetentionDuration.Count = retentionPolicy.Retention;
            csmDailyRetention.CSMRetentionDuration.DurationType = RetentionDurationType.Days;
            csmDailyRetention.RetentionTimes = RetentionTimes;

            return csmDailyRetention;
        }
        private static CSMWeeklyRetentionSchedule ConvertToCSMWeeklyRetentionObject(AzureBackupWeeklyRetentionPolicy retentionPolicy, IList<DateTime> RetentionTimes)
        {
            CSMWeeklyRetentionSchedule csmWeeklyRetention = new CSMWeeklyRetentionSchedule();
            csmWeeklyRetention.DaysOfTheWeek = retentionPolicy.DaysOfWeek;
            csmWeeklyRetention.CSMRetentionDuration = new CSMRetentionDuration();
            csmWeeklyRetention.CSMRetentionDuration.Count = retentionPolicy.Retention;
            csmWeeklyRetention.CSMRetentionDuration.DurationType = RetentionDurationType.Weeks;
            csmWeeklyRetention.RetentionTimes = RetentionTimes;
            return csmWeeklyRetention;
        }

        private static CSMMonthlyRetentionSchedule ConvertToGetCSMMonthlyRetentionObject(AzureBackupMonthlyRetentionPolicy retentionPolicy, IList<DateTime> RetentionTimes)
        {
            CSMMonthlyRetentionSchedule csmMonthlyRetention = new CSMMonthlyRetentionSchedule();

            if (retentionPolicy.RetentionFormat == RetentionFormat.Daily)
            {
                csmMonthlyRetention.RetentionScheduleType = RetentionScheduleFormat.Daily;
                csmMonthlyRetention.RetentionScheduleDaily = new CSMDailyRetentionFormat();
                csmMonthlyRetention.RetentionScheduleDaily.DaysOfTheMonth = ConvertToCSMDayList(retentionPolicy.DaysOfMonth);
            }

            else if (retentionPolicy.RetentionFormat == RetentionFormat.Weekly)
            {
                csmMonthlyRetention.RetentionScheduleWeekly = new CSMWeeklyRetentionFormat();
                csmMonthlyRetention.RetentionScheduleType = RetentionScheduleFormat.Weekly;
                csmMonthlyRetention.RetentionScheduleWeekly.DaysOfTheWeek = retentionPolicy.DaysOfWeek;
                csmMonthlyRetention.RetentionScheduleWeekly.WeeksOfTheMonth = retentionPolicy.WeekNumber;
            }

            csmMonthlyRetention.CSMRetentionDuration = new CSMRetentionDuration();
            csmMonthlyRetention.CSMRetentionDuration.Count = retentionPolicy.Retention;
            csmMonthlyRetention.CSMRetentionDuration.DurationType = RetentionDurationType.Months;
            csmMonthlyRetention.RetentionTimes = RetentionTimes;

            return csmMonthlyRetention;
        }

        private static CSMYearlyRetentionSchedule ConvertToCSMYearlyRetentionObject(AzureBackupYearlyRetentionPolicy retentionPolicy, IList<DateTime> RetentionTimes)
        {
            CSMYearlyRetentionSchedule csmYearlyRetention = new CSMYearlyRetentionSchedule();

            if (retentionPolicy.RetentionFormat == RetentionFormat.Daily)
            {
                csmYearlyRetention.RetentionScheduleType = RetentionScheduleFormat.Daily;
                csmYearlyRetention.RetentionScheduleDaily = new CSMDailyRetentionFormat();
                csmYearlyRetention.RetentionScheduleDaily.DaysOfTheMonth = ConvertToCSMDayList(retentionPolicy.DaysOfMonth);
            }

            else if (retentionPolicy.RetentionFormat == RetentionFormat.Weekly)
            {
                csmYearlyRetention.RetentionScheduleWeekly = new CSMWeeklyRetentionFormat();
                csmYearlyRetention.RetentionScheduleType = RetentionScheduleFormat.Weekly;
                csmYearlyRetention.RetentionScheduleWeekly.DaysOfTheWeek = retentionPolicy.DaysOfWeek;
                csmYearlyRetention.RetentionScheduleWeekly.WeeksOfTheMonth = retentionPolicy.WeekNumber;
            }

            csmYearlyRetention.CSMRetentionDuration = new CSMRetentionDuration();
            csmYearlyRetention.CSMRetentionDuration.Count = retentionPolicy.Retention;
            csmYearlyRetention.CSMRetentionDuration.DurationType = RetentionDurationType.Years;
            csmYearlyRetention.RetentionTimes = RetentionTimes;
            csmYearlyRetention.MonthsOfYear = retentionPolicy.MonthsOfYear;

            return csmYearlyRetention;
        }

        private static IList<Day> ConvertToCSMDayList(List<string> DaysOfMonth)
        {
            IList<Day> dayList = new List<Day>();

            foreach (string DayOfMonth in DaysOfMonth)
            {
                Day day = new Day();
                if (string.Compare(DayOfMonth,"IsLast", true) == 0)
                {
                    day.IsLast = true;
                }
                else
                {
                    day.Date = Convert.ToInt32(DayOfMonth);
                    day.IsLast = false;
                }
                dayList.Add(day);
            }

            return dayList;
        }

        #endregion
    }
}
