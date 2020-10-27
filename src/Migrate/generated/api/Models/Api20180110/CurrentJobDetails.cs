namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Current job details of the migration item.</summary>
    public partial class CurrentJobDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentJobDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentJobDetailsInternal
    {

        /// <summary>Backing field for <see cref="JobId" /> property.</summary>
        private string _jobId;

        /// <summary>The ARM Id of the job being executed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string JobId { get => this._jobId; set => this._jobId = value; }

        /// <summary>Backing field for <see cref="JobName" /> property.</summary>
        private string _jobName;

        /// <summary>The job name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string JobName { get => this._jobName; set => this._jobName = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>The start time of the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Creates an new <see cref="CurrentJobDetails" /> instance.</summary>
        public CurrentJobDetails()
        {

        }
    }
    /// Current job details of the migration item.
    public partial interface ICurrentJobDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The ARM Id of the job being executed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ARM Id of the job being executed.",
        SerializedName = @"jobId",
        PossibleTypes = new [] { typeof(string) })]
        string JobId { get; set; }
        /// <summary>The job name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The job name.",
        SerializedName = @"jobName",
        PossibleTypes = new [] { typeof(string) })]
        string JobName { get; set; }
        /// <summary>The start time of the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The start time of the job.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }

    }
    /// Current job details of the migration item.
    internal partial interface ICurrentJobDetailsInternal

    {
        /// <summary>The ARM Id of the job being executed.</summary>
        string JobId { get; set; }
        /// <summary>The job name.</summary>
        string JobName { get; set; }
        /// <summary>The start time of the job.</summary>
        global::System.DateTime? StartTime { get; set; }

    }
}