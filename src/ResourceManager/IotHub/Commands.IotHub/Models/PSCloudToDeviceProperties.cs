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

    public class PSCloudToDeviceProperties
    {
        /// <summary>
        /// The max delivery count for the device queue. Range : 1-100.
        /// </summary>
        [JsonProperty(PropertyName = "maxDeliveryCount")]
        public int? MaxDeliveryCount { get; set; }

        /// <summary>
        /// The default time to live for the device queue. Range : 1 Min
        /// (PT1M) - 2 Days (P2D).
        /// </summary>
        [JsonProperty(PropertyName = "defaultTtlAsIso8601")]
        public TimeSpan? DefaultTtlAsIso8601 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "feedback")]
        public PSFeedbackProperties Feedback { get; set; }
    }
}
