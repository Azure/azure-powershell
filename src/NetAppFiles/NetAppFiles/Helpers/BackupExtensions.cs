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
    public static class BackupExtensions
    {       
        public static PSNetAppFilesBackup ConvertToPs(this Management.NetApp.Models.Backup backup)
        {
            var psBackup = new PSNetAppFilesBackup
            {
                ResourceGroupName = new ResourceIdentifier(backup.Id).ResourceGroupName,
                Location = backup.Location,
                Id = backup.Id,
                Name = backup.Name,
                //not in yet was missing from swagger BackupId = backup.BackupId,
                Type = backup.Type,
                BackupType = backup.Type,
                Label = backup.Label,
                ProvisioningState = backup.ProvisioningState,
                Size = backup.Size
            };
            return psBackup;
        }

        public static List<PSNetAppFilesBackup> ConvertToPS(this IList<Management.NetApp.Models.Backup> volumeBackups)
        {
            return volumeBackups.Select(e => e.ConvertToPs()).ToList();
        }

    }
}
