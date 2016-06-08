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

using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System.Management.Automation;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleDevice", DefaultParameterSetName = StorSimpleCmdletParameterSet.Empty),
        OutputType(typeof(List<DeviceDetails>), typeof(IEnumerable<DeviceInfo>))]
    public class GetAzureStorSimpleDevice : StorSimpleCmdletBase
    {
        [Alias("ID")]
        [Parameter(Position = 0, Mandatory = false, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById, HelpMessage = StorSimpleCmdletHelpMessage.DeviceId)]
        [ValidateNotNullOrEmpty]
        public string DeviceId { get; set; }

        [Alias("Name")]
        [Parameter(Position = 0, Mandatory = false, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByName, HelpMessage = StorSimpleCmdletHelpMessage.DeviceName)]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Parameter(Position = 1, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.DeviceType)]
        [ValidateSet("Appliance", "VirtualAppliance")]
        [ValidateNotNullOrEmpty]
        public string Type { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.DeviceModel)]
        [ValidateNotNullOrEmpty]
        public string ModelID { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.DeviceConfigRequired)]
        public SwitchParameter Detailed { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                var deviceInfos = StorSimpleClient.GetAllDevices();
                switch(ParameterSetName)
                {
                    case StorSimpleCmdletParameterSet.IdentifyByName:
                        deviceInfos = deviceInfos.Where(x => x.FriendlyName.Equals(DeviceName, System.StringComparison.InvariantCultureIgnoreCase));
                        break;
                    case StorSimpleCmdletParameterSet.IdentifyById:
                        deviceInfos = deviceInfos.Where(x => x.DeviceId.Equals(DeviceId, System.StringComparison.InvariantCultureIgnoreCase));
                        break;
                    default:
                        break;
                }
                
                if (Type != null)
                {
                    DeviceType deviceType;
                    bool parseSuccess = Enum.TryParse(Type, true, out deviceType);
                    if (parseSuccess)
                    {
                        deviceInfos = deviceInfos.Where(x => x.Type.Equals(deviceType));
                    }
                }

                if (ModelID != null)
                {
                    deviceInfos = deviceInfos.Where(x => x.ModelDescription.Equals(ModelID, System.StringComparison.InvariantCultureIgnoreCase));
                }

                if (Detailed.IsPresent)
                {
                    List<DeviceDetails> deviceDetailsList = new List<DeviceDetails>();
                    foreach (var deviceInfo in deviceInfos)
                    {
                        deviceDetailsList.Add(StorSimpleClient.GetDeviceDetails(deviceInfo.DeviceId));
                    }
                    WriteObject(deviceDetailsList, true);
                }
                else
                {
                    WriteObject(deviceInfos, true);
                }
                WriteVerbose(string.Format(Resources.DeviceGet_StatusMessage, deviceInfos.Count(), deviceInfos.Count() > 1 ? "s" : string.Empty));
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}