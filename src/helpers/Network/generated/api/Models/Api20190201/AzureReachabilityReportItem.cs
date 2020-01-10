namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Azure reachability report details for a given provider location.</summary>
    public partial class AzureReachabilityReportItem :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportItem,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportItemInternal
    {

        /// <summary>Backing field for <see cref="AzureLocation" /> property.</summary>
        private string _azureLocation;

        /// <summary>The Azure region.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string AzureLocation { get => this._azureLocation; set => this._azureLocation = value; }

        /// <summary>Backing field for <see cref="Latency" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportLatencyInfo[] _latency;

        /// <summary>List of latency details for each of the time series.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportLatencyInfo[] Latency { get => this._latency; set => this._latency = value; }

        /// <summary>Backing field for <see cref="Provider" /> property.</summary>
        private string _provider;

        /// <summary>The Internet service provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Provider { get => this._provider; set => this._provider = value; }

        /// <summary>Creates an new <see cref="AzureReachabilityReportItem" /> instance.</summary>
        public AzureReachabilityReportItem()
        {

        }
    }
    /// Azure reachability report details for a given provider location.
    public partial interface IAzureReachabilityReportItem :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The Azure region.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Azure region.",
        SerializedName = @"azureLocation",
        PossibleTypes = new [] { typeof(string) })]
        string AzureLocation { get; set; }
        /// <summary>List of latency details for each of the time series.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of latency details for each of the time series.",
        SerializedName = @"latencies",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportLatencyInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportLatencyInfo[] Latency { get; set; }
        /// <summary>The Internet service provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Internet service provider.",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string Provider { get; set; }

    }
    /// Azure reachability report details for a given provider location.
    internal partial interface IAzureReachabilityReportItemInternal

    {
        /// <summary>The Azure region.</summary>
        string AzureLocation { get; set; }
        /// <summary>List of latency details for each of the time series.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportLatencyInfo[] Latency { get; set; }
        /// <summary>The Internet service provider.</summary>
        string Provider { get; set; }

    }
}