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


    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleFailoverVolumeContainers"), OutputType(typeof(IList<DataContainerGroup>))]
    public class GetAzureStorSimpleFailoverVolumeContainers : StorSimpleCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById, HelpMessage = StorSimpleCmdletHelpMessage.DeviceId)]
        [ValidateNotNullOrEmpty]
        public string DeviceId { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByName, HelpMessage = StorSimpleCmdletHelpMessage.DeviceName)]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                string deviceid = null;

                switch(ParameterSetName)
                {
                    case StorSimpleCmdletParameterSet.IdentifyById:
                        if (StorSimpleClient.IsValidDeviceId(DeviceId))
                        {
                            deviceid = DeviceId;
                        }
                        else
                        {
                            throw new ArgumentException(string.Format(Resources.NoDeviceFoundWithGivenIdInResourceMessage, StorSimpleContext.ResourceName, DeviceId));
                        }
                        break;
                    case StorSimpleCmdletParameterSet.IdentifyByName:
                        deviceid = StorSimpleClient.GetDeviceId(DeviceName);
                        if (deviceid == null)
                        {
                            throw new ArgumentException(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
                        }
                        break;
                    default:
                        break;
                }

                if (string.IsNullOrEmpty(deviceid))
                {
                    WriteObject(null);
                    return;
                }

                var dcgroupList = StorSimpleClient.GetFaileoverDataContainerGroups(deviceid).DataContainerGroupResponse.DCGroups;
                WriteObject(dcgroupList);
                WriteVerbose(string.Format(Resources.ReturnedCountDataContainerGroupMessage,
                    dcgroupList.Count,
                    dcgroupList.Count > 1 ? "s" : string.Empty));

            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}
