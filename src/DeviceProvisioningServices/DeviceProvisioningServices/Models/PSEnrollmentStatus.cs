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
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Enrollment status
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PSEnrollmentStatus
    {
        /// <summary>
        /// Device has not yet come on-line
        /// </summary>
        Unassigned = 1,

        /// <summary>
        /// Device has connected to the DRS but IoT Hub ID has not yet been returned to the device
        /// </summary>
        Assigning = 2,

        /// <summary>
        /// DRS successfully returned a device ID and connection string to the device
        /// </summary>
        Assigned = 3,

        /// <summary>
        /// Device enrollment failed
        /// </summary>
        Failed = 4,

        /// <summary>
        /// Device is disabled
        /// </summary>
        Disabled = 5
    }
}
