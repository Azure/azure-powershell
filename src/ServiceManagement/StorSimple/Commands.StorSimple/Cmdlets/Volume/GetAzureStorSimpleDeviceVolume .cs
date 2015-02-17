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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleDeviceVolume"), OutputType(typeof(VirtualDisk), typeof(IList<VirtualDisk>))]
    public class GetAzureStorSimpleDeviceVolume : StorSimpleCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName)]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByParentObject, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDataContainerObject)]
        [ValidateNotNullOrEmpty]
        public DataContainer VolumeContainer { get; set; }

        [Alias("Name")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByName, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageVolumeName)]
        [ValidateNotNullOrEmpty]
        public string VolumeName { get; set; }
        
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
                
                switch (ParameterSetName)
                {
                    case StorSimpleCmdletParameterSet.IdentifyByParentObject:
                        var volumeInfoList = StorSimpleClient.GetAllVolumesFordataContainer(deviceId, VolumeContainer.InstanceId);
                        WriteObject(volumeInfoList.ListofVirtualDisks);
                        WriteVerbose(string.Format(Resources.ReturnedCountVolumeMessage, volumeInfoList.ListofVirtualDisks.Count, volumeInfoList.ListofVirtualDisks.Count > 1 ? "s" : string.Empty));
                        break;
                    case StorSimpleCmdletParameterSet.IdentifyByName:
                        var volumeInfo = StorSimpleClient.GetVolumeByName(deviceId, VolumeName);
                        if (volumeInfo != null 
                            && volumeInfo.VirtualDiskInfo != null 
                            && volumeInfo.VirtualDiskInfo.InstanceId != null)
                        {
                            WriteObject(volumeInfo.VirtualDiskInfo);
                            WriteVerbose(string.Format(Resources.FoundVolumeMessage, VolumeName));
                        }
                        else
                        {
                            WriteVerbose(string.Format(Resources.NotFoundVolumeMessage, VolumeName));
                        }
                        break;
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}