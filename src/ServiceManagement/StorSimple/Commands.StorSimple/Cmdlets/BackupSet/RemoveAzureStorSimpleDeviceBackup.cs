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

using System.Linq;
using System.Management.Automation;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure;
using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;


namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// This commandlet will remove a given backup from the device
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureStorSimpleDeviceBackup", DefaultParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
    public class RemoveAzureStorSimpleDeviceBackup:StorSimpleCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByObject)]
        [ValidateNotNullOrEmptyAttribute]
        public string DeviceName { get; set; }


        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupIdToDelete,ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
        public string BackupId { get; set; }

        [Parameter(Position = 1, Mandatory = true,ValueFromPipeline = true,HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupIdToDelete,ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByObject)]
        public Backup Backup { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageForce)]
        public SwitchParameter Force { get; set; }
        
        [Parameter(Position = 3, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageWaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }

        private string deviceId = null;
        private string finalBackupId = null;

        public override void ExecuteCmdlet()
        {
            try
            {
                if (!ProcessParameters()) return;
                ConfirmAction(
                   Force.IsPresent,
                   string.Format(Resources.RemoveASSDBackupWarningMessage, finalBackupId),
                   string.Format(Resources.RemoveASSDBackupMessage, finalBackupId),
                  BackupId,
                  () =>
                  {

                      if (WaitForComplete.IsPresent)
                      {
                          var deleteTaskStatusInfo = StorSimpleClient.DeleteBackup(deviceId, finalBackupId);
                          HandleSyncTaskResponse(deleteTaskStatusInfo, "remove"); 
                      }
                      else
                      {
                          var taskresult = StorSimpleClient.DeleteBackupAsync(deviceId, finalBackupId);
                          HandleAsyncTaskResponse(taskresult, "remove");
                      }
                  });
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
                WriteVerbose(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
                WriteObject(null);
                return false;
            }
            switch (ParameterSetName)
            {
                case StorSimpleCmdletParameterSet.IdentifyById:
                    if (string.IsNullOrEmpty(BackupId))
                        throw new ArgumentException(Resources.InvalidBackupIdParameter);
                    else
                    {
                        finalBackupId = BackupId;
                    }
                    break;
                case StorSimpleCmdletParameterSet.IdentifyByObject:
                    if(Backup==null || string.IsNullOrEmpty(Backup.InstanceId))
                        throw new ArgumentException(Resources.InvalidBackupObjectParameter);
                    else
                    {
                        finalBackupId = Backup.InstanceId;
                    }
                    break;
            }
            return true;
        }
    }
}
