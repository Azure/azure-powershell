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
    /// <summary>
    /// this commandlet will let you create a new backuppolicy with schedules
    /// </summary>
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
        private List<String> volumeIdsToAddList = null;
        private NewBackupPolicyConfig newConfig = null;

        public override void ExecuteCmdlet()
        {
            try
            {
                newConfig = new NewBackupPolicyConfig();
                newConfig.Name = BackupPolicyName;

                if (!ProcessParameters())
                    return;

                if (WaitForComplete.IsPresent)
                {
                    var taskStatusInfo = StorSimpleClient.CreateBackupPolicy(deviceId, newConfig);
                    HandleSyncTaskResponse(taskStatusInfo, "add");
                    if (taskStatusInfo.AsyncTaskAggregatedResult == AsyncTaskAggregatedResult.Succeeded)
                    {
                        var createdBackupPolicy = StorSimpleClient.GetBackupPolicyByName(deviceId, BackupPolicyName);
                        WriteObject(createdBackupPolicy.BackupPolicyDetails);
                    }
                }
                else
                {
                    var taskresult = StorSimpleClient.CreateBackupPolicyAsync(deviceId, newConfig);
                    HandleAsyncTaskResponse(taskresult, "add");
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
        private bool ProcessParameters()
        {
            deviceId = StorSimpleClient.GetDeviceId(DeviceName);
            if (deviceId == null)
            {
                WriteVerbose(String.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
                WriteObject(null);
                return false;
            }

            ProcessAddSchedules();
            ProcessAddVolumeIds();
            return true;
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
