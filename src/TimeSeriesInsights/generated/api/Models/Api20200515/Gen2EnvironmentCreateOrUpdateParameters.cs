namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>
    /// Parameters supplied to the Create or Update Environment operation for a Gen2 environment.
    /// </summary>
    public partial class Gen2EnvironmentCreateOrUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2EnvironmentCreateOrUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2EnvironmentCreateOrUpdateParametersInternal,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentCreateOrUpdateParameters"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentCreateOrUpdateParameters __environmentCreateOrUpdateParameters = new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.EnvironmentCreateOrUpdateParameters();

        /// <summary>The kind of the environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentCreateOrUpdateParametersInternal)__environmentCreateOrUpdateParameters).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentCreateOrUpdateParametersInternal)__environmentCreateOrUpdateParameters).Kind = value; }

        /// <summary>The location of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ICreateOrUpdateTrackedResourcePropertiesInternal)__environmentCreateOrUpdateParameters).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ICreateOrUpdateTrackedResourcePropertiesInternal)__environmentCreateOrUpdateParameters).Location = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2EnvironmentCreationProperties Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2EnvironmentCreateOrUpdateParametersInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.Gen2EnvironmentCreationProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for StorageConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2StorageConfigurationInput Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2EnvironmentCreateOrUpdateParametersInternal.StorageConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2EnvironmentCreationPropertiesInternal)Property).StorageConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2EnvironmentCreationPropertiesInternal)Property).StorageConfiguration = value; }

        /// <summary>Internal Acessors for WarmStoreConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStoreConfigurationProperties Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2EnvironmentCreateOrUpdateParametersInternal.WarmStoreConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2EnvironmentCreationPropertiesInternal)Property).WarmStoreConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2EnvironmentCreationPropertiesInternal)Property).WarmStoreConfiguration = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2EnvironmentCreationProperties _property;

        /// <summary>Properties used to create a Gen2 environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2EnvironmentCreationProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.Gen2EnvironmentCreationProperties()); set => this._property = value; }

        /// <summary>
        /// The sku determines the type of environment, either Gen1 (S1 or S2) or Gen2 (L1). For Gen1 environments the sku determines
        /// the capacity of the environment, the ingress rate, and the billing rate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ISku Sku { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentCreateOrUpdateParametersInternal)__environmentCreateOrUpdateParameters).Sku; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentCreateOrUpdateParametersInternal)__environmentCreateOrUpdateParameters).Sku = value; }

        /// <summary>
        /// The capacity of the sku. For Gen1 environments, this value can be changed to support scale out of environments after they
        /// have been created.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public int SkuCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentCreateOrUpdateParametersInternal)__environmentCreateOrUpdateParameters).SkuCapacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentCreateOrUpdateParametersInternal)__environmentCreateOrUpdateParameters).SkuCapacity = value; }

        /// <summary>The name of this SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.SkuName SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentCreateOrUpdateParametersInternal)__environmentCreateOrUpdateParameters).SkuName; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentCreateOrUpdateParametersInternal)__environmentCreateOrUpdateParameters).SkuName = value; }

        /// <summary>The name of the storage account that will hold the environment's Gen2 data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public string StorageConfigurationAccountName { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2EnvironmentCreationPropertiesInternal)Property).StorageConfigurationAccountName; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2EnvironmentCreationPropertiesInternal)Property).StorageConfigurationAccountName = value; }

        /// <summary>
        /// The value of the management key that grants the Time Series Insights service write access to the storage account. This
        /// property is not shown in environment responses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public string StorageConfigurationManagementKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2EnvironmentCreationPropertiesInternal)Property).StorageConfigurationManagementKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2EnvironmentCreationPropertiesInternal)Property).StorageConfigurationManagementKey = value; }

        /// <summary>Key-value pairs of additional properties for the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ICreateOrUpdateTrackedResourcePropertiesTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ICreateOrUpdateTrackedResourcePropertiesInternal)__environmentCreateOrUpdateParameters).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ICreateOrUpdateTrackedResourcePropertiesInternal)__environmentCreateOrUpdateParameters).Tag = value; }

        /// <summary>
        /// The list of event properties which will be used to define the environment's time series id.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ITimeSeriesIdProperty[] TimeSeriesIdProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2EnvironmentCreationPropertiesInternal)Property).TimeSeriesIdProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2EnvironmentCreationPropertiesInternal)Property).TimeSeriesIdProperty = value; }

        /// <summary>
        /// ISO8601 timespan specifying the number of days the environment's events will be available for query from the warm store.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public global::System.TimeSpan WarmStoreConfigurationDataRetention { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2EnvironmentCreationPropertiesInternal)Property).WarmStoreConfigurationDataRetention; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2EnvironmentCreationPropertiesInternal)Property).WarmStoreConfigurationDataRetention = value; }

        /// <summary>Creates an new <see cref="Gen2EnvironmentCreateOrUpdateParameters" /> instance.</summary>
        public Gen2EnvironmentCreateOrUpdateParameters()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__environmentCreateOrUpdateParameters), __environmentCreateOrUpdateParameters);
            await eventListener.AssertObjectIsValid(nameof(__environmentCreateOrUpdateParameters), __environmentCreateOrUpdateParameters);
        }
    }
    /// Parameters supplied to the Create or Update Environment operation for a Gen2 environment.
    public partial interface IGen2EnvironmentCreateOrUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentCreateOrUpdateParameters
    {
        /// <summary>The name of the storage account that will hold the environment's Gen2 data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the storage account that will hold the environment's Gen2 data.",
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ITimeSeriesIdProperty) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ITimeSeriesIdProperty[] TimeSeriesIdProperty { get; set; }
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
    /// Parameters supplied to the Create or Update Environment operation for a Gen2 environment.
    internal partial interface IGen2EnvironmentCreateOrUpdateParametersInternal :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentCreateOrUpdateParametersInternal
    {
        /// <summary>Properties used to create a Gen2 environment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2EnvironmentCreationProperties Property { get; set; }
        /// <summary>
        /// The storage configuration provides the connection details that allows the Time Series Insights service to connect to the
        /// customer storage account that is used to store the environment's data.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IGen2StorageConfigurationInput StorageConfiguration { get; set; }
        /// <summary>The name of the storage account that will hold the environment's Gen2 data.</summary>
        string StorageConfigurationAccountName { get; set; }
        /// <summary>
        /// The value of the management key that grants the Time Series Insights service write access to the storage account. This
        /// property is not shown in environment responses.
        /// </summary>
        string StorageConfigurationManagementKey { get; set; }
        /// <summary>
        /// The list of event properties which will be used to define the environment's time series id.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ITimeSeriesIdProperty[] TimeSeriesIdProperty { get; set; }
        /// <summary>
        /// The warm store configuration provides the details to create a warm store cache that will retain a copy of the environment's
        /// data available for faster query.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStoreConfigurationProperties WarmStoreConfiguration { get; set; }
        /// <summary>
        /// ISO8601 timespan specifying the number of days the environment's events will be available for query from the warm store.
        /// </summary>
        global::System.TimeSpan WarmStoreConfigurationDataRetention { get; set; }

    }
}