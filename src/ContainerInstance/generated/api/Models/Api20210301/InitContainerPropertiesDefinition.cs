namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The init container definition properties.</summary>
    public partial class InitContainerPropertiesDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinition,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal
    {

        /// <summary>Backing field for <see cref="Command" /> property.</summary>
        private string[] _command;

        /// <summary>The command to execute within the init container in exec form.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string[] Command { get => this._command; set => this._command = value; }

        /// <summary>The state of the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string CurrentState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).CurrentStateState; }

        /// <summary>The human-readable status of the container instance state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string CurrentStateDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).CurrentStateDetailStatus; }

        /// <summary>
        /// The container instance exit codes correspond to those from the `docker run` command.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? CurrentStateExitCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).CurrentStateExitCode; }

        /// <summary>The date-time when the container instance state finished.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public global::System.DateTime? CurrentStateFinishTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).CurrentStateFinishTime; }

        /// <summary>The date-time when the container instance state started.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public global::System.DateTime? CurrentStateStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).CurrentStateStartTime; }

        /// <summary>Backing field for <see cref="EnvironmentVariable" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEnvironmentVariable[] _environmentVariable;

        /// <summary>The environment variables to set in the init container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEnvironmentVariable[] EnvironmentVariable { get => this._environmentVariable; set => this._environmentVariable = value; }

        /// <summary>Backing field for <see cref="Image" /> property.</summary>
        private string _image;

        /// <summary>The image of the init container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Image { get => this._image; set => this._image = value; }

        /// <summary>Backing field for <see cref="InstanceView" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceView _instanceView;

        /// <summary>The instance view of the init container. Only valid in response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceView InstanceView { get => (this._instanceView = this._instanceView ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.InitContainerPropertiesDefinitionInstanceView()); }

        /// <summary>The events of the init container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] InstanceViewEvent { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).Event; }

        /// <summary>The number of times that the init container has been restarted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? InstanceViewRestartCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).RestartCount; }

        /// <summary>Internal Acessors for CurrentState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal.CurrentState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).CurrentStateState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).CurrentStateState = value; }

        /// <summary>Internal Acessors for CurrentStateDetailStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal.CurrentStateDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).CurrentStateDetailStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).CurrentStateDetailStatus = value; }

        /// <summary>Internal Acessors for CurrentStateExitCode</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal.CurrentStateExitCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).CurrentStateExitCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).CurrentStateExitCode = value; }

        /// <summary>Internal Acessors for CurrentStateFinishTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal.CurrentStateFinishTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).CurrentStateFinishTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).CurrentStateFinishTime = value; }

        /// <summary>Internal Acessors for CurrentStateStartTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal.CurrentStateStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).CurrentStateStartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).CurrentStateStartTime = value; }

        /// <summary>Internal Acessors for InstanceView</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceView Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal.InstanceView { get => (this._instanceView = this._instanceView ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.InitContainerPropertiesDefinitionInstanceView()); set { {_instanceView = value;} } }

        /// <summary>Internal Acessors for InstanceViewCurrentState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerState Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal.InstanceViewCurrentState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).CurrentState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).CurrentState = value; }

        /// <summary>Internal Acessors for InstanceViewEvent</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal.InstanceViewEvent { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).Event; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).Event = value; }

        /// <summary>Internal Acessors for InstanceViewPreviousState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerState Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal.InstanceViewPreviousState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).PreviousState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).PreviousState = value; }

        /// <summary>Internal Acessors for InstanceViewRestartCount</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal.InstanceViewRestartCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).RestartCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).RestartCount = value; }

        /// <summary>Internal Acessors for PreviouState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal.PreviouState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).PreviouState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).PreviouState = value; }

        /// <summary>Internal Acessors for PreviouStateDetailStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal.PreviouStateDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).PreviouStateDetailStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).PreviouStateDetailStatus = value; }

        /// <summary>Internal Acessors for PreviouStateExitCode</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal.PreviouStateExitCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).PreviouStateExitCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).PreviouStateExitCode = value; }

        /// <summary>Internal Acessors for PreviouStateFinishTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal.PreviouStateFinishTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).PreviouStateFinishTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).PreviouStateFinishTime = value; }

        /// <summary>Internal Acessors for PreviouStateStartTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal.PreviouStateStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).PreviouStateStartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).PreviouStateStartTime = value; }

        /// <summary>The state of the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string PreviouState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).PreviouState; }

        /// <summary>The human-readable status of the container instance state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string PreviouStateDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).PreviouStateDetailStatus; }

        /// <summary>
        /// The container instance exit codes correspond to those from the `docker run` command.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? PreviouStateExitCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).PreviouStateExitCode; }

        /// <summary>The date-time when the container instance state finished.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public global::System.DateTime? PreviouStateFinishTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).PreviouStateFinishTime; }

        /// <summary>The date-time when the container instance state started.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public global::System.DateTime? PreviouStateStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceViewInternal)InstanceView).PreviouStateStartTime; }

        /// <summary>Backing field for <see cref="VolumeMount" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolumeMount[] _volumeMount;

        /// <summary>The volume mounts available to the init container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolumeMount[] VolumeMount { get => this._volumeMount; set => this._volumeMount = value; }

        /// <summary>Creates an new <see cref="InitContainerPropertiesDefinition" /> instance.</summary>
        public InitContainerPropertiesDefinition()
        {

        }
    }
    /// The init container definition properties.
    public partial interface IInitContainerPropertiesDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The command to execute within the init container in exec form.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The command to execute within the init container in exec form.",
        SerializedName = @"command",
        PossibleTypes = new [] { typeof(string) })]
        string[] Command { get; set; }
        /// <summary>The state of the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The state of the container instance.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string CurrentState { get;  }
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
        /// <summary>The environment variables to set in the init container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The environment variables to set in the init container.",
        SerializedName = @"environmentVariables",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEnvironmentVariable) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEnvironmentVariable[] EnvironmentVariable { get; set; }
        /// <summary>The image of the init container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The image of the init container.",
        SerializedName = @"image",
        PossibleTypes = new [] { typeof(string) })]
        string Image { get; set; }
        /// <summary>The events of the init container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The events of the init container.",
        SerializedName = @"events",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] InstanceViewEvent { get;  }
        /// <summary>The number of times that the init container has been restarted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The number of times that the init container has been restarted.",
        SerializedName = @"restartCount",
        PossibleTypes = new [] { typeof(int) })]
        int? InstanceViewRestartCount { get;  }
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
        /// <summary>The volume mounts available to the init container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The volume mounts available to the init container.",
        SerializedName = @"volumeMounts",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolumeMount) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolumeMount[] VolumeMount { get; set; }

    }
    /// The init container definition properties.
    internal partial interface IInitContainerPropertiesDefinitionInternal

    {
        /// <summary>The command to execute within the init container in exec form.</summary>
        string[] Command { get; set; }
        /// <summary>The state of the container instance.</summary>
        string CurrentState { get; set; }
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
        /// <summary>The environment variables to set in the init container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEnvironmentVariable[] EnvironmentVariable { get; set; }
        /// <summary>The image of the init container.</summary>
        string Image { get; set; }
        /// <summary>The instance view of the init container. Only valid in response.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceView InstanceView { get; set; }
        /// <summary>The current state of the init container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerState InstanceViewCurrentState { get; set; }
        /// <summary>The events of the init container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] InstanceViewEvent { get; set; }
        /// <summary>The previous state of the init container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerState InstanceViewPreviousState { get; set; }
        /// <summary>The number of times that the init container has been restarted.</summary>
        int? InstanceViewRestartCount { get; set; }
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
        /// <summary>The volume mounts available to the init container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolumeMount[] VolumeMount { get; set; }

    }
}