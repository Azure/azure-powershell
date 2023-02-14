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

    public class PSIotHubJobResponse
    {
        /// <summary>
        /// The job identifier.
        /// </summary>
        [JsonProperty(PropertyName = "jobId")]
        public string JobId { get; set; }

        /// <summary>
        /// Start time of the Job.
        /// </summary>
        [JsonProperty(PropertyName = "startTimeUtc")]
        public DateTime? StartTimeUtc { get; set; }

        /// <summary>
        /// Represents the time the job stopped processing.
        /// </summary>
        [JsonProperty(PropertyName = "endTimeUtc")]
        public DateTime? EndTimeUtc { get; set; }

        /// <summary>
        /// The type of job to execute. Possible values include: 'unknown',
        /// 'export', 'import', 'backup', 'readDeviceProperties',
        /// 'writeDeviceProperties', 'updateDeviceConfiguration',
        /// 'rebootDevice', 'factoryResetDevice', 'firmwareUpdate'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Status of the Job. Possible values include: 'unknown', 'enqueued',
        /// 'running', 'completed', 'failed', 'cancelled'
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public PSIotHubJobStatus? Status { get; set; }

        /// <summary>
        /// If status == failure, this represents a string containing the
        /// reason.
        /// </summary>
        [JsonProperty(PropertyName = "failureReason")]
        public string FailureReason { get; set; }

        /// <summary>
        /// The status message for the job.
        /// </summary>
        [JsonProperty(PropertyName = "statusMessage")]
        public string StatusMessage { get; set; }
    }
}
