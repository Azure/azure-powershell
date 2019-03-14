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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute
{
    /// <summary>
    /// SQL Server Configuration object that is returned by extension as a substatus.
    /// </summary>
    public class AzureVMSqlServerConfiguration
    {
        /// <summary>
        /// Auto Patching report object
        /// </summary>
        public class AutoPatchingReport
        { 
            public string Name { get; set; }
            public int Status { get; set; }
            public bool Enable { get; set; }
            public string DayOfWeek { get; set; }
            public int MaintenanceWindowStartingHour { get; set; }
            public int MaintenanceWindowDuration { get; set; }
            public string PatchCategory { get; set; }
        }

        /// <summary>
        /// Auto Backup report object
        /// </summary>
        public class AutoBackupReport
        {
            public string Name { get; set; }
            public int Status { get; set; }
            public bool Enable { get; set; }
            public bool EnableEncryption { get; set; }
            public string StorageAccountUrl { get; set; }
            public int RetentionPeriod { get; set; }
            public string BackupScheduleType { get; set; }
            public bool? BackupSystemDbs { get; set; }
            public string FullBackupFrequency { get; set; }
            public int? FullBackupStartTime { get; set; }
            public int? FullBackupWindowHours { get; set; }
            public int? LogBackupFrequency { get; set; }
        }

        /// <summary>
        /// Azure Key Vault report object
        /// </summary>
        public class AzureKeyVaultReport
        {
            public string Name { get; set; }
            public int Status { get; set; }
            public bool Enable { get; set; }
            public bool EnableEncryption { get; set; }
            public List<AzureVMSqlServerKeyVaultCredential> CredentialsList { get; set; }
        }
        
        /// <summary>
        /// Auto telemetry report object
        /// </summary>
        public class AutoTelemetrySettingsReport
        {
            public string Name { get; set; }
            public int Status { get; set; }
            public string Location { get; set; }
            public string PerformanceCollectorStatus { get; set; }
        }

        /// <summary>
        /// Auto patching settings
        /// </summary>
        public AutoPatchingReport AutoPatching { get; set; }

        /// <summary>
        /// Auto-backup settings
        /// </summary>
        public AutoBackupReport AutoBackup { get; set; }

        /// <summary>
        /// AkV settings
        /// </summary>
        public AzureKeyVaultReport AzureKeyVault { get; set; }

        /// <summary>
        /// Auto-telemetry settings
        /// </summary>
        public AutoTelemetrySettingsReport AutoTelemetryReport { get; set; }
    }
}
