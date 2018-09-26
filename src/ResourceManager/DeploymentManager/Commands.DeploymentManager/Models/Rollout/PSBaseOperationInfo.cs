namespace Microsoft.Azure.Commands.DeploymentManager.Models
{
    using System;
    using Microsoft.Azure.Management.DeploymentManager.Models;

    public class PSBaseOperationInfo
    {
        public PSBaseOperationInfo(
            DateTime? startTime,
            DateTime? endTime,
            DateTime? lastUpdateTime,
            CloudErrorBody error)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.LastUpdatedTime= lastUpdateTime;
            this.Error = error;
        }

        /// <summary>
        /// Gets start time of the action in UTC.
        /// </summary>
        public DateTime? StartTime
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets end time of the action in UTC.
		/// </summary>
		public DateTime? EndTime
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets last time in UTC this operation was updated.
		/// </summary>
		public DateTime? LastUpdatedTime
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets or sets the errors, if any, for the action.
		/// </summary>
		public CloudErrorBody Error
		{
			get;
			set;
		}
    }
}
