namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Http logs to file system configuration.</summary>
    public partial class FileSystemHttpLogsConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemHttpLogsConfig,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemHttpLogsConfigInternal
    {

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private bool? _enabled;

        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Enabled { get => this._enabled; set => this._enabled = value; }

        /// <summary>Backing field for <see cref="RetentionInDay" /> property.</summary>
        private int? _retentionInDay;

        /// <summary>
        /// Retention in days.
        /// Remove files older than X days.
        /// 0 or lower means no retention.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? RetentionInDay { get => this._retentionInDay; set => this._retentionInDay = value; }

        /// <summary>Backing field for <see cref="RetentionInMb" /> property.</summary>
        private int? _retentionInMb;

        /// <summary>
        /// Maximum size in megabytes that http log files can use.
        /// When reached old log files will be removed to make space for new ones.
        /// Value can range between 25 and 100.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? RetentionInMb { get => this._retentionInMb; set => this._retentionInMb = value; }

        /// <summary>Creates an new <see cref="FileSystemHttpLogsConfig" /> instance.</summary>
        public FileSystemHttpLogsConfig()
        {

        }
    }
    /// Http logs to file system configuration.
    public partial interface IFileSystemHttpLogsConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"True if configuration is enabled, false if it is disabled and null if configuration is not set.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Enabled { get; set; }
        /// <summary>
        /// Retention in days.
        /// Remove files older than X days.
        /// 0 or lower means no retention.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Retention in days.
        Remove files older than X days.
        0 or lower means no retention.",
        SerializedName = @"retentionInDays",
        PossibleTypes = new [] { typeof(int) })]
        int? RetentionInDay { get; set; }
        /// <summary>
        /// Maximum size in megabytes that http log files can use.
        /// When reached old log files will be removed to make space for new ones.
        /// Value can range between 25 and 100.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum size in megabytes that http log files can use.
        When reached old log files will be removed to make space for new ones.
        Value can range between 25 and 100.",
        SerializedName = @"retentionInMb",
        PossibleTypes = new [] { typeof(int) })]
        int? RetentionInMb { get; set; }

    }
    /// Http logs to file system configuration.
    internal partial interface IFileSystemHttpLogsConfigInternal

    {
        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        bool? Enabled { get; set; }
        /// <summary>
        /// Retention in days.
        /// Remove files older than X days.
        /// 0 or lower means no retention.
        /// </summary>
        int? RetentionInDay { get; set; }
        /// <summary>
        /// Maximum size in megabytes that http log files can use.
        /// When reached old log files will be removed to make space for new ones.
        /// Value can range between 25 and 100.
        /// </summary>
        int? RetentionInMb { get; set; }

    }
}