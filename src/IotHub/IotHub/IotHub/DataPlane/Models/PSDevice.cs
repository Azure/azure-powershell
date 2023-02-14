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
    using Newtonsoft.Json;

    public class PSDevice
    {
        /// <summary>
        /// Device ID
        /// </summary>
        [JsonProperty(PropertyName = "deviceId")]
        public string Id { get; set; }

        /// <summary>
        /// Device's Generation ID
        /// </summary>
        [JsonProperty(PropertyName = "generationId")]
        public string GenerationId { get; set; }

        /// <summary>
        /// Device's ETag
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string ETag { get; set; }

        /// <summary>
        /// Device's ConnectionState
        /// </summary>
        [JsonProperty(PropertyName = "connectionState")]
        public PSDeviceConnectionState ConnectionState { get; set; }

        /// <summary>
        /// Device's Status
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public PSDeviceStatus Status { get; set; }

        /// <summary>
        /// Reason, if any, for the Device to be in specified <see cref="Status"/>
        /// </summary>
        [JsonProperty(PropertyName = "statusReason")]
        public string StatusReason { get; set; }

        /// <summary>
        /// Time when the <see cref="ConnectionState"/> was last updated
        /// </summary>
        [JsonProperty(PropertyName = "connectionStateUpdatedTime")]
        public DateTime ConnectionStateUpdatedTime { get; set; }

        /// <summary>
        /// Time when the <see cref="Status"/> was last updated
        /// </summary>
        [JsonProperty(PropertyName = "statusUpdatedTime")]
        public DateTime StatusUpdatedTime { get; set; }

        /// <summary>
        /// Time when the <see cref="PSDevice"/> was last active
        /// </summary>
        [JsonProperty(PropertyName = "lastActivityTime")]
        public DateTime LastActivityTime { get; set; }

        /// <summary>
        /// Number of messages sent to the Device from the Cloud
        /// </summary>
        [JsonProperty(PropertyName = "cloudToDeviceMessageCount")]
        public int CloudToDeviceMessageCount { get; set; }

        /// <summary>
        /// Device's authentication mechanism
        /// </summary>
        [JsonProperty(PropertyName = "authentication")]
        public PSAuthenticationMechanism Authentication { get; set; }

        /// <summary>
        ///  Capabilities that are enabled on the device
        /// </summary>
        [JsonProperty(PropertyName = "capabilities")]
        public PSDeviceCapabilities Capabilities { get; set; }

        /// <summary>
        /// Scope to which this device instance belongs to
        /// </summary>
        [JsonProperty(PropertyName = "deviceScope")]
        public string Scope { get; set; }
    }

    public class PSDevices: PSDevice
    { }
}
