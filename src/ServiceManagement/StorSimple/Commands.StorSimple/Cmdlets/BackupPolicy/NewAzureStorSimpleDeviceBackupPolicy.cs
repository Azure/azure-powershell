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
    [Cmdlet(VerbsCommon.New, "AzureStorSimpleDeviceBackupPolicy")]
    public class NewAzureStorSimpleDeviceBackupPolicy:StorSimpleCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName)]
        [ValidateNotNullOrEmptyAttribute]
        public string DeviceName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageNewBackupPolicyName)]
        [ValidateNotNullOrEmptyAttribute]
        public String BackupPolicyName { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupsToAddList)]
        public PSObject[] BackupSchedulesToAdd { get; set; }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageVolumeIdsToAddList)]
        public PSObject[] VolumeIdsToAdd { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageWaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }

        private string deviceId = null;
        private List<BackupScheduleBase> schedulesToAddList = null;
        private List<String> volumeIdsToAddList = null;
        private NewBackupPolicyConfig newConfig = null;

        public override void ExecuteCmdlet()
        {
            try
            {
                newConfig = new NewBackupPolicyConfig();
                newConfig.Name = BackupPolicyName;

                ProcessParameters();

                if (WaitForComplete.IsPresent)
                {
                    var JobStatusInfo = StorSimpleClient.CreateBackupPolicy(deviceId, newConfig);
                    HandleSyncJobResponse(JobStatusInfo, "add");
                    if(JobStatusInfo.TaskResult == TaskResult.Succeeded)
                    {
                        var createdBackupPolicy = StorSimpleClient.GetBackupPolicyByName(deviceId, BackupPolicyName);
                        WriteObject(createdBackupPolicy.BackupPolicyDetails);
                    }
                }
                else
                {
                    var jobresult = StorSimpleClient.CreateBackupPolicyAsync(deviceId, newConfig);
                    HandleAsyncJobResponse(jobresult, "add");
                }
            }
            catch (Exception exception)
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
            ProcessAddVolumeIds();
        }

        /// <summary>
        /// reads the PSObject[] containing BackupSchedule objects and generates a list out of them
        /// </summary>
        private void ProcessAddSchedules()
        {
            newConfig.BackupSchedules = new List<BackupScheduleBase>();
            if (BackupSchedulesToAdd.Length > 0)
            {
                foreach (var addSchedule in BackupSchedulesToAdd)
                {
                    newConfig.BackupSchedules.Add((BackupScheduleBase) addSchedule.BaseObject);
                }
            }
            else
            {
                throw new ArgumentException(Resources.InvalidBackupSchedulesToAddParameter);
            }
        }

        /// <summary>
        /// reads the PSObject[] containing VolumeId objects (String) and generates a list out of them
        /// </summary>
        private void ProcessAddVolumeIds()
        {
            volumeIdsToAddList = new List<string>();
            if (VolumeIdsToAdd.Length > 0)
            {
                foreach (var volume in VolumeIdsToAdd)
                {
                    volumeIdsToAddList.Add((String) volume.BaseObject);
                }
            }
            else
            {
                throw new ArgumentException(Resources.InvalidVolumeIdsToAddParameter);
            }
            newConfig.VolumeIds = volumeIdsToAddList;
        }
    }
}
