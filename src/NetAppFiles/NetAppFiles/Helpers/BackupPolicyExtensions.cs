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
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.NetAppFiles.Helpers
{
    public static class BackupPolicyExtensions
    {       
        public static PSNetAppFilesBackupPolicy ConvertToPs(this Management.NetApp.Models.BackupPolicy backupPolicy)
        {
            var psBackupPolicy = new PSNetAppFilesBackupPolicy
            {
                ResourceGroupName = new ResourceIdentifier(backupPolicy.Id).ResourceGroupName,
                Location = backupPolicy.Location,
                Id = backupPolicy.Id,
                Name = backupPolicy.Name,
                Type = backupPolicy.Type,
                Tags = backupPolicy.Tags,
                Etag = backupPolicy.Etag,
                ProvisioningState = backupPolicy.ProvisioningState,
                BackupPolicyId = backupPolicy.Id,
                DailyBackupsToKeep = backupPolicy.DailyBackupsToKeep,
                WeeklyBackupsToKeep = backupPolicy.WeeklyBackupsToKeep,
                MonthlyBackupsToKeep = backupPolicy.MonthlyBackupsToKeep,
                VolumeBackups = (backupPolicy.VolumeBackups !=null) ?  backupPolicy.VolumeBackups.ConvertToPS() : null,
                VolumesAssigned = backupPolicy.VolumesAssigned,
                Enabled = backupPolicy.Enabled,
                SystemData = backupPolicy.SystemData?.ToPsSystemData(),
            };
            return psBackupPolicy;
        }

        public static List<PSNetAppFilesVolumeBackup> ConvertToPS(this IList<VolumeBackups> volumeBackups)
        {
            return volumeBackups.Select(e => e.ConvertToPs()).ToList();
        }

        public static PSNetAppFilesVolumeBackup ConvertToPs(this Management.NetApp.Models.VolumeBackups volumeBackup)
        {
            var psVolumeBackup = new PSNetAppFilesVolumeBackup()
            {
                BackupsCount = volumeBackup.BackupsCount,
                PolicyEnabled = volumeBackup.PolicyEnabled,
                VolumeName = volumeBackup.VolumeName,
                VolumeResourceId = volumeBackup.VolumeResourceId
            };
            return psVolumeBackup;
        }
    }
}
