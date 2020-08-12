namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>An object that represents the status of warm storage on an environment.</summary>
    public partial class WarmStorageEnvironmentStatus :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStorageEnvironmentStatus,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStorageEnvironmentStatusInternal
    {

        /// <summary>Internal Acessors for PropertiesUsage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStoragePropertiesUsage Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStorageEnvironmentStatusInternal.PropertiesUsage { get => (this._propertiesUsage = this._propertiesUsage ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.WarmStoragePropertiesUsage()); set { {_propertiesUsage = value;} } }

        /// <summary>Internal Acessors for PropertyUsageStateDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStoragePropertiesUsageStateDetails Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStorageEnvironmentStatusInternal.PropertyUsageStateDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStoragePropertiesUsageInternal)PropertiesUsage).StateDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStoragePropertiesUsageInternal)PropertiesUsage).StateDetail = value; }

        /// <summary>Backing field for <see cref="PropertiesUsage" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStoragePropertiesUsage _propertiesUsage;

        /// <summary>An object that contains the status of warm storage properties usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStoragePropertiesUsage PropertiesUsage { get => (this._propertiesUsage = this._propertiesUsage ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.WarmStoragePropertiesUsage()); }

        /// <summary>
        /// This string represents the state of warm storage properties usage. It can be "Ok", "Error", "Unknown".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.WarmStoragePropertiesState? PropertyUsageState { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStoragePropertiesUsageInternal)PropertiesUsage).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStoragePropertiesUsageInternal)PropertiesUsage).State = value; }

        /// <summary>
        /// A value that represents the number of properties used by the environment for S1/S2 SKU and number of properties used by
        /// Warm Store for PAYG SKU
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public int? StateDetailCurrentCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStoragePropertiesUsageInternal)PropertiesUsage).StateDetailCurrentCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStoragePropertiesUsageInternal)PropertiesUsage).StateDetailCurrentCount = value; }

        /// <summary>
        /// A value that represents the maximum number of properties used allowed by the environment for S1/S2 SKU and maximum number
        /// of properties allowed by Warm Store for PAYG SKU.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public int? StateDetailMaxCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStoragePropertiesUsageInternal)PropertiesUsage).StateDetailMaxCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStoragePropertiesUsageInternal)PropertiesUsage).StateDetailMaxCount = value; }

        /// <summary>Creates an new <see cref="WarmStorageEnvironmentStatus" /> instance.</summary>
        public WarmStorageEnvironmentStatus()
        {

        }
    }
    /// An object that represents the status of warm storage on an environment.
    public partial interface IWarmStorageEnvironmentStatus :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable
    {
        /// <summary>
        /// This string represents the state of warm storage properties usage. It can be "Ok", "Error", "Unknown".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This string represents the state of warm storage properties usage. It can be ""Ok"", ""Error"", ""Unknown"".",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.WarmStoragePropertiesState) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.WarmStoragePropertiesState? PropertyUsageState { get; set; }
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
        int? StateDetailCurrentCount { get; set; }
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
        int? StateDetailMaxCount { get; set; }

    }
    /// An object that represents the status of warm storage on an environment.
    internal partial interface IWarmStorageEnvironmentStatusInternal

    {
        /// <summary>An object that contains the status of warm storage properties usage.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStoragePropertiesUsage PropertiesUsage { get; set; }
        /// <summary>
        /// This string represents the state of warm storage properties usage. It can be "Ok", "Error", "Unknown".
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.WarmStoragePropertiesState? PropertyUsageState { get; set; }
        /// <summary>An object that contains the details about warm storage properties usage state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStoragePropertiesUsageStateDetails PropertyUsageStateDetail { get; set; }
        /// <summary>
        /// A value that represents the number of properties used by the environment for S1/S2 SKU and number of properties used by
        /// Warm Store for PAYG SKU
        /// </summary>
        int? StateDetailCurrentCount { get; set; }
        /// <summary>
        /// A value that represents the maximum number of properties used allowed by the environment for S1/S2 SKU and maximum number
        /// of properties allowed by Warm Store for PAYG SKU.
        /// </summary>
        int? StateDetailMaxCount { get; set; }

    }
}