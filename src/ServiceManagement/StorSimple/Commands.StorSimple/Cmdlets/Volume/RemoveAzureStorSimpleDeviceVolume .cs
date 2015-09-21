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

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    [Cmdlet(VerbsCommon.Remove, "AzureStorSimpleDeviceVolume"), OutputType(typeof(TaskStatusInfo))]
    public class RemoveAzureStorSimpleDeviceVolume : StorSimpleCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.DeviceName)]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Alias("Name")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByName, HelpMessage = StorSimpleCmdletHelpMessage.VolumeName)]
        [ValidateNotNullOrEmpty]
        public string VolumeName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByObject, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.VolumeObject)]
        [ValidateNotNullOrEmpty]
        public VirtualDisk Volume { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.WaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.Force)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(Force.IsPresent,
                          Resources.RemoveWarningVolume,
                          Resources.RemoveConfirmationVolume,
                          string.Empty,
                          () =>
                          {
                              try
                              {
                                  var deviceid = StorSimpleClient.GetDeviceId(DeviceName);

                                  if (deviceid == null)
                                  {
                                      throw new ArgumentException(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
                                  }

                                  string volumeId = string.Empty;
                                  switch(ParameterSetName)
                                  {
                                      case StorSimpleCmdletParameterSet.IdentifyByObject:
                                          volumeId = Volume.InstanceId;
                                          break;
                                      case StorSimpleCmdletParameterSet.IdentifyByName:
                                          var volumeInfo = StorSimpleClient.GetVolumeByName(deviceid, VolumeName);
                                          if (volumeInfo == null || volumeInfo.VirtualDiskInfo == null || volumeInfo.VirtualDiskInfo.InstanceId == null)
                                          {
                                              throw new ArgumentException(Resources.NotFoundMessageVirtualDisk);
                                          }
                                          volumeId = volumeInfo.VirtualDiskInfo.InstanceId;
                                          break;
                                  }

                                  if (WaitForComplete.IsPresent)
                                  {
                                      WriteVerbose("About to run a task to remove your volume!");
                                      var taskstatus = StorSimpleClient.RemoveVolume(deviceid, volumeId);
                                      HandleSyncTaskResponse(taskstatus, "delete");
                                  }
                                  else
                                  {
                                      WriteVerbose("About to run a task to remove your volume!");
                                      var taskresponse = StorSimpleClient.RemoveVolumeAsync(deviceid, volumeId);
                                      HandleAsyncTaskResponse(taskresponse, "delete");
                                  }
                              }
                              catch (Exception exception)
                              {
                                  this.HandleException(exception);
                              }
                          });
            
        }
    }
}