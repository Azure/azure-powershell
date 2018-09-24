﻿// ----------------------------------------------------------------------------------
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

using System.Security;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    /// <summary>
    /// Autobackup public settings to configure managed backup on SQL VM
    /// </summary>
    public class PublicAutoBackupSettings
    {
        /// <summary>
        /// Defines if the Auto-backup feature is enabled or disabled
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// Defines if backups will be encrypted or not
        /// </summary>
        public bool EnableEncryption { get; set; }

        /// <summary>
        /// Defines the number of days to keep the backups
        /// </summary>
        public int RetentionPeriod { get; set; }

        /// <summary>
        /// Whether to include system databases in Backup
        /// </summary>
        public bool? BackupSystemDbs { get; set; }

        /// <summary>
        /// Gets the Backup Schedule Type
        /// </summary>
        public string BackupScheduleType { get; set; }

        /// <summary>
        /// Gets the Full Backup Frequency
        /// </summary>
        public string FullBackupFrequency { get; set; }

        /// <summary>
        /// Gets the Full Backup Start Time
        /// </summary>
        public int? FullBackupStartTime { get; set; }

        /// <summary>
        /// Gets the Full Backup Window Hours
        /// </summary>
        public int? FullBackupWindowHours { get; set; }

        /// <summary>
        /// Gets the Log Backup Frequency
        /// </summary>
        public int? LogBackupFrequency { get; set; }
    }
}
