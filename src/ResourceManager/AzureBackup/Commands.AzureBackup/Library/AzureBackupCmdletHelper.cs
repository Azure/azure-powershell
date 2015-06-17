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

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{   
        public class AzureBackupCmdletHelper
        {
            public const int MinRetentionInDays = 7;
            public const int MaxRetentionInDays = 30;
            public const int MinRetentionInWeeks = 1;
            public const int MaxRetentionInWeeks = 4;
            public static AzureBackupCmdletBase azureBackupCmdletBase;

            public AzureBackupCmdletHelper(AzureBackupCmdletBase azureBackupCmd)
            {
                azureBackupCmdletBase = azureBackupCmd;
            }

            public static void WriteAzureBackupProtectionPolicy(string ResourceGroupName,
                string ResourceName, string Location, ProtectionPolicyInfo sourcePolicy)
            {
                azureBackupCmdletBase.WriteObject(new AzureBackupProtectionPolicy(ResourceGroupName, ResourceName, Location, sourcePolicy));
            }

            public static void WriteAzureBackupProtectionPolicy(string ResourceGroupName,
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

            public static BackupSchedule FillBackupSchedule(string backupType, string scheduleType, DateTime scheduleStartTime,
                string retentionType, int retentionDuration, string[] scheduleRunDays)
            {
                var backupSchedule = new BackupSchedule();

                backupSchedule.BackupType = backupType;
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

            public static void ValidateAzureBackupPolicyRequest(AzureBackupProtectionPolicy policy)
            {

                //ValidateWorkloadType(azureBackupCmd, policy.WorkloadType);
                ValidateBackupType(policy.BackupType);
                ValidateScheduleType(policy.ScheduleType);
                ValidateScheduleRunDays(policy.ScheduleRunDays);
                ValidateRetentionType(policy.RetentionType);
            }

            private static void ValidateWorkloadType(string workloadType)
            {
                WorkloadType item = (WorkloadType)Enum.Parse(typeof(WorkloadType), workloadType, true);

                if (item != WorkloadType.VM)
                {
                    var exception = new Exception("Invalid value for param WorkloadType, Valid values are VM.");
                    var errorRecord = new ErrorRecord(exception, string.Empty, ErrorCategory.InvalidData, null);
                    azureBackupCmdletBase.WriteError(errorRecord);
                }
            }

            private static void ValidateBackupType(string backupType)
            {
                BackupType item = (BackupType)Enum.Parse(typeof(BackupType), backupType, true);

                if (item != BackupType.Full)
                {
                    var exception = new Exception("Invalid value for param BackupType, Valid values are Full.");
                    var errorRecord = new ErrorRecord(exception, string.Empty, ErrorCategory.InvalidData, null);
                    azureBackupCmdletBase.WriteError(errorRecord);
                }
            }

            private static void ValidateScheduleType(string scheduleType)
            {
                ScheduleType item = (ScheduleType)Enum.Parse(typeof(ScheduleType), scheduleType, true);

                if (!(item == ScheduleType.Daily || item == ScheduleType.Weekly))
                {
                    var exception = new Exception("Invalid value for param ScheduleType, Valid values are Daily, Weekly.");
                    var errorRecord = new ErrorRecord(exception, string.Empty, ErrorCategory.InvalidData, null);
                    azureBackupCmdletBase.WriteError(errorRecord);
                }
            }

            private static void ValidateRetentionType(string retentionType)
            {
                RetentionType item = (RetentionType)Enum.Parse(typeof(RetentionType), retentionType, true);

                if (!(item == RetentionType.Days || item == RetentionType.Weeks))
                {
                    var exception = new Exception("Invalid value for param RetentionType, Valid values are Days, Weeks.");
                    var errorRecord = new ErrorRecord(exception, string.Empty, ErrorCategory.InvalidData, null);
                    azureBackupCmdletBase.WriteError(errorRecord);
                }
            }

            private static void ValidateScheduleRunDays(List<string> scheduleRunDays)
            {
                foreach (string scheduleRunDay in scheduleRunDays)
                {
                    DayOfWeek item = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), scheduleRunDay, true);

                    if (!(item == DayOfWeek.Sunday || item == DayOfWeek.Monday || item == DayOfWeek.Tuesday ||
                        item == DayOfWeek.Wednesday || item == DayOfWeek.Thursday || item == DayOfWeek.Friday || item == DayOfWeek.Saturday))
                    {
                        var exception = new Exception("Invalid value for param ScheduleRunDays, " +
                            "Valid values are Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday");
                        var errorRecord = new ErrorRecord(exception, string.Empty, ErrorCategory.InvalidData, null);
                        azureBackupCmdletBase.WriteError(errorRecord);
                    }
                }
            }
            private static RetentionPolicy FillRetentionPolicy(string retentionType, int retentionDuration)
            {
                ValidateRetentionRange(retentionType, retentionDuration);
                var retentionPolicy = new RetentionPolicy
                {
                    RetentionType = (RetentionDurationType)Enum.Parse(typeof(RetentionDurationType), retentionType, true),
                    RetentionDuration = retentionDuration
                };

                return retentionPolicy;
            }

            private static void ValidateRetentionRange(string retentionType, int retentionDuration)
            {
                if(retentionType == RetentionDurationType.Days.ToString() && (retentionDuration < MinRetentionInDays
                    || retentionDuration > MaxRetentionInDays))
                {
                    var exception = new Exception("For Retention in days , valid values of retention duration are 7 to 30.");
                    var errorRecord = new ErrorRecord(exception, string.Empty, ErrorCategory.InvalidData, null);
                    azureBackupCmdletBase.WriteError(errorRecord);
                }

                if (retentionType == RetentionDurationType.Weeks.ToString() && (retentionDuration < MinRetentionInWeeks
                    || retentionDuration > MaxRetentionInWeeks))
                {
                    var exception = new Exception("For Retention in weeks , valid values of retention duration are 1 to 4.");
                    var errorRecord = new ErrorRecord(exception, string.Empty, ErrorCategory.InvalidData, null);
                    azureBackupCmdletBase.WriteError(errorRecord);
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
                    var exception = new Exception("For weekly scheduletype , ScheduleRunDays should not be empty.");
                    var errorRecord = new ErrorRecord(exception, string.Empty, ErrorCategory.InvalidData, null);
                    azureBackupCmdletBase.WriteError(errorRecord);
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

            private static DateTime ParseScheduleRunTime(DateTime scheduleStartTime)
            {
                scheduleStartTime = scheduleStartTime.ToUniversalTime();
                DateTime scheduleRunTime = new DateTime(scheduleStartTime.Year, scheduleStartTime.Month,
                    scheduleStartTime.Day, scheduleStartTime.Hour, scheduleStartTime.Minute - (scheduleStartTime.Minute % 30), 0);
                return scheduleRunTime;
            }
        }
}
