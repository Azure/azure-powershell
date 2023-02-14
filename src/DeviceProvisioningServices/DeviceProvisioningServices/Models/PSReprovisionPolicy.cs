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

namespace Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Models
{
    using Newtonsoft.Json;

    public class PSReprovisionPolicy
    {
        /// <summary>
        /// When set to true (default), the Device Provisioning Service will evaluate the device's IoT Hub assignment
        /// and update it if necessary for any provisioning requests beyond the first from a given device.
        /// If set to false, the device will stay assigned to its current IoT hub.
        /// </summary>
        [JsonProperty(PropertyName = "updateHubAssignment", DefaultValueHandling = DefaultValueHandling.Include)]
        public bool UpdateHubAssignment { get; set; }

        /// <summary>
        /// When set to true (default), the Device Provisioning Service will migrate the device's data (twin, device capabilities, and device ID) from one IoT hub to another during an IoT hub assignment update.
        /// If set to false, the Device Provisioning Service will reset the device's data to the initial desired configuration stored in the provisioning service's enrollment list.
        /// </summary>
        [JsonProperty(PropertyName = "migrateDeviceData", DefaultValueHandling = DefaultValueHandling.Include)]
        public bool MigrateDeviceData { get; set; }
    }
}