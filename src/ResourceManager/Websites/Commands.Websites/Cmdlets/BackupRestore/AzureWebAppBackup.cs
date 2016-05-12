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

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// A simple class containing fields for all metadata associated with a backup.
    /// </summary>
    public class AzureWebAppBackup
    {
        /// <summary>
        /// The resource group of the web app
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// The name of the web app
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of the web app slot
        /// </summary>
        public string Slot { get; set; }

        /// <summary>
        /// SAS URL for the storage account container which contains this backup
        /// </summary>
        public string StorageAccountUrl { get; set; }

        /// <summary>
        /// Name of the blob which contains data for this backup
        /// </summary>
        public string BlobName { get; set; }

        /// <summary>
        /// Databases backed up along with the web app
        /// </summary>
        public DatabaseBackupSetting[] Databases { get; set; }

        /// <summary>
        /// The numberic ID of this backup
        /// </summary>
        public int? BackupId { get; set; }

        /// <summary>
        /// The user-friendly name of this backup
        /// </summary>
        public string BackupName { get; set; }

        /// <summary>
        /// The status of the backup. Possible values are InProgress, Failed, Succeeded,
        /// TimedOut, Created, Skipped, PartiallySucceeded, DeleteInProgress, DeleteFailed,
        /// Deleted. 
        /// </summary>
        public string BackupStatus { get; set; }

        /// <summary>
        /// True if this backup was automatically created due to a backup schedule
        /// </summary>
        public bool? Scheduled { get; set; }

        /// <summary>
        /// The size of this backup in bytes
        /// </summary>
        public long? BackupSizeInBytes { get; set; }

        /// <summary>
        /// Size of the original web app which has been backed up
        /// </summary>
        public long? WebsiteSizeInBytes { get; set; }

        /// <summary>
        /// Time when the backup was requested
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        /// Time when the web app was last restored from this backup
        /// </summary>
        public DateTime? LastRestored { get; set; }

        /// <summary>
        /// Time when the backup finished
        /// </summary>
        public DateTime? Finished { get; set; }

        /// <summary>
        /// Log of any failures or warnings associated with this backup
        /// </summary>
        public string Log { get; set; }

        /// <summary>
        /// Unique correlation identifier. Please use this along with the timestamp while communicating with Azure support.
        /// </summary>
        public string CorrelationId { get; set; }
    }
}
