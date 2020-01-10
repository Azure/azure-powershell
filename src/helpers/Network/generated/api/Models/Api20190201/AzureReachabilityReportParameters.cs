namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Geographic and time constraints for Azure reachability report.</summary>
    public partial class AzureReachabilityReportParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportParametersInternal
    {

        /// <summary>Backing field for <see cref="AzureLocation" /> property.</summary>
        private string[] _azureLocation;

        /// <summary>Optional Azure regions to scope the query to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] AzureLocation { get => this._azureLocation; set => this._azureLocation = value; }

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private global::System.DateTime _endTime;

        /// <summary>The end time for the Azure reachability report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public global::System.DateTime EndTime { get => this._endTime; set => this._endTime = value; }

        /// <summary>Internal Acessors for ProviderLocation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportLocation Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportParametersInternal.ProviderLocation { get => (this._providerLocation = this._providerLocation ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AzureReachabilityReportLocation()); set { {_providerLocation = value;} } }

        /// <summary>Backing field for <see cref="Provider" /> property.</summary>
        private string[] _provider;

        /// <summary>List of Internet service providers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] Provider { get => this._provider; set => this._provider = value; }

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

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime _startTime;

        /// <summary>The start time for the Azure reachability report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public global::System.DateTime StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Creates an new <see cref="AzureReachabilityReportParameters" /> instance.</summary>
        public AzureReachabilityReportParameters()
        {

        }
    }
    /// Geographic and time constraints for Azure reachability report.
    public partial interface IAzureReachabilityReportParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Optional Azure regions to scope the query to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Optional Azure regions to scope the query to.",
        SerializedName = @"azureLocations",
        PossibleTypes = new [] { typeof(string) })]
        string[] AzureLocation { get; set; }
        /// <summary>The end time for the Azure reachability report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The end time for the Azure reachability report.",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime EndTime { get; set; }
        /// <summary>List of Internet service providers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of Internet service providers.",
        SerializedName = @"providers",
        PossibleTypes = new [] { typeof(string) })]
        string[] Provider { get; set; }
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
        /// <summary>The start time for the Azure reachability report.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The start time for the Azure reachability report.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime StartTime { get; set; }

    }
    /// Geographic and time constraints for Azure reachability report.
    internal partial interface IAzureReachabilityReportParametersInternal

    {
        /// <summary>Optional Azure regions to scope the query to.</summary>
        string[] AzureLocation { get; set; }
        /// <summary>The end time for the Azure reachability report.</summary>
        global::System.DateTime EndTime { get; set; }
        /// <summary>List of Internet service providers.</summary>
        string[] Provider { get; set; }
        /// <summary>Parameters that define a geographic location.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportLocation ProviderLocation { get; set; }
        /// <summary>The name of the city or town.</summary>
        string ProviderLocationCity { get; set; }
        /// <summary>The name of the country.</summary>
        string ProviderLocationCountry { get; set; }
        /// <summary>The name of the state.</summary>
        string ProviderLocationState { get; set; }
        /// <summary>The start time for the Azure reachability report.</summary>
        global::System.DateTime StartTime { get; set; }

    }
}