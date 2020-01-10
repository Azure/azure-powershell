namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>BGP settings details</summary>
    public partial class BgpSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpSettings,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpSettingsInternal
    {

        /// <summary>Backing field for <see cref="Asn" /> property.</summary>
        private long? _asn;

        /// <summary>The BGP speaker's ASN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public long? Asn { get => this._asn; set => this._asn = value; }

        /// <summary>Backing field for <see cref="BgpPeeringAddress" /> property.</summary>
        private string _bgpPeeringAddress;

        /// <summary>The BGP peering address and BGP identifier of this BGP speaker.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string BgpPeeringAddress { get => this._bgpPeeringAddress; set => this._bgpPeeringAddress = value; }

        /// <summary>Backing field for <see cref="PeerWeight" /> property.</summary>
        private int? _peerWeight;

        /// <summary>The weight added to routes learned from this BGP speaker.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? PeerWeight { get => this._peerWeight; set => this._peerWeight = value; }

        /// <summary>Creates an new <see cref="BgpSettings" /> instance.</summary>
        public BgpSettings()
        {

        }
    }
    /// BGP settings details
    public partial interface IBgpSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The BGP speaker's ASN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The BGP speaker's ASN.",
        SerializedName = @"asn",
        PossibleTypes = new [] { typeof(long) })]
        long? Asn { get; set; }
        /// <summary>The BGP peering address and BGP identifier of this BGP speaker.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The BGP peering address and BGP identifier of this BGP speaker.",
        SerializedName = @"bgpPeeringAddress",
        PossibleTypes = new [] { typeof(string) })]
        string BgpPeeringAddress { get; set; }
        /// <summary>The weight added to routes learned from this BGP speaker.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The weight added to routes learned from this BGP speaker.",
        SerializedName = @"peerWeight",
        PossibleTypes = new [] { typeof(int) })]
        int? PeerWeight { get; set; }

    }
    /// BGP settings details
    internal partial interface IBgpSettingsInternal

    {
        /// <summary>The BGP speaker's ASN.</summary>
        long? Asn { get; set; }
        /// <summary>The BGP peering address and BGP identifier of this BGP speaker.</summary>
        string BgpPeeringAddress { get; set; }
        /// <summary>The weight added to routes learned from this BGP speaker.</summary>
        int? PeerWeight { get; set; }

    }
}