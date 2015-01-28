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
    [Cmdlet(VerbsLifecycle.Start, "AzureStorSimpleDeviceBackupRestoreJob",DefaultParameterSetName = StorSimpleCmdletParameterSet.Empty),OutputType(typeof(TaskResponse), typeof(TaskStatusInfo))]
    public class StartAzureStorSimpleDeviceBackupRestoreJob: StorSimpleCmdletBase
    {
        private string deviceId = null;

        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName, ParameterSetName = StorSimpleCmdletParameterSet.Empty)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
        [ValidateNotNullOrEmptyAttribute]
        public string DeviceName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupIdToRestore, ParameterSetName = StorSimpleCmdletParameterSet.Empty)]
        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupIdToRestore, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
        public string BackupId { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessagesnapshotIdToRestore, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
        public string SnapshotId { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageWaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageForce)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                ProcessParameters();
                ConfirmAction(
                   Force.IsPresent,
                   string.Format(Resources.StartASSDBackupRestoreJobWarningMessage, BackupId),
                   string.Format(Resources.StartASSDBackupRestoreJobMessage, BackupId),
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
                WriteVerbose(Resources.NotFoundMessageDevice);
            }
        }
    }
}
