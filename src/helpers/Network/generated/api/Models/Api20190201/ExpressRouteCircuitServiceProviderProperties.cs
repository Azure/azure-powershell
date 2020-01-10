namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Contains ServiceProviderProperties in an ExpressRouteCircuit.</summary>
    public partial class ExpressRouteCircuitServiceProviderProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitServiceProviderProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitServiceProviderPropertiesInternal
    {

        /// <summary>Backing field for <see cref="BandwidthInMbps" /> property.</summary>
        private int? _bandwidthInMbps;

        /// <summary>The BandwidthInMbps.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? BandwidthInMbps { get => this._bandwidthInMbps; set => this._bandwidthInMbps = value; }

        /// <summary>Backing field for <see cref="PeeringLocation" /> property.</summary>
        private string _peeringLocation;

        /// <summary>The peering location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string PeeringLocation { get => this._peeringLocation; set => this._peeringLocation = value; }

        /// <summary>Backing field for <see cref="ServiceProviderName" /> property.</summary>
        private string _serviceProviderName;

        /// <summary>The serviceProviderName.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ServiceProviderName { get => this._serviceProviderName; set => this._serviceProviderName = value; }

        /// <summary>
        /// Creates an new <see cref="ExpressRouteCircuitServiceProviderProperties" /> instance.
        /// </summary>
        public ExpressRouteCircuitServiceProviderProperties()
        {

        }
    }
    /// Contains ServiceProviderProperties in an ExpressRouteCircuit.
    public partial interface IExpressRouteCircuitServiceProviderProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The BandwidthInMbps.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The BandwidthInMbps.",
        SerializedName = @"bandwidthInMbps",
        PossibleTypes = new [] { typeof(int) })]
        int? BandwidthInMbps { get; set; }
        /// <summary>The peering location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The peering location.",
        SerializedName = @"peeringLocation",
        PossibleTypes = new [] { typeof(string) })]
        string PeeringLocation { get; set; }
        /// <summary>The serviceProviderName.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The serviceProviderName.",
        SerializedName = @"serviceProviderName",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceProviderName { get; set; }

    }
    /// Contains ServiceProviderProperties in an ExpressRouteCircuit.
    internal partial interface IExpressRouteCircuitServiceProviderPropertiesInternal

    {
        /// <summary>The BandwidthInMbps.</summary>
        int? BandwidthInMbps { get; set; }
        /// <summary>The peering location.</summary>
        string PeeringLocation { get; set; }
        /// <summary>The serviceProviderName.</summary>
        string ServiceProviderName { get; set; }

    }
}