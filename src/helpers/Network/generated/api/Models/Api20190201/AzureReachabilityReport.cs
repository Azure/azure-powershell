namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Azure reachability report details.</summary>
    public partial class AzureReachabilityReport :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReport,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportInternal
    {

        /// <summary>Backing field for <see cref="AggregationLevel" /> property.</summary>
        private string _aggregationLevel;

        /// <summary>
        /// The aggregation level of Azure reachability report. Can be Country, State or City.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string AggregationLevel { get => this._aggregationLevel; set => this._aggregationLevel = value; }

        /// <summary>Internal Acessors for ProviderLocation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportLocation Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportInternal.ProviderLocation { get => (this._providerLocation = this._providerLocation ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AzureReachabilityReportLocation()); set { {_providerLocation = value;} } }

        /// <summary>Backing field for <see cref="ProviderLocation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportLocation _providerLocation;

        /// <summary>Parameters that define a geographic location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportLocation ProviderLocation { get => (this._providerLocation = this._providerLocation ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AzureReachabilityReportLocation()); set => this._providerLocation = value; }

        /// <summary>The name of the city or town.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProviderLocationCity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportLocationInternal)ProviderLocation).City; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportLocationInternal)ProviderLocation).City = value; }

        /// <summary>The name of the country.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProviderLocationCountry { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportLocationInternal)ProviderLocation).Country; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportLocationInternal)ProviderLocation).Country = value; }

        /// <summary>The name of the state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProviderLocationState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportLocationInternal)ProviderLocation).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportLocationInternal)ProviderLocation).State = value; }

        /// <summary>Backing field for <see cref="ReachabilityReport" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportItem[] _reachabilityReport;

        /// <summary>List of Azure reachability report items.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportItem[] ReachabilityReport { get => this._reachabilityReport; set => this._reachabilityReport = value; }

        /// <summary>Creates an new <see cref="AzureReachabilityReport" /> instance.</summary>
        public AzureReachabilityReport()
        {

        }
    }
    /// Azure reachability report details.
    public partial interface IAzureReachabilityReport :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The aggregation level of Azure reachability report. Can be Country, State or City.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The aggregation level of Azure reachability report. Can be Country, State or City.",
        SerializedName = @"aggregationLevel",
        PossibleTypes = new [] { typeof(string) })]
        string AggregationLevel { get; set; }
        /// <summary>The name of the city or town.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the city or town.",
        SerializedName = @"city",
        PossibleTypes = new [] { typeof(string) })]
        string ProviderLocationCity { get; set; }
        /// <summary>The name of the country.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the country.",
        SerializedName = @"country",
        PossibleTypes = new [] { typeof(string) })]
        string ProviderLocationCountry { get; set; }
        /// <summary>The name of the state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the state.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string ProviderLocationState { get; set; }
        /// <summary>List of Azure reachability report items.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"List of Azure reachability report items.",
        SerializedName = @"reachabilityReport",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportItem[] ReachabilityReport { get; set; }

    }
    /// Azure reachability report details.
    internal partial interface IAzureReachabilityReportInternal

    {
        /// <summary>
        /// The aggregation level of Azure reachability report. Can be Country, State or City.
        /// </summary>
        string AggregationLevel { get; set; }
        /// <summary>Parameters that define a geographic location.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportLocation ProviderLocation { get; set; }
        /// <summary>The name of the city or town.</summary>
        string ProviderLocationCity { get; set; }
        /// <summary>The name of the country.</summary>
        string ProviderLocationCountry { get; set; }
        /// <summary>The name of the state.</summary>
        string ProviderLocationState { get; set; }
        /// <summary>List of Azure reachability report items.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportItem[] ReachabilityReport { get; set; }

    }
}