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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.WebSites.Models;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// Modifies the automatic backup configuration for an Azure Web App
    /// </summary>
    [Cmdlet(VerbsData.Edit, "AzureRmWebAppBackupConfiguration")]
    public class EditAzureWebAppBackupConfiguration : WebAppOptionalSlotBaseCmdlet
    {
        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The SAS URL for the Azure Storage container used to store the backup.")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountUrl;

        [Parameter(Position = 4, Mandatory = true, HelpMessage = "Numeric value for how often the backups should be made.")]
        [ValidateNotNullOrEmpty]
        public int FrequencyInterval { get; set; }

        [Parameter(Position = 5, Mandatory = true, HelpMessage = "Unit of time for how often the backups should be made.")]
        [ValidateNotNullOrEmpty]
        public FrequencyUnit FrequencyUnit { get; set; }

        [Parameter(Position = 6, Mandatory = true, HelpMessage = "How many days the automatic backups should be saved before being automatically deleted.")]
        [ValidateNotNullOrEmpty]
        public int RetentionPeriodInDays { get; set; }

        [Parameter(Position = 7, Mandatory = true, HelpMessage = "The time when the automatic backups should begin.")]
        [ValidateNotNullOrEmpty]
        public DateTime StartTime { get; set; }

        [Parameter(Position = 8, Mandatory = false, HelpMessage = "True if one backup should always be kept in the storage account, regardless of how old it is.")]
        public SwitchParameter KeepAtLeastOneBackup { get; set; }

        [Parameter(Position = 9, Mandatory = false, HelpMessage = "The databases to backup.")]
        [ValidateNotNullOrEmpty]
        public DatabaseBackupSetting[] Databases;

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            BackupSchedule schedule = new BackupSchedule(FrequencyUnit, FrequencyInterval, KeepAtLeastOneBackup.IsPresent,
                RetentionPeriodInDays, StartTime);
            BackupRequest request = new BackupRequest()
            {
                Location = "",
                Enabled = true,
                StorageAccountUrl = this.StorageAccountUrl,
                BackupSchedule = schedule,
                Databases = this.Databases,
                BackupRequestType = BackupRestoreOperationType.Default
            };
            WriteObject(WebsitesClient.UpdateWebAppBackupConfiguration(ResourceGroupName, Name, Slot, request));
        }
    }
}
