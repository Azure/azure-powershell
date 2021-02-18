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
    using System.Collections;
    using Newtonsoft.Json;

    /// <summary>
    /// Configuration for IotHub devices and modules.
    /// </summary>
    public class PSConfiguration
    {
        /// <summary>
        /// Gets Identifier for the configuration.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string Id { get; set; }

        /// <summary>
        /// Gets Schema version for the configuration.
        /// </summary>
        [JsonProperty(PropertyName = "schemaVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string SchemaVersion { get; set; }

        /// <summary>
        /// Gets or sets labels for the configuration.
        /// </summary>
        [JsonProperty(PropertyName = "labels", NullValueHandling = NullValueHandling.Ignore)]
        public Hashtable Labels { get; set; }

        /// <summary>
        /// Gets or sets Content for the configuration.
        /// </summary>
        [JsonProperty(PropertyName = "content", NullValueHandling = NullValueHandling.Ignore)]
        public PSConfigurationContent Content { get; set; }

        /// <summary>
        /// Gets the content type for configuration.
        /// </summary>
        [JsonProperty(PropertyName = "contentType")]
        public string ContentType { get; internal set; }

        /// <summary>
        /// Gets or sets Target Condition for the configuration.
        /// </summary>
        [JsonProperty(PropertyName = "targetCondition")]
        public string TargetCondition { get; set; }

        /// <summary>
        /// Gets creation time for the configuration.
        /// </summary>
        [JsonProperty(PropertyName = "createdTimeUtc")]
        public DateTime CreatedTimeUtc { get; internal set; }

        /// <summary>
        /// Gets last update time for the configuration.
        /// </summary>
        [JsonProperty(PropertyName = "lastUpdatedTimeUtc")]
        public DateTime LastUpdatedTimeUtc { get; internal set; }

        /// <summary>
        /// Gets or sets Priority for the configuration.
        /// </summary>
        [JsonProperty(PropertyName = "priority")]
        public int Priority { get; set; }

        /// <summary>
        /// System Configuration Metrics.
        /// </summary>
        [JsonProperty(PropertyName = "systemMetrics", NullValueHandling = NullValueHandling.Ignore)]
        public PSConfigurationMetrics SystemMetrics { get; internal set; }

        /// <summary>
        /// Custom Configuration Metrics.
        /// </summary>
        [JsonProperty(PropertyName = "metrics", NullValueHandling = NullValueHandling.Ignore)]
        public PSConfigurationMetrics Metrics { get; set; }

        /// <summary>
        /// Gets or sets configuration's ETag.
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string ETag { get; set; }
    }

    public class PSConfigurations : PSConfiguration
    { }

    public class PSDeployment: PSConfiguration
    { }

    public class PSDeployments: PSConfiguration
    { }
}