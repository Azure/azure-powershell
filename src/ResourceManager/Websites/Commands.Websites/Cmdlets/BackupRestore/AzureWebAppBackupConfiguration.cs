
using System;
using Microsoft.Azure.Management.WebSites.Models;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    public class AzureWebAppBackupConfiguration
    {
        public string Name { get; set; }
        public string ResourceGroupName { get; set; }
        public string StorageAccountUrl { get; set; }
        public int? FrequencyInterval { get; set; }
        public string FrequencyUnit { get; set; }
        public int? RetentionPeriodInDays { get; set; }
        public DateTime? StartTime { get; set; }
        public DatabaseBackupSetting[] Databases { get; set; }
        public bool? KeepAtLeastOneBackup { get; set; }
        public bool? Enabled { get; set; }
    }
}