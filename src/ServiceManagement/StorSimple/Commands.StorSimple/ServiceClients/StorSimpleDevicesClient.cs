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
using System.Linq;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets.Library;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    public partial class StorSimpleClient
    {
        public IEnumerable<DeviceInfo> GetAllDevices()
        {
            return this.GetStorSimpleClient().Devices.List(this.GetCustomRequestHeaders());
        }

        public DeviceDetails GetDeviceDetails(string deviceId)
        {
            var deviceDetailsResponse = this.GetStorSimpleClient().DeviceDetails.Get(deviceId, this.GetCustomRequestHeaders());
            if (deviceDetailsResponse == null)
            {
                return null;
            }
            return deviceDetailsResponse.DeviceDetails;
        }

        public TaskStatusInfo UpdateDeviceDetails(DeviceDetails updatedDetails)
        {
            // Copy stuff over from the DeviceDetails object into a new DeviceDetailsRequest object.
            var request = new DeviceDetailsRequest();
            MiscUtils.CopyProperties(updatedDetails, request);
            var taskStatusInfo = this.GetStorSimpleClient().DeviceDetails.UpdateDeviceDetails(request, this.GetCustomRequestHeaders());
            return taskStatusInfo;
        }

        public string GetDeviceId(string deviceToUse)
        {
            if (deviceToUse == null) throw new ArgumentNullException("deviceToUse");
            var deviceInfos = GetAllDevices();
            return (from deviceInfo in deviceInfos where deviceInfo.FriendlyName.Equals(deviceToUse, StringComparison.InvariantCultureIgnoreCase) select deviceInfo.DeviceId).FirstOrDefault();
        }

        public List<IscsiConnection> GetAllIscsiConnections(string deviceId)
        {
            var iscsiConnectionResponse =  GetStorSimpleClient().IscsiConnection.Get(deviceId, GetCustomRequestHeaders());
            if (iscsiConnectionResponse == null || iscsiConnectionResponse.IscsiConnections == null)
            {
                return null;
            }
            return iscsiConnectionResponse.IscsiConnections.ToList();
        }
    }
}