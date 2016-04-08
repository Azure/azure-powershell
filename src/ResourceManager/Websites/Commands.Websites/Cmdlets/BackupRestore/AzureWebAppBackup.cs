
using System;
using Microsoft.Azure.Management.WebSites.Models;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    public class AzureWebAppBackup
    {
        public string ResourceGroupName { get; set; }
        public string Name { get; set; }
        public string Slot { get; set; }
        public string StorageAccountUrl { get; set; }
        public string BlobName { get; set; }
        public DatabaseBackupSetting[] Databases { get; set; }
        public int? BackupId { get; set; }
        public string BackupName { get; set; }
        public string BackupStatus { get; set; }
        public bool Scheduled { get; set; }
        public long? BackupSizeInBytes { get; set; }
        public long? WebsiteSizeInBytes { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastRestored { get; set; }
        public DateTime? Finished { get; set; }
        public string Log { get; set; }
        public string CorrelationId { get; set; }
    }
}
