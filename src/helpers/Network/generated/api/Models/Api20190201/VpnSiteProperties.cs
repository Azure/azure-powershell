namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters for VpnSite</summary>
    public partial class VpnSiteProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal
    {

        /// <summary>Backing field for <see cref="AddressSpace" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace _addressSpace;

        /// <summary>The AddressSpace that contains an array of IP address ranges.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace AddressSpace { get => (this._addressSpace = this._addressSpace ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpace()); set => this._addressSpace = value; }

        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] AddressSpaceAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpaceInternal)AddressSpace).AddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpaceInternal)AddressSpace).AddressPrefix = value; }

        /// <summary>Backing field for <see cref="BgpProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettings _bgpProperty;

        /// <summary>The set of bgp properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettings BgpProperty { get => (this._bgpProperty = this._bgpProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.BgpSettings()); set => this._bgpProperty = value; }

        /// <summary>The BGP speaker's ASN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public long? BgpPropertyAsn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettingsInternal)BgpProperty).Asn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettingsInternal)BgpProperty).Asn = value; }

        /// <summary>The BGP peering address and BGP identifier of this BGP speaker.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string BgpPropertyBgpPeeringAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettingsInternal)BgpProperty).BgpPeeringAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettingsInternal)BgpProperty).BgpPeeringAddress = value; }

        /// <summary>The weight added to routes learned from this BGP speaker.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? BgpPropertyPeerWeight { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettingsInternal)BgpProperty).PeerWeight; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettingsInternal)BgpProperty).PeerWeight = value; }

        /// <summary>Backing field for <see cref="DeviceProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDeviceProperties _deviceProperty;

        /// <summary>The device properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDeviceProperties DeviceProperty { get => (this._deviceProperty = this._deviceProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.DeviceProperties()); set => this._deviceProperty = value; }

        /// <summary>Model of the device.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DevicePropertyDeviceModel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDevicePropertiesInternal)DeviceProperty).DeviceModel; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDevicePropertiesInternal)DeviceProperty).DeviceModel = value; }

        /// <summary>Name of the device Vendor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DevicePropertyDeviceVendor { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDevicePropertiesInternal)DeviceProperty).DeviceVendor; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDevicePropertiesInternal)DeviceProperty).DeviceVendor = value; }

        /// <summary>Link speed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? DevicePropertyLinkSpeedInMbps { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDevicePropertiesInternal)DeviceProperty).LinkSpeedInMbps; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDevicePropertiesInternal)DeviceProperty).LinkSpeedInMbps = value; }

        /// <summary>Backing field for <see cref="IPAddress" /> property.</summary>
        private string _iPAddress;

        /// <summary>The ip-address for the vpn-site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string IPAddress { get => this._iPAddress; set => this._iPAddress = value; }

        /// <summary>Backing field for <see cref="IsSecuritySite" /> property.</summary>
        private bool? _isSecuritySite;

        /// <summary>IsSecuritySite flag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? IsSecuritySite { get => this._isSecuritySite; set => this._isSecuritySite = value; }

        /// <summary>Internal Acessors for AddressSpace</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal.AddressSpace { get => (this._addressSpace = this._addressSpace ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpace()); set { {_addressSpace = value;} } }

        /// <summary>Internal Acessors for BgpProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettings Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal.BgpProperty { get => (this._bgpProperty = this._bgpProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.BgpSettings()); set { {_bgpProperty = value;} } }

        /// <summary>Internal Acessors for DeviceProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDeviceProperties Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal.DeviceProperty { get => (this._deviceProperty = this._deviceProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.DeviceProperties()); set { {_deviceProperty = value;} } }

        /// <summary>Internal Acessors for VirtualWan</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal.VirtualWan { get => (this._virtualWan = this._virtualWan ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_virtualWan = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? _provisioningState;

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="SiteKey" /> property.</summary>
        private string _siteKey;

        /// <summary>The key for vpn-site that can be used for connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string SiteKey { get => this._siteKey; set => this._siteKey = value; }

        /// <summary>Backing field for <see cref="VirtualWan" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _virtualWan;

        /// <summary>The VirtualWAN to which the vpnSite belongs</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource VirtualWan { get => (this._virtualWan = this._virtualWan ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._virtualWan = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string VirtualWanId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)VirtualWan).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)VirtualWan).Id = value; }

        /// <summary>Creates an new <see cref="VpnSiteProperties" /> instance.</summary>
        public VpnSiteProperties()
        {

        }
    }
    /// Parameters for VpnSite
    public partial interface IVpnSiteProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of address blocks reserved for this virtual network in CIDR notation.",
        SerializedName = @"addressPrefixes",
        PossibleTypes = new [] { typeof(string) })]
        string[] AddressSpaceAddressPrefix { get; set; }
        /// <summary>The BGP speaker's ASN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The BGP speaker's ASN.",
        SerializedName = @"asn",
        PossibleTypes = new [] { typeof(long) })]
        long? BgpPropertyAsn { get; set; }
        /// <summary>The BGP peering address and BGP identifier of this BGP speaker.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The BGP peering address and BGP identifier of this BGP speaker.",
        SerializedName = @"bgpPeeringAddress",
        PossibleTypes = new [] { typeof(string) })]
        string BgpPropertyBgpPeeringAddress { get; set; }
        /// <summary>The weight added to routes learned from this BGP speaker.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The weight added to routes learned from this BGP speaker.",
        SerializedName = @"peerWeight",
        PossibleTypes = new [] { typeof(int) })]
        int? BgpPropertyPeerWeight { get; set; }
        /// <summary>Model of the device.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Model of the device.",
        SerializedName = @"deviceModel",
        PossibleTypes = new [] { typeof(string) })]
        string DevicePropertyDeviceModel { get; set; }
        /// <summary>Name of the device Vendor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the device Vendor.",
        SerializedName = @"deviceVendor",
        PossibleTypes = new [] { typeof(string) })]
        string DevicePropertyDeviceVendor { get; set; }
        /// <summary>Link speed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Link speed.",
        SerializedName = @"linkSpeedInMbps",
        PossibleTypes = new [] { typeof(int) })]
        int? DevicePropertyLinkSpeedInMbps { get; set; }
        /// <summary>The ip-address for the vpn-site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ip-address for the vpn-site.",
        SerializedName = @"ipAddress",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddress { get; set; }
        /// <summary>IsSecuritySite flag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"IsSecuritySite flag",
        SerializedName = @"isSecuritySite",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsSecuritySite { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The key for vpn-site that can be used for connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The key for vpn-site that can be used for connections.",
        SerializedName = @"siteKey",
        PossibleTypes = new [] { typeof(string) })]
        string SiteKey { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualWanId { get; set; }

    }
    /// Parameters for VpnSite
    internal partial interface IVpnSitePropertiesInternal

    {
        /// <summary>The AddressSpace that contains an array of IP address ranges.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace AddressSpace { get; set; }
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        string[] AddressSpaceAddressPrefix { get; set; }
        /// <summary>The set of bgp properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettings BgpProperty { get; set; }
        /// <summary>The BGP speaker's ASN.</summary>
        long? BgpPropertyAsn { get; set; }
        /// <summary>The BGP peering address and BGP identifier of this BGP speaker.</summary>
        string BgpPropertyBgpPeeringAddress { get; set; }
        /// <summary>The weight added to routes learned from this BGP speaker.</summary>
        int? BgpPropertyPeerWeight { get; set; }
        /// <summary>The device properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDeviceProperties DeviceProperty { get; set; }
        /// <summary>Model of the device.</summary>
        string DevicePropertyDeviceModel { get; set; }
        /// <summary>Name of the device Vendor.</summary>
        string DevicePropertyDeviceVendor { get; set; }
        /// <summary>Link speed.</summary>
        int? DevicePropertyLinkSpeedInMbps { get; set; }
        /// <summary>The ip-address for the vpn-site.</summary>
        string IPAddress { get; set; }
        /// <summary>IsSecuritySite flag</summary>
        bool? IsSecuritySite { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The key for vpn-site that can be used for connections.</summary>
        string SiteKey { get; set; }
        /// <summary>The VirtualWAN to which the vpnSite belongs</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource VirtualWan { get; set; }
        /// <summary>Resource ID.</summary>
        string VirtualWanId { get; set; }

    }
}