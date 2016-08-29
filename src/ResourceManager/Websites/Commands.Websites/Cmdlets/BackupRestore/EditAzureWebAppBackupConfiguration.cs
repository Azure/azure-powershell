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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// Modifies the automatic backup configuration for an Azure Web App
    /// </summary>
    [Cmdlet(VerbsData.Edit, "AzureRmWebAppBackupConfiguration"), OutputType(typeof(AzureWebAppBackupConfiguration))]
    public class EditAzureWebAppBackupConfiguration : WebAppOptionalSlotBaseCmdlet
    {
        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The SAS URL for the Azure Storage container used to store the backup.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountUrl;

        [Parameter(Position = 4, Mandatory = true, HelpMessage = "Numeric value for how often the backups should be made.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public int FrequencyInterval { get; set; }

        [Parameter(Position = 5, Mandatory = true, HelpMessage = "Unit of time for how often the backups should be made. Options are \"Hour\" and \"Day\".", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string FrequencyUnit { get; set; }

        [Parameter(Position = 6, Mandatory = true, HelpMessage = "How many days the automatic backups should be saved before being automatically deleted.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public int RetentionPeriodInDays { get; set; }

        [Parameter(Position = 7, Mandatory = false, HelpMessage = "The time when the automatic backups should begin. Backups will begin immediately if this is null.", ValueFromPipelineByPropertyName = true)]
        public DateTime StartTime { get; set; }

        [Parameter(Position = 8, Mandatory = false, HelpMessage = "The databases to backup.", ValueFromPipelineByPropertyName = true)]
        public DatabaseBackupSetting[] Databases;

        [Parameter(Position = 9, Mandatory = false, HelpMessage = "True if one backup should always be kept in the storage account, regardless of how old it is.", ValueFromPipelineByPropertyName = true)]
        public SwitchParameter KeepAtLeastOneBackup { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            var freq = BackupRestoreUtils.StringToFrequencyUnit(FrequencyUnit);
            BackupSchedule schedule = new BackupSchedule(freq, FrequencyInterval, KeepAtLeastOneBackup.IsPresent,
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
            WebsitesClient.UpdateWebAppBackupConfiguration(ResourceGroupName, Name, Slot, request);
            var config = new AzureWebAppBackupConfiguration()
            {
                Name = this.Name,
                ResourceGroupName = this.ResourceGroupName,
                StorageAccountUrl = this.StorageAccountUrl,
                FrequencyInterval = this.FrequencyInterval,
                FrequencyUnit = this.FrequencyUnit,
                RetentionPeriodInDays = this.RetentionPeriodInDays,
                StartTime = this.StartTime,
                KeepAtLeastOneBackup = this.KeepAtLeastOneBackup.IsPresent,
                Databases = this.Databases,
                Enabled = true
            };
            WriteObject(config);
        }
    }
}
