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

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSLivySessionStateInformation : PSLivyStateInformation
    {
        public PSLivySessionStateInformation(SparkSessionState stateInfo)
            : base(stateInfo?.NotStartedAt,
                stateInfo?.StartingAt,
                stateInfo?.DeadAt,
                stateInfo?.TerminatedAt,
                stateInfo?.RecoveringAt,
                stateInfo?.CurrentState,
                stateInfo?.JobCreationRequest)
        {
            this.IdleAt = stateInfo?.IdleAt;
            this.ShuttingDownAt = stateInfo?.ShuttingDownAt;
            this.BusyAt = stateInfo?.BusyAt;
            this.ErrorAt = stateInfo?.ErrorAt;
        }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? IdleAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? ShuttingDownAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? BusyAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? ErrorAt { get; set; }
    }
}