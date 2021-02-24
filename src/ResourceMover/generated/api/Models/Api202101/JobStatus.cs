namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines the job status.</summary>
    public partial class JobStatus :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IJobStatus,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IJobStatusInternal
    {

        /// <summary>Backing field for <see cref="JobName" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName? _jobName;

        /// <summary>Defines the job name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName? JobName { get => this._jobName; }

        /// <summary>Backing field for <see cref="JobProgress" /> property.</summary>
        private string _jobProgress;

        /// <summary>Gets or sets the monitoring job percentage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string JobProgress { get => this._jobProgress; }

        /// <summary>Internal Acessors for JobName</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName? Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IJobStatusInternal.JobName { get => this._jobName; set { {_jobName = value;} } }

        /// <summary>Internal Acessors for JobProgress</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IJobStatusInternal.JobProgress { get => this._jobProgress; set { {_jobProgress = value;} } }

        /// <summary>Creates an new <see cref="JobStatus" /> instance.</summary>
        public JobStatus()
        {

        }
    }
    /// Defines the job status.
    public partial interface IJobStatus :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>Defines the job name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Defines the job name.",
        SerializedName = @"jobName",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName? JobName { get;  }
        /// <summary>Gets or sets the monitoring job percentage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets or sets the monitoring job percentage.",
        SerializedName = @"jobProgress",
        PossibleTypes = new [] { typeof(string) })]
        string JobProgress { get;  }

    }
    /// Defines the job status.
    internal partial interface IJobStatusInternal

    {
        /// <summary>Defines the job name.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName? JobName { get; set; }
        /// <summary>Gets or sets the monitoring job percentage.</summary>
        string JobProgress { get; set; }

    }
}