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

using Microsoft.Azure.Management.BackupServices.Models;
using System;

namespace Microsoft.Azure.Commands.AzureBackup.Models
{
    public class AzureBackupRecoveryPointContextObject : AzureRMBackupItemContextObject
    {
        /// <summary>
        /// RecoveryPointId of Azure Backup Item
        /// </summary>
        public string RecoveryPointName { get; set; }

        public AzureBackupRecoveryPointContextObject()
            : base()
        {
        }

        public AzureBackupRecoveryPointContextObject(CSMRecoveryPointResponse recoveryPointInfo, AzureRMBackupItem azureBackupItem)
            : base(azureBackupItem)
        {
            RecoveryPointName = recoveryPointInfo.Name;
        }
    }

    /// <summary>
    /// Represents Azure Backup Container
    /// </summary>
    public class AzureRMBackupRecoveryPoint : AzureBackupRecoveryPointContextObject
    {
        /// <summary>
        /// Last Recovery Point for the Azure Backup Item
        /// </summary>
        public DateTime RecoveryPointTime { get; set; }

        /// <summary>
        /// DataSourceId of Azure Backup Item
        /// </summary>
        public string RecoveryPointType { get; set; }

        public AzureRMBackupRecoveryPoint()
            : base()
        {
        }

        public AzureRMBackupRecoveryPoint(CSMRecoveryPointResponse recoveryPointInfo, AzureRMBackupItem azureBackupItem)
            : base(recoveryPointInfo, azureBackupItem)
        {
            RecoveryPointTime = recoveryPointInfo.Properties.RecoveryPointTime;
            RecoveryPointType = recoveryPointInfo.Properties.RecoveryPointType;
        }
    }
}