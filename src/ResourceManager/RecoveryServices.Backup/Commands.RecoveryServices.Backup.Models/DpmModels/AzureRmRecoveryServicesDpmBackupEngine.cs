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

using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    public class AzureRmRecoveryServicesBackupDpmBackupEngine : AzureRmRecoveryServicesBackupEngineBase
    {
        /// <summary>
        /// Friendly name of the container
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Registration Status
        /// </summary>
        public string Status { get; set; }

        public AzureRmRecoveryServicesBackupDpmBackupEngine(BackupEngineResource backupEngine)
            : base(backupEngine)
        {
            BackupEngineBase dpmBackupEngine = (BackupEngineBase)backupEngine.Properties;
            FriendlyName = dpmBackupEngine.FriendlyName;
            Status = dpmBackupEngine.RegistrationStatus;
        }
    }

    public class AzureRmRecoveryServicesBackupAzureBackupServerEngine : AzureRmRecoveryServicesBackupEngineBase
    {
        /// <summary>
        /// Friendly name of the container
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Registration Status
        /// </summary>
        public string Status { get; set; }

        public AzureRmRecoveryServicesBackupAzureBackupServerEngine(BackupEngineResource backupEngine)
            : base(backupEngine)
        {
            AzureBackupServerEngine azureBackupServerEngine = (AzureBackupServerEngine)backupEngine.Properties;
            FriendlyName = azureBackupServerEngine.FriendlyName;
            Status = azureBackupServerEngine.RegistrationStatus;
        }
    }
}
