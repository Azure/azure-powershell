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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple.Models;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "AzureStorSimpleDeviceVolume"), OutputType(typeof(TaskStatusInfo))]
    public class SetAzureStorSimpleDeviceVolume : StorSimpleCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName)]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Alias("Name")]
        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageVolumeName)]
        [ValidateNotNullOrEmpty]
        public string VolumeName { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageVolumeOnline)]
        [ValidateNotNullOrEmpty]
        public bool? Online { get; set; }

        [Alias("SizeInBytes")]
        [Parameter(Position = 3, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageVolumeSize)]
        [ValidateNotNullOrEmpty]
        public Int64? VolumeSizeInBytes { get; set; }

        [Alias("AppType")]
        [ValidateSet("PrimaryVolume","ArchiveVolume")]
        [Parameter(Position = 4, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageVolumeAppType)]
        [ValidateNotNullOrEmpty]
        public AppType? VolumeAppType { get; set; }

        [Parameter(Position = 5, Mandatory = false, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageVolumeAcrList)]
        [ValidateNotNullOrEmpty]
        public List<AccessControlRecord> AccessControlRecords { get; set; }

        [Parameter(Position = 6, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageWaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                var deviceId = StorSimpleClient.GetDeviceId(DeviceName);
                if (deviceId == null)
                {
                    WriteVerbose(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
                    WriteObject(null);
                    return;
                }

                VirtualDisk diskDetails = StorSimpleClient.GetVolumeByName(deviceId, VolumeName).VirtualDiskInfo;
                if (diskDetails == null)
                {
                    WriteVerbose(Resources.NotFoundMessageVirtualDisk);
                    WriteObject(null);
                    return;
                }
                
                if (Online != null)
                {
                    diskDetails.Online = Online.GetValueOrDefault();
                }
                if (VolumeSizeInBytes != null)
                {
                    diskDetails.SizeInBytes = VolumeSizeInBytes.GetValueOrDefault();
                }
                if (VolumeAppType != null)
                {
                    diskDetails.AppType = VolumeAppType.GetValueOrDefault();
                }
                if (AccessControlRecords != null)
                {
                    diskDetails.AcrList = AccessControlRecords;
                }

                if (WaitForComplete.IsPresent)
                {
                    var taskstatus = StorSimpleClient.UpdateVolume(deviceId, diskDetails.InstanceId, diskDetails);
                    HandleSyncTaskResponse(taskstatus, "update");
                    var updatedVolume = StorSimpleClient.GetVolumeByName(deviceId, VolumeName);
                    WriteObject(updatedVolume.VirtualDiskInfo);
                }
                else
                {
                    var taskresult = StorSimpleClient.UpdateVolumeAsync(deviceId, diskDetails.InstanceId, diskDetails);

                    HandleAsyncTaskResponse(taskresult, "update");
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

    }
}