namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>A streaming job.</summary>
    public partial class ClusterJob :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJob,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJobInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource ID of the streaming job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Backing field for <see cref="JobState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobState? _jobState;

        /// <summary>The current execution state of the streaming job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobState? JobState { get => this._jobState; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJobInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for JobState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobState? Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJobInternal.JobState { get => this._jobState; set { {_jobState = value;} } }

        /// <summary>Internal Acessors for StreamingUnit</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.IClusterJobInternal.StreamingUnit { get => this._streamingUnit; set { {_streamingUnit = value;} } }

        /// <summary>Backing field for <see cref="StreamingUnit" /> property.</summary>
        private int? _streamingUnit;

        /// <summary>The number of streaming units that are used by the streaming job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public int? StreamingUnit { get => this._streamingUnit; }

        /// <summary>Creates an new <see cref="ClusterJob" /> instance.</summary>
        public ClusterJob()
        {

        }
    }
    /// A streaming job.
    public partial interface IClusterJob :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>Resource ID of the streaming job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource ID of the streaming job.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>The current execution state of the streaming job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The current execution state of the streaming job.",
        SerializedName = @"jobState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobState) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobState? JobState { get;  }
        /// <summary>The number of streaming units that are used by the streaming job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The number of streaming units that are used by the streaming job.",
        SerializedName = @"streamingUnits",
        PossibleTypes = new [] { typeof(int) })]
        int? StreamingUnit { get;  }

    }
    /// A streaming job.
    internal partial interface IClusterJobInternal

    {
        /// <summary>Resource ID of the streaming job.</summary>
        string Id { get; set; }
        /// <summary>The current execution state of the streaming job.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobState? JobState { get; set; }
        /// <summary>The number of streaming units that are used by the streaming job.</summary>
        int? StreamingUnit { get; set; }

    }
}