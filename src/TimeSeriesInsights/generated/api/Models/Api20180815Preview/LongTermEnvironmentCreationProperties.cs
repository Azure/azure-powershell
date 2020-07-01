namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>Properties used to create a long-term environment.</summary>
    public partial class LongTermEnvironmentCreationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreationPropertiesInternal
    {

        /// <summary>Internal Acessors for StorageConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermStorageConfigurationInput Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreationPropertiesInternal.StorageConfiguration { get => (this._storageConfiguration = this._storageConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.LongTermStorageConfigurationInput()); set { {_storageConfiguration = value;} } }

        /// <summary>Internal Acessors for WarmStoreConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IWarmStoreConfigurationProperties Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreationPropertiesInternal.WarmStoreConfiguration { get => (this._warmStoreConfiguration = this._warmStoreConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.WarmStoreConfigurationProperties()); set { {_warmStoreConfiguration = value;} } }

        /// <summary>Backing field for <see cref="StorageConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermStorageConfigurationInput _storageConfiguration;

        /// <summary>
        /// The storage configuration provides the connection details that allows the Time Series Insights service to connect to the
        /// customer storage account that is used to store the environment's data.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermStorageConfigurationInput StorageConfiguration { get => (this._storageConfiguration = this._storageConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.LongTermStorageConfigurationInput()); set => this._storageConfiguration = value; }

        /// <summary>
        /// The name of the storage account that will hold the environment's long term data.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public string StorageConfigurationAccountName { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermStorageConfigurationInputInternal)StorageConfiguration).AccountName; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermStorageConfigurationInputInternal)StorageConfiguration).AccountName = value; }

        /// <summary>
        /// The value of the management key that grants the Time Series Insights service write access to the storage account. This
        /// property is not shown in environment responses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public string StorageConfigurationManagementKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermStorageConfigurationInputInternal)StorageConfiguration).ManagementKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermStorageConfigurationInputInternal)StorageConfiguration).ManagementKey = value; }

        /// <summary>Backing field for <see cref="TimeSeriesIdProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITimeSeriesIdProperty[] _timeSeriesIdProperty;

        /// <summary>
        /// The list of event properties which will be used to define the environment's time series id.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITimeSeriesIdProperty[] TimeSeriesIdProperty { get => this._timeSeriesIdProperty; set => this._timeSeriesIdProperty = value; }

        /// <summary>Backing field for <see cref="WarmStoreConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IWarmStoreConfigurationProperties _warmStoreConfiguration;

        /// <summary>
        /// The warm store configuration provides the details to create a warm store cache that will retain a copy of the environment's
        /// data available for faster query.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IWarmStoreConfigurationProperties WarmStoreConfiguration { get => (this._warmStoreConfiguration = this._warmStoreConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.WarmStoreConfigurationProperties()); set => this._warmStoreConfiguration = value; }

        /// <summary>
        /// ISO8601 timespan specifying the number of days the environment's events will be available for query from the warm store.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public global::System.TimeSpan WarmStoreConfigurationDataRetention { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IWarmStoreConfigurationPropertiesInternal)WarmStoreConfiguration).DataRetention; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IWarmStoreConfigurationPropertiesInternal)WarmStoreConfiguration).DataRetention = value; }

        /// <summary>Creates an new <see cref="LongTermEnvironmentCreationProperties" /> instance.</summary>
        public LongTermEnvironmentCreationProperties()
        {

        }
    }
    /// Properties used to create a long-term environment.
    public partial interface ILongTermEnvironmentCreationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The name of the storage account that will hold the environment's long term data.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the storage account that will hold the environment's long term data.",
        SerializedName = @"accountName",
        PossibleTypes = new [] { typeof(string) })]
        string StorageConfigurationAccountName { get; set; }
        /// <summary>
        /// The value of the management key that grants the Time Series Insights service write access to the storage account. This
        /// property is not shown in environment responses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The value of the management key that grants the Time Series Insights service write access to the storage account. This property is not shown in environment responses.",
        SerializedName = @"managementKey",
        PossibleTypes = new [] { typeof(string) })]
        string StorageConfigurationManagementKey { get; set; }
        /// <summary>
        /// The list of event properties which will be used to define the environment's time series id.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The list of event properties which will be used to define the environment's time series id.",
        SerializedName = @"timeSeriesIdProperties",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITimeSeriesIdProperty) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITimeSeriesIdProperty[] TimeSeriesIdProperty { get; set; }
        /// <summary>
        /// ISO8601 timespan specifying the number of days the environment's events will be available for query from the warm store.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"ISO8601 timespan specifying the number of days the environment's events will be available for query from the warm store.",
        SerializedName = @"dataRetention",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan WarmStoreConfigurationDataRetention { get; set; }

    }
    /// Properties used to create a long-term environment.
    internal partial interface ILongTermEnvironmentCreationPropertiesInternal

    {
        /// <summary>
        /// The storage configuration provides the connection details that allows the Time Series Insights service to connect to the
        /// customer storage account that is used to store the environment's data.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermStorageConfigurationInput StorageConfiguration { get; set; }
        /// <summary>
        /// The name of the storage account that will hold the environment's long term data.
        /// </summary>
        string StorageConfigurationAccountName { get; set; }
        /// <summary>
        /// The value of the management key that grants the Time Series Insights service write access to the storage account. This
        /// property is not shown in environment responses.
        /// </summary>
        string StorageConfigurationManagementKey { get; set; }
        /// <summary>
        /// The list of event properties which will be used to define the environment's time series id.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITimeSeriesIdProperty[] TimeSeriesIdProperty { get; set; }
        /// <summary>
        /// The warm store configuration provides the details to create a warm store cache that will retain a copy of the environment's
        /// data available for faster query.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IWarmStoreConfigurationProperties WarmStoreConfiguration { get; set; }
        /// <summary>
        /// ISO8601 timespan specifying the number of days the environment's events will be available for query from the warm store.
        /// </summary>
        global::System.TimeSpan WarmStoreConfigurationDataRetention { get; set; }

    }
}