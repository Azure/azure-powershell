namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>
    /// The warm store configuration provides the details to create a warm store cache that will retain a copy of the environment's
    /// data available for faster query.
    /// </summary>
    public partial class WarmStoreConfigurationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IWarmStoreConfigurationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IWarmStoreConfigurationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="DataRetention" /> property.</summary>
        private global::System.TimeSpan _dataRetention;

        /// <summary>
        /// ISO8601 timespan specifying the number of days the environment's events will be available for query from the warm store.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public global::System.TimeSpan DataRetention { get => this._dataRetention; set => this._dataRetention = value; }

        /// <summary>Creates an new <see cref="WarmStoreConfigurationProperties" /> instance.</summary>
        public WarmStoreConfigurationProperties()
        {

        }
    }
    /// The warm store configuration provides the details to create a warm store cache that will retain a copy of the environment's
    /// data available for faster query.
    public partial interface IWarmStoreConfigurationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable
    {
        /// <summary>
        /// ISO8601 timespan specifying the number of days the environment's events will be available for query from the warm store.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"ISO8601 timespan specifying the number of days the environment's events will be available for query from the warm store.",
        SerializedName = @"dataRetention",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan DataRetention { get; set; }

    }
    /// The warm store configuration provides the details to create a warm store cache that will retain a copy of the environment's
    /// data available for faster query.
    internal partial interface IWarmStoreConfigurationPropertiesInternal

    {
        /// <summary>
        /// ISO8601 timespan specifying the number of days the environment's events will be available for query from the warm store.
        /// </summary>
        global::System.TimeSpan DataRetention { get; set; }

    }
}