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

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    public abstract class AzureBackupPolicyCmdletBase : AzureBackupVaultCmdletBase
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            WriteDebug(String.Format("Cmdlet called for ResourceGroupName: {0}, ResourceName: {1}, Location: {2}", ResourceGroupName, ResourceName, Location));
        }

        public void WriteAzureBackupProtectionPolicy(ProtectionPolicyInfo sourcePolicy)
        {
            this.WriteObject(new AzureBackupProtectionPolicy(ResourceGroupName, ResourceName, Location, sourcePolicy));
        }

        public void WriteAzureBackupProtectionPolicy(IEnumerable<ProtectionPolicyInfo> sourcePolicyList)
        {
            List<AzureBackupProtectionPolicy> targetList = new List<AzureBackupProtectionPolicy>();

            foreach (var sourcePolicy in sourcePolicyList)
            {
                targetList.Add(new AzureBackupProtectionPolicy(ResourceGroupName, ResourceName, Location, sourcePolicy));
            }

            this.WriteObject(targetList, true);
        }

        public BackupSchedule GetBackupSchedule(string backupType, string scheduleType, DateTime scheduleStartTime,
            string retentionType, int retentionDuration, string[] scheduleRunDays = null)
        {
            var backupSchedule = new BackupSchedule();

            backupSchedule.BackupType = backupType;
            backupSchedule.RetentionPolicy = GetRetentionPolicy(retentionType, retentionDuration);
            //Enum.Parse(ScheduleRunType, this.ScheduleType),
            backupSchedule.ScheduleRun = scheduleType;
            if (string.Compare(scheduleType, "Weekly", true) == 0)
            {
                backupSchedule.ScheduleRunDays = GetScheduleRunDays(scheduleRunDays);
            }

            DateTime scheduleRunTime = GetScheduleRunTime(scheduleStartTime);

            backupSchedule.ScheduleRunTimes = new List<DateTime> { scheduleRunTime };

            WriteDebug("Exiting GetBackupSchedule");
            return backupSchedule;
        }

        private RetentionPolicy GetRetentionPolicy(string retentionType, int retentionDuration)
        {
            var retentionPolicy = new RetentionPolicy
            {
                RetentionType = (RetentionDurationType)Enum.Parse(typeof(RetentionDurationType), retentionType, true),
                RetentionDuration = retentionDuration
            };

            return retentionPolicy;
        }

        private IList<DayOfWeek> GetScheduleRunDays(string[] scheduleRunDays)
        {
            if (scheduleRunDays == null || scheduleRunDays.Length <= 0)
            {
                var exception = new Exception("For weekly scheduletype , ScheduleRunDays param is required.");
                var errorRecord = new ErrorRecord(exception, string.Empty, ErrorCategory.InvalidData, null);
                WriteError(errorRecord);
            }

            IList<DayOfWeek> ListofWeekDays = new List<DayOfWeek>();

            foreach (var dayOfWeek in scheduleRunDays)
            {
                WriteDebug("dayOfWeek" + dayOfWeek.ToString());
                DayOfWeek item = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayOfWeek, true);
                WriteDebug("Item" + item.ToString());
                if (!ListofWeekDays.Contains(item))
                {
                    ListofWeekDays.Add(item);
                }
            }

            return ListofWeekDays;
        }

        private DateTime GetScheduleRunTime(DateTime scheduleStartTime)
        {
            scheduleStartTime = scheduleStartTime.ToUniversalTime();
            DateTime scheduleRunTime = new DateTime(scheduleStartTime.Year, scheduleStartTime.Month,
                scheduleStartTime.Day, scheduleStartTime.Hour, scheduleStartTime.Minute - (scheduleStartTime.Minute % 30), 0);
            return scheduleRunTime;
        }
    }
}