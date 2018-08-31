namespace Microsoft.Azure.Commands.DeploymentManager.Models
{
    using System;
    using Microsoft.Azure.DeploymentManager.Models;

    public class PSStepOperationInfo
    {
        public PSStepOperationInfo(StepOperationInfo stepOperationInfo)
        {
            this.DeploymentName = stepOperationInfo.DeploymentName;
            this.CorrelationId = stepOperationInfo.CorrelationId;
            this.StartTime = stepOperationInfo.StartTime;
            this.EndTime = stepOperationInfo.EndTime;
            this.LastUpdatedTime = stepOperationInfo.LastUpdatedTime;
            this.Error = stepOperationInfo.Error;
        }

		/// <summary>
		/// Gets the name of the Azure Resource Manager deployment initiated as
		/// part of the step.
		/// </summary>
		public string DeploymentName
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets unique identifier to track the request for ARM-based
		/// resources.
		/// </summary>
		public string CorrelationId
		{
			get;
			private set;
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
		public ErrorProperties Error
		{
			get;
			set;
		}

    }
}
