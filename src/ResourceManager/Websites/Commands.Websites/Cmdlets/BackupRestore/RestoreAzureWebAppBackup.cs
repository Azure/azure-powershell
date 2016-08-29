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

using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.WebSites.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.BackupRestore
{
    /// <summary>
    /// Restores an Azure Web App backup
    /// </summary>
    [Cmdlet(VerbsData.Restore, "AzureRmWebAppBackup")]
    public class RestoreAzureWebAppBackup : WebAppOptionalSlotBaseCmdlet
    {
        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The SAS URL for the Azure Storage container used to store the backup.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountUrl;

        [Parameter(Position = 4, Mandatory = true, HelpMessage = "The name of the backup blob to restore.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string BlobName;

        [Parameter(Mandatory = false, HelpMessage = "The databases to restore. Must match the list of databases in the backup.", ValueFromPipelineByPropertyName = true)]
        public DatabaseBackupSetting[] Databases { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "If specified, an existing web app will be overwritten by the contents of the backup.", ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Overwrite;

        [Parameter(Mandatory = false, HelpMessage = "If specified, custom domains are removed automatically during restore. Otherwise, custom domains are added to the site object when it is being restored, but the restore might fail due to conflicts.", ValueFromPipelineByPropertyName = true)]
        public SwitchParameter IgnoreConflictingHostNames { get; set; }

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
            // The id here does not actually matter. It is an artifact of the CSM API requirements. It should be possible
            // to restore from a backup that is no longer stored in our Backups table.
            WebsitesClient.RestoreSite(ResourceGroupName, Name, Slot, "1", request);
        }
    }
}
