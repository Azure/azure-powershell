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

namespace Microsoft.Azure.Commands.Management.IotHub.Common
{
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Devices;
    using System.Collections.Generic;
    using System.Linq;

    public static class IotHubDataPlaneUtils
    {
        public static Device ToDevice(PSDevice psDevice)
        {
            return IotHubUtils.ConvertObject<PSDevice, Device>(psDevice);
        }

        public static PSDevice ToPSDevice(Device device)
        {
            return IotHubUtils.ConvertObject<Device, PSDevice>(device);
        }

        public static IEnumerable<PSDevices> ToPSDevices(IEnumerable<Device> devices)
        {
            return IotHubUtils.ConvertObject<IEnumerable<Device>, IEnumerable<PSDevices>>(devices.ToList());
        }
    }
}