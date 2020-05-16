namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Http logs configuration.</summary>
    public partial class HttpLogsConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfig,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfigInternal
    {

        /// <summary>Backing field for <see cref="AzureBlobStorage" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageHttpLogsConfig _azureBlobStorage;

        /// <summary>Http logs to azure blob storage configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageHttpLogsConfig AzureBlobStorage { get => (this._azureBlobStorage = this._azureBlobStorage ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AzureBlobStorageHttpLogsConfig()); set => this._azureBlobStorage = value; }

        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? AzureBlobStorageEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageHttpLogsConfigInternal)AzureBlobStorage).Enabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageHttpLogsConfigInternal)AzureBlobStorage).Enabled = value; }

        /// <summary>
        /// Retention in days.
        /// Remove blobs older than X days.
        /// 0 or lower means no retention.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? AzureBlobStorageRetentionInDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageHttpLogsConfigInternal)AzureBlobStorage).RetentionInDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageHttpLogsConfigInternal)AzureBlobStorage).RetentionInDay = value; }

        /// <summary>SAS url to a azure blob container with read/write/list/delete permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string AzureBlobStorageSasUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageHttpLogsConfigInternal)AzureBlobStorage).SasUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageHttpLogsConfigInternal)AzureBlobStorage).SasUrl = value; }

        /// <summary>Backing field for <see cref="FileSystem" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemHttpLogsConfig _fileSystem;

        /// <summary>Http logs to file system configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemHttpLogsConfig FileSystem { get => (this._fileSystem = this._fileSystem ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.FileSystemHttpLogsConfig()); set => this._fileSystem = value; }

        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? FileSystemEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemHttpLogsConfigInternal)FileSystem).Enabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemHttpLogsConfigInternal)FileSystem).Enabled = value; }

        /// <summary>
        /// Retention in days.
        /// Remove files older than X days.
        /// 0 or lower means no retention.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? FileSystemRetentionInDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemHttpLogsConfigInternal)FileSystem).RetentionInDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemHttpLogsConfigInternal)FileSystem).RetentionInDay = value; }

        /// <summary>
        /// Maximum size in megabytes that http log files can use.
        /// When reached old log files will be removed to make space for new ones.
        /// Value can range between 25 and 100.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? FileSystemRetentionInMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemHttpLogsConfigInternal)FileSystem).RetentionInMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemHttpLogsConfigInternal)FileSystem).RetentionInMb = value; }

        /// <summary>Internal Acessors for AzureBlobStorage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageHttpLogsConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfigInternal.AzureBlobStorage { get => (this._azureBlobStorage = this._azureBlobStorage ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AzureBlobStorageHttpLogsConfig()); set { {_azureBlobStorage = value;} } }

        /// <summary>Internal Acessors for FileSystem</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemHttpLogsConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfigInternal.FileSystem { get => (this._fileSystem = this._fileSystem ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.FileSystemHttpLogsConfig()); set { {_fileSystem = value;} } }

        /// <summary>Creates an new <see cref="HttpLogsConfig" /> instance.</summary>
        public HttpLogsConfig()
        {

        }
    }
    /// Http logs configuration.
    public partial interface IHttpLogsConfig :
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
        bool? AzureBlobStorageEnabled { get; set; }
        /// <summary>
        /// Retention in days.
        /// Remove blobs older than X days.
        /// 0 or lower means no retention.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Retention in days.
        Remove blobs older than X days.
        0 or lower means no retention.",
        SerializedName = @"retentionInDays",
        PossibleTypes = new [] { typeof(int) })]
        int? AzureBlobStorageRetentionInDay { get; set; }
        /// <summary>SAS url to a azure blob container with read/write/list/delete permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SAS url to a azure blob container with read/write/list/delete permissions.",
        SerializedName = @"sasUrl",
        PossibleTypes = new [] { typeof(string) })]
        string AzureBlobStorageSasUrl { get; set; }
        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"True if configuration is enabled, false if it is disabled and null if configuration is not set.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? FileSystemEnabled { get; set; }
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
        int? FileSystemRetentionInDay { get; set; }
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
        int? FileSystemRetentionInMb { get; set; }

    }
    /// Http logs configuration.
    internal partial interface IHttpLogsConfigInternal

    {
        /// <summary>Http logs to azure blob storage configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageHttpLogsConfig AzureBlobStorage { get; set; }
        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        bool? AzureBlobStorageEnabled { get; set; }
        /// <summary>
        /// Retention in days.
        /// Remove blobs older than X days.
        /// 0 or lower means no retention.
        /// </summary>
        int? AzureBlobStorageRetentionInDay { get; set; }
        /// <summary>SAS url to a azure blob container with read/write/list/delete permissions.</summary>
        string AzureBlobStorageSasUrl { get; set; }
        /// <summary>Http logs to file system configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemHttpLogsConfig FileSystem { get; set; }
        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        bool? FileSystemEnabled { get; set; }
        /// <summary>
        /// Retention in days.
        /// Remove files older than X days.
        /// 0 or lower means no retention.
        /// </summary>
        int? FileSystemRetentionInDay { get; set; }
        /// <summary>
        /// Maximum size in megabytes that http log files can use.
        /// When reached old log files will be removed to make space for new ones.
        /// Value can range between 25 and 100.
        /// </summary>
        int? FileSystemRetentionInMb { get; set; }

    }
}