using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.WebSites.Models;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.BackupRestore
{
    /// <summary>
    /// Restores an Azure Web App backup
    /// </summary>
    [Cmdlet(VerbsData.Restore, "AzureRmWebAppBackup")]
    public class RestoreAzureWebAppBackup : WebAppOptionalSlotBaseCmdlet
    {
        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The SAS URL for the Azure Storage container used to store the backup.")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountUrl;

        [Parameter(Position = 4, Mandatory = true, HelpMessage = "The name of the backup blob to restore.")]
        [ValidateNotNullOrEmpty]
        public string BlobName;

        [Parameter(Position = 5, Mandatory = false, HelpMessage = "If specified, an existing web app will be overwritten by the contents of the backup.")]
        public SwitchParameter Overwrite;

        [Parameter(Position = 6, Mandatory = false, HelpMessage = "If specified, custom domains are removed automatically during restore. Otherwise, custom domains are added to the site object when it is being restored, but the restore might fail due to conflicts.")]
        public SwitchParameter IgnoreConflictingHostNames { get; set; }

        [Parameter(Position = 7, Mandatory = false, HelpMessage = "The databases to restore. Must match the list of databases in the backup.")]
        [ValidateNotNullOrEmpty]
        public IList<DatabaseBackupSetting> Databases { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            RestoreRequest request = new RestoreRequest()
            {
                Location = "",
                StorageAccountUrl = this.StorageAccountUrl,
                BlobName = this.BlobName,
                SiteName = CmdletHelpers.GenerateSiteWithSlotName(Name, Slot),
                Overwrite = this.Overwrite.IsPresent,
                IgnoreConflictingHostNames = this.IgnoreConflictingHostNames.IsPresent,
                Databases = this.Databases,
                OperationType = BackupRestoreOperationType.Default
            };
            // The id here does not actually matter. It is an artifact of the CSM API requirements.
            WebsitesClient.RestoreSite(ResourceGroupName, Name, Slot, "1", request);
        }

    }
}
