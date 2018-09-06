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

namespace Microsoft.Azure.Commands.DeploymentManager.Models
{
    using System;
    using Microsoft.Azure.Management.DeploymentManager.Models;

    public class PSRolloutOperationInfo
    {
        public PSRolloutOperationInfo(RolloutOperationInfo rolloutOperationInfo)
        {
            this.RetryAttempt = rolloutOperationInfo.RetryAttempt;
            this.SkipSucceededOnRetry = rolloutOperationInfo.SkipSucceededOnRetry;
            this.StartTime = rolloutOperationInfo.StartTime;
            this.EndTime = rolloutOperationInfo.EndTime;
            this.Error = rolloutOperationInfo.Error;
        }

		/// <summary>
		/// Gets or sets the ordinal count of retry attempt. 0 if no retries of
		/// the rollout have been performed.
		/// </summary>
		public int? RetryAttempt
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets true if skipping all successful steps in the given
		/// retry attempt was chosen. False otherwise.
		/// </summary>
		public bool? SkipSucceededOnRetry
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the start time of the rollout in UTC.
		/// </summary>
		public DateTime? StartTime
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the start time of the rollout in UTC. This property will not
		/// be set if the rollout has not completed yet.
		/// </summary>
		public DateTime? EndTime
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the start time of the rollout in UTC. This property will not
		/// be set if the rollout has not completed yet.
		/// </summary>
		public CloudErrorBody Error
		{
			get;
			set;
		}
    }
}
