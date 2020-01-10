namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Real-time inventory of available ExpressRoute port bandwidths.</summary>
    public partial class ExpressRoutePortsLocationBandwidths :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortsLocationBandwidths,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortsLocationBandwidthsInternal
    {

        /// <summary>Internal Acessors for OfferName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortsLocationBandwidthsInternal.OfferName { get => this._offerName; set { {_offerName = value;} } }

        /// <summary>Internal Acessors for ValueInGbps</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortsLocationBandwidthsInternal.ValueInGbps { get => this._valueInGbps; set { {_valueInGbps = value;} } }

        /// <summary>Backing field for <see cref="OfferName" /> property.</summary>
        private string _offerName;

        /// <summary>Bandwidth descriptive name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string OfferName { get => this._offerName; }

        /// <summary>Backing field for <see cref="ValueInGbps" /> property.</summary>
        private int? _valueInGbps;

        /// <summary>Bandwidth value in Gbps</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? ValueInGbps { get => this._valueInGbps; }

        /// <summary>Creates an new <see cref="ExpressRoutePortsLocationBandwidths" /> instance.</summary>
        public ExpressRoutePortsLocationBandwidths()
        {

        }
    }
    /// Real-time inventory of available ExpressRoute port bandwidths.
    public partial interface IExpressRoutePortsLocationBandwidths :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Bandwidth descriptive name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Bandwidth descriptive name",
        SerializedName = @"offerName",
        PossibleTypes = new [] { typeof(string) })]
        string OfferName { get;  }
        /// <summary>Bandwidth value in Gbps</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Bandwidth value in Gbps",
        SerializedName = @"valueInGbps",
        PossibleTypes = new [] { typeof(int) })]
        int? ValueInGbps { get;  }

    }
    /// Real-time inventory of available ExpressRoute port bandwidths.
    internal partial interface IExpressRoutePortsLocationBandwidthsInternal

    {
        /// <summary>Bandwidth descriptive name</summary>
        string OfferName { get; set; }
        /// <summary>Bandwidth value in Gbps</summary>
        int? ValueInGbps { get; set; }

    }
}