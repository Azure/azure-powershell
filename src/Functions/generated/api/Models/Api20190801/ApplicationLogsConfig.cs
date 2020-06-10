namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Application logs configuration.</summary>
    public partial class ApplicationLogsConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfig,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal
    {

        /// <summary>Backing field for <see cref="AzureBlobStorage" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageApplicationLogsConfig _azureBlobStorage;

        /// <summary>Application logs to blob storage configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageApplicationLogsConfig AzureBlobStorage { get => (this._azureBlobStorage = this._azureBlobStorage ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AzureBlobStorageApplicationLogsConfig()); set => this._azureBlobStorage = value; }

        /// <summary>Log level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? AzureBlobStorageLevel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageApplicationLogsConfigInternal)AzureBlobStorage).Level; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageApplicationLogsConfigInternal)AzureBlobStorage).Level = value; }

        /// <summary>
        /// Retention in days.
        /// Remove blobs older than X days.
        /// 0 or lower means no retention.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? AzureBlobStorageRetentionInDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageApplicationLogsConfigInternal)AzureBlobStorage).RetentionInDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageApplicationLogsConfigInternal)AzureBlobStorage).RetentionInDay = value; }

        /// <summary>SAS url to a azure blob container with read/write/list/delete permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string AzureBlobStorageSasUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageApplicationLogsConfigInternal)AzureBlobStorage).SasUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageApplicationLogsConfigInternal)AzureBlobStorage).SasUrl = value; }

        /// <summary>Backing field for <see cref="AzureTableStorage" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureTableStorageApplicationLogsConfig _azureTableStorage;

        /// <summary>Application logs to azure table storage configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureTableStorageApplicationLogsConfig AzureTableStorage { get => (this._azureTableStorage = this._azureTableStorage ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AzureTableStorageApplicationLogsConfig()); set => this._azureTableStorage = value; }

        /// <summary>Log level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? AzureTableStorageLevel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureTableStorageApplicationLogsConfigInternal)AzureTableStorage).Level; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureTableStorageApplicationLogsConfigInternal)AzureTableStorage).Level = value; }

        /// <summary>SAS URL to an Azure table with add/query/delete permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string AzureTableStorageSasUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureTableStorageApplicationLogsConfigInternal)AzureTableStorage).SasUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureTableStorageApplicationLogsConfigInternal)AzureTableStorage).SasUrl = value; }

        /// <summary>Backing field for <see cref="FileSystem" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemApplicationLogsConfig _fileSystem;

        /// <summary>Application logs to file system configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemApplicationLogsConfig FileSystem { get => (this._fileSystem = this._fileSystem ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.FileSystemApplicationLogsConfig()); set => this._fileSystem = value; }

        /// <summary>Log level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? FileSystemLevel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemApplicationLogsConfigInternal)FileSystem).Level; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemApplicationLogsConfigInternal)FileSystem).Level = value; }

        /// <summary>Internal Acessors for AzureBlobStorage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageApplicationLogsConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal.AzureBlobStorage { get => (this._azureBlobStorage = this._azureBlobStorage ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AzureBlobStorageApplicationLogsConfig()); set { {_azureBlobStorage = value;} } }

        /// <summary>Internal Acessors for AzureTableStorage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureTableStorageApplicationLogsConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal.AzureTableStorage { get => (this._azureTableStorage = this._azureTableStorage ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AzureTableStorageApplicationLogsConfig()); set { {_azureTableStorage = value;} } }

        /// <summary>Internal Acessors for FileSystem</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemApplicationLogsConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal.FileSystem { get => (this._fileSystem = this._fileSystem ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.FileSystemApplicationLogsConfig()); set { {_fileSystem = value;} } }

        /// <summary>Creates an new <see cref="ApplicationLogsConfig" /> instance.</summary>
        public ApplicationLogsConfig()
        {

        }
    }
    /// Application logs configuration.
    public partial interface IApplicationLogsConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Log level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Log level.",
        SerializedName = @"level",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? AzureBlobStorageLevel { get; set; }
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
        /// <summary>Log level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Log level.",
        SerializedName = @"level",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? AzureTableStorageLevel { get; set; }
        /// <summary>SAS URL to an Azure table with add/query/delete permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"SAS URL to an Azure table with add/query/delete permissions.",
        SerializedName = @"sasUrl",
        PossibleTypes = new [] { typeof(string) })]
        string AzureTableStorageSasUrl { get; set; }
        /// <summary>Log level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Log level.",
        SerializedName = @"level",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? FileSystemLevel { get; set; }

    }
    /// Application logs configuration.
    internal partial interface IApplicationLogsConfigInternal

    {
        /// <summary>Application logs to blob storage configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageApplicationLogsConfig AzureBlobStorage { get; set; }
        /// <summary>Log level.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? AzureBlobStorageLevel { get; set; }
        /// <summary>
        /// Retention in days.
        /// Remove blobs older than X days.
        /// 0 or lower means no retention.
        /// </summary>
        int? AzureBlobStorageRetentionInDay { get; set; }
        /// <summary>SAS url to a azure blob container with read/write/list/delete permissions.</summary>
        string AzureBlobStorageSasUrl { get; set; }
        /// <summary>Application logs to azure table storage configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureTableStorageApplicationLogsConfig AzureTableStorage { get; set; }
        /// <summary>Log level.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? AzureTableStorageLevel { get; set; }
        /// <summary>SAS URL to an Azure table with add/query/delete permissions.</summary>
        string AzureTableStorageSasUrl { get; set; }
        /// <summary>Application logs to file system configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemApplicationLogsConfig FileSystem { get; set; }
        /// <summary>Log level.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? FileSystemLevel { get; set; }

    }
}