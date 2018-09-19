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

    public class PSFeedbackProperties
    {
        /// <summary>
        /// The lock duration for the feedback queue. Range: 5 Sec (PT5S) - 5
        /// Min (PT5M).
        /// </summary>
        [JsonProperty(PropertyName = "lockDurationAsIso8601")]
        public TimeSpan? LockDurationAsIso8601 { get; set; }

        /// <summary>
        /// The time to live for the feedback queue. Range: 1 Min (PT1M) - 2
        /// Days (P2D).
        /// </summary>
        [JsonProperty(PropertyName = "ttlAsIso8601")]
        public TimeSpan? TtlAsIso8601 { get; set; }

        /// <summary>
        /// The max delivery count. Range : 1-100.
        /// </summary>
        [JsonProperty(PropertyName = "maxDeliveryCount")]
        public int? MaxDeliveryCount { get; set; }
    }
}
