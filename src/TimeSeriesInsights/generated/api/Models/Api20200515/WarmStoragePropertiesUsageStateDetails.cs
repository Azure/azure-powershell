namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>An object that contains the details about warm storage properties usage state.</summary>
    public partial class WarmStoragePropertiesUsageStateDetails :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStoragePropertiesUsageStateDetails,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStoragePropertiesUsageStateDetailsInternal
    {

        /// <summary>Backing field for <see cref="CurrentCount" /> property.</summary>
        private int? _currentCount;

        /// <summary>
        /// A value that represents the number of properties used by the environment for S1/S2 SKU and number of properties used by
        /// Warm Store for PAYG SKU
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public int? CurrentCount { get => this._currentCount; set => this._currentCount = value; }

        /// <summary>Backing field for <see cref="MaxCount" /> property.</summary>
        private int? _maxCount;

        /// <summary>
        /// A value that represents the maximum number of properties used allowed by the environment for S1/S2 SKU and maximum number
        /// of properties allowed by Warm Store for PAYG SKU.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public int? MaxCount { get => this._maxCount; set => this._maxCount = value; }

        /// <summary>Creates an new <see cref="WarmStoragePropertiesUsageStateDetails" /> instance.</summary>
        public WarmStoragePropertiesUsageStateDetails()
        {

        }
    }
    /// An object that contains the details about warm storage properties usage state.
    public partial interface IWarmStoragePropertiesUsageStateDetails :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable
    {
        /// <summary>
        /// A value that represents the number of properties used by the environment for S1/S2 SKU and number of properties used by
        /// Warm Store for PAYG SKU
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value that represents the number of properties used by the environment for S1/S2 SKU and number of properties used by Warm Store for PAYG SKU",
        SerializedName = @"currentCount",
        PossibleTypes = new [] { typeof(int) })]
        int? CurrentCount { get; set; }
        /// <summary>
        /// A value that represents the maximum number of properties used allowed by the environment for S1/S2 SKU and maximum number
        /// of properties allowed by Warm Store for PAYG SKU.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value that represents the maximum number of properties used allowed by the environment for S1/S2 SKU and maximum number of properties allowed by Warm Store for PAYG SKU.",
        SerializedName = @"maxCount",
        PossibleTypes = new [] { typeof(int) })]
        int? MaxCount { get; set; }

    }
    /// An object that contains the details about warm storage properties usage state.
    internal partial interface IWarmStoragePropertiesUsageStateDetailsInternal

    {
        /// <summary>
        /// A value that represents the number of properties used by the environment for S1/S2 SKU and number of properties used by
        /// Warm Store for PAYG SKU
        /// </summary>
        int? CurrentCount { get; set; }
        /// <summary>
        /// A value that represents the maximum number of properties used allowed by the environment for S1/S2 SKU and maximum number
        /// of properties allowed by Warm Store for PAYG SKU.
        /// </summary>
        int? MaxCount { get; set; }

    }
}