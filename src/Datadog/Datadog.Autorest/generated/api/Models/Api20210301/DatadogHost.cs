namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Extensions;

    public partial class DatadogHost :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHost,
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal
    {

        /// <summary>Backing field for <see cref="Alias" /> property.</summary>
        private string[] _alias;

        /// <summary>The aliases for the host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string[] Alias { get => this._alias; set => this._alias = value; }

        /// <summary>Backing field for <see cref="App" /> property.</summary>
        private string[] _app;

        /// <summary>The Datadog integrations reporting metrics for the host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string[] App { get => this._app; set => this._app = value; }

        /// <summary>The installer version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string InstallMethodInstallerVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadataInternal)Meta).InstallMethodInstallerVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadataInternal)Meta).InstallMethodInstallerVersion = value ?? null; }

        /// <summary>The tool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string InstallMethodTool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadataInternal)Meta).InstallMethodTool; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadataInternal)Meta).InstallMethodTool = value ?? null; }

        /// <summary>The tool version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string InstallMethodToolVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadataInternal)Meta).InstallMethodToolVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadataInternal)Meta).InstallMethodToolVersion = value ?? null; }

        /// <summary>The transport.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string LogAgentTransport { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadataInternal)Meta).LogAgentTransport; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadataInternal)Meta).LogAgentTransport = value ?? null; }

        /// <summary>Backing field for <see cref="Meta" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadata _meta;

        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadata Meta { get => (this._meta = this._meta ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogHostMetadata()); set => this._meta = value; }

        /// <summary>The agent version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string MetaAgentVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadataInternal)Meta).AgentVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadataInternal)Meta).AgentVersion = value ?? null; }

        /// <summary>Internal Acessors for Meta</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadata Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal.Meta { get => (this._meta = this._meta ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogHostMetadata()); set { {_meta = value;} } }

        /// <summary>Internal Acessors for MetaInstallMethod</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogInstallMethod Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal.MetaInstallMethod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadataInternal)Meta).InstallMethod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadataInternal)Meta).InstallMethod = value; }

        /// <summary>Internal Acessors for MetaLogsAgent</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogLogsAgent Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostInternal.MetaLogsAgent { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadataInternal)Meta).LogsAgent; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadataInternal)Meta).LogsAgent = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="DatadogHost" /> instance.</summary>
        public DatadogHost()
        {

        }
    }
    public partial interface IDatadogHost :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.IJsonSerializable
    {
        /// <summary>The aliases for the host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The aliases for the host.",
        SerializedName = @"aliases",
        PossibleTypes = new [] { typeof(string) })]
        string[] Alias { get; set; }
        /// <summary>The Datadog integrations reporting metrics for the host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Datadog integrations reporting metrics for the host.",
        SerializedName = @"apps",
        PossibleTypes = new [] { typeof(string) })]
        string[] App { get; set; }
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
        /// <summary>The agent version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The agent version.",
        SerializedName = @"agentVersion",
        PossibleTypes = new [] { typeof(string) })]
        string MetaAgentVersion { get; set; }
        /// <summary>The name of the host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the host.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    internal partial interface IDatadogHostInternal

    {
        /// <summary>The aliases for the host.</summary>
        string[] Alias { get; set; }
        /// <summary>The Datadog integrations reporting metrics for the host.</summary>
        string[] App { get; set; }
        /// <summary>The installer version.</summary>
        string InstallMethodInstallerVersion { get; set; }
        /// <summary>The tool.</summary>
        string InstallMethodTool { get; set; }
        /// <summary>The tool version.</summary>
        string InstallMethodToolVersion { get; set; }
        /// <summary>The transport.</summary>
        string LogAgentTransport { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogHostMetadata Meta { get; set; }
        /// <summary>The agent version.</summary>
        string MetaAgentVersion { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogInstallMethod MetaInstallMethod { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogLogsAgent MetaLogsAgent { get; set; }
        /// <summary>The name of the host.</summary>
        string Name { get; set; }

    }
}