using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    public partial class PSStorSimpleClient
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
