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

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{   
        public class AzureBackupCmdletHelper
        {
            public const int MinRetentionInDays = 7;
            public const int MaxRetentionInDays = 30;
            public const int MinRetentionInWeeks = 1;
            public const int MaxRetentionInWeeks = 4;
            public AzureBackupCmdletBase azureBackupCmdletBase {get; set;}

            public AzureBackupCmdletHelper(AzureBackupCmdletBase azureBackupCmd)
            {
                azureBackupCmdletBase = azureBackupCmd;
            }

            public void WriteAzureBackupProtectionPolicy(string ResourceGroupName,
                string ResourceName, string Location, ProtectionPolicyInfo sourcePolicy)
            {
                azureBackupCmdletBase.WriteObject(new AzureBackupProtectionPolicy(ResourceGroupName, ResourceName, Location, sourcePolicy));
            }

            public void WriteAzureBackupProtectionPolicy(string ResourceGroupName,
                string ResourceName, string Location, IEnumerable<ProtectionPolicyInfo> sourcePolicyList)
            {
                List<AzureBackupProtectionPolicy> targetList = new List<AzureBackupProtectionPolicy>();

                foreach (var sourcePolicy in sourcePolicyList)
                {
                    targetList.Add(new AzureBackupProtectionPolicy(ResourceGroupName,
                        ResourceName, Location, sourcePolicy));
                }

                azureBackupCmdletBase.WriteObject(targetList, true);
            }

            public AzureBackupProtectionPolicy GetAzureBackupProtectionPolicyByName(string policyName, string ResourceGroupName,
                string ResourceName, string Location)
            {
                var policyListResponse = azureBackupCmdletBase.AzureBackupClient.ProtectionPolicy.ListAsync(azureBackupCmdletBase.GetCustomRequestHeaders(), azureBackupCmdletBase.CmdletCancellationToken).Result;
                
                azureBackupCmdletBase.WriteDebug("Got the protectionPolicy List");

                IEnumerable<ProtectionPolicyInfo> policyObjects = null;

                policyObjects = policyListResponse.ProtectionPolicies.Objects.Where(x => x.Name.Equals(policyName, System.StringComparison.InvariantCultureIgnoreCase));

                azureBackupCmdletBase.WriteDebug("Got the protectionPolicy with Name" + policyName);

                IEnumerator<ProtectionPolicyInfo> enumerator = policyObjects.GetEnumerator();
                enumerator.MoveNext();

                ProtectionPolicyInfo protectionPolicyInfo = enumerator.Current;

                if (protectionPolicyInfo == null)
                {
                    return null;
                }

                return new AzureBackupProtectionPolicy(ResourceGroupName, ResourceName, Location, protectionPolicyInfo);
            }

            public BackupSchedule FillBackupSchedule(string backupType, string scheduleType, DateTime scheduleStartTime,
                string retentionType, int retentionDuration, string[] scheduleRunDays)
            {
                var backupSchedule = new BackupSchedule();

                backupSchedule.BackupType = Enum.Parse(typeof(BackupType), backupType, true).ToString();
                backupSchedule.RetentionPolicy = FillRetentionPolicy(retentionType, retentionDuration);

                scheduleType = FillScheduleType(scheduleType, scheduleRunDays);
                backupSchedule.ScheduleRun = scheduleType;
                
                if (string.Compare(scheduleType, ScheduleType.Weekly.ToString(), true) == 0)
                {
                    backupSchedule.ScheduleRunDays = ParseScheduleRunDays(scheduleRunDays);
                }

                DateTime scheduleRunTime = ParseScheduleRunTime(scheduleStartTime);

                backupSchedule.ScheduleRunTimes = new List<DateTime> { scheduleRunTime };

                azureBackupCmdletBase.WriteDebug("Exiting GetBackupSchedule");
                return backupSchedule;
            }

            private RetentionPolicy FillRetentionPolicy(string retentionType, int retentionDuration)
            {
                ValidateRetentionRange(retentionType, retentionDuration);
                var retentionPolicy = new RetentionPolicy
                {
                    RetentionType = (RetentionDurationType)Enum.Parse(typeof(RetentionDurationType), retentionType, true),
                    RetentionDuration = retentionDuration
                };

                return retentionPolicy;
            }

            private void ValidateRetentionRange(string retentionType, int retentionDuration)
            {
                if(retentionType == RetentionDurationType.Days.ToString() && (retentionDuration < MinRetentionInDays
                    || retentionDuration > MaxRetentionInDays))
                {
                    var exception = new Exception("For Retention in days , valid values of retention duration are 7 to 30.");
                    var errorRecord = new ErrorRecord(exception, string.Empty, ErrorCategory.InvalidData, null);
                    azureBackupCmdletBase.WriteError(errorRecord);
                    throw exception;
                }

                if (retentionType == RetentionDurationType.Weeks.ToString() && (retentionDuration < MinRetentionInWeeks
                    || retentionDuration > MaxRetentionInWeeks))
                {
                    var exception = new Exception("For Retention in weeks , valid values of retention duration are 1 to 4.");
                    var errorRecord = new ErrorRecord(exception, string.Empty, ErrorCategory.InvalidData, null);
                    azureBackupCmdletBase.WriteError(errorRecord);
                    throw exception;
                }

            }

            private string FillScheduleType(string scheduleType, string[] scheduleRunDays)
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

            private IList<DayOfWeek> ParseScheduleRunDays(string[] scheduleRunDays)
            {
                if (scheduleRunDays == null || scheduleRunDays.Length <= 0)
                {
                    var exception = new Exception("For weekly scheduletype , ScheduleRunDays should not be empty.");
                    var errorRecord = new ErrorRecord(exception, string.Empty, ErrorCategory.InvalidData, null);
                    azureBackupCmdletBase.WriteError(errorRecord);
                    throw exception;
                }

                IList<DayOfWeek> ListofWeekDays = new List<DayOfWeek>();

                foreach (var dayOfWeek in scheduleRunDays)
                {
                    azureBackupCmdletBase.WriteDebug("dayOfWeek" + dayOfWeek.ToString());
                    DayOfWeek item = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayOfWeek, true);
                    azureBackupCmdletBase.WriteDebug("Item" + item.ToString());
                    if (!ListofWeekDays.Contains(item))
                    {
                        ListofWeekDays.Add(item);
                    }
                }

                return ListofWeekDays;
            }

            private DateTime ParseScheduleRunTime(DateTime scheduleStartTime)
            {
                scheduleStartTime = scheduleStartTime.ToUniversalTime();
                DateTime scheduleRunTime = new DateTime(scheduleStartTime.Year, scheduleStartTime.Month,
                    scheduleStartTime.Day, scheduleStartTime.Hour, scheduleStartTime.Minute - (scheduleStartTime.Minute % 30), 0);
                return scheduleRunTime;
            }
        }
}
