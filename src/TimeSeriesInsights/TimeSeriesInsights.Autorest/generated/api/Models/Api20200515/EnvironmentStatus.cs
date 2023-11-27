namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>
    /// An object that represents the status of the environment, and its internal state in the Time Series Insights service.
    /// </summary>
    public partial class EnvironmentStatus :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentStatus,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentStatusInternal
    {

        /// <summary>Backing field for <see cref="Ingress" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IIngressEnvironmentStatus _ingress;

        /// <summary>An object that represents the status of ingress on an environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IIngressEnvironmentStatus Ingress { get => (this._ingress = this._ingress ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IngressEnvironmentStatus()); }

        /// <summary>
        /// This string represents the state of ingress operations on an environment. It can be "Disabled", "Ready", "Running", "Paused"
        /// or "Unknown"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.IngressState? IngressState { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IIngressEnvironmentStatusInternal)Ingress).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IIngressEnvironmentStatusInternal)Ingress).State = value; }

        /// <summary>Internal Acessors for Ingress</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IIngressEnvironmentStatus Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentStatusInternal.Ingress { get => (this._ingress = this._ingress ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IngressEnvironmentStatus()); set { {_ingress = value;} } }

        /// <summary>Internal Acessors for IngressStateDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentStateDetails Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentStatusInternal.IngressStateDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IIngressEnvironmentStatusInternal)Ingress).StateDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IIngressEnvironmentStatusInternal)Ingress).StateDetail = value; }

        /// <summary>Internal Acessors for PropertyUsageStateDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStoragePropertiesUsageStateDetails Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentStatusInternal.PropertyUsageStateDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStorageEnvironmentStatusInternal)WarmStorage).PropertyUsageStateDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStorageEnvironmentStatusInternal)WarmStorage).PropertyUsageStateDetail = value; }

        /// <summary>Internal Acessors for WarmStorage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStorageEnvironmentStatus Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentStatusInternal.WarmStorage { get => (this._warmStorage = this._warmStorage ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.WarmStorageEnvironmentStatus()); set { {_warmStorage = value;} } }

        /// <summary>Internal Acessors for WarmStoragePropertiesUsage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStoragePropertiesUsage Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentStatusInternal.WarmStoragePropertiesUsage { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStorageEnvironmentStatusInternal)WarmStorage).PropertiesUsage; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStorageEnvironmentStatusInternal)WarmStorage).PropertiesUsage = value; }

        /// <summary>
        /// This string represents the state of warm storage properties usage. It can be "Ok", "Error", "Unknown".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.WarmStoragePropertiesState? PropertyUsageState { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStorageEnvironmentStatusInternal)WarmStorage).PropertyUsageState; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStorageEnvironmentStatusInternal)WarmStorage).PropertyUsageState = value; }

        /// <summary>
        /// Contains the code that represents the reason of an environment being in a particular state. Can be used to programmatically
        /// handle specific cases.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public string StateDetailCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IIngressEnvironmentStatusInternal)Ingress).StateDetailCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IIngressEnvironmentStatusInternal)Ingress).StateDetailCode = value; }

        /// <summary>
        /// A value that represents the number of properties used by the environment for S1/S2 SKU and number of properties used by
        /// Warm Store for PAYG SKU
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public int? StateDetailCurrentCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStorageEnvironmentStatusInternal)WarmStorage).StateDetailCurrentCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStorageEnvironmentStatusInternal)WarmStorage).StateDetailCurrentCount = value; }

        /// <summary>
        /// A value that represents the maximum number of properties used allowed by the environment for S1/S2 SKU and maximum number
        /// of properties allowed by Warm Store for PAYG SKU.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public int? StateDetailMaxCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStorageEnvironmentStatusInternal)WarmStorage).StateDetailMaxCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStorageEnvironmentStatusInternal)WarmStorage).StateDetailMaxCount = value; }

        /// <summary>A message that describes the state in detail.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public string StateDetailMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IIngressEnvironmentStatusInternal)Ingress).StateDetailMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IIngressEnvironmentStatusInternal)Ingress).StateDetailMessage = value; }

        /// <summary>Backing field for <see cref="WarmStorage" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStorageEnvironmentStatus _warmStorage;

        /// <summary>An object that represents the status of warm storage on an environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStorageEnvironmentStatus WarmStorage { get => (this._warmStorage = this._warmStorage ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.WarmStorageEnvironmentStatus()); }

        /// <summary>Creates an new <see cref="EnvironmentStatus" /> instance.</summary>
        public EnvironmentStatus()
        {

        }
    }
    /// An object that represents the status of the environment, and its internal state in the Time Series Insights service.
    public partial interface IEnvironmentStatus :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable
    {
        /// <summary>
        /// This string represents the state of ingress operations on an environment. It can be "Disabled", "Ready", "Running", "Paused"
        /// or "Unknown"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This string represents the state of ingress operations on an environment. It can be ""Disabled"", ""Ready"", ""Running"", ""Paused"" or ""Unknown""",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.IngressState) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.IngressState? IngressState { get; set; }
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
        /// Contains the code that represents the reason of an environment being in a particular state. Can be used to programmatically
        /// handle specific cases.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Contains the code that represents the reason of an environment being in a particular state. Can be used to programmatically handle specific cases.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string StateDetailCode { get; set; }
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
        /// <summary>A message that describes the state in detail.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A message that describes the state in detail.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string StateDetailMessage { get; set; }

    }
    /// An object that represents the status of the environment, and its internal state in the Time Series Insights service.
    internal partial interface IEnvironmentStatusInternal

    {
        /// <summary>An object that represents the status of ingress on an environment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IIngressEnvironmentStatus Ingress { get; set; }
        /// <summary>
        /// This string represents the state of ingress operations on an environment. It can be "Disabled", "Ready", "Running", "Paused"
        /// or "Unknown"
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.IngressState? IngressState { get; set; }
        /// <summary>An object that contains the details about an environment's state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentStateDetails IngressStateDetail { get; set; }
        /// <summary>
        /// This string represents the state of warm storage properties usage. It can be "Ok", "Error", "Unknown".
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.WarmStoragePropertiesState? PropertyUsageState { get; set; }
        /// <summary>An object that contains the details about warm storage properties usage state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStoragePropertiesUsageStateDetails PropertyUsageStateDetail { get; set; }
        /// <summary>
        /// Contains the code that represents the reason of an environment being in a particular state. Can be used to programmatically
        /// handle specific cases.
        /// </summary>
        string StateDetailCode { get; set; }
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
        /// <summary>A message that describes the state in detail.</summary>
        string StateDetailMessage { get; set; }
        /// <summary>An object that represents the status of warm storage on an environment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStorageEnvironmentStatus WarmStorage { get; set; }
        /// <summary>An object that contains the status of warm storage properties usage.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IWarmStoragePropertiesUsage WarmStoragePropertiesUsage { get; set; }

    }
}