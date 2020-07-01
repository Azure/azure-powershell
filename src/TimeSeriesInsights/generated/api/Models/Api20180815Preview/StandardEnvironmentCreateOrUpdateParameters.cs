namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>
    /// Parameters supplied to the Create or Update Environment operation for a standard environment.
    /// </summary>
    public partial class StandardEnvironmentCreateOrUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentCreateOrUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentCreateOrUpdateParametersInternal,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParameters"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParameters __environmentCreateOrUpdateParameters = new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.EnvironmentCreateOrUpdateParameters();

        /// <summary>
        /// ISO8601 timespan specifying the minimum number of days the environment's events will be available for query.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public global::System.TimeSpan DataRetentionTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentCreationPropertiesInternal)Property).DataRetentionTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentCreationPropertiesInternal)Property).DataRetentionTime = value; }

        /// <summary>The kind of the environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)__environmentCreateOrUpdateParameters).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)__environmentCreateOrUpdateParameters).Kind = value; }

        /// <summary>The location of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)__environmentCreateOrUpdateParameters).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)__environmentCreateOrUpdateParameters).Location = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentCreationProperties Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentCreateOrUpdateParametersInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.StandardEnvironmentCreationProperties()); set { {_property = value;} } }

        /// <summary>
        /// The list of event properties which will be used to partition data in the environment.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITimeSeriesIdProperty[] PartitionKeyProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentCreationPropertiesInternal)Property).PartitionKeyProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentCreationPropertiesInternal)Property).PartitionKeyProperty = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentCreationProperties _property;

        /// <summary>Properties used to create a standard environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentCreationProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.StandardEnvironmentCreationProperties()); set => this._property = value; }

        /// <summary>
        /// The sku determines the type of environment, either standard (S1 or S2) or long-term (L1). For standard environments the
        /// sku determines the capacity of the environment, the ingress rate, and the billing rate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ISku Sku { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)__environmentCreateOrUpdateParameters).Sku; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)__environmentCreateOrUpdateParameters).Sku = value; }

        /// <summary>
        /// The capacity of the sku. For standard environments, this value can be changed to support scale out of environments after
        /// they have been created.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public int SkuCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)__environmentCreateOrUpdateParameters).SkuCapacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)__environmentCreateOrUpdateParameters).SkuCapacity = value; }

        /// <summary>The name of this SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.SkuName SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)__environmentCreateOrUpdateParameters).SkuName; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)__environmentCreateOrUpdateParameters).SkuName = value; }

        /// <summary>
        /// The behavior the Time Series Insights service should take when the environment's capacity has been exceeded. If "PauseIngress"
        /// is specified, new events will not be read from the event source. If "PurgeOldData" is specified, new events will continue
        /// to be read and old events will be deleted from the environment. The default behavior is PurgeOldData.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.StorageLimitExceededBehavior? StorageLimitExceededBehavior { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentCreationPropertiesInternal)Property).StorageLimitExceededBehavior; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentCreationPropertiesInternal)Property).StorageLimitExceededBehavior = value; }

        /// <summary>Key-value pairs of additional properties for the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)__environmentCreateOrUpdateParameters).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)__environmentCreateOrUpdateParameters).Tag = value; }

        /// <summary>
        /// Creates an new <see cref="StandardEnvironmentCreateOrUpdateParameters" /> instance.
        /// </summary>
        public StandardEnvironmentCreateOrUpdateParameters()
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
    /// Parameters supplied to the Create or Update Environment operation for a standard environment.
    public partial interface IStandardEnvironmentCreateOrUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParameters
    {
        /// <summary>
        /// ISO8601 timespan specifying the minimum number of days the environment's events will be available for query.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"ISO8601 timespan specifying the minimum number of days the environment's events will be available for query.",
        SerializedName = @"dataRetentionTime",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan DataRetentionTime { get; set; }
        /// <summary>
        /// The list of event properties which will be used to partition data in the environment.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of event properties which will be used to partition data in the environment.",
        SerializedName = @"partitionKeyProperties",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITimeSeriesIdProperty) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITimeSeriesIdProperty[] PartitionKeyProperty { get; set; }
        /// <summary>
        /// The behavior the Time Series Insights service should take when the environment's capacity has been exceeded. If "PauseIngress"
        /// is specified, new events will not be read from the event source. If "PurgeOldData" is specified, new events will continue
        /// to be read and old events will be deleted from the environment. The default behavior is PurgeOldData.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The behavior the Time Series Insights service should take when the environment's capacity has been exceeded. If ""PauseIngress"" is specified, new events will not be read from the event source. If ""PurgeOldData"" is specified, new events will continue to be read and old events will be deleted from the environment. The default behavior is PurgeOldData.",
        SerializedName = @"storageLimitExceededBehavior",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.StorageLimitExceededBehavior) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.StorageLimitExceededBehavior? StorageLimitExceededBehavior { get; set; }

    }
    /// Parameters supplied to the Create or Update Environment operation for a standard environment.
    internal partial interface IStandardEnvironmentCreateOrUpdateParametersInternal :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal
    {
        /// <summary>
        /// ISO8601 timespan specifying the minimum number of days the environment's events will be available for query.
        /// </summary>
        global::System.TimeSpan DataRetentionTime { get; set; }
        /// <summary>
        /// The list of event properties which will be used to partition data in the environment.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITimeSeriesIdProperty[] PartitionKeyProperty { get; set; }
        /// <summary>Properties used to create a standard environment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentCreationProperties Property { get; set; }
        /// <summary>
        /// The behavior the Time Series Insights service should take when the environment's capacity has been exceeded. If "PauseIngress"
        /// is specified, new events will not be read from the event source. If "PurgeOldData" is specified, new events will continue
        /// to be read and old events will be deleted from the environment. The default behavior is PurgeOldData.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.StorageLimitExceededBehavior? StorageLimitExceededBehavior { get; set; }

    }
}