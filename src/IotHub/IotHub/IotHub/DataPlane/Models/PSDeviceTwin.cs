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

namespace Microsoft.Azure.Commands.Management.IotHub.Models
{
    using System;
    using Microsoft.Azure.Devices.Shared;
    using Newtonsoft.Json;

    /// <summary>
    /// Device Twin Representation.
    /// </summary>
    public class PSDeviceTwin
    {
        /// <summary>
        /// Device ID
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// Device's Tags.
        /// </summary>
        public TwinCollection Tags { get; set; }

        /// <summary>
        /// Device's properties.
        /// </summary>
        public TwinProperties Properties { get; set; }

        /// <summary>
        /// Device's Twin Version.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public long Version { get; set; }

        /// <summary>
        /// Device's Twin ETag.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string ETag { get; set; }

        /// <summary>
        /// Device's ConnectionState.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public PSDeviceConnectionState ConnectionState { get; set; }

        /// <summary>
        /// Device's Status.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public PSDeviceStatus Status { get; set; }

        /// <summary>
        /// Reason, if any, for the Device to be in specified <see cref="Status"/>.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string StatusReason { get; set; }

        /// <summary>
        /// Time when the <see cref="ConnectionState"/> was last updated.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public DateTime ConnectionStateUpdatedTime { get; set; }

        /// <summary>
        /// Time when the <see cref="Status"/> was last updated.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public DateTime StatusUpdatedTime { get; set; }

        /// <summary>
        /// Time when the <see cref="PSDevice"/> was last active.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public DateTime LastActivityTime { get; set; }

        /// <summary>
        /// Number of messages sent to the Device from the Cloud.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int CloudToDeviceMessageCount { get; set; }

        /// <summary>
        /// Device's authentication type.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public PSAuthenticationType AuthenticationType { get; set; }

        /// <summary>
        /// Capabilities that are enabled on the device
        /// </summary>
        public DeviceCapabilities Capabilities { get; set; }
    }
}
