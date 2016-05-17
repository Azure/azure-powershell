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

using Microsoft.Azure.Management.WebSites.Models;
using System;
using System.Linq;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    internal class BackupRestoreUtils
    {
        public static FrequencyUnit StringToFrequencyUnit(string frequencyUnit)
        {
            FrequencyUnit freq;
            try
            {
                freq = (FrequencyUnit)Enum.Parse(typeof(FrequencyUnit), frequencyUnit, true);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException(string.Format("{0} is not a valid FrequencyUnit. Valid options are Hour and Day.", frequencyUnit));
            }
            return freq;
        }

        public static AzureWebAppBackup BackupItemToAppBackup(BackupItem backup, string resourceGroupName, string name, string slot)
        {
            if (backup == null)
            {
                return new AzureWebAppBackup();
            }
            var dbs = backup.Databases == null ? null : backup.Databases.ToArray();
            string status = backup.Status == null ? null : backup.Status.ToString();
            return new AzureWebAppBackup
            {
                ResourceGroupName = resourceGroupName,
                Name = name,
                Slot = slot,
                StorageAccountUrl = backup.StorageAccountUrl,
                BlobName = backup.BlobName,
                Databases = dbs,
                BackupId = backup.BackupItemId,
                BackupName = backup.BackupItemName,
                BackupStatus = status,
                Scheduled = backup.Scheduled,
                BackupSizeInBytes = backup.SizeInBytes,
                WebsiteSizeInBytes = backup.WebsiteSizeInBytes,
                Created = backup.Created,
                LastRestored = backup.LastRestoreTimeStamp,
                Finished = backup.FinishedTimeStamp,
                Log = backup.Log,
                CorrelationId = backup.CorrelationId
            };
        }

        public static AzureWebAppBackupConfiguration BackupRequestToAppBackupConfiguration(BackupRequest configuration, string resourceGroupName, string name, string slot)
        {
            if (configuration == null)
            {
                return new AzureWebAppBackupConfiguration();
            }
            BackupSchedule schedule = configuration.BackupSchedule;
            DatabaseBackupSetting[] databases = null;
            bool? enabled = configuration.Enabled;
            if (configuration.Databases != null)
            {
                databases = configuration.Databases.ToArray();
            }

            int? frequencyInterval = null;
            string frequencyUnit = null;
            int? retentionPeriodInDays = null;
            DateTime? startTime = null;
            bool? keepAtLeastOneBackup = null;
            if (schedule != null)
            {
                frequencyInterval = schedule.FrequencyInterval;
                if (schedule.FrequencyUnit != null)
                {
                    frequencyUnit = schedule.FrequencyUnit.ToString();
                }
                retentionPeriodInDays = schedule.RetentionPeriodInDays;
                startTime = schedule.StartTime;
                keepAtLeastOneBackup = schedule.KeepAtLeastOneBackup;
            }

            return new AzureWebAppBackupConfiguration()
            {
                Name = name,
                ResourceGroupName = resourceGroupName,
                StorageAccountUrl = configuration.StorageAccountUrl,
                FrequencyInterval = frequencyInterval,
                FrequencyUnit = frequencyUnit,
                RetentionPeriodInDays = retentionPeriodInDays,
                StartTime = startTime,
                Databases = databases,
                KeepAtLeastOneBackup = keepAtLeastOneBackup,
                Enabled = enabled
            };
        }
    }
}
