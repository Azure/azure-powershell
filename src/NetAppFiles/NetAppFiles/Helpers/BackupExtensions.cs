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

using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.NetAppFiles.Helpers
{
    public static class BackupExtensions
    {
        public static PSNetAppFilesBackup ConvertToPs(this Management.NetApp.Models.Backup backup)
        {
            var psBackup = new PSNetAppFilesBackup
            {
                ResourceGroupName = new ResourceIdentifier(backup.Id).ResourceGroupName,
                Id = backup.Id,
                Name = backup.Name,
                BackupId = backup.BackupId,
                Type = backup.Type,
                BackupType = backup.BackupType,
                Label = backup.Label,
                ProvisioningState = backup.ProvisioningState,
                Size = backup.Size,
                VolumeResourceId = backup.VolumeResourceId,
                UseExistingSnapshot = backup.UseExistingSnapshot,
                SnapshotName = backup.SnapshotName,
                CreationDate = backup.CreationDate
            };
            return psBackup;
        }

        public static List<PSNetAppFilesBackup> ConvertToPS(this IList<Management.NetApp.Models.Backup> volumeBackups)
        {
            return volumeBackups.Select(e => e.ConvertToPs()).ToList();
        }

        public static PSNetAppFilesVolumeBackupStatus ConvertToPs(this Management.NetApp.Models.BackupStatus backupStatus)
        {
            var psBackupStatus = new PSNetAppFilesVolumeBackupStatus
            {
                Healthy = backupStatus.Healthy,
                MirrorState = backupStatus.MirrorState,
                RelationshipStatus = backupStatus.RelationshipStatus,
                UnhealthyReason = backupStatus.UnhealthyReason,
                ErrorMessage = backupStatus.ErrorMessage,
                LastTransferSize = backupStatus.LastTransferSize,
                LastTransferType = backupStatus.LastTransferType,
                TotalTransferBytes = backupStatus.TotalTransferBytes
            };
            return psBackupStatus;
        }

        public static PSNetAppFilesVolumeRestoreStatus ConvertToPs(this Management.NetApp.Models.RestoreStatus restoreStatus)
        {
            var psRestoreStatus = new PSNetAppFilesVolumeRestoreStatus
            {
                Healthy = restoreStatus.Healthy,
                MirrorState = restoreStatus.MirrorState,
                RelationshipStatus = restoreStatus.RelationshipStatus,
                UnhealthyReason = restoreStatus.UnhealthyReason,
                ErrorMessage = restoreStatus.ErrorMessage,
                TotalTransferBytes = restoreStatus.TotalTransferBytes
            };
            return psRestoreStatus;
        }
    }
}