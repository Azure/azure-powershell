namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The container instance properties.</summary>
    public partial class ContainerProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Command" /> property.</summary>
        private string[] _command;

        /// <summary>The commands to execute within the container instance in exec form.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string[] Command { get => this._command; set => this._command = value; }

        /// <summary>The state of the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string CurrentState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).CurrentStateState; }

        /// <summary>The human-readable status of the container instance state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string CurrentStateDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).CurrentStateDetailStatus; }

        /// <summary>
        /// The container instance exit codes correspond to those from the `docker run` command.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? CurrentStateExitCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).CurrentStateExitCode; }

        /// <summary>The date-time when the container instance state finished.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public global::System.DateTime? CurrentStateFinishTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).CurrentStateFinishTime; }

        /// <summary>The date-time when the container instance state started.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public global::System.DateTime? CurrentStateStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).CurrentStateStartTime; }

        /// <summary>Backing field for <see cref="EnvironmentVariable" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEnvironmentVariable[] _environmentVariable;

        /// <summary>The environment variables to set in the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEnvironmentVariable[] EnvironmentVariable { get => this._environmentVariable; set => this._environmentVariable = value; }

        /// <summary>Backing field for <see cref="Image" /> property.</summary>
        private string _image;

        /// <summary>The name of the image used to create the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Image { get => this._image; set => this._image = value; }

        /// <summary>Backing field for <see cref="InstanceView" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceView _instanceView;

        /// <summary>The instance view of the container instance. Only valid in response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceView InstanceView { get => (this._instanceView = this._instanceView ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerPropertiesInstanceView()); }

        /// <summary>The events of the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] InstanceViewEvent { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).Event; }

        /// <summary>The number of times that the container instance has been restarted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? InstanceViewRestartCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).RestartCount; }

        /// <summary>The CPU limit of this container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public double? LimitCpu { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).LimitCpu; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).LimitCpu = value ?? default(double); }

        /// <summary>The memory limit in GB of this container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public double? LimitMemoryInGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).LimitMemoryInGb; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).LimitMemoryInGb = value ?? default(double); }

        /// <summary>The count of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? LimitsGpuCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).LimitsGpuCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).LimitsGpuCount = value ?? default(int); }

        /// <summary>The SKU of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku? LimitsGpuSku { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).LimitsGpuSku; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).LimitsGpuSku = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku)""); }

        /// <summary>Backing field for <see cref="LivenessProbe" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbe _livenessProbe;

        /// <summary>The liveness probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbe LivenessProbe { get => (this._livenessProbe = this._livenessProbe ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerProbe()); set => this._livenessProbe = value; }

        /// <summary>The commands to execute within the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string[] LivenessProbeExecCommand { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).ExecCommand; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).ExecCommand = value ?? null /* arrayOf */; }

        /// <summary>The failure threshold.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? LivenessProbeFailureThreshold { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).FailureThreshold; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).FailureThreshold = value ?? default(int); }

        /// <summary>The header name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string LivenessProbeHttpGetHttpHeadersName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).HttpHeaderName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).HttpHeaderName = value ?? null; }

        /// <summary>The header value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string LivenessProbeHttpGetHttpHeadersValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).HttpHeaderValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).HttpHeaderValue = value ?? null; }

        /// <summary>The path to probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string LivenessProbeHttpGetPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).HttpGetPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).HttpGetPath = value ?? null; }

        /// <summary>The port number to probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? LivenessProbeHttpGetPort { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).HttpGetPort; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).HttpGetPort = value ?? default(int); }

        /// <summary>The scheme.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme? LivenessProbeHttpGetScheme { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).HttpGetScheme; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).HttpGetScheme = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme)""); }

        /// <summary>The initial delay seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? LivenessProbeInitialDelaySecond { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).InitialDelaySecond; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).InitialDelaySecond = value ?? default(int); }

        /// <summary>The period seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? LivenessProbePeriodSecond { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).PeriodSecond; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).PeriodSecond = value ?? default(int); }

        /// <summary>The success threshold.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? LivenessProbeSuccessThreshold { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).SuccessThreshold; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).SuccessThreshold = value ?? default(int); }

        /// <summary>The timeout seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? LivenessProbeTimeoutSecond { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).TimeoutSecond; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).TimeoutSecond = value ?? default(int); }

        /// <summary>Internal Acessors for CurrentState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.CurrentState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).CurrentStateState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).CurrentStateState = value; }

        /// <summary>Internal Acessors for CurrentStateDetailStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.CurrentStateDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).CurrentStateDetailStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).CurrentStateDetailStatus = value; }

        /// <summary>Internal Acessors for CurrentStateExitCode</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.CurrentStateExitCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).CurrentStateExitCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).CurrentStateExitCode = value; }

        /// <summary>Internal Acessors for CurrentStateFinishTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.CurrentStateFinishTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).CurrentStateFinishTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).CurrentStateFinishTime = value; }

        /// <summary>Internal Acessors for CurrentStateStartTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.CurrentStateStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).CurrentStateStartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).CurrentStateStartTime = value; }

        /// <summary>Internal Acessors for InstanceView</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceView Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.InstanceView { get => (this._instanceView = this._instanceView ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerPropertiesInstanceView()); set { {_instanceView = value;} } }

        /// <summary>Internal Acessors for InstanceViewCurrentState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerState Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.InstanceViewCurrentState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).CurrentState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).CurrentState = value; }

        /// <summary>Internal Acessors for InstanceViewEvent</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.InstanceViewEvent { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).Event; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).Event = value; }

        /// <summary>Internal Acessors for InstanceViewPreviousState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerState Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.InstanceViewPreviousState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).PreviousState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).PreviousState = value; }

        /// <summary>Internal Acessors for InstanceViewRestartCount</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.InstanceViewRestartCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).RestartCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).RestartCount = value; }

        /// <summary>Internal Acessors for LimitGpu</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResource Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.LimitGpu { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).LimitGpu; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).LimitGpu = value; }

        /// <summary>Internal Acessors for LivenessProbe</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbe Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.LivenessProbe { get => (this._livenessProbe = this._livenessProbe ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerProbe()); set { {_livenessProbe = value;} } }

        /// <summary>Internal Acessors for LivenessProbeExec</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerExec Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.LivenessProbeExec { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).Exec; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).Exec = value; }

        /// <summary>Internal Acessors for LivenessProbeHttpGet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGet Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.LivenessProbeHttpGet { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).HttpGet; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).HttpGet = value; }

        /// <summary>Internal Acessors for LivenessProbeHttpGetHttpHeader</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IHttpHeaders Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.LivenessProbeHttpGetHttpHeader { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).HttpGetHttpHeader; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)LivenessProbe).HttpGetHttpHeader = value; }

        /// <summary>Internal Acessors for PreviouState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.PreviouState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).PreviouState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).PreviouState = value; }

        /// <summary>Internal Acessors for PreviouStateDetailStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.PreviouStateDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).PreviouStateDetailStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).PreviouStateDetailStatus = value; }

        /// <summary>Internal Acessors for PreviouStateExitCode</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.PreviouStateExitCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).PreviouStateExitCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).PreviouStateExitCode = value; }

        /// <summary>Internal Acessors for PreviouStateFinishTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.PreviouStateFinishTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).PreviouStateFinishTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).PreviouStateFinishTime = value; }

        /// <summary>Internal Acessors for PreviouStateStartTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.PreviouStateStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).PreviouStateStartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).PreviouStateStartTime = value; }

        /// <summary>Internal Acessors for ReadinessProbe</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbe Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.ReadinessProbe { get => (this._readinessProbe = this._readinessProbe ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerProbe()); set { {_readinessProbe = value;} } }

        /// <summary>Internal Acessors for ReadinessProbeExec</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerExec Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.ReadinessProbeExec { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).Exec; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).Exec = value; }

        /// <summary>Internal Acessors for ReadinessProbeHttpGet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGet Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.ReadinessProbeHttpGet { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).HttpGet; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).HttpGet = value; }

        /// <summary>Internal Acessors for ReadinessProbeHttpGetHttpHeader</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IHttpHeaders Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.ReadinessProbeHttpGetHttpHeader { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).HttpGetHttpHeader; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).HttpGetHttpHeader = value; }

        /// <summary>Internal Acessors for RequestGpu</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResource Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.RequestGpu { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).RequestGpu; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).RequestGpu = value; }

        /// <summary>Internal Acessors for Resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirements Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.Resource { get => (this._resource = this._resource ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ResourceRequirements()); set { {_resource = value;} } }

        /// <summary>Internal Acessors for ResourceLimit</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceLimits Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.ResourceLimit { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).Limit; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).Limit = value; }

        /// <summary>Internal Acessors for ResourceRequest</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequests Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInternal.ResourceRequest { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).Request; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).Request = value; }

        /// <summary>Backing field for <see cref="Port" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPort[] _port;

        /// <summary>The exposed ports on the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPort[] Port { get => this._port; set => this._port = value; }

        /// <summary>The state of the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string PreviouState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).PreviouState; }

        /// <summary>The human-readable status of the container instance state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string PreviouStateDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).PreviouStateDetailStatus; }

        /// <summary>
        /// The container instance exit codes correspond to those from the `docker run` command.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? PreviouStateExitCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).PreviouStateExitCode; }

        /// <summary>The date-time when the container instance state finished.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public global::System.DateTime? PreviouStateFinishTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).PreviouStateFinishTime; }

        /// <summary>The date-time when the container instance state started.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public global::System.DateTime? PreviouStateStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)InstanceView).PreviouStateStartTime; }

        /// <summary>Backing field for <see cref="ReadinessProbe" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbe _readinessProbe;

        /// <summary>The readiness probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbe ReadinessProbe { get => (this._readinessProbe = this._readinessProbe ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerProbe()); set => this._readinessProbe = value; }

        /// <summary>The commands to execute within the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string[] ReadinessProbeExecCommand { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).ExecCommand; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).ExecCommand = value ?? null /* arrayOf */; }

        /// <summary>The failure threshold.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? ReadinessProbeFailureThreshold { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).FailureThreshold; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).FailureThreshold = value ?? default(int); }

        /// <summary>The header name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string ReadinessProbeHttpGetHttpHeadersName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).HttpHeaderName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).HttpHeaderName = value ?? null; }

        /// <summary>The header value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string ReadinessProbeHttpGetHttpHeadersValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).HttpHeaderValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).HttpHeaderValue = value ?? null; }

        /// <summary>The path to probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string ReadinessProbeHttpGetPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).HttpGetPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).HttpGetPath = value ?? null; }

        /// <summary>The port number to probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? ReadinessProbeHttpGetPort { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).HttpGetPort; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).HttpGetPort = value ?? default(int); }

        /// <summary>The scheme.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme? ReadinessProbeHttpGetScheme { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).HttpGetScheme; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).HttpGetScheme = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme)""); }

        /// <summary>The initial delay seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? ReadinessProbeInitialDelaySecond { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).InitialDelaySecond; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).InitialDelaySecond = value ?? default(int); }

        /// <summary>The period seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? ReadinessProbePeriodSecond { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).PeriodSecond; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).PeriodSecond = value ?? default(int); }

        /// <summary>The success threshold.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? ReadinessProbeSuccessThreshold { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).SuccessThreshold; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).SuccessThreshold = value ?? default(int); }

        /// <summary>The timeout seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? ReadinessProbeTimeoutSecond { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).TimeoutSecond; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal)ReadinessProbe).TimeoutSecond = value ?? default(int); }

        /// <summary>The CPU request of this container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public double RequestCpu { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).RequestCpu; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).RequestCpu = value ; }

        /// <summary>The memory request in GB of this container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public double RequestMemoryInGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).RequestMemoryInGb; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).RequestMemoryInGb = value ; }

        /// <summary>The count of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? RequestsGpuCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).RequestsGpuCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).RequestsGpuCount = value ?? default(int); }

        /// <summary>The SKU of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku? RequestsGpuSku { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).RequestsGpuSku; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)Resource).RequestsGpuSku = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku)""); }

        /// <summary>Backing field for <see cref="Resource" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirements _resource;

        /// <summary>The resource requirements of the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirements Resource { get => (this._resource = this._resource ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ResourceRequirements()); set => this._resource = value; }

        /// <summary>Backing field for <see cref="VolumeMount" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolumeMount[] _volumeMount;

        /// <summary>The volume mounts available to the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolumeMount[] VolumeMount { get => this._volumeMount; set => this._volumeMount = value; }

        /// <summary>Creates an new <see cref="ContainerProperties" /> instance.</summary>
        public ContainerProperties()
        {

        }
    }
    /// The container instance properties.
    public partial interface IContainerProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The commands to execute within the container instance in exec form.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The commands to execute within the container instance in exec form.",
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
        /// <summary>The environment variables to set in the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The environment variables to set in the container instance.",
        SerializedName = @"environmentVariables",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEnvironmentVariable) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEnvironmentVariable[] EnvironmentVariable { get; set; }
        /// <summary>The name of the image used to create the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the image used to create the container instance.",
        SerializedName = @"image",
        PossibleTypes = new [] { typeof(string) })]
        string Image { get; set; }
        /// <summary>The events of the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The events of the container instance.",
        SerializedName = @"events",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] InstanceViewEvent { get;  }
        /// <summary>The number of times that the container instance has been restarted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The number of times that the container instance has been restarted.",
        SerializedName = @"restartCount",
        PossibleTypes = new [] { typeof(int) })]
        int? InstanceViewRestartCount { get;  }
        /// <summary>The CPU limit of this container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The CPU limit of this container instance.",
        SerializedName = @"cpu",
        PossibleTypes = new [] { typeof(double) })]
        double? LimitCpu { get; set; }
        /// <summary>The memory limit in GB of this container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The memory limit in GB of this container instance.",
        SerializedName = @"memoryInGB",
        PossibleTypes = new [] { typeof(double) })]
        double? LimitMemoryInGb { get; set; }
        /// <summary>The count of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The count of the GPU resource.",
        SerializedName = @"count",
        PossibleTypes = new [] { typeof(int) })]
        int? LimitsGpuCount { get; set; }
        /// <summary>The SKU of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The SKU of the GPU resource.",
        SerializedName = @"sku",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku? LimitsGpuSku { get; set; }
        /// <summary>The commands to execute within the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The commands to execute within the container.",
        SerializedName = @"command",
        PossibleTypes = new [] { typeof(string) })]
        string[] LivenessProbeExecCommand { get; set; }
        /// <summary>The failure threshold.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The failure threshold.",
        SerializedName = @"failureThreshold",
        PossibleTypes = new [] { typeof(int) })]
        int? LivenessProbeFailureThreshold { get; set; }
        /// <summary>The header name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The header name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string LivenessProbeHttpGetHttpHeadersName { get; set; }
        /// <summary>The header value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The header value.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string LivenessProbeHttpGetHttpHeadersValue { get; set; }
        /// <summary>The path to probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The path to probe.",
        SerializedName = @"path",
        PossibleTypes = new [] { typeof(string) })]
        string LivenessProbeHttpGetPath { get; set; }
        /// <summary>The port number to probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The port number to probe.",
        SerializedName = @"port",
        PossibleTypes = new [] { typeof(int) })]
        int? LivenessProbeHttpGetPort { get; set; }
        /// <summary>The scheme.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The scheme.",
        SerializedName = @"scheme",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme? LivenessProbeHttpGetScheme { get; set; }
        /// <summary>The initial delay seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The initial delay seconds.",
        SerializedName = @"initialDelaySeconds",
        PossibleTypes = new [] { typeof(int) })]
        int? LivenessProbeInitialDelaySecond { get; set; }
        /// <summary>The period seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The period seconds.",
        SerializedName = @"periodSeconds",
        PossibleTypes = new [] { typeof(int) })]
        int? LivenessProbePeriodSecond { get; set; }
        /// <summary>The success threshold.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The success threshold.",
        SerializedName = @"successThreshold",
        PossibleTypes = new [] { typeof(int) })]
        int? LivenessProbeSuccessThreshold { get; set; }
        /// <summary>The timeout seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The timeout seconds.",
        SerializedName = @"timeoutSeconds",
        PossibleTypes = new [] { typeof(int) })]
        int? LivenessProbeTimeoutSecond { get; set; }
        /// <summary>The exposed ports on the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The exposed ports on the container instance.",
        SerializedName = @"ports",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPort) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPort[] Port { get; set; }
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
        /// <summary>The commands to execute within the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The commands to execute within the container.",
        SerializedName = @"command",
        PossibleTypes = new [] { typeof(string) })]
        string[] ReadinessProbeExecCommand { get; set; }
        /// <summary>The failure threshold.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The failure threshold.",
        SerializedName = @"failureThreshold",
        PossibleTypes = new [] { typeof(int) })]
        int? ReadinessProbeFailureThreshold { get; set; }
        /// <summary>The header name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The header name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string ReadinessProbeHttpGetHttpHeadersName { get; set; }
        /// <summary>The header value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The header value.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string ReadinessProbeHttpGetHttpHeadersValue { get; set; }
        /// <summary>The path to probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The path to probe.",
        SerializedName = @"path",
        PossibleTypes = new [] { typeof(string) })]
        string ReadinessProbeHttpGetPath { get; set; }
        /// <summary>The port number to probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The port number to probe.",
        SerializedName = @"port",
        PossibleTypes = new [] { typeof(int) })]
        int? ReadinessProbeHttpGetPort { get; set; }
        /// <summary>The scheme.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The scheme.",
        SerializedName = @"scheme",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme? ReadinessProbeHttpGetScheme { get; set; }
        /// <summary>The initial delay seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The initial delay seconds.",
        SerializedName = @"initialDelaySeconds",
        PossibleTypes = new [] { typeof(int) })]
        int? ReadinessProbeInitialDelaySecond { get; set; }
        /// <summary>The period seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The period seconds.",
        SerializedName = @"periodSeconds",
        PossibleTypes = new [] { typeof(int) })]
        int? ReadinessProbePeriodSecond { get; set; }
        /// <summary>The success threshold.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The success threshold.",
        SerializedName = @"successThreshold",
        PossibleTypes = new [] { typeof(int) })]
        int? ReadinessProbeSuccessThreshold { get; set; }
        /// <summary>The timeout seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The timeout seconds.",
        SerializedName = @"timeoutSeconds",
        PossibleTypes = new [] { typeof(int) })]
        int? ReadinessProbeTimeoutSecond { get; set; }
        /// <summary>The CPU request of this container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The CPU request of this container instance.",
        SerializedName = @"cpu",
        PossibleTypes = new [] { typeof(double) })]
        double RequestCpu { get; set; }
        /// <summary>The memory request in GB of this container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The memory request in GB of this container instance.",
        SerializedName = @"memoryInGB",
        PossibleTypes = new [] { typeof(double) })]
        double RequestMemoryInGb { get; set; }
        /// <summary>The count of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The count of the GPU resource.",
        SerializedName = @"count",
        PossibleTypes = new [] { typeof(int) })]
        int? RequestsGpuCount { get; set; }
        /// <summary>The SKU of the GPU resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The SKU of the GPU resource.",
        SerializedName = @"sku",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku? RequestsGpuSku { get; set; }
        /// <summary>The volume mounts available to the container instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The volume mounts available to the container instance.",
        SerializedName = @"volumeMounts",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolumeMount) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolumeMount[] VolumeMount { get; set; }

    }
    /// The container instance properties.
    internal partial interface IContainerPropertiesInternal

    {
        /// <summary>The commands to execute within the container instance in exec form.</summary>
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
        /// <summary>The environment variables to set in the container instance.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEnvironmentVariable[] EnvironmentVariable { get; set; }
        /// <summary>The name of the image used to create the container instance.</summary>
        string Image { get; set; }
        /// <summary>The instance view of the container instance. Only valid in response.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceView InstanceView { get; set; }
        /// <summary>Current container instance state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerState InstanceViewCurrentState { get; set; }
        /// <summary>The events of the container instance.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] InstanceViewEvent { get; set; }
        /// <summary>Previous container instance state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerState InstanceViewPreviousState { get; set; }
        /// <summary>The number of times that the container instance has been restarted.</summary>
        int? InstanceViewRestartCount { get; set; }
        /// <summary>The CPU limit of this container instance.</summary>
        double? LimitCpu { get; set; }
        /// <summary>The GPU limit of this container instance.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResource LimitGpu { get; set; }
        /// <summary>The memory limit in GB of this container instance.</summary>
        double? LimitMemoryInGb { get; set; }
        /// <summary>The count of the GPU resource.</summary>
        int? LimitsGpuCount { get; set; }
        /// <summary>The SKU of the GPU resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku? LimitsGpuSku { get; set; }
        /// <summary>The liveness probe.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbe LivenessProbe { get; set; }
        /// <summary>The execution command to probe</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerExec LivenessProbeExec { get; set; }
        /// <summary>The commands to execute within the container.</summary>
        string[] LivenessProbeExecCommand { get; set; }
        /// <summary>The failure threshold.</summary>
        int? LivenessProbeFailureThreshold { get; set; }
        /// <summary>The Http Get settings to probe</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGet LivenessProbeHttpGet { get; set; }
        /// <summary>The HTTP headers.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IHttpHeaders LivenessProbeHttpGetHttpHeader { get; set; }
        /// <summary>The header name.</summary>
        string LivenessProbeHttpGetHttpHeadersName { get; set; }
        /// <summary>The header value.</summary>
        string LivenessProbeHttpGetHttpHeadersValue { get; set; }
        /// <summary>The path to probe.</summary>
        string LivenessProbeHttpGetPath { get; set; }
        /// <summary>The port number to probe.</summary>
        int? LivenessProbeHttpGetPort { get; set; }
        /// <summary>The scheme.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme? LivenessProbeHttpGetScheme { get; set; }
        /// <summary>The initial delay seconds.</summary>
        int? LivenessProbeInitialDelaySecond { get; set; }
        /// <summary>The period seconds.</summary>
        int? LivenessProbePeriodSecond { get; set; }
        /// <summary>The success threshold.</summary>
        int? LivenessProbeSuccessThreshold { get; set; }
        /// <summary>The timeout seconds.</summary>
        int? LivenessProbeTimeoutSecond { get; set; }
        /// <summary>The exposed ports on the container instance.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPort[] Port { get; set; }
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
        /// <summary>The readiness probe.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbe ReadinessProbe { get; set; }
        /// <summary>The execution command to probe</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerExec ReadinessProbeExec { get; set; }
        /// <summary>The commands to execute within the container.</summary>
        string[] ReadinessProbeExecCommand { get; set; }
        /// <summary>The failure threshold.</summary>
        int? ReadinessProbeFailureThreshold { get; set; }
        /// <summary>The Http Get settings to probe</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGet ReadinessProbeHttpGet { get; set; }
        /// <summary>The HTTP headers.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IHttpHeaders ReadinessProbeHttpGetHttpHeader { get; set; }
        /// <summary>The header name.</summary>
        string ReadinessProbeHttpGetHttpHeadersName { get; set; }
        /// <summary>The header value.</summary>
        string ReadinessProbeHttpGetHttpHeadersValue { get; set; }
        /// <summary>The path to probe.</summary>
        string ReadinessProbeHttpGetPath { get; set; }
        /// <summary>The port number to probe.</summary>
        int? ReadinessProbeHttpGetPort { get; set; }
        /// <summary>The scheme.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme? ReadinessProbeHttpGetScheme { get; set; }
        /// <summary>The initial delay seconds.</summary>
        int? ReadinessProbeInitialDelaySecond { get; set; }
        /// <summary>The period seconds.</summary>
        int? ReadinessProbePeriodSecond { get; set; }
        /// <summary>The success threshold.</summary>
        int? ReadinessProbeSuccessThreshold { get; set; }
        /// <summary>The timeout seconds.</summary>
        int? ReadinessProbeTimeoutSecond { get; set; }
        /// <summary>The CPU request of this container instance.</summary>
        double RequestCpu { get; set; }
        /// <summary>The GPU request of this container instance.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResource RequestGpu { get; set; }
        /// <summary>The memory request in GB of this container instance.</summary>
        double RequestMemoryInGb { get; set; }
        /// <summary>The count of the GPU resource.</summary>
        int? RequestsGpuCount { get; set; }
        /// <summary>The SKU of the GPU resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku? RequestsGpuSku { get; set; }
        /// <summary>The resource requirements of the container instance.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirements Resource { get; set; }
        /// <summary>The resource limits of this container instance.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceLimits ResourceLimit { get; set; }
        /// <summary>The resource requests of this container instance.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequests ResourceRequest { get; set; }
        /// <summary>The volume mounts available to the container instance.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolumeMount[] VolumeMount { get; set; }

    }
}