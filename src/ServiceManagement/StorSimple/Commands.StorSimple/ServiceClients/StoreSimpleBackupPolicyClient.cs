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
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    public partial class StorSimpleClient
    {
        public BackupPolicyListResponse GetAllBackupPolicies(string deviceId)
        {
            var backupPolicyList = this.GetStorSimpleClient().BackupPolicy.List(deviceId, GetCustomRequestHeaders());
            backupPolicyList.BackupPolicies = CorrectLastBackupForNewPolicy(backupPolicyList.BackupPolicies);
            return backupPolicyList;
        }

        public GetBackupPolicyDetailsResponse GetBackupPolicyByName(string deviceId, string backupPolicyName)
        {
            var backupPolicyDetail = this.GetStorSimpleClient().BackupPolicy.GetBackupPolicyDetailsByName(deviceId, backupPolicyName, GetCustomRequestHeaders());
            backupPolicyDetail.BackupPolicyDetails = CorrectLastBackupForNewPolicyDetail(backupPolicyDetail.BackupPolicyDetails);
            return backupPolicyDetail;
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

        /// <summary>
        /// for a new backuppolicy for which no backup has yet been taken,service returns last backup time as 1/1/2010 which is misleading
        /// we are setting it to null
        /// </summary>
        /// <param name="backupPolicyList"></param>
        /// <returns></returns>
        private IList<BackupPolicy> CorrectLastBackupForNewPolicy(IList<BackupPolicy> backupPolicyList)
        {
            if (backupPolicyList != null)
            {
                for (int i = 0; i < backupPolicyList.Count; ++i)
                {
                    if (backupPolicyList[i].LastBackup.Value.Year == 2010
                        && backupPolicyList[i].LastBackup.Value.Month == 1
                        && backupPolicyList[i].LastBackup.Value.Day == 1)
                    {
                        //this means that for this policy no backup has yet been taken
                        //so the service returns 1/1/2010 which is incorrect. hence we are correcting it here
                        backupPolicyList[i].LastBackup = null;
                    }
                }
            }
            return backupPolicyList;
        }

        /// <summary>
        /// for a new backuppolicy for which no backup has yet been taken,service returns last backup time as 1/1/2010 which is misleading
        /// we are setting it to null
        /// </summary>
        /// <param name="backupPolicyList"></param>
        /// <returns></returns>
        private BackupPolicyDetails CorrectLastBackupForNewPolicyDetail(BackupPolicyDetails backupPolicyDetail)
        {
            if (backupPolicyDetail != null && backupPolicyDetail.LastBackup != null)
            {
                if (backupPolicyDetail.LastBackup.Value.Year == 2010
                    && backupPolicyDetail.LastBackup.Value.Month == 1
                    && backupPolicyDetail.LastBackup.Value.Day == 1)
                {
                    //this means that for this policy no backup has yet been taken
                    //so the service returns 1/1/2010 which is incorrect. hence we are correcting it here
                    backupPolicyDetail.LastBackup = null;
                }

            }
            return backupPolicyDetail;
        }

        public void ValidateBackupScheduleBase(BackupScheduleBase newScheduleObject)
        {
            newScheduleObject.StartTime = GetValidStartTime(newScheduleObject.StartTime);
            ValidateRetentionCount(newScheduleObject.RetentionCount);
            ValidateRecurrenceValue(newScheduleObject.Recurrence.RecurrenceValue);
        }

        public void ValidateBackupScheduleUpdateRequest(BackupScheduleUpdateRequest updateScheduleObject)
        {
            updateScheduleObject.StartTime = GetValidStartTime(updateScheduleObject.StartTime);
            ValidateRetentionCount(updateScheduleObject.RetentionCount);
            ValidateRecurrenceValue(updateScheduleObject.Recurrence.RecurrenceValue);
        }

        private string GetValidStartTime(string startTime)
        {
            DateTime StartFromDt;
            if (!string.IsNullOrEmpty(startTime))
            {
                bool dateTimeValid = DateTime.TryParse(startTime, out StartFromDt);

                if (!dateTimeValid)
                {
                    throw new ArgumentException(Resources.StartFromDateForBackupNotValid);
                }
            }
            else
                StartFromDt = DateTime.Now;

            return StartFromDt.ToString("yyyy-MM-ddTHH:mm:sszzz");
        }

        private void ValidateRetentionCount(long retentionCount)
        {
            if (retentionCount < 1 || retentionCount > 64)
            {
                throw new ArgumentException(Resources.RetentionCountRangeInvalid);
            }
        }

        private void ValidateRecurrenceValue(int recurrenceValue)
        {
            if (recurrenceValue <= 0)
            {
                throw new ArgumentException(Resources.RecurrenceValueLessThanZero);
            }
        }
    }
}
