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

using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    using Microsoft.WindowsAzure.Commands.StorSimple.Models;

    public partial class StorSimpleClient
    {
        public GetBackupResponse GetAllBackups(string deviceId, string filterType, string isAllSelected, string filterValue, string startDateTime, string endDateTime,
            string skip, string top)
        {
            return this.GetStorSimpleClient()
                .Backup.Get(deviceId, filterType, isAllSelected, filterValue, startDateTime, endDateTime, skip, top,
                    GetCustomRequestHeaders());
        }

        public TaskStatusInfo DeleteBackup(string deviceid, string backupSetId)
        {
            return GetStorSimpleClient().Backup.Delete(deviceid, backupSetId, GetCustomRequestHeaders());
        }

        public TaskResponse DeleteBackupAsync(string deviceid, string backupSetId)
        {
            return GetStorSimpleClient().Backup.BeginDeleting(deviceid, backupSetId, GetCustomRequestHeaders());
        }

        public TaskStatusInfo RestoreBackup(string deviceid, RestoreBackupRequest backupRequest)
        {
            return GetStorSimpleClient().Backup.Restore(deviceid, backupRequest, GetCustomRequestHeaders());
        }

        public TaskResponse RestoreBackupAsync(string deviceid, RestoreBackupRequest backupRequest)
        {
            return GetStorSimpleClient().Backup.BeginRestoring(deviceid, backupRequest, GetCustomRequestHeaders());
        }

        public TaskStatusInfo DoBackup(string deviceid, string backupPolicyId, BackupNowRequest request)
        {
            return GetStorSimpleClient().Backup.Create(deviceid, backupPolicyId, request, GetCustomRequestHeaders());
        }

        public TaskResponse DoBackupAsync(string deviceid, string backupPolicyId, BackupNowRequest request)
        {
            return GetStorSimpleClient().Backup.BeginCreatingBackup(deviceid, backupPolicyId, request, GetCustomRequestHeaders());
        }

        public JobResponse CloneVolume(string deviceId, TriggerCloneRequest request)
        {
            return this.GetStorSimpleClient().CloneVolume.Trigger(deviceId, request, this.GetCustomRequestHeaders());
        }
    }
}
