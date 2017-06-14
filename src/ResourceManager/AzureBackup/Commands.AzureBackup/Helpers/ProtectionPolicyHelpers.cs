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

using Microsoft.Azure.Commands.AzureBackup.Models;
using Microsoft.Azure.Commands.AzureBackup.Properties;
using Microsoft.Azure.Management.BackupServices.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CmdletModel = Microsoft.Azure.Commands.AzureBackup.Models;

namespace Microsoft.Azure.Commands.AzureBackup.Helpers
{
    public static class ProtectionPolicyHelpers
    {
        public const int MinRetentionInDays = 1;
        public const int MaxRetentionInDays = 366;
        public const int MinRetention = 1;
        public const int MaxRetentionInWeeks = 260;
        public const int MaxRetentionInMonths = 120;
        public const int MaxRetentionInYears = 99;
        public const int MinPolicyNameLength = 3;
        public const int MaxPolicyNameLength = 150;
        public const string LastDayOfTheMonth = "Last";
        public static Regex rgx = new Regex(@"^[A-Za-z][-A-Za-z0-9]*[A-Za-z0-9]$");

        public static AzureRMBackupProtectionPolicy GetCmdletPolicy(CmdletModel.AzureRMBackupVault vault, CSMProtectionPolicyResponse sourcePolicy)
        {
            if (sourcePolicy == null)
            {
                return null;
            }

            return new AzureRMBackupProtectionPolicy(vault, sourcePolicy.Properties, sourcePolicy.Id);
        }

        public static IEnumerable<AzureRMBackupProtectionPolicy> GetCmdletPolicies(CmdletModel.AzureRMBackupVault vault, IEnumerable<CSMProtectionPolicyResponse> sourcePolicyList)
        {
            if (sourcePolicyList == null)
            {
                return null;
            }

            List<AzureRMBackupProtectionPolicy> targetList = new List<AzureRMBackupProtectionPolicy>();

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
            if (policyName.Length < MinPolicyNameLength || policyName.Length > MaxPolicyNameLength)
            {
                var exception = new ArgumentException(Resources.ProtectionPolicyNameLengthException);
                throw exception;
            }

            if (!rgx.IsMatch(policyName))
            {
                var exception = new ArgumentException(Resources.ProtectionPolicyNameException);
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
                    throw new ArgumentException(Resources.BackupScheduleDailyParamException);
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
                    throw new ArgumentException(Resources.BackupScheduleWeeklyParamException);
                }
                else
                {
                    return ScheduleType.Daily.ToString();
                }
            }
        }

