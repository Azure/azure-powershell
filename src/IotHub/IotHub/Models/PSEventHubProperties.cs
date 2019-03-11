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

    public class PSEventHubProperties
    {
        /// <summary>
        /// The retention time in days. Range of values [For F1: 1-1, S1: 1-7,
        /// S2: 1-7, S3: 1-7].
        /// </summary>
        [JsonProperty(PropertyName = "retentionTimeInDays")]
        public long? RetentionTimeInDays { get; set; }

        /// <summary>
        /// The partition count. Range of values [For F1: 2-2, S1: 2-128, S2:
        /// 2-128, S3: 2-128].
        /// </summary>
        [JsonProperty(PropertyName = "partitionCount")]
        public int? PartitionCount { get; set; }

        /// <summary>
        /// The partition ids.
        /// </summary>
        [JsonProperty(PropertyName = "partitionIds")]
        public IList<string> PartitionIds { get; set; }

        /// <summary>
        /// The eventhub path.
        /// </summary>
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }

        /// <summary>
        /// The endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "endpoint")]
        public string Endpoint { get; set; }

    }
}
