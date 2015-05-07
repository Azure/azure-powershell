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

using System.Management.Automation;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// this commandlet will let you create a new backuppolicy with schedules
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureStorSimpleDeviceBackupPolicy")]
    public class NewAzureStorSimpleDeviceBackupPolicy:StorSimpleCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.DeviceName)]
        [ValidateNotNullOrEmptyAttribute]
        public string DeviceName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.NewBackupPolicyName)]
        [ValidateNotNullOrEmptyAttribute]
        public string BackupPolicyName { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.BackupsToAddList)]
        public PSObject[] BackupSchedulesToAdd { get; set; }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.VolumeIdsToAddList)]
        public PSObject[] VolumeIdsToAdd { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.WaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }

        private string deviceId = null;
        private List<string> volumeIdsToAddList = null;
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
                throw new ArgumentException(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
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
        /// reads the PSObject[] containing VolumeId objects (string) and generates a list out of them
        /// </summary>
        private void ProcessAddVolumeIds()
        {
            volumeIdsToAddList = new List<string>();
            if (VolumeIdsToAdd.Length > 0)
            {
                foreach (var volume in VolumeIdsToAdd)
                {
                    volumeIdsToAddList.Add((string) volume.BaseObject);
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
