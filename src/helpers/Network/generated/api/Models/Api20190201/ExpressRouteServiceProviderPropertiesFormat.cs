namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of ExpressRouteServiceProvider.</summary>
    public partial class ExpressRouteServiceProviderPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteServiceProviderPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteServiceProviderPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="BandwidthsOffered" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteServiceProviderBandwidthsOffered[] _bandwidthsOffered;

        /// <summary>Gets bandwidths offered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteServiceProviderBandwidthsOffered[] BandwidthsOffered { get => this._bandwidthsOffered; set => this._bandwidthsOffered = value; }

        /// <summary>Backing field for <see cref="PeeringLocation" /> property.</summary>
        private string[] _peeringLocation;

        /// <summary>Get a list of peering locations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] PeeringLocation { get => this._peeringLocation; set => this._peeringLocation = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>Gets the provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>
        /// Creates an new <see cref="ExpressRouteServiceProviderPropertiesFormat" /> instance.
        /// </summary>
        public ExpressRouteServiceProviderPropertiesFormat()
        {

        }
    }
    /// Properties of ExpressRouteServiceProvider.
    public partial interface IExpressRouteServiceProviderPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Gets bandwidths offered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets bandwidths offered.",
        SerializedName = @"bandwidthsOffered",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteServiceProviderBandwidthsOffered) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteServiceProviderBandwidthsOffered[] BandwidthsOffered { get; set; }
        /// <summary>Get a list of peering locations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Get a list of peering locations.",
        SerializedName = @"peeringLocations",
        PossibleTypes = new [] { typeof(string) })]
        string[] PeeringLocation { get; set; }
        /// <summary>Gets the provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the provisioning state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }

    }
    /// Properties of ExpressRouteServiceProvider.
    internal partial interface IExpressRouteServiceProviderPropertiesFormatInternal

    {
        /// <summary>Gets bandwidths offered.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteServiceProviderBandwidthsOffered[] BandwidthsOffered { get; set; }
        /// <summary>Get a list of peering locations.</summary>
        string[] PeeringLocation { get; set; }
        /// <summary>Gets the provisioning state of the resource.</summary>
        string ProvisioningState { get; set; }

    }
}