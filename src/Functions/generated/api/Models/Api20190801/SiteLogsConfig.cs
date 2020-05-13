namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Configuration of App Service site logs.</summary>
    public partial class SiteLogsConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfig,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>
        /// Retention in days.
        /// Remove blobs older than X days.
        /// 0 or lower means no retention.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? ApplicationLogsAzureBlobStorageRetentionInDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).ApplicationLogsAzureBlobStorageRetentionInDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).ApplicationLogsAzureBlobStorageRetentionInDay = value; }

        /// <summary>SAS url to a azure blob container with read/write/list/delete permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ApplicationLogsAzureBlobStorageSasUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).ApplicationLogsAzureBlobStorageSasUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).ApplicationLogsAzureBlobStorageSasUrl = value; }

        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? AzureBlobStorageEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).AzureBlobStorageEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).AzureBlobStorageEnabled = value; }

        /// <summary>Log level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? AzureBlobStorageLevel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).AzureBlobStorageLevel; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).AzureBlobStorageLevel = value; }

        /// <summary>Log level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? AzureTableStorageLevel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).AzureTableStorageLevel; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).AzureTableStorageLevel = value; }

        /// <summary>SAS URL to an Azure table with add/query/delete permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string AzureTableStorageSasUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).AzureTableStorageSasUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).AzureTableStorageSasUrl = value; }

        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? DetailedErrorMessageEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).DetailedErrorMessageEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).DetailedErrorMessageEnabled = value; }

        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? FailedRequestTracingEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).FailedRequestTracingEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).FailedRequestTracingEnabled = value; }

        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? FileSystemEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).FileSystemEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).FileSystemEnabled = value; }

        /// <summary>Log level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel? FileSystemLevel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).FileSystemLevel; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).FileSystemLevel = value; }

        /// <summary>
        /// Retention in days.
        /// Remove files older than X days.
        /// 0 or lower means no retention.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? FileSystemRetentionInDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).FileSystemRetentionInDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).FileSystemRetentionInDay = value; }

        /// <summary>
        /// Maximum size in megabytes that http log files can use.
        /// When reached old log files will be removed to make space for new ones.
        /// Value can range between 25 and 100.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? FileSystemRetentionInMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).FileSystemRetentionInMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).FileSystemRetentionInMb = value; }

        /// <summary>
        /// Retention in days.
        /// Remove blobs older than X days.
        /// 0 or lower means no retention.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? HttpLogsAzureBlobStorageRetentionInDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).HttpLogsAzureBlobStorageRetentionInDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).HttpLogsAzureBlobStorageRetentionInDay = value; }

        /// <summary>SAS url to a azure blob container with read/write/list/delete permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HttpLogsAzureBlobStorageSasUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).HttpLogsAzureBlobStorageSasUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).HttpLogsAzureBlobStorageSasUrl = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Internal Acessors for ApplicationLog</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal.ApplicationLog { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).ApplicationLog; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).ApplicationLog = value; }

        /// <summary>Internal Acessors for ApplicationLogAzureBlobStorage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageApplicationLogsConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal.ApplicationLogAzureBlobStorage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).ApplicationLogAzureBlobStorage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).ApplicationLogAzureBlobStorage = value; }

        /// <summary>Internal Acessors for ApplicationLogAzureTableStorage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureTableStorageApplicationLogsConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal.ApplicationLogAzureTableStorage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).ApplicationLogAzureTableStorage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).ApplicationLogAzureTableStorage = value; }

        /// <summary>Internal Acessors for ApplicationLogFileSystem</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemApplicationLogsConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal.ApplicationLogFileSystem { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).ApplicationLogFileSystem; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).ApplicationLogFileSystem = value; }

        /// <summary>Internal Acessors for DetailedErrorMessage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEnabledConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal.DetailedErrorMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).DetailedErrorMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).DetailedErrorMessage = value; }

        /// <summary>Internal Acessors for FailedRequestsTracing</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEnabledConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal.FailedRequestsTracing { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).FailedRequestsTracing; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).FailedRequestsTracing = value; }

        /// <summary>Internal Acessors for HttpLog</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal.HttpLog { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).HttpLog; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).HttpLog = value; }

        /// <summary>Internal Acessors for HttpLogAzureBlobStorage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageHttpLogsConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal.HttpLogAzureBlobStorage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).HttpLogAzureBlobStorage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).HttpLogAzureBlobStorage = value; }

        /// <summary>Internal Acessors for HttpLogFileSystem</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemHttpLogsConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal.HttpLogFileSystem { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).HttpLogFileSystem; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigPropertiesInternal)Property).HttpLogFileSystem = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteLogsConfigProperties()); set { {_property = value;} } }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigProperties _property;

        /// <summary>SiteLogsConfig resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteLogsConfigProperties()); set => this._property = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Creates an new <see cref="SiteLogsConfig" /> instance.</summary>
        public SiteLogsConfig()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// Configuration of App Service site logs.
    public partial interface ISiteLogsConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
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
    /// Configuration of App Service site logs.
    internal partial interface ISiteLogsConfigInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
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
        /// <summary>SiteLogsConfig resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigProperties Property { get; set; }

    }
}