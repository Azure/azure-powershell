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
    public partial class StorSimpleClient
    {
        public BackupPolicyListResponse GetAllBackupPolicies(string deviceId)
        {
            return this.GetStorSimpleClient().BackupPolicy.List(deviceId, GetCustomRequestHeaders());
        }

        public GetBackupPolicyDetailsResponse GetBackupPolicyByName(string deviceId, string backupPolicyName)
        {
            return this.GetStorSimpleClient().BackupPolicy.GetBackupPolicyDetailsByName(deviceId, backupPolicyName, GetCustomRequestHeaders());
        }

        public TaskStatusInfo DeleteBackupPolicy(string deviceid, string backupPolicyId)
        {
            return GetStorSimpleClient().BackupPolicy.Delete(deviceid, backupPolicyId, GetCustomRequestHeaders());
        }

        public TaskResponse DeleteBackupPolicyAsync(string deviceid, string backupPolicyId)
        {
            return GetStorSimpleClient().BackupPolicy.BeginDeleting(deviceid, backupPolicyId, GetCustomRequestHeaders());
        }

        public TaskStatusInfo CreateBackupPolicy(string deviceId, NewBackupPolicyConfig config)
        {
            return GetStorSimpleClient().BackupPolicy.Create(deviceId, config, GetCustomRequestHeaders());
        }

        public TaskResponse CreateBackupPolicyAsync(string deviceId, NewBackupPolicyConfig config)
        {
            return GetStorSimpleClient().BackupPolicy.BeginCreatingBackupPolicy(deviceId, config, GetCustomRequestHeaders());
        }

        public TaskStatusInfo UpdateBackupPolicy(string deviceId, string policyId, UpdateBackupPolicyConfig updatepolicyConfig)
        {
            return GetStorSimpleClient().BackupPolicy.Update(deviceId, policyId, updatepolicyConfig, GetCustomRequestHeaders());
        }

        public TaskResponse UpdateBackupPolicyAsync(string deviceId, string policyId, UpdateBackupPolicyConfig updatepolicyConfig)
        {
            return GetStorSimpleClient().BackupPolicy.BeginUpdatingBackupPolicy(deviceId, policyId, updatepolicyConfig, GetCustomRequestHeaders());
        }
    }
}
