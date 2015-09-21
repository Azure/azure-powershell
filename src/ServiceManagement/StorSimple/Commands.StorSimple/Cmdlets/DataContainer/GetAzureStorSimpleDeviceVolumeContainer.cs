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
    

    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleDeviceVolumeContainer"),OutputType(typeof(DataContainer), typeof(IList<DataContainer>))]
    public class GetAzureStorSimpleDeviceVolumeContainer : StorSimpleCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.DeviceName)]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Alias("Name")]
        [Parameter(Position = 1, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.DataContainerName)]
        [ValidateNotNullOrEmpty]
        public string VolumeContainerName { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                var deviceid = StorSimpleClient.GetDeviceId(DeviceName);

                if (deviceid == null)
                {
                    throw new ArgumentException(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
                }

                if (VolumeContainerName == null)
                {
                    var dataContainerList = StorSimpleClient.GetAllDataContainers(deviceid);
                    WriteObject(dataContainerList.DataContainers);
                    WriteVerbose(string.Format(Resources.ReturnedCountDataContainerMessage, dataContainerList.DataContainers.Count, dataContainerList.DataContainers.Count > 1 ? "s" : string.Empty));
                }
                else
                {
                    var dataContainer = StorSimpleClient.GetDataContainer(deviceid, VolumeContainerName);
                    if(dataContainer != null 
                        && dataContainer.DataContainerInfo != null
                        && dataContainer.DataContainerInfo.InstanceId != null)
                    {
                        WriteObject(dataContainer.DataContainerInfo);
                        WriteVerbose(string.Format(Resources.FoundDataContainerMessage, VolumeContainerName));
                    }
                    else
                    {
                        WriteVerbose(string.Format(Resources.NotFoundDataContainerMessage, VolumeContainerName));
                    }
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}