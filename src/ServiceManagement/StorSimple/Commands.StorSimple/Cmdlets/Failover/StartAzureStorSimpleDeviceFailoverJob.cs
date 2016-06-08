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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Start, "AzureStorSimpleDeviceFailoverJob", DefaultParameterSetName = StorSimpleCmdletParameterSet.Empty),
        OutputType(typeof(string))]
    public class StartAzureStorSimpleDeviceFailoverJob : StorSimpleCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById, HelpMessage = StorSimpleCmdletHelpMessage.DeviceId)]
        [ValidateNotNullOrEmpty]
        public string DeviceId { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByName, HelpMessage = StorSimpleCmdletHelpMessage.DeviceName)]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.VolumeContainerGroups)]
        [ValidateNotNull]
        public List<DataContainerGroup> VolumecontainerGroups { get; set; }

        [Parameter(Position = 2, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById, HelpMessage = StorSimpleCmdletHelpMessage.FailoverTargetDeviceId)]
        [ValidateNotNullOrEmpty]
        public string TargetDeviceId { get; set; }

        [Parameter(Position = 2, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByName, HelpMessage = StorSimpleCmdletHelpMessage.FailoverTargetDeviceName)]
        [ValidateNotNullOrEmpty]
        public string TargetDeviceName { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.Force)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                string sourceDeviceIdentifierInMessage = string.IsNullOrEmpty(DeviceName) ? DeviceId : DeviceName;
                string targetDeviceIdentifierInMessage = string.IsNullOrEmpty(TargetDeviceName) ? TargetDeviceId : TargetDeviceName;
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Resources.StartDeviceFailoverJobWarningMessage, sourceDeviceIdentifierInMessage, targetDeviceIdentifierInMessage),
                    string.Format(Resources.StartDeviceFailoverJobMessage, sourceDeviceIdentifierInMessage, targetDeviceIdentifierInMessage),
                    string.Empty,
                    () =>
                    {
                        string deviceId = null;
                        string targetDeviceId = null;

                        switch(ParameterSetName)
                        {
                            case StorSimpleCmdletParameterSet.IdentifyById:
                                deviceId = DeviceId;
                                targetDeviceId = TargetDeviceId;
                                break;
                            case StorSimpleCmdletParameterSet.IdentifyByName:
                                deviceId = StorSimpleClient.GetDeviceId(DeviceName);
                                targetDeviceId = StorSimpleClient.GetDeviceId(TargetDeviceName);
                                if (deviceId == null)
                                {
                                    throw new ArgumentException(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
                                }
                                if (targetDeviceId == null)
                                {
                                    throw new ArgumentException(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, TargetDeviceName));
                                }
                                break;
                            default:
                                break;
                        }

                        if (string.IsNullOrEmpty(deviceId) || string.IsNullOrEmpty(targetDeviceId))
                        {
                            WriteObject(null);
                            return;
                        }

                        if (!ValidTargetDeviceForFailover(deviceId, targetDeviceId))
                        {
                            WriteObject(null);
                            return;
                        }

                        var vcIdList = StorSimpleClient.GetVcIdListFromVcGroups(VolumecontainerGroups);

                        var drRequest = new DeviceFailoverRequest()
                        {
                            DataContainerIds = vcIdList,
                            TargetDeviceId = targetDeviceId,
                            CleanupPrimary = true,
                            ReturnWorkflowId = true
                        };

                        var jobResponse = StorSimpleClient.TriggerFailover(deviceId, drRequest);
                        HandleDeviceJobResponse(jobResponse, "start");
                    });
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}
