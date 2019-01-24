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
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PSEventHubConsumerGroupInfo
    {
        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public IDictionary<string, string> Properties { get; set; }

        /// <summary>
        /// Gets the Event Hub-compatible consumer group identifier.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; private set; }

        /// <summary>
        /// Gets the Event Hub-compatible consumer group name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the resource type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }

        /// <summary>
        /// Gets the etag.
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; private set; }
    }
}
