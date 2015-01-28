﻿// ----------------------------------------------------------------------------------
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

using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure;
using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using System.Text.RegularExpressions;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// this commandlet can be used to update an existing backuppolicy
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureStorSimpleDeviceBackupPolicy"), OutputType(typeof(BackupPolicyDetails))]
    public class SetAzureStorSimpleDeviceBackupPolicy: StorSimpleCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName)]
        [ValidateNotNullOrEmptyAttribute]
        public string DeviceName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupPolicyIdToUpdate)]
        [ValidateNotNullOrEmptyAttribute]
        public string BackupPolicyId { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupPolicyNameChange)]
        [ValidateNotNullOrEmptyAttribute]
        public string BackupPolicyName { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupScheduleBaseObjsToAdd)]
        public PSObject[] BackupSchedulesToAdd { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupScheduleBaseObjsToUpdate)]
        public PSObject[] BackupSchedulesToUpdate { get; set; }

        [Parameter(Position = 5, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupScheduleBaseObjsToDelete)]
        public PSObject[] BackupScheduleIdsToDelete { get; set; }

        [Parameter(Position = 6, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageVolumeObjsToUpdate)]
        public PSObject[] VolumeIdsToUpdate { get; set; }

        [Parameter(Position = 7, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageWaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }

        private string deviceId = null;
        private List<BackupScheduleBase> schedulesToAdd = null;
        private List<BackupScheduleUpdateRequest> schedulesToUpdate = null;
        private List<string> scheduleIdsTodelete = null;
        private List<string> volumeIdsToUpdate = null;

        private UpdateBackupPolicyConfig updateConfig = null;
        public override void ExecuteCmdlet()
        {
            try
            {
                updateConfig = new UpdateBackupPolicyConfig();
                if (!ProcessParameters())
                    return;

                updateConfig.InstanceId = BackupPolicyId;
                updateConfig.Name = BackupPolicyName;
                updateConfig.IsPolicyRenamed = true;
                updateConfig.BackupSchedulesToBeAdded = schedulesToAdd;
                updateConfig.BackupSchedulesToBeUpdated = schedulesToUpdate;
                updateConfig.BackupSchedulesToBeDeleted = scheduleIdsTodelete;
                updateConfig.VolumeIds = volumeIdsToUpdate;

                if (WaitForComplete.IsPresent)
                {
                    WriteVerbose("About to run a task to update your backuppolicy!"); 
                    var taskStatusInfo = StorSimpleClient.UpdateBackupPolicy(deviceId, BackupPolicyId, updateConfig);
                    HandleSyncTaskResponse(taskStatusInfo, "update");
                    if (taskStatusInfo.AsyncTaskAggregatedResult == AsyncTaskAggregatedResult.Succeeded)
                    {
                        var updatedBackupPolicy = StorSimpleClient.GetBackupPolicyByName(deviceId, BackupPolicyName);
                        WriteObject(updatedBackupPolicy.BackupPolicyDetails);
                    }
                }
                else
                {
                    WriteVerbose("About to create a task to update your backuppolicy!");
                    var taskresult = StorSimpleClient.UpdateBackupPolicyAsync(deviceId, BackupPolicyId, updateConfig);
                    HandleAsyncTaskResponse(taskresult, "Update");
                }
            }

            catch(Exception exception)
            {
                this.HandleException(exception);
            }
        }


        private bool ProcessParameters()
        {
            deviceId = StorSimpleClient.GetDeviceId(DeviceName);
            if (deviceId == null)
            {
                WriteVerbose(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
                WriteObject(null);
                return false;
            }

            ProcessAddSchedules();
            ProcessUpdateSchedules();
            ProcessDeleteScheduleIds();
            ProcessUpdateVolumeIds();
            return true;
        }

        private void ProcessAddSchedules()
        {
            if (BackupSchedulesToAdd!=null && BackupSchedulesToAdd.Length > 0)
            {
                schedulesToAdd = new List<BackupScheduleBase>();
                foreach (var addSchedule in BackupSchedulesToAdd)
                {
                    BackupScheduleBase backupSchedule = (BackupScheduleBase)addSchedule.BaseObject;
                    schedulesToAdd.Add(backupSchedule);
                }
            }
            updateConfig.BackupSchedulesToBeAdded = schedulesToAdd;
        }

        private void ProcessUpdateSchedules()
        {          
            if (BackupSchedulesToUpdate!=null && BackupSchedulesToUpdate.Length > 0)
            {
                schedulesToUpdate = new List<BackupScheduleUpdateRequest>();
                foreach (var updateSchedule in BackupSchedulesToUpdate)
                {
                    BackupScheduleUpdateRequest updateschedule = (BackupScheduleUpdateRequest) updateSchedule.BaseObject;
                    schedulesToUpdate.Add(updateschedule);
                }
            }
            updateConfig.BackupSchedulesToBeUpdated = schedulesToUpdate;
        }

        private void ProcessDeleteScheduleIds()
        {
            if (BackupScheduleIdsToDelete!=null && BackupScheduleIdsToDelete.Length > 0)
            {
                scheduleIdsTodelete = new List<string>();
                foreach (var deleteSchedule in BackupScheduleIdsToDelete)
                {
                    string scheduleIdToDelete = (string)deleteSchedule.BaseObject;
                    scheduleIdsTodelete.Add(scheduleIdToDelete);
                }
            }
            updateConfig.BackupSchedulesToBeDeleted = scheduleIdsTodelete;
        }

        private void ProcessUpdateVolumeIds()
        {
            if (VolumeIdsToUpdate!=null && VolumeIdsToUpdate.Length > 0)
            {
                volumeIdsToUpdate = new List<string>();
                foreach (var volume in VolumeIdsToUpdate)
                {
                    string volumeId = (string)volume.BaseObject;
                    volumeIdsToUpdate.Add(volumeId);
                }
            }
            updateConfig.VolumeIds = volumeIdsToUpdate;
        }
    }
}
