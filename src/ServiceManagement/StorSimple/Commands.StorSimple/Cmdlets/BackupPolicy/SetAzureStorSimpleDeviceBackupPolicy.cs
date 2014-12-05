using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure;
using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "AzureStorSimpleDeviceBackupPolicy"), OutputType(typeof(NewBackupPolicyConfig))]
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
        private List<String> scheduleIdsTodelete = null;
        private List<String> volumeIdsToUpdate = null;

        private UpdateBackupPolicyConfig updateConfig = null;
        public override void ExecuteCmdlet()
        {
            try
            {
                updateConfig = new UpdateBackupPolicyConfig();
                ProcessParameters();

                updateConfig.InstanceId = BackupPolicyId;
                updateConfig.Name = BackupPolicyName;
                updateConfig.IsPolicyRenamed = false;
                updateConfig.BackupSchedulesToBeAdded = schedulesToAdd;
                updateConfig.BackupSchedulesToBeUpdated = schedulesToUpdate;
                updateConfig.BackupSchedulesToBeDeleted = scheduleIdsTodelete;
                updateConfig.VolumeIds = volumeIdsToUpdate;

                if (WaitForComplete.IsPresent)
                {
                    var JobStatusInfo = StorSimpleClient.UpdateBackupPolicy(deviceId, BackupPolicyId, updateConfig);
                    HandleSyncJobResponse(JobStatusInfo, "update");
                    if(JobStatusInfo.TaskResult == TaskResult.Succeeded)
                    {
                        var updatedBackupPolicy = StorSimpleClient.GetBackupPolicyByName(deviceId, BackupPolicyName);
                        WriteObject(updatedBackupPolicy.BackupPolicyDetails);
                    }
                }
                else
                {
                    var jobresult = StorSimpleClient.UpdateBackupPolicyAsync(deviceId, BackupPolicyId, updateConfig);
                    HandleAsyncJobResponse(jobresult, "Update");
                }
            }

            catch(Exception exception)
            {
                this.HandleException(exception);
            }
        }


        private void ProcessParameters()
        {
            deviceId = StorSimpleClient.GetDeviceId(DeviceName);
            if (deviceId == null)
            {
                WriteVerbose(Resources.NotFoundMessageDevice);
            }

            ProcessAddSchedules();
            ProcessUpdateSchedules();
            ProcessDeleteScheduleIds();
            ProcessUpdateVolumeIds();
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
                    String scheduleIdToDelete = (String)deleteSchedule.BaseObject;
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
                    String volumeId = (String)volume.BaseObject;
                    volumeIdsToUpdate.Add(volumeId);
                }
            }
            updateConfig.VolumeIds = volumeIdsToUpdate;
        }
    }
}