        public static void ValidateRetentionPolicy(IList<AzureRMBackupRetentionPolicy> retentionPolicyList, CSMBackupSchedule backupSchedule = null)
        {
            bool validateDailyRetention = false;
            bool validateWeeklyRetention = false;
            int dailyRetentionPolicyCount = 0;
            int weeklyRetentionPolicyCount = 0;
            int monthlyRetentionPolicyCount = 0;
            int yearlyRetentionPolicyCount = 0;

            if (retentionPolicyList.Count == 0)
            {
                var exception = new ArgumentException(Resources.RetentionPolicyCountException);
                throw exception;
            }

            foreach (AzureRMBackupRetentionPolicy retentionPolicy in retentionPolicyList)
            {
                if (retentionPolicy.RetentionType == RetentionType.Daily.ToString())
                {
                    ValidateDailyRetention((AzureBackupDailyRetentionPolicy)retentionPolicy);
                    validateDailyRetention = true;
                    dailyRetentionPolicyCount = dailyRetentionPolicyCount + 1;
                }
                else if (retentionPolicy.RetentionType == RetentionType.Weekly.ToString())
                {
                    ValidateWeeklyRetention((AzureBackupWeeklyRetentionPolicy)retentionPolicy);
                    validateWeeklyRetention = true;
                    if (backupSchedule != null)
                    {
                        var weeklyRetention = (AzureBackupWeeklyRetentionPolicy)retentionPolicy;
                        ValidateForWeeklyBackupScheduleDaysOfWeek(backupSchedule.ScheduleRun, backupSchedule.ScheduleRunDays, weeklyRetention.DaysOfWeek);
                    }
                    weeklyRetentionPolicyCount = weeklyRetentionPolicyCount + 1;
                }
                else if (retentionPolicy.RetentionType == RetentionType.Monthly.ToString())
                {
                    ValidateMonthlyRetention((AzureBackupMonthlyRetentionPolicy)retentionPolicy);
                    if (backupSchedule != null)
                    {
                        var monthlyRetention = (AzureBackupMonthlyRetentionPolicy)retentionPolicy;
                        ValidateForWeeklyBackupSchedule(monthlyRetention.RetentionFormat, backupSchedule.ScheduleRun, backupSchedule.ScheduleRunDays, monthlyRetention.DaysOfWeek);
                    }
                    monthlyRetentionPolicyCount = monthlyRetentionPolicyCount + 1;
                }
                else if (retentionPolicy.RetentionType == RetentionType.Yearly.ToString())
                {
                    ValidateYearlyRetention((AzureBackupYearlyRetentionPolicy)retentionPolicy);
                    if (backupSchedule != null)
                    {
                        var yearlyRetention = (AzureBackupYearlyRetentionPolicy)retentionPolicy;
                        ValidateForWeeklyBackupSchedule(yearlyRetention.RetentionFormat, backupSchedule.ScheduleRun, backupSchedule.ScheduleRunDays, yearlyRetention.DaysOfWeek);
                    }
                    yearlyRetentionPolicyCount = yearlyRetentionPolicyCount + 1;
                }
            }

            ValidateRetentionPolicyCount(dailyRetentionPolicyCount, weeklyRetentionPolicyCount, monthlyRetentionPolicyCount,
                                          yearlyRetentionPolicyCount);

            if (backupSchedule != null)
            {
                string scheduleType = backupSchedule.ScheduleRun;
                if (scheduleType == ScheduleType.Daily.ToString() && validateDailyRetention == false)
                {
                    var exception = new ArgumentException(Resources.DailyScheduleException);
                    throw exception;
                }

                if (scheduleType == ScheduleType.Weekly.ToString() && validateWeeklyRetention == false)
                {
                    var exception = new ArgumentException(Resources.WeeklyScheduleException);
                    throw exception;
                }

                if (scheduleType == ScheduleType.Weekly.ToString() && validateDailyRetention == true)
                {
                    var exception = new ArgumentException(Resources.WeeklyScheduleWithDailyException);
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
                var exception = new ArgumentException(Resources.WeeklyScheduleRunDaysException);
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

        private static void ValidateRetentionPolicyCount(int dailyRetentionCount, int weeklyRetentionCount,
            int monthlyRetentionCount, int yearlyRetentionCount)
        {
            if (dailyRetentionCount > 1)
            {
                var exception = new ArgumentException(Resources.DailyRetentionPolicyException);
                throw exception;
            }

            if (weeklyRetentionCount > 1)
            {
                var exception = new ArgumentException(Resources.WeeklyRetentionPolicyException);
                throw exception;
            }

            if (monthlyRetentionCount > 1)
            {
                var exception = new ArgumentException(Resources.MonthlyRetentionPolicyException);
                throw exception;
            }

            if (yearlyRetentionCount > 1)
            {
                var exception = new ArgumentException(Resources.YearlyRetentionPolicyException);
                throw exception;
            }

        }

        private static void ValidateDailyRetention(AzureBackupDailyRetentionPolicy dailyRetention)
        {
            if (dailyRetention.Retention < MinRetentionInDays || dailyRetention.Retention > MaxRetentionInDays)
            {
                var exception = new ArgumentException(string.Format(Resources.DailyRetentionPolicyValueException, MinRetentionInDays, MaxRetentionInDays));
                throw exception;
            }
        }

        private static void ValidateWeeklyRetention(AzureBackupWeeklyRetentionPolicy weeklyRetention)
        {
            if (weeklyRetention.Retention < MinRetention || weeklyRetention.Retention > MaxRetentionInWeeks)
            {
                var exception = new ArgumentException(string.Format(Resources.WeeklyRetentionPolicyValueException, MinRetention, MaxRetentionInWeeks));
                throw exception;
            }

            if (weeklyRetention.DaysOfWeek == null || weeklyRetention.DaysOfWeek.Count == 0)
            {
                var exception = new ArgumentException(Resources.WeeklyRetentionPolicyDaysOfWeekException);
                throw exception;
            }
        }

        private static void ValidateMonthlyRetention(AzureBackupMonthlyRetentionPolicy monthlyRetention)
        {
            if (monthlyRetention.Retention < MinRetention || monthlyRetention.Retention > MaxRetentionInMonths)
            {
                var exception = new ArgumentException(string.Format(Resources.MonthlyRetentionPolicyValueException, MinRetention, MaxRetentionInMonths));
                throw exception;
            }

            if (monthlyRetention.RetentionFormat == RetentionFormat.Daily)
            {
                if (monthlyRetention.DaysOfMonth == null || monthlyRetention.DaysOfMonth.Count == 0)
                {
                    var exception = new ArgumentException(Resources.MonthlyRetentionPolicyDaysOfMonthParamException);
                    throw exception;
                }

                if (monthlyRetention.DaysOfWeek != null || monthlyRetention.WeekNumber != null)
                {
                    var exception = new ArgumentException(Resources.MonthlyRetentionPolicyDaysOfWeekParamException);
                    throw exception;
                }
            }

            if (monthlyRetention.RetentionFormat == RetentionFormat.Weekly)
            {
                if (monthlyRetention.DaysOfWeek == null || monthlyRetention.DaysOfWeek.Count == 0)
                {
                    var exception = new ArgumentException(Resources.MonthlyRetentionPolicyDaysOfWeekException);
                    throw exception;
                }

                if (monthlyRetention.WeekNumber == null || monthlyRetention.WeekNumber.Count == 0)
                {
                    var exception = new ArgumentException(Resources.MonthlyRetentionPolicyWeekNumException);
                    throw exception;
                }

                if (monthlyRetention.DaysOfMonth != null)
                {
                    var exception = new ArgumentException(Resources.MonthlyRetentionPolicyDaysOfMonthsException);
                    throw exception;
                }
            }
        }

        private static void ValidateYearlyRetention(AzureBackupYearlyRetentionPolicy yearlyRetention)
        {
            if (yearlyRetention.Retention < MinRetention || yearlyRetention.Retention > MaxRetentionInYears)
            {
                var exception = new ArgumentException(string.Format(Resources.YearlyRetentionPolicyValueException, MinRetention, MaxRetentionInYears));
                throw exception;
            }

            if (yearlyRetention.MonthsOfYear == null || yearlyRetention.MonthsOfYear.Count == 0)
            {
                var exception = new ArgumentException(Resources.YearlyRetentionPolicyMonthOfYearParamException);
                throw exception;
            }

            if (yearlyRetention.RetentionFormat == RetentionFormat.Daily)
            {
                if (yearlyRetention.DaysOfMonth == null || yearlyRetention.DaysOfMonth.Count == 0)
                {
                    var exception = new ArgumentException(Resources.YearlyRetentionPolicyDaysOfMonthParamException);
                    throw exception;
                }

                if (yearlyRetention.DaysOfWeek != null || yearlyRetention.WeekNumber != null)
                {
                    var exception = new ArgumentException(Resources.YearlyRetentionPolicyDaysOfWeekParamException);
                    throw exception;
                }
            }

            if (yearlyRetention.RetentionFormat == RetentionFormat.Weekly)
            {
                if (yearlyRetention.DaysOfWeek == null || yearlyRetention.DaysOfWeek.Count == 0)
                {
                    var exception = new ArgumentException(Resources.YearlyRetentionPolicyDaysOfWeekInWeeksFormatParamException);
                    throw exception;
                }

                if (yearlyRetention.WeekNumber == null || yearlyRetention.WeekNumber.Count == 0)
                {
                    var exception = new ArgumentException(Resources.YearlyRetentionPolicyWeekNumParamException);
                    throw exception;
                }

                if (yearlyRetention.DaysOfMonth != null)
                {
                    var exception = new ArgumentException(Resources.YearlyRetentionPolicyDaysOfMonthInWeekFormatException);
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
                    throw new ArgumentException(Resources.DaysOfMonthsNotAllowedinMonthlyYearlyFormat);
                }
                foreach (var day in retentionScheduleRunDays)
                {
                    if (!backupScheduleRunDays.Contains(day))
                    {
                        throw new ArgumentException(Resources.MonthlyYearlyRetentionArgumentException);
                    }
                }
            }

        }

        private static void ValidateForWeeklyBackupScheduleDaysOfWeek(string backupScheduleType, IList<DayOfWeek> backupScheduleRunDays, List<DayOfWeek> retentionScheduleRunDays)
        {
            if (string.Compare(backupScheduleType, ScheduleType.Weekly.ToString(), true) == 0)
            {
                if (backupScheduleRunDays.Count != retentionScheduleRunDays.Count)
                {
                    throw new ArgumentException(Resources.DaysOfTheWeekOfRetentionScheduleException);
                }
                foreach (var day in retentionScheduleRunDays)
                {
                    if (!backupScheduleRunDays.Contains(day))
                    {
                        throw new ArgumentException(Resources.DaysofTheWeekInWeeklyRetentionException);
                    }
                }
            }

        }

        # region Conversion Helper Functions

        public static IList<AzureRMBackupRetentionPolicy> ConvertCSMRetentionPolicyListToPowershell(CSMLongTermRetentionPolicy LTRRetentionPolicy)
        {
            IList<AzureRMBackupRetentionPolicy> retentionPolicyList = new List<AzureRMBackupRetentionPolicy>();
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

        public static string ConvertToPowershellWorkloadType(string workloadType)
        {
            if (string.Compare(workloadType, "IaasVM", true) == 0)
            {
                return WorkloadType.AzureVM.ToString();
            }
            else
            {
                throw new ArgumentException(Resources.UnsupportedWorkloadTypeException);
            }
        }
        public static CSMLongTermRetentionPolicy ConvertToCSMRetentionPolicyObject(IList<AzureRMBackupRetentionPolicy> retentionPolicyList, CSMBackupSchedule backupSchedule)
        {
            CSMLongTermRetentionPolicy csmLongTermRetentionPolicy = new CSMLongTermRetentionPolicy();
            foreach (AzureRMBackupRetentionPolicy retentionPolicy in retentionPolicyList)
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

        public static string ConvertToCSMWorkLoadType(string workloadType)
        {
            string csmWorkloadType = "IaasVM";
            WorkloadType type = (WorkloadType)Enum.Parse(typeof(WorkloadType), workloadType, true);

            if (type == WorkloadType.AzureVM)
            {
                return csmWorkloadType;
            }
            else
            {
                throw new ArgumentException(Resources.UnsupportedWorkloadTypeException);
            }
        }

        private static AzureBackupDailyRetentionPolicy ConvertToPowershellDailyRetentionObject(CSMDailyRetentionSchedule DailySchedule)
        {
            if (DailySchedule == null)
                return null;
            AzureBackupDailyRetentionPolicy dailyRetention = new AzureBackupDailyRetentionPolicy("Daily", DailySchedule.CSMRetentionDuration.Count);
            dailyRetention.RetentionTimes = DailySchedule.RetentionTimes;

            return dailyRetention;
        }

        private static AzureBackupWeeklyRetentionPolicy ConvertToPowershellWeeklyRetentionObject(CSMWeeklyRetentionSchedule WeeklySchedule)
        {
            if (WeeklySchedule == null)
                return null;
            AzureBackupWeeklyRetentionPolicy weeklyRetention = new AzureBackupWeeklyRetentionPolicy("Weekly", WeeklySchedule.CSMRetentionDuration.Count,
                WeeklySchedule.DaysOfTheWeek);
            weeklyRetention.RetentionTimes = WeeklySchedule.RetentionTimes;

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

            monthlyRetention.RetentionTimes = MonthlySchedule.RetentionTimes;
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

            yearlyRetention.RetentionTimes = YearlySchedule.RetentionTimes;
            return yearlyRetention;
        }

        private static List<string> ConvertToPowershellDayList(IList<Day> daysOfTheMonthList)
        {
            List<string> dayList = new List<string>();
            foreach (Day day in daysOfTheMonthList)
            {
                if (day.IsLast)
                {
                    dayList.Add(LastDayOfTheMonth);
                }
                else
                {
                    dayList.Add(day.Date.ToString());
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
                if (string.Compare(DayOfMonth, LastDayOfTheMonth, true) == 0)
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
