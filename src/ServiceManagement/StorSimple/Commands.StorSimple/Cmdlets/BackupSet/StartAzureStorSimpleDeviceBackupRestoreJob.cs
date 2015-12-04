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
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Start, "AzureStorSimpleDeviceBackupRestoreJob",DefaultParameterSetName = StorSimpleCmdletParameterSet.Empty),OutputType(typeof(TaskResponse), typeof(TaskStatusInfo))]
    public class StartAzureStorSimpleDeviceBackupRestoreJob: StorSimpleCmdletBase
    {
        private string deviceId = null;

        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.DeviceName, ParameterSetName = StorSimpleCmdletParameterSet.Empty)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.DeviceName, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
        [ValidateNotNullOrEmptyAttribute]
        public string DeviceName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.BackupIdToRestore, ParameterSetName = StorSimpleCmdletParameterSet.Empty)]
        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.BackupIdToRestore, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
        public string BackupId { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.SnapshotIdToRestore, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
        public string SnapshotId { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.WaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.Force)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                ProcessParameters();
                ConfirmAction(
                   Force.IsPresent,
                   string.Format(Resources.StartAzureStorSimpleDeviceBackupRestoreJobWarningMessage, BackupId),
                   string.Format(Resources.StartAzureStorSimpleDeviceBackupRestoreJobMessage, BackupId),
                  BackupId,
                  () =>
                  {
                      RestoreBackupRequest request = new RestoreBackupRequest();
                      request.BackupSetId = BackupId;
                      request.SnapshotId = SnapshotId;

                      if (WaitForComplete.IsPresent)
                      {
                          var restoreBackupResult = StorSimpleClient.RestoreBackup(deviceId, request);
                          HandleSyncTaskResponse(restoreBackupResult, "start");
                      }
                      else
                      {
                          //async scenario
                          var taskresult = StorSimpleClient.RestoreBackupAsync(deviceId, request);
                          HandleAsyncTaskResponse(taskresult, "start");
                      }
                  });
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
                throw new ArgumentException(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
            }
        }
    }
}
