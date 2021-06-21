namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Extensions;

    public partial class DatadogHostMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadata,
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadataInternal
    {

        /// <summary>Backing field for <see cref="AgentVersion" /> property.</summary>
        private string _agentVersion;

        /// <summary>The agent version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string AgentVersion { get => this._agentVersion; set => this._agentVersion = value; }

        /// <summary>Backing field for <see cref="InstallMethod" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogInstallMethod _installMethod;

        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogInstallMethod InstallMethod { get => (this._installMethod = this._installMethod ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogInstallMethod()); set => this._installMethod = value; }

        /// <summary>The installer version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string InstallMethodInstallerVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogInstallMethodInternal)InstallMethod).InstallerVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogInstallMethodInternal)InstallMethod).InstallerVersion = value ?? null; }

        /// <summary>The tool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string InstallMethodTool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogInstallMethodInternal)InstallMethod).Tool; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogInstallMethodInternal)InstallMethod).Tool = value ?? null; }

        /// <summary>The tool version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string InstallMethodToolVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogInstallMethodInternal)InstallMethod).ToolVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogInstallMethodInternal)InstallMethod).ToolVersion = value ?? null; }

        /// <summary>The transport.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string LogAgentTransport { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogLogsAgentInternal)LogsAgent).Transport; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogLogsAgentInternal)LogsAgent).Transport = value ?? null; }

        /// <summary>Backing field for <see cref="LogsAgent" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogLogsAgent _logsAgent;

        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogLogsAgent LogsAgent { get => (this._logsAgent = this._logsAgent ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogLogsAgent()); set => this._logsAgent = value; }

        /// <summary>Internal Acessors for InstallMethod</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogInstallMethod Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadataInternal.InstallMethod { get => (this._installMethod = this._installMethod ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogInstallMethod()); set { {_installMethod = value;} } }

        /// <summary>Internal Acessors for LogsAgent</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogLogsAgent Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadataInternal.LogsAgent { get => (this._logsAgent = this._logsAgent ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogLogsAgent()); set { {_logsAgent = value;} } }

        /// <summary>Creates an new <see cref="DatadogHostMetadata" /> instance.</summary>
        public DatadogHostMetadata()
        {

        }
    }
    public partial interface IDatadogHostMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.IJsonSerializable
    {
        /// <summary>The agent version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The agent version.",
        SerializedName = @"agentVersion",
        PossibleTypes = new [] { typeof(string) })]
        string AgentVersion { get; set; }
        /// <summary>The installer version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The installer version.",
        SerializedName = @"installerVersion",
        PossibleTypes = new [] { typeof(string) })]
        string InstallMethodInstallerVersion { get; set; }
        /// <summary>The tool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The tool.",
        SerializedName = @"tool",
        PossibleTypes = new [] { typeof(string) })]
        string InstallMethodTool { get; set; }
        /// <summary>The tool version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The tool version.",
        SerializedName = @"toolVersion",
        PossibleTypes = new [] { typeof(string) })]
        string InstallMethodToolVersion { get; set; }
        /// <summary>The transport.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The transport.",
        SerializedName = @"transport",
        PossibleTypes = new [] { typeof(string) })]
        string LogAgentTransport { get; set; }

    }
    internal partial interface IDatadogHostMetadataInternal

    {
        /// <summary>The agent version.</summary>
        string AgentVersion { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogInstallMethod InstallMethod { get; set; }
        /// <summary>The installer version.</summary>
        string InstallMethodInstallerVersion { get; set; }
        /// <summary>The tool.</summary>
        string InstallMethodTool { get; set; }
        /// <summary>The tool version.</summary>
        string InstallMethodToolVersion { get; set; }
        /// <summary>The transport.</summary>
        string LogAgentTransport { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogLogsAgent LogsAgent { get; set; }

    }
}