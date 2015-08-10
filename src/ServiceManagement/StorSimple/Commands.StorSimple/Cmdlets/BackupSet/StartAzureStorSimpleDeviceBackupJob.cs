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
    [Cmdlet(VerbsLifecycle.Start, "AzureStorSimpleDeviceBackupJob", DefaultParameterSetName = StorSimpleCmdletParameterSet.Empty),OutputType(typeof(TaskResponse), typeof(TaskStatusInfo))]
    public class StartAzureStorSimpleDeviceBackupJob : StorSimpleCmdletBase
    {
        private const string PARAMETERSET_BACKUPTYPE = "BackupTypeGiven";

        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.DeviceName, ParameterSetName = StorSimpleCmdletParameterSet.Empty)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.DeviceName, ParameterSetName = PARAMETERSET_BACKUPTYPE)]
        [ValidateNotNullOrEmptyAttribute]
        public string DeviceName { get; set; }


        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.BackupPolicyIdForCreate, ParameterSetName = StorSimpleCmdletParameterSet.Empty)]
        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.BackupPolicyIdForCreate, ParameterSetName = PARAMETERSET_BACKUPTYPE)]
        public string BackupPolicyId { get; set; }


        [Parameter(Position = 2, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.BackupTypeDesc, ParameterSetName = PARAMETERSET_BACKUPTYPE)]
        [ValidateSet("LocalSnapshot", "CloudSnapshot")]
        public string BackupType { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.WaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }

        private string deviceId = null;
        private BackupNowRequest backupNowRequest = null;

         public override void ExecuteCmdlet()
        {
             try
             {
                 ProcessParameters();
                 if (WaitForComplete.IsPresent)
                 {
                     var taskStatusInfo = StorSimpleClient.DoBackup(deviceId, BackupPolicyId, backupNowRequest);
                     HandleSyncTaskResponse(taskStatusInfo, "start");
                 }
                 else
                 {
                     var taskresult = StorSimpleClient.DoBackupAsync(deviceId, BackupPolicyId, backupNowRequest);
                     HandleAsyncTaskResponse(taskresult, "start");
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
                throw new ArgumentException(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
            }

             BackupType backupTypeSelected = Management.StorSimple.Models.BackupType.Invalid;
             switch (ParameterSetName)
             {
                 case StorSimpleCmdletParameterSet.Empty:
                     backupTypeSelected = Microsoft.WindowsAzure.Management.StorSimple.Models.BackupType.LocalSnapshot;
                     break;
                 case PARAMETERSET_BACKUPTYPE:
                     backupTypeSelected = (BackupType)Enum.Parse(typeof(BackupType), BackupType);
                     break;
             }
             backupNowRequest = new BackupNowRequest();
             backupNowRequest.Type = backupTypeSelected;
        }
    }
}
