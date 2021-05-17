namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The instance view of the init container. Only valid in response.</summary>
    public partial class InitContainerPropertiesDefinitionInstanceView :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceView,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal
    {

        /// <summary>Backing field for <see cref="CurrentState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerState _currentState;

        /// <summary>The current state of the init container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerState CurrentState { get => (this._currentState = this._currentState ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerState()); }

        /// <summary>The human-readable status of the container instance state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string CurrentStateDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)CurrentState).DetailStatus; }

        /// <summary>
        /// The container instance exit codes correspond to those from the `docker run` command.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? CurrentStateExitCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)CurrentState).ExitCode; }

        /// <summary>The date-time when the container instance state finished.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public global::System.DateTime? CurrentStateFinishTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)CurrentState).FinishTime; }

        /// <summary>The date-time when the container instance state started.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public global::System.DateTime? CurrentStateStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)CurrentState).StartTime; }

        /// <summary>The state of the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string CurrentStateState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)CurrentState).State; }

        /// <summary>Backing field for <see cref="Event" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] _event;

        /// <summary>The events of the init container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] Event { get => this._event; }

        /// <summary>Internal Acessors for CurrentState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerState Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal.CurrentState { get => (this._currentState = this._currentState ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerState()); set { {_currentState = value;} } }

        /// <summary>Internal Acessors for CurrentStateDetailStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal.CurrentStateDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)CurrentState).DetailStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)CurrentState).DetailStatus = value; }

        /// <summary>Internal Acessors for CurrentStateExitCode</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal.CurrentStateExitCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)CurrentState).ExitCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)CurrentState).ExitCode = value; }

        /// <summary>Internal Acessors for CurrentStateFinishTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal.CurrentStateFinishTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)CurrentState).FinishTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)CurrentState).FinishTime = value; }

        /// <summary>Internal Acessors for CurrentStateStartTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal.CurrentStateStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)CurrentState).StartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)CurrentState).StartTime = value; }

        /// <summary>Internal Acessors for CurrentStateState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal.CurrentStateState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)CurrentState).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)CurrentState).State = value; }

        /// <summary>Internal Acessors for Event</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal.Event { get => this._event; set { {_event = value;} } }

        /// <summary>Internal Acessors for PreviouState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal.PreviouState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)PreviousState).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)PreviousState).State = value; }

        /// <summary>Internal Acessors for PreviouStateDetailStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal.PreviouStateDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)PreviousState).DetailStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)PreviousState).DetailStatus = value; }

        /// <summary>Internal Acessors for PreviouStateExitCode</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal.PreviouStateExitCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)PreviousState).ExitCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)PreviousState).ExitCode = value; }

        /// <summary>Internal Acessors for PreviouStateFinishTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal.PreviouStateFinishTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)PreviousState).FinishTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)PreviousState).FinishTime = value; }

        /// <summary>Internal Acessors for PreviouStateStartTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal.PreviouStateStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)PreviousState).StartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)PreviousState).StartTime = value; }

        /// <summary>Internal Acessors for PreviousState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerState Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal.PreviousState { get => (this._previousState = this._previousState ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerState()); set { {_previousState = value;} } }

        /// <summary>Internal Acessors for RestartCount</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal.RestartCount { get => this._restartCount; set { {_restartCount = value;} } }

        /// <summary>The state of the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string PreviouState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)PreviousState).State; }

        /// <summary>The human-readable status of the container instance state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string PreviouStateDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)PreviousState).DetailStatus; }

        /// <summary>
        /// The container instance exit codes correspond to those from the `docker run` command.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? PreviouStateExitCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)PreviousState).ExitCode; }

        /// <summary>The date-time when the container instance state finished.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public global::System.DateTime? PreviouStateFinishTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)PreviousState).FinishTime; }

        /// <summary>The date-time when the container instance state started.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public global::System.DateTime? PreviouStateStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerStateInternal)PreviousState).StartTime; }

        /// <summary>Backing field for <see cref="PreviousState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerState _previousState;

        /// <summary>The previous state of the init container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerState PreviousState { get => (this._previousState = this._previousState ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerState()); }

        /// <summary>Backing field for <see cref="RestartCount" /> property.</summary>
        private int? _restartCount;

        /// <summary>The number of times that the init container has been restarted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public int? RestartCount { get => this._restartCount; }

        /// <summary>
        /// Creates an new <see cref="InitContainerPropertiesDefinitionInstanceView" /> instance.
        /// </summary>
        public InitContainerPropertiesDefinitionInstanceView()
        {

        }
    }
    /// The instance view of the init container. Only valid in response.
    public partial interface IInitContainerPropertiesDefinitionInstanceView :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The human-readable status of the container instance state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The human-readable status of the container instance state.",
        SerializedName = @"detailStatus",
        PossibleTypes = new [] { typeof(string) })]
        string CurrentStateDetailStatus { get;  }
        /// <summary>
        /// The container instance exit codes correspond to those from the `docker run` command.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The container instance exit codes correspond to those from the `docker run` command.",
        SerializedName = @"exitCode",
        PossibleTypes = new [] { typeof(int) })]
        int? CurrentStateExitCode { get;  }
        /// <summary>The date-time when the container instance state finished.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The date-time when the container instance state finished.",
        SerializedName = @"finishTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CurrentStateFinishTime { get;  }
        /// <summary>The date-time when the container instance state started.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The date-time when the container instance state started.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CurrentStateStartTime { get;  }
        /// <summary>The state of the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The state of the container instance.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string CurrentStateState { get;  }
        /// <summary>The events of the init container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The events of the init container.",
        SerializedName = @"events",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] Event { get;  }
        /// <summary>The state of the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The state of the container instance.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string PreviouState { get;  }
        /// <summary>The human-readable status of the container instance state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The human-readable status of the container instance state.",
        SerializedName = @"detailStatus",
        PossibleTypes = new [] { typeof(string) })]
        string PreviouStateDetailStatus { get;  }
        /// <summary>
        /// The container instance exit codes correspond to those from the `docker run` command.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The container instance exit codes correspond to those from the `docker run` command.",
        SerializedName = @"exitCode",
        PossibleTypes = new [] { typeof(int) })]
        int? PreviouStateExitCode { get;  }
        /// <summary>The date-time when the container instance state finished.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The date-time when the container instance state finished.",
        SerializedName = @"finishTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? PreviouStateFinishTime { get;  }
        /// <summary>The date-time when the container instance state started.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The date-time when the container instance state started.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? PreviouStateStartTime { get;  }
        /// <summary>The number of times that the init container has been restarted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The number of times that the init container has been restarted.",
        SerializedName = @"restartCount",
        PossibleTypes = new [] { typeof(int) })]
        int? RestartCount { get;  }

    }
    /// The instance view of the init container. Only valid in response.
    internal partial interface IInitContainerPropertiesDefinitionInstanceViewInternal

    {
        /// <summary>The current state of the init container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerState CurrentState { get; set; }
        /// <summary>The human-readable status of the container instance state.</summary>
        string CurrentStateDetailStatus { get; set; }
        /// <summary>
        /// The container instance exit codes correspond to those from the `docker run` command.
        /// </summary>
        int? CurrentStateExitCode { get; set; }
        /// <summary>The date-time when the container instance state finished.</summary>
        global::System.DateTime? CurrentStateFinishTime { get; set; }
        /// <summary>The date-time when the container instance state started.</summary>
        global::System.DateTime? CurrentStateStartTime { get; set; }
        /// <summary>The state of the container instance.</summary>
        string CurrentStateState { get; set; }
        /// <summary>The events of the init container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] Event { get; set; }
        /// <summary>The state of the container instance.</summary>
        string PreviouState { get; set; }
        /// <summary>The human-readable status of the container instance state.</summary>
        string PreviouStateDetailStatus { get; set; }
        /// <summary>
        /// The container instance exit codes correspond to those from the `docker run` command.
        /// </summary>
        int? PreviouStateExitCode { get; set; }
        /// <summary>The date-time when the container instance state finished.</summary>
        global::System.DateTime? PreviouStateFinishTime { get; set; }
        /// <summary>The date-time when the container instance state started.</summary>
        global::System.DateTime? PreviouStateStartTime { get; set; }
        /// <summary>The previous state of the init container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerState PreviousState { get; set; }
        /// <summary>The number of times that the init container has been restarted.</summary>
        int? RestartCount { get; set; }

    }
}