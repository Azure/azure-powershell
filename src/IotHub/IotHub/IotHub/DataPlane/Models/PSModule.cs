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

    public class PSModule
    {
        /// <summary>
        /// Module ID
        /// </summary>
        [JsonProperty(PropertyName = "moduleId")]
        public string Id { get; set; }

        /// <summary>
        /// Device ID
        /// </summary>
        [JsonProperty(PropertyName = "deviceId")]
        public string DeviceId { get; set; }

        /// <summary>
        /// Modules's Generation ID
        /// </summary>
        [JsonProperty(PropertyName = "generationId")]
        public string GenerationId { get; set; }

        /// <summary>
        /// Modules's ETag
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string ETag { get; set; }

        /// <summary>
        /// Modules's ConnectionState
        /// </summary>
        [JsonProperty(PropertyName = "connectionState")]
        public PSDeviceConnectionState ConnectionState { get; set; }

        /// <summary>
        /// Time when the <see cref="ConnectionState"/> was last updated
        /// </summary>
        [JsonProperty(PropertyName = "connectionStateUpdatedTime")]
        public DateTime ConnectionStateUpdatedTime { get; set; }

        /// <summary>
        /// Time when the <see cref="PSDevice"/> was last active
        /// </summary>
        [JsonProperty(PropertyName = "lastActivityTime")]
        public DateTime LastActivityTime { get; set; }

        /// <summary>
        /// Number of messages sent to the Module from the Cloud
        /// </summary>
        [JsonProperty(PropertyName = "cloudToDeviceMessageCount")]
        public int CloudToDeviceMessageCount { get; set; }

        /// <summary>
        /// Module's authentication mechanism
        /// </summary>
        [JsonProperty(PropertyName = "authentication")]
        public PSAuthenticationMechanism Authentication { get; set; }

        /// <summary>
        /// Represents the modules managed by owner
        /// </summary>
        [JsonProperty(PropertyName = "managedBy")]
        public string ManagedBy { get; set; }
    }

    public class PSModules : PSModule
    { }
}
