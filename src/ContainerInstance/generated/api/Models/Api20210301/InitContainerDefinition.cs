namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The init container definition.</summary>
    public partial class InitContainerDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinition,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinitionInternal
    {

        /// <summary>The command to execute within the init container in exec form.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string[] Command { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).Command; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).Command = value ?? null /* arrayOf */; }

        /// <summary>The state of the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string CurrentState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).CurrentState; }

        /// <summary>The human-readable status of the container instance state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string CurrentStateDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).CurrentStateDetailStatus; }

        /// <summary>
        /// The container instance exit codes correspond to those from the `docker run` command.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? CurrentStateExitCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).CurrentStateExitCode; }

        /// <summary>The date-time when the container instance state finished.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public global::System.DateTime? CurrentStateFinishTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).CurrentStateFinishTime; }

        /// <summary>The date-time when the container instance state started.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public global::System.DateTime? CurrentStateStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).CurrentStateStartTime; }

        /// <summary>The environment variables to set in the init container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEnvironmentVariable[] EnvironmentVariable { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).EnvironmentVariable; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).EnvironmentVariable = value ?? null /* arrayOf */; }

        /// <summary>The image of the init container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string Image { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).Image; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).Image = value ?? null; }

        /// <summary>The events of the init container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] InstanceViewEvent { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).InstanceViewEvent; }

        /// <summary>The number of times that the init container has been restarted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? InstanceViewRestartCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).InstanceViewRestartCount; }

        /// <summary>Internal Acessors for CurrentState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinitionInternal.CurrentState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).CurrentState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).CurrentState = value; }

        /// <summary>Internal Acessors for CurrentStateDetailStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinitionInternal.CurrentStateDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).CurrentStateDetailStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).CurrentStateDetailStatus = value; }

        /// <summary>Internal Acessors for CurrentStateExitCode</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinitionInternal.CurrentStateExitCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).CurrentStateExitCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).CurrentStateExitCode = value; }

        /// <summary>Internal Acessors for CurrentStateFinishTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinitionInternal.CurrentStateFinishTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).CurrentStateFinishTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).CurrentStateFinishTime = value; }

        /// <summary>Internal Acessors for CurrentStateStartTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinitionInternal.CurrentStateStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).CurrentStateStartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).CurrentStateStartTime = value; }

        /// <summary>Internal Acessors for InstanceView</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInstanceView Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinitionInternal.InstanceView { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).InstanceView; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).InstanceView = value; }

        /// <summary>Internal Acessors for InstanceViewCurrentState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerState Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinitionInternal.InstanceViewCurrentState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).InstanceViewCurrentState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).InstanceViewCurrentState = value; }

        /// <summary>Internal Acessors for InstanceViewEvent</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinitionInternal.InstanceViewEvent { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).InstanceViewEvent; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).InstanceViewEvent = value; }

        /// <summary>Internal Acessors for InstanceViewPreviousState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerState Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinitionInternal.InstanceViewPreviousState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).InstanceViewPreviousState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).InstanceViewPreviousState = value; }

        /// <summary>Internal Acessors for InstanceViewRestartCount</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinitionInternal.InstanceViewRestartCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).InstanceViewRestartCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).InstanceViewRestartCount = value; }

        /// <summary>Internal Acessors for PreviouState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinitionInternal.PreviouState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).PreviouState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).PreviouState = value; }

        /// <summary>Internal Acessors for PreviouStateDetailStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinitionInternal.PreviouStateDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).PreviouStateDetailStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).PreviouStateDetailStatus = value; }

        /// <summary>Internal Acessors for PreviouStateExitCode</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinitionInternal.PreviouStateExitCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).PreviouStateExitCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).PreviouStateExitCode = value; }

        /// <summary>Internal Acessors for PreviouStateFinishTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinitionInternal.PreviouStateFinishTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).PreviouStateFinishTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).PreviouStateFinishTime = value; }

        /// <summary>Internal Acessors for PreviouStateStartTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinitionInternal.PreviouStateStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).PreviouStateStartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).PreviouStateStartTime = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinition Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinitionInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.InitContainerPropertiesDefinition()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name for the init container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>The state of the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string PreviouState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).PreviouState; }

        /// <summary>The human-readable status of the container instance state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string PreviouStateDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).PreviouStateDetailStatus; }

        /// <summary>
        /// The container instance exit codes correspond to those from the `docker run` command.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? PreviouStateExitCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).PreviouStateExitCode; }

        /// <summary>The date-time when the container instance state finished.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public global::System.DateTime? PreviouStateFinishTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).PreviouStateFinishTime; }

        /// <summary>The date-time when the container instance state started.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public global::System.DateTime? PreviouStateStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).PreviouStateStartTime; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinition _property;

        /// <summary>The properties for the init container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinition Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.InitContainerPropertiesDefinition()); set => this._property = value; }

        /// <summary>The volume mounts available to the init container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolumeMount[] VolumeMount { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).VolumeMount; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinitionInternal)Property).VolumeMount = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="InitContainerDefinition" /> instance.</summary>
        public InitContainerDefinition()
        {

        }
    }
    /// The init container definition.
    public partial interface IInitContainerDefinition :
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
        /// <summary>The name for the init container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name for the init container.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
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
    /// The init container definition.
    internal partial interface IInitContainerDefinitionInternal

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
        /// <summary>The name for the init container.</summary>
        string Name { get; set; }
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
        /// <summary>The properties for the init container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerPropertiesDefinition Property { get; set; }
        /// <summary>The volume mounts available to the init container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolumeMount[] VolumeMount { get; set; }

    }
}