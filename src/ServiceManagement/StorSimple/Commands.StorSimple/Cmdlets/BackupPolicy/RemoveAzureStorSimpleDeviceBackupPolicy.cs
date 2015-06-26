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
    [Cmdlet(VerbsCommon.Remove, "AzureStorSimpleDeviceBackupPolicy", DefaultParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
    public class RemoveAzureStorSimpleDeviceBackupPolicy : StorSimpleCmdletBase
    {
        private string deviceId = null;

        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.DeviceName, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.DeviceName, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByObject)]
        [ValidateNotNullOrEmptyAttribute]
        public string DeviceName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.BackupPolicyIdToDelete, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
        public string BackupPolicyId { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.BackupPolicyToDelete, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByObject)]
        public BackupPolicyDetails BackupPolicy { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.Force)]
        public SwitchParameter Force { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.WaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }

        private string backupPolicyIdFinal = null;
        public override void ExecuteCmdlet()
        {
            try
            {
                if (!ProcessParameters())
                    return;
                ConfirmAction(
                   Force.IsPresent,
                   string.Format(Resources.RemoveAzureStorSimpleDeviceBackupPolicyWarningMessage, backupPolicyIdFinal),
                   string.Format(Resources.RemoveAzureStorSimpleDeviceBackupPolicyMessage, backupPolicyIdFinal),
                  backupPolicyIdFinal,
                  () =>
                  {
                      if (WaitForComplete.IsPresent)
                      {
                          WriteVerbose("About to run a task to remove your backuppolicy!");
                          var deleteTaskStatusInfo = StorSimpleClient.DeleteBackupPolicy(deviceId, backupPolicyIdFinal);
                          HandleSyncTaskResponse(deleteTaskStatusInfo, "remove");
                      }
                      else
                      {
                          WriteVerbose("About to create a task to remove your backuppolicy!");
                          var taskresult = StorSimpleClient.DeleteBackupPolicyAsync(deviceId, backupPolicyIdFinal);
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
                throw new ArgumentException(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
            }
            switch (ParameterSetName)
            {
                case StorSimpleCmdletParameterSet.IdentifyById:
                    Guid backuppolicyIdGuid;
                    bool isIdValidGuid = Guid.TryParse(BackupPolicyId,out backuppolicyIdGuid);
                    if (string.IsNullOrEmpty(BackupPolicyId)
                        || !isIdValidGuid)
                        throw new ArgumentException(Resources.InvalidBackupPolicyIdParameter);
                    else
                    {
                        backupPolicyIdFinal = BackupPolicyId;
                    }
                    break;
                case StorSimpleCmdletParameterSet.IdentifyByObject:
                    if (BackupPolicy == null || string.IsNullOrEmpty(BackupPolicy.InstanceId))
                        throw new ArgumentException(Resources.InvalidBackupPolicyObjectParameter);
                    else
                    {
                        backupPolicyIdFinal = BackupPolicy.InstanceId;
                    }
                    break;
            }
            return true;
        }
    }
}
