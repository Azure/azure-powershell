using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure.Commands.CloudService.Development;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    public partial class PSStorSimpleClient
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

        public TaskStatusInfo DoBackup(string deviceid, String backupPolicyId, BackupNowRequest request)
        {
            return GetStorSimpleClient().Backup.Create(deviceid, backupPolicyId, request, GetCustomRequestHeaders());
        }

        public TaskResponse DoBackupAsync(string deviceid, String backupPolicyId, BackupNowRequest request)
        {
            return GetStorSimpleClient().Backup.BeginCreatingBackup(deviceid, backupPolicyId, request, GetCustomRequestHeaders());
        }
    }
}
