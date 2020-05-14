namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>SiteLogsConfig resource specific properties</summary>
    public partial class SiteLogsConfigProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ApplicationLog" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfig _applicationLog;

        /// <summary>Application logs configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfig ApplicationLog { get => (this._applicationLog = this._applicationLog ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ApplicationLogsConfig()); set => this._applicationLog = value; }

        /// <summary>
        /// Retention in days.
        /// Remove blobs older than X days.
        /// 0 or lower means no retention.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? ApplicationLogsAzureBlobStorageRetentionInDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)ApplicationLog).AzureBlobStorageRetentionInDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)ApplicationLog).AzureBlobStorageRetentionInDay = value; }

        /// <summary>SAS url to a azure blob container with read/write/list/delete permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ApplicationLogsAzureBlobStorageSasUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)ApplicationLog).AzureBlobStorageSasUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)ApplicationLog).AzureBlobStorageSasUrl = value; }

        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? AzureBlobStorageEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfigInternal)HttpLog).AzureBlobStorageEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfigInternal)HttpLog).AzureBlobStorageEnabled = value; }

        /// <summary>Log level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? AzureBlobStorageLevel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)ApplicationLog).AzureBlobStorageLevel; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)ApplicationLog).AzureBlobStorageLevel = value; }

        /// <summary>Log level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? AzureTableStorageLevel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)ApplicationLog).AzureTableStorageLevel; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)ApplicationLog).AzureTableStorageLevel = value; }

        /// <summary>SAS URL to an Azure table with add/query/delete permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string AzureTableStorageSasUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)ApplicationLog).AzureTableStorageSasUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)ApplicationLog).AzureTableStorageSasUrl = value; }

        /// <summary>Backing field for <see cref="DetailedErrorMessage" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEnabledConfig _detailedErrorMessage;

        /// <summary>Detailed error messages configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEnabledConfig DetailedErrorMessage { get => (this._detailedErrorMessage = this._detailedErrorMessage ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.EnabledConfig()); set => this._detailedErrorMessage = value; }

        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? DetailedErrorMessageEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEnabledConfigInternal)DetailedErrorMessage).Enabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEnabledConfigInternal)DetailedErrorMessage).Enabled = value; }

        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? FailedRequestTracingEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEnabledConfigInternal)FailedRequestsTracing).Enabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEnabledConfigInternal)FailedRequestsTracing).Enabled = value; }

        /// <summary>Backing field for <see cref="FailedRequestsTracing" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEnabledConfig _failedRequestsTracing;

        /// <summary>Failed requests tracing configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEnabledConfig FailedRequestsTracing { get => (this._failedRequestsTracing = this._failedRequestsTracing ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.EnabledConfig()); set => this._failedRequestsTracing = value; }

        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? FileSystemEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfigInternal)HttpLog).FileSystemEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfigInternal)HttpLog).FileSystemEnabled = value; }

        /// <summary>Log level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? FileSystemLevel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)ApplicationLog).FileSystemLevel; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)ApplicationLog).FileSystemLevel = value; }

        /// <summary>
        /// Retention in days.
        /// Remove files older than X days.
        /// 0 or lower means no retention.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? FileSystemRetentionInDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfigInternal)HttpLog).FileSystemRetentionInDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfigInternal)HttpLog).FileSystemRetentionInDay = value; }

        /// <summary>
        /// Maximum size in megabytes that http log files can use.
        /// When reached old log files will be removed to make space for new ones.
        /// Value can range between 25 and 100.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? FileSystemRetentionInMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfigInternal)HttpLog).FileSystemRetentionInMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfigInternal)HttpLog).FileSystemRetentionInMb = value; }

        /// <summary>Backing field for <see cref="HttpLog" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfig _httpLog;

        /// <summary>HTTP logs configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfig HttpLog { get => (this._httpLog = this._httpLog ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HttpLogsConfig()); set => this._httpLog = value; }

        /// <summary>
        /// Retention in days.
        /// Remove blobs older than X days.
        /// 0 or lower means no retention.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? HttpLogsAzureBlobStorageRetentionInDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfigInternal)HttpLog).AzureBlobStorageRetentionInDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfigInternal)HttpLog).AzureBlobStorageRetentionInDay = value; }

        /// <summary>SAS url to a azure blob container with read/write/list/delete permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HttpLogsAzureBlobStorageSasUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfigInternal)HttpLog).AzureBlobStorageSasUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfigInternal)HttpLog).AzureBlobStorageSasUrl = value; }

        /// <summary>Internal Acessors for ApplicationLog</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal.ApplicationLog { get => (this._applicationLog = this._applicationLog ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ApplicationLogsConfig()); set { {_applicationLog = value;} } }

        /// <summary>Internal Acessors for ApplicationLogAzureBlobStorage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageApplicationLogsConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal.ApplicationLogAzureBlobStorage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)ApplicationLog).AzureBlobStorage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)ApplicationLog).AzureBlobStorage = value; }

        /// <summary>Internal Acessors for ApplicationLogAzureTableStorage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureTableStorageApplicationLogsConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal.ApplicationLogAzureTableStorage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)ApplicationLog).AzureTableStorage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)ApplicationLog).AzureTableStorage = value; }

        /// <summary>Internal Acessors for ApplicationLogFileSystem</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemApplicationLogsConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal.ApplicationLogFileSystem { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)ApplicationLog).FileSystem; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)ApplicationLog).FileSystem = value; }

        /// <summary>Internal Acessors for DetailedErrorMessage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEnabledConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal.DetailedErrorMessage { get => (this._detailedErrorMessage = this._detailedErrorMessage ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.EnabledConfig()); set { {_detailedErrorMessage = value;} } }

        /// <summary>Internal Acessors for FailedRequestsTracing</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEnabledConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal.FailedRequestsTracing { get => (this._failedRequestsTracing = this._failedRequestsTracing ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.EnabledConfig()); set { {_failedRequestsTracing = value;} } }

        /// <summary>Internal Acessors for HttpLog</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal.HttpLog { get => (this._httpLog = this._httpLog ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HttpLogsConfig()); set { {_httpLog = value;} } }

        /// <summary>Internal Acessors for HttpLogAzureBlobStorage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageHttpLogsConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal.HttpLogAzureBlobStorage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfigInternal)HttpLog).AzureBlobStorage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfigInternal)HttpLog).AzureBlobStorage = value; }

        /// <summary>Internal Acessors for HttpLogFileSystem</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemHttpLogsConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal.HttpLogFileSystem { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfigInternal)HttpLog).FileSystem; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfigInternal)HttpLog).FileSystem = value; }

        /// <summary>Creates an new <see cref="SiteLogsConfigProperties" /> instance.</summary>
        public SiteLogsConfigProperties()
        {

        }
    }
    /// SiteLogsConfig resource specific properties
    public partial interface ISiteLogsConfigProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
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
        int? ApplicationLogsAzureBlobStorageRetentionInDay { get; set; }
        /// <summary>SAS url to a azure blob container with read/write/list/delete permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SAS url to a azure blob container with read/write/list/delete permissions.",
        SerializedName = @"sasUrl",
        PossibleTypes = new [] { typeof(string) })]
        string ApplicationLogsAzureBlobStorageSasUrl { get; set; }
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
        /// <summary>Log level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Log level.",
        SerializedName = @"level",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? AzureBlobStorageLevel { get; set; }
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
        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"True if configuration is enabled, false if it is disabled and null if configuration is not set.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? DetailedErrorMessageEnabled { get; set; }
        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"True if configuration is enabled, false if it is disabled and null if configuration is not set.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? FailedRequestTracingEnabled { get; set; }
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
        /// <summary>Log level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Log level.",
        SerializedName = @"level",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? FileSystemLevel { get; set; }
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
        int? HttpLogsAzureBlobStorageRetentionInDay { get; set; }
        /// <summary>SAS url to a azure blob container with read/write/list/delete permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SAS url to a azure blob container with read/write/list/delete permissions.",
        SerializedName = @"sasUrl",
        PossibleTypes = new [] { typeof(string) })]
        string HttpLogsAzureBlobStorageSasUrl { get; set; }

    }
    /// SiteLogsConfig resource specific properties
    internal partial interface ISiteLogsConfigPropertiesInternal

    {
        /// <summary>Application logs configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfig ApplicationLog { get; set; }
        /// <summary>Application logs to blob storage configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageApplicationLogsConfig ApplicationLogAzureBlobStorage { get; set; }
        /// <summary>Application logs to azure table storage configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureTableStorageApplicationLogsConfig ApplicationLogAzureTableStorage { get; set; }
        /// <summary>Application logs to file system configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemApplicationLogsConfig ApplicationLogFileSystem { get; set; }
        /// <summary>
        /// Retention in days.
        /// Remove blobs older than X days.
        /// 0 or lower means no retention.
        /// </summary>
        int? ApplicationLogsAzureBlobStorageRetentionInDay { get; set; }
        /// <summary>SAS url to a azure blob container with read/write/list/delete permissions.</summary>
        string ApplicationLogsAzureBlobStorageSasUrl { get; set; }
        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        bool? AzureBlobStorageEnabled { get; set; }
        /// <summary>Log level.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? AzureBlobStorageLevel { get; set; }
        /// <summary>Log level.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? AzureTableStorageLevel { get; set; }
        /// <summary>SAS URL to an Azure table with add/query/delete permissions.</summary>
        string AzureTableStorageSasUrl { get; set; }
        /// <summary>Detailed error messages configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEnabledConfig DetailedErrorMessage { get; set; }
        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        bool? DetailedErrorMessageEnabled { get; set; }
        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        bool? FailedRequestTracingEnabled { get; set; }
        /// <summary>Failed requests tracing configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEnabledConfig FailedRequestsTracing { get; set; }
        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        bool? FileSystemEnabled { get; set; }
        /// <summary>Log level.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? FileSystemLevel { get; set; }
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
        /// <summary>HTTP logs configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfig HttpLog { get; set; }
        /// <summary>Http logs to azure blob storage configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageHttpLogsConfig HttpLogAzureBlobStorage { get; set; }
        /// <summary>Http logs to file system configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemHttpLogsConfig HttpLogFileSystem { get; set; }
        /// <summary>
        /// Retention in days.
        /// Remove blobs older than X days.
        /// 0 or lower means no retention.
        /// </summary>
        int? HttpLogsAzureBlobStorageRetentionInDay { get; set; }
        /// <summary>SAS url to a azure blob container with read/write/list/delete permissions.</summary>
        string HttpLogsAzureBlobStorageSasUrl { get; set; }

    }
}