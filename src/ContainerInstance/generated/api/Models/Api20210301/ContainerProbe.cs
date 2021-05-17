namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The container probe, for liveness or readiness</summary>
    public partial class ContainerProbe :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbe,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal
    {

        /// <summary>Backing field for <see cref="Exec" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerExec _exec;

        /// <summary>The execution command to probe</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerExec Exec { get => (this._exec = this._exec ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerExec()); set => this._exec = value; }

        /// <summary>The commands to execute within the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string[] ExecCommand { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerExecInternal)Exec).Command; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerExecInternal)Exec).Command = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="FailureThreshold" /> property.</summary>
        private int? _failureThreshold;

        /// <summary>The failure threshold.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public int? FailureThreshold { get => this._failureThreshold; set => this._failureThreshold = value; }

        /// <summary>Backing field for <see cref="HttpGet" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGet _httpGet;

        /// <summary>The Http Get settings to probe</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGet HttpGet { get => (this._httpGet = this._httpGet ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerHttpGet()); set => this._httpGet = value; }

        /// <summary>The path to probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string HttpGetPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGetInternal)HttpGet).Path; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGetInternal)HttpGet).Path = value ?? null; }

        /// <summary>The port number to probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public int? HttpGetPort { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGetInternal)HttpGet).Port; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGetInternal)HttpGet).Port = value ?? default(int); }

        /// <summary>The scheme.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme? HttpGetScheme { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGetInternal)HttpGet).Scheme; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGetInternal)HttpGet).Scheme = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme)""); }

        /// <summary>The header name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string HttpHeaderName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGetInternal)HttpGet).HttpHeaderName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGetInternal)HttpGet).HttpHeaderName = value ?? null; }

        /// <summary>The header value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string HttpHeaderValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGetInternal)HttpGet).HttpHeaderValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGetInternal)HttpGet).HttpHeaderValue = value ?? null; }

        /// <summary>Backing field for <see cref="InitialDelaySecond" /> property.</summary>
        private int? _initialDelaySecond;

        /// <summary>The initial delay seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public int? InitialDelaySecond { get => this._initialDelaySecond; set => this._initialDelaySecond = value; }

        /// <summary>Internal Acessors for Exec</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerExec Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal.Exec { get => (this._exec = this._exec ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerExec()); set { {_exec = value;} } }

        /// <summary>Internal Acessors for HttpGet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGet Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal.HttpGet { get => (this._httpGet = this._httpGet ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerHttpGet()); set { {_httpGet = value;} } }

        /// <summary>Internal Acessors for HttpGetHttpHeader</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IHttpHeaders Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerProbeInternal.HttpGetHttpHeader { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGetInternal)HttpGet).HttpHeader; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGetInternal)HttpGet).HttpHeader = value; }

        /// <summary>Backing field for <see cref="PeriodSecond" /> property.</summary>
        private int? _periodSecond;

        /// <summary>The period seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public int? PeriodSecond { get => this._periodSecond; set => this._periodSecond = value; }

        /// <summary>Backing field for <see cref="SuccessThreshold" /> property.</summary>
        private int? _successThreshold;

        /// <summary>The success threshold.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public int? SuccessThreshold { get => this._successThreshold; set => this._successThreshold = value; }

        /// <summary>Backing field for <see cref="TimeoutSecond" /> property.</summary>
        private int? _timeoutSecond;

        /// <summary>The timeout seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public int? TimeoutSecond { get => this._timeoutSecond; set => this._timeoutSecond = value; }

        /// <summary>Creates an new <see cref="ContainerProbe" /> instance.</summary>
        public ContainerProbe()
        {

        }
    }
    /// The container probe, for liveness or readiness
    public partial interface IContainerProbe :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The commands to execute within the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The commands to execute within the container.",
        SerializedName = @"command",
        PossibleTypes = new [] { typeof(string) })]
        string[] ExecCommand { get; set; }
        /// <summary>The failure threshold.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The failure threshold.",
        SerializedName = @"failureThreshold",
        PossibleTypes = new [] { typeof(int) })]
        int? FailureThreshold { get; set; }
        /// <summary>The path to probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The path to probe.",
        SerializedName = @"path",
        PossibleTypes = new [] { typeof(string) })]
        string HttpGetPath { get; set; }
        /// <summary>The port number to probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The port number to probe.",
        SerializedName = @"port",
        PossibleTypes = new [] { typeof(int) })]
        int? HttpGetPort { get; set; }
        /// <summary>The scheme.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The scheme.",
        SerializedName = @"scheme",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme? HttpGetScheme { get; set; }
        /// <summary>The header name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The header name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string HttpHeaderName { get; set; }
        /// <summary>The header value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The header value.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string HttpHeaderValue { get; set; }
        /// <summary>The initial delay seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The initial delay seconds.",
        SerializedName = @"initialDelaySeconds",
        PossibleTypes = new [] { typeof(int) })]
        int? InitialDelaySecond { get; set; }
        /// <summary>The period seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The period seconds.",
        SerializedName = @"periodSeconds",
        PossibleTypes = new [] { typeof(int) })]
        int? PeriodSecond { get; set; }
        /// <summary>The success threshold.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The success threshold.",
        SerializedName = @"successThreshold",
        PossibleTypes = new [] { typeof(int) })]
        int? SuccessThreshold { get; set; }
        /// <summary>The timeout seconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The timeout seconds.",
        SerializedName = @"timeoutSeconds",
        PossibleTypes = new [] { typeof(int) })]
        int? TimeoutSecond { get; set; }

    }
    /// The container probe, for liveness or readiness
    internal partial interface IContainerProbeInternal

    {
        /// <summary>The execution command to probe</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerExec Exec { get; set; }
        /// <summary>The commands to execute within the container.</summary>
        string[] ExecCommand { get; set; }
        /// <summary>The failure threshold.</summary>
        int? FailureThreshold { get; set; }
        /// <summary>The Http Get settings to probe</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGet HttpGet { get; set; }
        /// <summary>The HTTP headers.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IHttpHeaders HttpGetHttpHeader { get; set; }
        /// <summary>The path to probe.</summary>
        string HttpGetPath { get; set; }
        /// <summary>The port number to probe.</summary>
        int? HttpGetPort { get; set; }
        /// <summary>The scheme.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme? HttpGetScheme { get; set; }
        /// <summary>The header name.</summary>
        string HttpHeaderName { get; set; }
        /// <summary>The header value.</summary>
        string HttpHeaderValue { get; set; }
        /// <summary>The initial delay seconds.</summary>
        int? InitialDelaySecond { get; set; }
        /// <summary>The period seconds.</summary>
        int? PeriodSecond { get; set; }
        /// <summary>The success threshold.</summary>
        int? SuccessThreshold { get; set; }
        /// <summary>The timeout seconds.</summary>
        int? TimeoutSecond { get; set; }

    }
}