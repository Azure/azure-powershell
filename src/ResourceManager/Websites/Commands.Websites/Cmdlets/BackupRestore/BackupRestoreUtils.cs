
using System;
using System.Linq;
using Microsoft.Azure.Management.WebSites.Models;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    internal class BackupRestoreUtils
    {
        public static FrequencyUnit StringToFrequencyUnit(string frequencyUnit)
        {
            FrequencyUnit freq;
            Enum.TryParse(frequencyUnit, true, out freq);
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
