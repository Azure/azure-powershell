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
using System;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Model
{
    public class AzureSqlElasticJobExecutionModel : AzureSqlElasticJobBaseModel
    {
        /// <summary>
        /// Gets or sets the job execution id
        /// </summary>
        public Guid? JobExecutionId { get; set; }

        /// <summary>
        /// Gets or sets the job version
        /// </summary>
        public int? JobVersion { get; set; }

        /// <summary>
        /// Gets or sets the lifecycle
        /// </summary>
        public string Lifecycle { get; set; }

        /// <summary>
        /// Gets or sets the provisioning state
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets the create time
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// Gets or sets the start time
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the current attempts
        /// </summary>
        public int? CurrentAttempts { get; set; }

        /// <summary>
        /// Gets or sets the current attempt start time
        /// </summary>
        public DateTime? CurrentAttemptStartTime { get; set; }

        /// <summary>
        /// Gets or sets the last message
        /// </summary>
        public string LastMessage { get; set; }
    }
}
