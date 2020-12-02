namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Model class for event details of a job status event.</summary>
    public partial class JobStatusEventDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobStatusEventDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobStatusEventDetailsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventSpecificDetails"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventSpecificDetails __eventSpecificDetails = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EventSpecificDetails();

        /// <summary>Backing field for <see cref="AffectedObjectType" /> property.</summary>
        private string _affectedObjectType;

        /// <summary>AffectedObjectType for the event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AffectedObjectType { get => this._affectedObjectType; set => this._affectedObjectType = value; }

        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventSpecificDetailsInternal)__eventSpecificDetails).InstanceType; }

        /// <summary>Backing field for <see cref="JobFriendlyName" /> property.</summary>
        private string _jobFriendlyName;

        /// <summary>JobName for the Event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string JobFriendlyName { get => this._jobFriendlyName; set => this._jobFriendlyName = value; }

        /// <summary>Backing field for <see cref="JobId" /> property.</summary>
        private string _jobId;

        /// <summary>Job arm id for the event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string JobId { get => this._jobId; set => this._jobId = value; }

        /// <summary>Backing field for <see cref="JobStatus" /> property.</summary>
        private string _jobStatus;

        /// <summary>JobStatus for the Event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string JobStatus { get => this._jobStatus; set => this._jobStatus = value; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventSpecificDetailsInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventSpecificDetailsInternal)__eventSpecificDetails).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventSpecificDetailsInternal)__eventSpecificDetails).InstanceType = value; }

        /// <summary>Creates an new <see cref="JobStatusEventDetails" /> instance.</summary>
        public JobStatusEventDetails()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__eventSpecificDetails), __eventSpecificDetails);
            await eventListener.AssertObjectIsValid(nameof(__eventSpecificDetails), __eventSpecificDetails);
        }
    }
    /// Model class for event details of a job status event.
    public partial interface IJobStatusEventDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventSpecificDetails
    {
        /// <summary>AffectedObjectType for the event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"AffectedObjectType for the event.",
        SerializedName = @"affectedObjectType",
        PossibleTypes = new [] { typeof(string) })]
        string AffectedObjectType { get; set; }
        /// <summary>JobName for the Event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"JobName for the Event.",
        SerializedName = @"jobFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string JobFriendlyName { get; set; }
        /// <summary>Job arm id for the event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job arm id for the event.",
        SerializedName = @"jobId",
        PossibleTypes = new [] { typeof(string) })]
        string JobId { get; set; }
        /// <summary>JobStatus for the Event.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"JobStatus for the Event.",
        SerializedName = @"jobStatus",
        PossibleTypes = new [] { typeof(string) })]
        string JobStatus { get; set; }

    }
    /// Model class for event details of a job status event.
    internal partial interface IJobStatusEventDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventSpecificDetailsInternal
    {
        /// <summary>AffectedObjectType for the event.</summary>
        string AffectedObjectType { get; set; }
        /// <summary>JobName for the Event.</summary>
        string JobFriendlyName { get; set; }
        /// <summary>Job arm id for the event.</summary>
        string JobId { get; set; }
        /// <summary>JobStatus for the Event.</summary>
        string JobStatus { get; set; }

    }
}