namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters for VpnGateway</summary>
    public partial class VpnGatewayProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnGatewayProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnGatewayPropertiesInternal
    {

        /// <summary>Backing field for <see cref="BgpSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettings _bgpSetting;

        /// <summary>Local network gateway's BGP speaker settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettings BgpSetting { get => (this._bgpSetting = this._bgpSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.BgpSettings()); set => this._bgpSetting = value; }

        /// <summary>The BGP speaker's ASN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public long? BgpSettingAsn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettingsInternal)BgpSetting).Asn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettingsInternal)BgpSetting).Asn = value; }

        /// <summary>The BGP peering address and BGP identifier of this BGP speaker.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string BgpSettingBgpPeeringAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettingsInternal)BgpSetting).BgpPeeringAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettingsInternal)BgpSetting).BgpPeeringAddress = value; }

        /// <summary>The weight added to routes learned from this BGP speaker.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? BgpSettingPeerWeight { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettingsInternal)BgpSetting).PeerWeight; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettingsInternal)BgpSetting).PeerWeight = value; }

        /// <summary>Backing field for <see cref="Connection" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnection[] _connection;

        /// <summary>List of all vpn connections to the gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnection[] Connection { get => this._connection; set => this._connection = value; }

        /// <summary>Internal Acessors for BgpSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettings Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnGatewayPropertiesInternal.BgpSetting { get => (this._bgpSetting = this._bgpSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.BgpSettings()); set { {_bgpSetting = value;} } }

        /// <summary>Internal Acessors for VirtualHub</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnGatewayPropertiesInternal.VirtualHub { get => (this._virtualHub = this._virtualHub ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_virtualHub = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? _provisioningState;

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="VirtualHub" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _virtualHub;

        /// <summary>The VirtualHub to which the gateway belongs</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource VirtualHub { get => (this._virtualHub = this._virtualHub ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._virtualHub = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string VirtualHubId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)VirtualHub).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)VirtualHub).Id = value; }

        /// <summary>Backing field for <see cref="VpnGatewayScaleUnit" /> property.</summary>
        private int? _vpnGatewayScaleUnit;

        /// <summary>The scale unit for this vpn gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? VpnGatewayScaleUnit { get => this._vpnGatewayScaleUnit; set => this._vpnGatewayScaleUnit = value; }

        /// <summary>Creates an new <see cref="VpnGatewayProperties" /> instance.</summary>
        public VpnGatewayProperties()
        {

        }
    }
    /// Parameters for VpnGateway
    public partial interface IVpnGatewayProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The BGP speaker's ASN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The BGP speaker's ASN.",
        SerializedName = @"asn",
        PossibleTypes = new [] { typeof(long) })]
        long? BgpSettingAsn { get; set; }
        /// <summary>The BGP peering address and BGP identifier of this BGP speaker.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The BGP peering address and BGP identifier of this BGP speaker.",
        SerializedName = @"bgpPeeringAddress",
        PossibleTypes = new [] { typeof(string) })]
        string BgpSettingBgpPeeringAddress { get; set; }
        /// <summary>The weight added to routes learned from this BGP speaker.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The weight added to routes learned from this BGP speaker.",
        SerializedName = @"peerWeight",
        PossibleTypes = new [] { typeof(int) })]
        int? BgpSettingPeerWeight { get; set; }
        /// <summary>List of all vpn connections to the gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of all vpn connections to the gateway.",
        SerializedName = @"connections",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnection) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnection[] Connection { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualHubId { get; set; }
        /// <summary>The scale unit for this vpn gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The scale unit for this vpn gateway.",
        SerializedName = @"vpnGatewayScaleUnit",
        PossibleTypes = new [] { typeof(int) })]
        int? VpnGatewayScaleUnit { get; set; }

    }
    /// Parameters for VpnGateway
    internal partial interface IVpnGatewayPropertiesInternal

    {
        /// <summary>Local network gateway's BGP speaker settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettings BgpSetting { get; set; }
        /// <summary>The BGP speaker's ASN.</summary>
        long? BgpSettingAsn { get; set; }
        /// <summary>The BGP peering address and BGP identifier of this BGP speaker.</summary>
        string BgpSettingBgpPeeringAddress { get; set; }
        /// <summary>The weight added to routes learned from this BGP speaker.</summary>
        int? BgpSettingPeerWeight { get; set; }
        /// <summary>List of all vpn connections to the gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnection[] Connection { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The VirtualHub to which the gateway belongs</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource VirtualHub { get; set; }
        /// <summary>Resource ID.</summary>
        string VirtualHubId { get; set; }
        /// <summary>The scale unit for this vpn gateway.</summary>
        int? VpnGatewayScaleUnit { get; set; }

    }
}