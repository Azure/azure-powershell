namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>VpnSite Resource.</summary>
    public partial class VpnSite :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSite,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.Resource();

        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string[] AddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).AddressSpaceAddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).AddressSpaceAddressPrefix = value; }

        /// <summary>The BGP speaker's ASN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public long? BgpAsn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).BgpPropertyAsn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).BgpPropertyAsn = value; }

        /// <summary>The weight added to routes learned from this BGP speaker.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public int? BgpPeerWeight { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).BgpPropertyPeerWeight; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).BgpPropertyPeerWeight = value; }

        /// <summary>The BGP peering address and BGP identifier of this BGP speaker.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string BgpPeeringAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).BgpPropertyBgpPeeringAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).BgpPropertyBgpPeeringAddress = value; }

        /// <summary>Model of the device.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string DeviceModel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).DevicePropertyDeviceModel; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).DevicePropertyDeviceModel = value; }

        /// <summary>Name of the device Vendor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string DeviceVendor { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).DevicePropertyDeviceVendor; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).DevicePropertyDeviceVendor = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Etag { get => this._etag; }

        /// <summary>The ip-address for the vpn-site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string IPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).IPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).IPAddress = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Id = value; }

        /// <summary>Link speed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public int? LinkSpeedInMbps { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).DevicePropertyLinkSpeedInMbps; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).DevicePropertyLinkSpeedInMbps = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 1)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Location = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type = value; }

        /// <summary>Internal Acessors for AddressSpace</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal.AddressSpace { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).AddressSpace; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).AddressSpace = value; }

        /// <summary>Internal Acessors for BgpProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettings Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal.BgpProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).BgpProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).BgpProperty = value; }

        /// <summary>Internal Acessors for DeviceProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDeviceProperties Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal.DeviceProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).DeviceProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).DeviceProperty = value; }

        /// <summary>Internal Acessors for Etag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal.Etag { get => this._etag; set { {_etag = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteProperties Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnSiteProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for VirtualWan</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteInternal.VirtualWan { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).VirtualWan; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).VirtualWan = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 0)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteProperties _property;

        /// <summary>Properties of the VPN site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnSiteProperties()); set => this._property = value; }

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 4, Label = @"Provisioning State")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>IsSecuritySite flag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 3, Label = @"Security Site")]
        public bool? SecuritySite { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).IsSecuritySite; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).IsSecuritySite = value; }

        /// <summary>The key for vpn-site that can be used for connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 2, Label = @"Site Key")]
        public string SiteKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).SiteKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).SiteKey = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string VirtualWanId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).VirtualWanId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSitePropertiesInternal)Property).VirtualWanId = value; }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }

        /// <summary>Creates an new <see cref="VpnSite" /> instance.</summary>
        public VpnSite()
        {

        }
    }
    /// VpnSite Resource.
    public partial interface IVpnSite :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource
    {
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of address blocks reserved for this virtual network in CIDR notation.",
        SerializedName = @"addressPrefixes",
        PossibleTypes = new [] { typeof(string) })]
        string[] AddressPrefix { get; set; }
        /// <summary>The BGP speaker's ASN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The BGP speaker's ASN.",
        SerializedName = @"asn",
        PossibleTypes = new [] { typeof(long) })]
        long? BgpAsn { get; set; }
        /// <summary>The weight added to routes learned from this BGP speaker.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The weight added to routes learned from this BGP speaker.",
        SerializedName = @"peerWeight",
        PossibleTypes = new [] { typeof(int) })]
        int? BgpPeerWeight { get; set; }
        /// <summary>The BGP peering address and BGP identifier of this BGP speaker.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The BGP peering address and BGP identifier of this BGP speaker.",
        SerializedName = @"bgpPeeringAddress",
        PossibleTypes = new [] { typeof(string) })]
        string BgpPeeringAddress { get; set; }
        /// <summary>Model of the device.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Model of the device.",
        SerializedName = @"deviceModel",
        PossibleTypes = new [] { typeof(string) })]
        string DeviceModel { get; set; }
        /// <summary>Name of the device Vendor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the device Vendor.",
        SerializedName = @"deviceVendor",
        PossibleTypes = new [] { typeof(string) })]
        string DeviceVendor { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get;  }
        /// <summary>The ip-address for the vpn-site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ip-address for the vpn-site.",
        SerializedName = @"ipAddress",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddress { get; set; }
        /// <summary>Link speed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Link speed.",
        SerializedName = @"linkSpeedInMbps",
        PossibleTypes = new [] { typeof(int) })]
        int? LinkSpeedInMbps { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>IsSecuritySite flag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"IsSecuritySite flag",
        SerializedName = @"isSecuritySite",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SecuritySite { get; set; }
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
    /// VpnSite Resource.
    internal partial interface IVpnSiteInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal
    {
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        string[] AddressPrefix { get; set; }
        /// <summary>The AddressSpace that contains an array of IP address ranges.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace AddressSpace { get; set; }
        /// <summary>The BGP speaker's ASN.</summary>
        long? BgpAsn { get; set; }
        /// <summary>The weight added to routes learned from this BGP speaker.</summary>
        int? BgpPeerWeight { get; set; }
        /// <summary>The BGP peering address and BGP identifier of this BGP speaker.</summary>
        string BgpPeeringAddress { get; set; }
        /// <summary>The set of bgp properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettings BgpProperty { get; set; }
        /// <summary>Model of the device.</summary>
        string DeviceModel { get; set; }
        /// <summary>The device properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDeviceProperties DeviceProperty { get; set; }
        /// <summary>Name of the device Vendor.</summary>
        string DeviceVendor { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>The ip-address for the vpn-site.</summary>
        string IPAddress { get; set; }
        /// <summary>Link speed.</summary>
        int? LinkSpeedInMbps { get; set; }
        /// <summary>Properties of the VPN site.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSiteProperties Property { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>IsSecuritySite flag</summary>
        bool? SecuritySite { get; set; }
        /// <summary>The key for vpn-site that can be used for connections.</summary>
        string SiteKey { get; set; }
        /// <summary>The VirtualWAN to which the vpnSite belongs</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource VirtualWan { get; set; }
        /// <summary>Resource ID.</summary>
        string VirtualWanId { get; set; }

    }
}