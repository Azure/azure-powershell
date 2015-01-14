
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    public partial class PSStorSimpleClient
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