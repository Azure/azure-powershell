// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.DeploymentManager.Models
{
    using System;
    using Microsoft.Azure.Management.DeploymentManager.Models;

    public class PSRolloutOperationInfo : PSBaseOperationInfo
    {
        public PSRolloutOperationInfo(RolloutOperationInfo rolloutOperationInfo) : base(
            rolloutOperationInfo?.StartTime,
            rolloutOperationInfo?.EndTime,
            null,
            rolloutOperationInfo?.Error)
        {
            this.RetryAttempt = rolloutOperationInfo.RetryAttempt;
            this.SkipSucceededOnRetry = rolloutOperationInfo.SkipSucceededOnRetry;
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
    }
}
