namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Extensions;

    public partial class DatadogInstallMethod :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogInstallMethod,
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogInstallMethodInternal
    {

        /// <summary>Backing field for <see cref="InstallerVersion" /> property.</summary>
        private string _installerVersion;

        /// <summary>The installer version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string InstallerVersion { get => this._installerVersion; set => this._installerVersion = value; }

        /// <summary>Backing field for <see cref="Tool" /> property.</summary>
        private string _tool;

        /// <summary>The tool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string Tool { get => this._tool; set => this._tool = value; }

        /// <summary>Backing field for <see cref="ToolVersion" /> property.</summary>
        private string _toolVersion;

        /// <summary>The tool version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string ToolVersion { get => this._toolVersion; set => this._toolVersion = value; }

        /// <summary>Creates an new <see cref="DatadogInstallMethod" /> instance.</summary>
        public DatadogInstallMethod()
        {

        }
    }
    public partial interface IDatadogInstallMethod :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.IJsonSerializable
    {
        /// <summary>The installer version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The installer version.",
        SerializedName = @"installerVersion",
        PossibleTypes = new [] { typeof(string) })]
        string InstallerVersion { get; set; }
        /// <summary>The tool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The tool.",
        SerializedName = @"tool",
        PossibleTypes = new [] { typeof(string) })]
        string Tool { get; set; }
        /// <summary>The tool version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The tool version.",
        SerializedName = @"toolVersion",
        PossibleTypes = new [] { typeof(string) })]
        string ToolVersion { get; set; }

    }
    internal partial interface IDatadogInstallMethodInternal

    {
        /// <summary>The installer version.</summary>
        string InstallerVersion { get; set; }
        /// <summary>The tool.</summary>
        string Tool { get; set; }
        /// <summary>The tool version.</summary>
        string ToolVersion { get; set; }

    }
}