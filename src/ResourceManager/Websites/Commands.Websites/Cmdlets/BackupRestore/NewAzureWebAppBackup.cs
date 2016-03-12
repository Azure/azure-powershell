using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.WebSites.Models;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// Creates a backup of an Azure Web App
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmWebAppBackup"), OutputType(typeof(BackupItem))]
    public class NewAzureWebAppBackup : WebAppOptionalSlotBaseCmdlet
    {
        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The SAS URL for the Azure Storage container used to store the backup.")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountUrl;

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "The name of the backup.")]
        public string BackupName { get; set; }

        [Parameter(Position = 5, Mandatory = false, HelpMessage = "The databases to backup.")]
        public DatabaseBackupSetting[] Databases;

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            BackupRequest request = new BackupRequest()
            {
                // Location is required by Resource (base class of BackupRequest)
                // to not be null, but is not actually significant for the request.
                Location = "",
                StorageAccountUrl = this.StorageAccountUrl,
                BackupRequestName = this.BackupName,
                Databases = this.Databases
            };
            WriteObject(WebsitesClient.BackupSite(ResourceGroupName, Name, Slot, request));
        }
    }
}
