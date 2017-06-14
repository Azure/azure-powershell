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
using Microsoft.Azure.Management.BackupServices.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.AzureBackup.Models
{
    /// <summary>
    /// Represents ProtectionPolicy object
    /// </summary>
    public class AzureRMBackupProtectionPolicy : AzureBackupVaultContextObject
    {
        /// <summary>
        /// Name of the azurebackup object
        /// </summary>

        public string PolicyId { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string ScheduleType { get; set; }

        public List<string> DaysOfWeek { get; set; }

        public DateTime BackupTime { get; set; }

        public IList<AzureRMBackupRetentionPolicy> RetentionPolicy { get; set; }

        public AzureRMBackupProtectionPolicy()
        {
        }

        public AzureRMBackupProtectionPolicy(AzureRMBackupVault vault, CSMProtectionPolicyProperties sourcePolicy, string policyId)
            : base(vault)
        {
            PolicyId = policyId;
            Name = sourcePolicy.PolicyName;
            Type = ProtectionPolicyHelpers.ConvertToPowershellWorkloadType(sourcePolicy.WorkloadType);
            ScheduleType = sourcePolicy.BackupSchedule.ScheduleRun;
            BackupTime = ProtectionPolicyHelpers.ConvertToPowershellScheduleRunTimes(sourcePolicy.BackupSchedule.ScheduleRunTimes);
            DaysOfWeek = ProtectionPolicyHelpers.ConvertToPowershellScheduleRunDays(sourcePolicy.BackupSchedule.ScheduleRunDays);
            RetentionPolicy = ProtectionPolicyHelpers.ConvertCSMRetentionPolicyListToPowershell(sourcePolicy.LtrRetentionPolicy);
        }
    }

    public class AzureRMBackupRetentionPolicy
    {
        public string RetentionType { get; set; }

        public int Retention { get; set; }

        public IList<DateTime> RetentionTimes { get; set; }

        public AzureRMBackupRetentionPolicy(string retentionType, int retention)
        {
            this.RetentionType = retentionType;
            this.Retention = retention;
        }
    }

    public class AzureBackupDailyRetentionPolicy : AzureRMBackupRetentionPolicy
    {
        public AzureBackupDailyRetentionPolicy(string retentionType, int retention)
            : base(retentionType, retention)
        { }
    }

    public class AzureBackupWeeklyRetentionPolicy : AzureRMBackupRetentionPolicy
    {
        public List<DayOfWeek> DaysOfWeek { get; set; }
        public AzureBackupWeeklyRetentionPolicy(string retentionType, int retention, IList<DayOfWeek> daysOfWeek)
            : base(retentionType, retention)
        {
            this.DaysOfWeek = new List<DayOfWeek>(daysOfWeek);
        }
    }

    public class AzureBackupMonthlyRetentionPolicy : AzureRMBackupRetentionPolicy
    {
        public RetentionFormat RetentionFormat { get; set; }

        public List<string> DaysOfMonth { get; set; }

        public List<WeekNumber> WeekNumber { get; set; }

        public List<DayOfWeek> DaysOfWeek { get; set; }

        public AzureBackupMonthlyRetentionPolicy(string retentionType, int retention, RetentionFormat retentionFormat, List<string> daysOfMonth,
            List<WeekNumber> weekNumber, List<DayOfWeek> daysOfWeek)
            : base(retentionType, retention)
        {
            this.RetentionFormat = retentionFormat;
            this.DaysOfMonth = daysOfMonth;
            this.WeekNumber = weekNumber;
            this.DaysOfWeek = daysOfWeek;
        }
    }

    public class AzureBackupYearlyRetentionPolicy : AzureRMBackupRetentionPolicy
    {
        public List<Month> MonthsOfYear { get; set; }

        public RetentionFormat RetentionFormat { get; set; }

        public List<string> DaysOfMonth { get; set; }

        public List<WeekNumber> WeekNumber { get; set; }

        public List<DayOfWeek> DaysOfWeek { get; set; }

        public AzureBackupYearlyRetentionPolicy(string retentionType, int retention, List<Month> monthsOfYear, RetentionFormat retentionFormat, List<string> daysOfMonth,
            List<WeekNumber> weekNumber, List<DayOfWeek> daysOfWeek)
            : base(retentionType, retention)
        {
            this.MonthsOfYear = monthsOfYear;
            this.RetentionFormat = retentionFormat;
            this.DaysOfMonth = daysOfMonth;
            this.WeekNumber = weekNumber;
            this.DaysOfWeek = daysOfWeek;
        }
    }

}
