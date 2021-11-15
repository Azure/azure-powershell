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

using Azure.Analytics.Synapse.Spark.Models;
using System;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public abstract class PSLivyStateInformation
    {
        public PSLivyStateInformation(
            DateTimeOffset? notStartedAt,
            DateTimeOffset? startingAt,
            DateTimeOffset? deadAt,
            DateTimeOffset? terminatedAt,
            DateTimeOffset? recoveringAt,
            string currentState,
            SparkRequest jobCreationRequest)
        {
            this.NotStartedAt = notStartedAt;
            this.StartingAt = startingAt;
            this.DeadAt = deadAt;
            this.TerminatedAt = terminatedAt;
            this.RecoveringAt = recoveringAt;
            this.CurrentState = currentState;
            this.JobCreationRequest = jobCreationRequest != null ? new PSLivyRequestBase(jobCreationRequest) : null;
        }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? NotStartedAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? StartingAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? DeadAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? TerminatedAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? RecoveringAt { get; set; }

        /// <summary>
        /// </summary>
        public string CurrentState { get; set; }

        /// <summary>
        /// </summary>
        public PSLivyRequestBase JobCreationRequest { get; set; }
    }
}