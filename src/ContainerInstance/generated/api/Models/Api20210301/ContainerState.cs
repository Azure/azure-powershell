namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The container instance state.</summary>
    public partial class ContainerState :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerState,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal
    {

        /// <summary>Backing field for <see cref="DetailStatus" /> property.</summary>
        private string _detailStatus;

        /// <summary>The human-readable status of the container instance state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string DetailStatus { get => this._detailStatus; }

        /// <summary>Backing field for <see cref="ExitCode" /> property.</summary>
        private int? _exitCode;

        /// <summary>
        /// The container instance exit codes correspond to those from the `docker run` command.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public int? ExitCode { get => this._exitCode; }

        /// <summary>Backing field for <see cref="FinishTime" /> property.</summary>
        private global::System.DateTime? _finishTime;

        /// <summary>The date-time when the container instance state finished.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public global::System.DateTime? FinishTime { get => this._finishTime; }

        /// <summary>Internal Acessors for DetailStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal.DetailStatus { get => this._detailStatus; set { {_detailStatus = value;} } }

        /// <summary>Internal Acessors for ExitCode</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal.ExitCode { get => this._exitCode; set { {_exitCode = value;} } }

        /// <summary>Internal Acessors for FinishTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal.FinishTime { get => this._finishTime; set { {_finishTime = value;} } }

        /// <summary>Internal Acessors for StartTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal.StartTime { get => this._startTime; set { {_startTime = value;} } }

        /// <summary>Internal Acessors for State</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal.State { get => this._state; set { {_state = value;} } }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>The date-time when the container instance state started.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private string _state;

        /// <summary>The state of the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string State { get => this._state; }

        /// <summary>Creates an new <see cref="ContainerState" /> instance.</summary>
        public ContainerState()
        {

        }
    }
    /// The container instance state.
    public partial interface IContainerState :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The human-readable status of the container instance state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The human-readable status of the container instance state.",
        SerializedName = @"detailStatus",
        PossibleTypes = new [] { typeof(string) })]
        string DetailStatus { get;  }
        /// <summary>
        /// The container instance exit codes correspond to those from the `docker run` command.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The container instance exit codes correspond to those from the `docker run` command.",
        SerializedName = @"exitCode",
        PossibleTypes = new [] { typeof(int) })]
        int? ExitCode { get;  }
        /// <summary>The date-time when the container instance state finished.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The date-time when the container instance state finished.",
        SerializedName = @"finishTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? FinishTime { get;  }
        /// <summary>The date-time when the container instance state started.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The date-time when the container instance state started.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get;  }
        /// <summary>The state of the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The state of the container instance.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string State { get;  }

    }
    /// The container instance state.
    internal partial interface IContainerStateInternal

    {
        /// <summary>The human-readable status of the container instance state.</summary>
        string DetailStatus { get; set; }
        /// <summary>
        /// The container instance exit codes correspond to those from the `docker run` command.
        /// </summary>
        int? ExitCode { get; set; }
        /// <summary>The date-time when the container instance state finished.</summary>
        global::System.DateTime? FinishTime { get; set; }
        /// <summary>The date-time when the container instance state started.</summary>
        global::System.DateTime? StartTime { get; set; }
        /// <summary>The state of the container instance.</summary>
        string State { get; set; }

    }
}