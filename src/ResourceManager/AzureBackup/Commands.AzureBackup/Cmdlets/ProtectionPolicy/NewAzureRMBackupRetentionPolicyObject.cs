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

using Microsoft.Azure.Commands.AzureBackup.Helpers;
using Microsoft.Azure.Commands.AzureBackup.Models;
using Microsoft.Azure.Management.BackupServices.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Create new retention policy object.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmBackupRetentionPolicyObject"), OutputType(typeof(AzureRMBackupRetentionPolicy), typeof(List<AzureRMBackupRetentionPolicy>))]
    public class NewAzureRMBackupRetentionPolicyObject : AzureBackupCmdletBase
    {
        protected const string DailyRetentionParamSet = "DailyRetentionParamSet";
        protected const string WeeklyRetentionParamSet = "WeeklyRetentionParamSet";
        protected const string MonthlyRetentionInDailyFormatParamSet = "MonthlyRetentionInDailyFormatParamSet";
        protected const string MonthlyRetentionInWeeklyFormatParamSet = "MonthlyRetentionInWeeklyFormatParamSet";
        protected const string YearlyRetentionInDailyFormatParamSet = "YearlyRetentionInDailyFormatParamSet";
        protected const string YearlyRetentionInWeeklyFormatParamSet = "YearlyRetentionInWeeklyFormatParamSet";

        [Parameter(ParameterSetName = DailyRetentionParamSet, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.DailyRetention)]
        public SwitchParameter DailyRetention { get; set; }

        [Parameter(ParameterSetName = WeeklyRetentionParamSet, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.WeeklyRetention)]
        public SwitchParameter WeeklyRetention { get; set; }

        [Parameter(ParameterSetName = MonthlyRetentionInDailyFormatParamSet, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.MonthlyRetentionInDailyFormat)]
        public SwitchParameter MonthlyRetentionInDailyFormat { get; set; }

        [Parameter(ParameterSetName = MonthlyRetentionInWeeklyFormatParamSet, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.MonthlyRetentionInWeeklyFormat)]
        public SwitchParameter MonthlyRetentionInWeeklyFormat { get; set; }

        [Parameter(ParameterSetName = YearlyRetentionInDailyFormatParamSet, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.YearlyRetentionInDailyFormat)]
        public SwitchParameter YearlyRetentionInDailyFormat { get; set; }

        [Parameter(ParameterSetName = YearlyRetentionInWeeklyFormatParamSet, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.YearlyRetentionInWeeklyFormat)]
        public SwitchParameter YearlyRetentionInWeeklyFormat { get; set; }

        [Parameter(ParameterSetName = WeeklyRetentionParamSet, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.DaysOfWeek)]
        [Parameter(ParameterSetName = MonthlyRetentionInWeeklyFormatParamSet, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.DaysOfWeek)]
        [Parameter(ParameterSetName = YearlyRetentionInWeeklyFormatParamSet, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.DaysOfWeek)]
        [ValidateSet("Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", IgnoreCase = true)]
        public string[] DaysOfWeek { get; set; }

        [Parameter(ParameterSetName = MonthlyRetentionInDailyFormatParamSet, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.DaysOfMonth)]
        [Parameter(ParameterSetName = YearlyRetentionInDailyFormatParamSet, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.DaysOfMonth)]
        [ValidateSet("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18",
            "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "Last", IgnoreCase = true)]
        public List<string> DaysOfMonth { get; set; }

        [Parameter(ParameterSetName = MonthlyRetentionInWeeklyFormatParamSet, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.WeekNumber)]
        [Parameter(ParameterSetName = YearlyRetentionInWeeklyFormatParamSet, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.WeekNumber)]
        [ValidateSet("First", "Second", "Third", "Fourth", "Last", IgnoreCase = true)]
        public string[] WeekNumber { get; set; }

        [Parameter(ParameterSetName = YearlyRetentionInDailyFormatParamSet, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.MonthsOfYear)]
        [Parameter(ParameterSetName = YearlyRetentionInWeeklyFormatParamSet, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.MonthsOfYear)]
        [ValidateSet("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December", IgnoreCase = true)]
        public string[] MonthsOfYear { get; set; }

        [Parameter(Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.Retention)]
        public int Retention { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();
                if (DailyRetention != false)
                {
                    AzureRMBackupRetentionPolicy retentionPolicy = new AzureBackupDailyRetentionPolicy(RetentionType.Daily.ToString(), Retention);
                    ProtectionPolicyHelpers.ValidateRetentionPolicy(new List<AzureRMBackupRetentionPolicy> { retentionPolicy });
                    WriteObject(retentionPolicy);
                }

                if (WeeklyRetention != false)
                {
                    List<DayOfWeek> daysofWeekList = ConvertDaysOfWeek(DaysOfWeek);
                    AzureRMBackupRetentionPolicy retentionPolicy = new AzureBackupWeeklyRetentionPolicy(RetentionType.Weekly.ToString(), Retention, daysofWeekList);
                    ProtectionPolicyHelpers.ValidateRetentionPolicy(new List<AzureRMBackupRetentionPolicy> { retentionPolicy });
                    WriteObject(retentionPolicy);
                }

                if (MonthlyRetentionInDailyFormat != false)
                {
                    AzureRMBackupRetentionPolicy retentionPolicy = new AzureBackupMonthlyRetentionPolicy(RetentionType.Monthly.ToString(), Retention, RetentionFormat.Daily, DaysOfMonth,
                        null, null);
                    ProtectionPolicyHelpers.ValidateRetentionPolicy(new List<AzureRMBackupRetentionPolicy> { retentionPolicy });
                    WriteObject(retentionPolicy);
                }

                if (MonthlyRetentionInWeeklyFormat != false)
                {
                    List<DayOfWeek> daysofWeekList = ConvertDaysOfWeek(DaysOfWeek);
                    List<WeekNumber> weekNumbers = ConvertWeekNumbers(WeekNumber);
                    AzureRMBackupRetentionPolicy retentionPolicy = new AzureBackupMonthlyRetentionPolicy(RetentionType.Monthly.ToString(), Retention, RetentionFormat.Weekly, DaysOfMonth,
                        weekNumbers, daysofWeekList);

                    ProtectionPolicyHelpers.ValidateRetentionPolicy(new List<AzureRMBackupRetentionPolicy> { retentionPolicy });

                    WriteObject(retentionPolicy);
                }

                if (YearlyRetentionInDailyFormat != false)
                {
                    List<Month> monthsOfYear = ConvertMonthsOfYear(MonthsOfYear);
                    AzureRMBackupRetentionPolicy retentionPolicy = new AzureBackupYearlyRetentionPolicy(RetentionType.Yearly.ToString(), Retention, monthsOfYear, RetentionFormat.Daily,
                        DaysOfMonth, null, null);

                    ProtectionPolicyHelpers.ValidateRetentionPolicy(new List<AzureRMBackupRetentionPolicy> { retentionPolicy });

                    WriteObject(retentionPolicy);
                }

                if (YearlyRetentionInWeeklyFormat != false)
                {
                    List<DayOfWeek> daysofWeekList = ConvertDaysOfWeek(DaysOfWeek);
                    List<WeekNumber> weekNumbers = ConvertWeekNumbers(WeekNumber);
                    List<Month> monthsOfYear = ConvertMonthsOfYear(MonthsOfYear);
                    AzureRMBackupRetentionPolicy retentionPolicy = new AzureBackupYearlyRetentionPolicy(RetentionType.Yearly.ToString(), Retention, monthsOfYear,
                        RetentionFormat.Weekly, DaysOfMonth, weekNumbers, daysofWeekList);

                    ProtectionPolicyHelpers.ValidateRetentionPolicy(new List<AzureRMBackupRetentionPolicy> { retentionPolicy });

                    WriteObject(retentionPolicy);
                }
            });
        }

        private List<DayOfWeek> ConvertDaysOfWeek(string[] daysOfWeek)
        {
            List<DayOfWeek> ListofWeekDays = new List<DayOfWeek>();

            foreach (var dayOfWeek in daysOfWeek)
            {
                DayOfWeek item = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayOfWeek, true);
                if (!ListofWeekDays.Contains(item))
                {
                    ListofWeekDays.Add(item);
                }
            }

            return ListofWeekDays;
        }

        private List<WeekNumber> ConvertWeekNumbers(string[] weekNumbers)
        {
            List<WeekNumber> ListofWeekNumbers = new List<WeekNumber>();

            foreach (var weekNumber in weekNumbers)
            {
                WeekNumber item = (WeekNumber)Enum.Parse(typeof(WeekNumber), weekNumber, true);
                if (!ListofWeekNumbers.Contains(item))
                {
                    ListofWeekNumbers.Add(item);
                }
            }

            return ListofWeekNumbers;
        }

        private List<Month> ConvertMonthsOfYear(string[] monthsOfYear)
        {
            List<Month> ListofMonthsOfYear = new List<Month>();

            foreach (var monthOfYear in monthsOfYear)
            {
                Month item = (Month)Enum.Parse(typeof(Month), monthOfYear, true);
                if (!ListofMonthsOfYear.Contains(item))
                {
                    ListofMonthsOfYear.Add(item);
                }
            }
            return ListofMonthsOfYear;
        }
    }
}
