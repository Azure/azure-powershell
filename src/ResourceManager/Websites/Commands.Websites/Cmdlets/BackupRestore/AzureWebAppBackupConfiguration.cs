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
    /// A simple class containing fields for all metadata associated with a backup configuration.
    /// </summary>
    public class AzureWebAppBackupConfiguration
    {
        /// <summary>
        /// The name of the web app
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The resource group of the web app
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// SAS URL for the storage account container to use for scheduled backups
        /// </summary>
        public string StorageAccountUrl { get; set; }

        /// <summary>
        /// Numeric part of backup frequency. For example, for weekly backups, FrequencyInterval = 7 and FrequencyUnit = Day.
        /// </summary>
        public int? FrequencyInterval { get; set; }

        /// <summary>
        /// Unit of backup frequency. Valid options are Hour and Day. For example, for weekly backups, FrequencyInterval = 7 and FrequencyUnit = Day.
        /// </summary>
        public string FrequencyUnit { get; set; }

        /// <summary>
        /// Number of days the automatic backups should be retained before being automatically deleted.
        /// </summary>
        public int? RetentionPeriodInDays { get; set; }

        /// <summary>
        /// The time when the first automatic backup should be created.
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// The databases to be backed up automatically along with the web app
        /// </summary>
        public DatabaseBackupSetting[] Databases { get; set; }

        /// <summary>
        /// True if one backup should always be left in the storage account regardless of retention period.
        /// </summary>
        public bool? KeepAtLeastOneBackup { get; set; }

        /// <summary>
        /// True if the automatic backups are enabled.
        /// </summary>
        public bool? Enabled { get; set; }
    }
}