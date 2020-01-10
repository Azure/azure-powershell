namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Contains bandwidths offered in ExpressRouteServiceProvider resources.</summary>
    public partial class ExpressRouteServiceProviderBandwidthsOffered :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteServiceProviderBandwidthsOffered,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteServiceProviderBandwidthsOfferedInternal
    {

        /// <summary>Backing field for <see cref="OfferName" /> property.</summary>
        private string _offerName;

        /// <summary>The OfferName.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string OfferName { get => this._offerName; set => this._offerName = value; }

        /// <summary>Backing field for <see cref="ValueInMbps" /> property.</summary>
        private int? _valueInMbps;

        /// <summary>The ValueInMbps.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? ValueInMbps { get => this._valueInMbps; set => this._valueInMbps = value; }

        /// <summary>
        /// Creates an new <see cref="ExpressRouteServiceProviderBandwidthsOffered" /> instance.
        /// </summary>
        public ExpressRouteServiceProviderBandwidthsOffered()
        {

        }
    }
    /// Contains bandwidths offered in ExpressRouteServiceProvider resources.
    public partial interface IExpressRouteServiceProviderBandwidthsOffered :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The OfferName.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OfferName.",
        SerializedName = @"offerName",
        PossibleTypes = new [] { typeof(string) })]
        string OfferName { get; set; }
        /// <summary>The ValueInMbps.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ValueInMbps.",
        SerializedName = @"valueInMbps",
        PossibleTypes = new [] { typeof(int) })]
        int? ValueInMbps { get; set; }

    }
    /// Contains bandwidths offered in ExpressRouteServiceProvider resources.
    internal partial interface IExpressRouteServiceProviderBandwidthsOfferedInternal

    {
        /// <summary>The OfferName.</summary>
        string OfferName { get; set; }
        /// <summary>The ValueInMbps.</summary>
        int? ValueInMbps { get; set; }

    }
}