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
using System.Linq;
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// Lists all the connected ISCSI initiators
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleDeviceConnectedInitiator"), OutputType(typeof(List<IscsiConnection>))]
    public class GetAzureStorSimpleDeviceConnectedInitiator : StorSimpleCmdletBase
    {
        [Alias("ID")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById, HelpMessage = StorSimpleCmdletHelpMessage.DeviceId)]
        [ValidateNotNullOrEmpty]
        public string DeviceId { get; set; }

        [Alias("Name")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByName, HelpMessage = StorSimpleCmdletHelpMessage.DeviceName)]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        //not overriding BeginProcessing so resource context validation will happen here

        public override void ExecuteCmdlet()
        {
            try
            {
                List<IscsiConnection> iscsiConnections = null;
                var currentResourceName = StorSimpleClient.GetResourceContext().ResourceName;
                string deviceIdFinal = null;
                if(ParameterSetName == StorSimpleCmdletParameterSet.IdentifyByName)
                {
                    var deviceToUse = StorSimpleClient.GetAllDevices().Where(x => x.FriendlyName.Equals(DeviceName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                    if (deviceToUse == null)
                    {
                        throw new ArgumentException(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, currentResourceName, DeviceName));
                    }
                    deviceIdFinal = deviceToUse.DeviceId;
                }
                else
                    deviceIdFinal = DeviceId;

                //verify that this device is configured
                this.VerifyDeviceConfigurationCompleteForDevice(deviceIdFinal);
                iscsiConnections = StorSimpleClient.GetAllIscsiConnections(deviceIdFinal);
                WriteObject(iscsiConnections);
                WriteVerbose(string.Format(Resources.IscsiConnectionGet_StatusMessage,iscsiConnections.Count, (iscsiConnections.Count > 1?"s":string.Empty)));
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}