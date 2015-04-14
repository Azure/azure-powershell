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

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets.Volume
{

    [Cmdlet(VerbsCommon.New, "AzureStorSimpleDeviceVolume"), OutputType(typeof(TaskStatusInfo))]
    public class NewAzureStorSimpleDeviceVolume : StorSimpleCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.DeviceName)]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Alias("Container")]
        [Parameter(Position = 1, Mandatory = true, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.DataContainerObject)]
        [ValidateNotNullOrEmpty]
        public DataContainer VolumeContainer { get; set; }
        
        [Alias("Name")]
        [Parameter(Position = 2, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.VolumeName)]
        [ValidateNotNullOrEmpty]
        public string VolumeName { get; set; }

        [Alias("SizeInBytes")]
        [Parameter(Position = 3, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.VolumeSize)]
        [ValidateNotNullOrEmpty]
        public Int64 VolumeSizeInBytes { get; set; }

        [Parameter(Position = 4, Mandatory = true, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.VolumeAcrList)]
        [ValidateNotNull]
        [AllowEmptyCollection]
        public List<AccessControlRecord> AccessControlRecords { get; set; }

        [Alias("AppType")]
        [ValidateSet("PrimaryVolume","ArchiveVolume")]
        [Parameter(Position = 5, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.VolumeAppType)]
        [ValidateNotNullOrEmpty]
        public AppType VolumeAppType { get; set; }

        [Parameter(Position = 6, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.VolumeOnline)]
        [ValidateNotNullOrEmpty]
        public bool Online { get; set; }

        [Parameter(Position = 7, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.VolumeDefaultBackup)]
        [ValidateNotNullOrEmpty]
        public bool EnableDefaultBackup { get; set; }

        [Parameter(Position = 8, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.VolumeMonitoring)]
        [ValidateNotNullOrEmpty]
        public bool EnableMonitoring { get; set; }

        [Parameter(Position = 9, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.WaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }
        
        public override void ExecuteCmdlet()
        {
            try
            {
                string deviceid = null;
                deviceid = StorSimpleClient.GetDeviceId(DeviceName);

                if (deviceid == null)
                {
                    throw new ArgumentException(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
                }

                //Virtual disk create request object
                var virtualDiskToCreate = new VirtualDiskRequest()
                {
                    Name = VolumeName,
                    AccessType = AccessType.ReadWrite,
                    AcrList = AccessControlRecords,
                    AppType = VolumeAppType,
                    IsDefaultBackupEnabled = EnableDefaultBackup,
                    SizeInBytes = VolumeSizeInBytes,
                    DataContainer = VolumeContainer,
                    Online = Online,
                    IsMonitoringEnabled = EnableMonitoring
                };

                if (WaitForComplete.IsPresent)
                {
                    var taskStatus = StorSimpleClient.CreateVolume(deviceid, virtualDiskToCreate); ;
                    HandleSyncTaskResponse(taskStatus, "create");
                    if (taskStatus.AsyncTaskAggregatedResult == AsyncTaskAggregatedResult.Succeeded)
                    {
                        var createdVolume = StorSimpleClient.GetVolumeByName(deviceid, VolumeName);
                        WriteObject(createdVolume.VirtualDiskInfo);
                    }
                }

                else
                {
                    var taskstatus = StorSimpleClient.CreateVolumeAsync(deviceid, virtualDiskToCreate); ;
                    HandleAsyncTaskResponse(taskstatus, "create");
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}