namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Application logs to file system configuration.</summary>
    public partial class FileSystemApplicationLogsConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemApplicationLogsConfig,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemApplicationLogsConfigInternal
    {

        /// <summary>Backing field for <see cref="Level" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? _level;

        /// <summary>Log level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? Level { get => this._level; set => this._level = value; }

        /// <summary>Creates an new <see cref="FileSystemApplicationLogsConfig" /> instance.</summary>
        public FileSystemApplicationLogsConfig()
        {

        }
    }
    /// Application logs to file system configuration.
    public partial interface IFileSystemApplicationLogsConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Log level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Log level.",
        SerializedName = @"level",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? Level { get; set; }

    }
    /// Application logs to file system configuration.
    internal partial interface IFileSystemApplicationLogsConfigInternal

    {
        /// <summary>Log level.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? Level { get; set; }

    }
}