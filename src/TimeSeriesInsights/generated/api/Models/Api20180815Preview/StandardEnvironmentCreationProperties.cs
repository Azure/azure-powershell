namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>Properties used to create a standard environment.</summary>
    public partial class StandardEnvironmentCreationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentCreationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IStandardEnvironmentCreationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="DataRetentionTime" /> property.</summary>
        private global::System.TimeSpan _dataRetentionTime;

        /// <summary>
        /// ISO8601 timespan specifying the minimum number of days the environment's events will be available for query.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public global::System.TimeSpan DataRetentionTime { get => this._dataRetentionTime; set => this._dataRetentionTime = value; }

        /// <summary>Backing field for <see cref="PartitionKeyProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITimeSeriesIdProperty[] _partitionKeyProperty;

        /// <summary>
        /// The list of event properties which will be used to partition data in the environment.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITimeSeriesIdProperty[] PartitionKeyProperty { get => this._partitionKeyProperty; set => this._partitionKeyProperty = value; }

        /// <summary>Backing field for <see cref="StorageLimitExceededBehavior" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.StorageLimitExceededBehavior? _storageLimitExceededBehavior;

        /// <summary>
        /// The behavior the Time Series Insights service should take when the environment's capacity has been exceeded. If "PauseIngress"
        /// is specified, new events will not be read from the event source. If "PurgeOldData" is specified, new events will continue
        /// to be read and old events will be deleted from the environment. The default behavior is PurgeOldData.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.StorageLimitExceededBehavior? StorageLimitExceededBehavior { get => this._storageLimitExceededBehavior; set => this._storageLimitExceededBehavior = value; }

        /// <summary>Creates an new <see cref="StandardEnvironmentCreationProperties" /> instance.</summary>
        public StandardEnvironmentCreationProperties()
        {

        }
    }
    /// Properties used to create a standard environment.
    public partial interface IStandardEnvironmentCreationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable
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
    /// Properties used to create a standard environment.
    internal partial interface IStandardEnvironmentCreationPropertiesInternal

    {
        /// <summary>
        /// ISO8601 timespan specifying the minimum number of days the environment's events will be available for query.
        /// </summary>
        global::System.TimeSpan DataRetentionTime { get; set; }
        /// <summary>
        /// The list of event properties which will be used to partition data in the environment.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITimeSeriesIdProperty[] PartitionKeyProperty { get; set; }
        /// <summary>
        /// The behavior the Time Series Insights service should take when the environment's capacity has been exceeded. If "PauseIngress"
        /// is specified, new events will not be read from the event source. If "PurgeOldData" is specified, new events will continue
        /// to be read and old events will be deleted from the environment. The default behavior is PurgeOldData.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.StorageLimitExceededBehavior? StorageLimitExceededBehavior { get; set; }

    }
}