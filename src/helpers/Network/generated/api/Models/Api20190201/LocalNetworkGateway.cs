namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>A common class for general resource information</summary>
    public partial class LocalNetworkGateway :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGateway,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal,
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
        public string[] AddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormatInternal)Property).LocalNetworkAddressSpaceAddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormatInternal)Property).LocalNetworkAddressSpaceAddressPrefix = value; }

        /// <summary>The BGP speaker's ASN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public long? BgpAsn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormatInternal)Property).BgpSettingAsn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormatInternal)Property).BgpSettingAsn = value; }

        /// <summary>The weight added to routes learned from this BGP speaker.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public int? BgpPeerWeight { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormatInternal)Property).BgpSettingPeerWeight; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormatInternal)Property).BgpSettingPeerWeight = value; }

        /// <summary>The BGP peering address and BGP identifier of this BGP speaker.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string BgpPeeringAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormatInternal)Property).BgpSettingBgpPeeringAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormatInternal)Property).BgpSettingBgpPeeringAddress = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>IP address of local network gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 3, Label = @"Gateway IP Address")]
        public string GatewayIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormatInternal)Property).GatewayIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormatInternal)Property).GatewayIPAddress = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Id = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 2)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Location = value; }

        /// <summary>Internal Acessors for BgpSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettings Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal.BgpSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormatInternal)Property).BgpSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormatInternal)Property).BgpSetting = value; }

        /// <summary>Internal Acessors for LocalNetworkAddressSpace</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal.LocalNetworkAddressSpace { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormatInternal)Property).LocalNetworkAddressSpace; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormatInternal)Property).LocalNetworkAddressSpace = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.LocalNetworkGatewayPropertiesFormat()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 1)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormat _property;

        /// <summary>Properties of the local network gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.LocalNetworkGatewayPropertiesFormat()); set => this._property = value; }

        /// <summary>
        /// The provisioning state of the LocalNetworkGateway resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 4, Label = @"Provisioning State")]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormatInternal)Property).ProvisioningState; }

        /// <summary>The resource GUID property of the LocalNetworkGateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 0, Label = @"GUID")]
        public string ResourceGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormatInternal)Property).ResourceGuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormatInternal)Property).ResourceGuid = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="LocalNetworkGateway" /> instance.</summary>
        public LocalNetworkGateway()
        {

        }

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
    }
    /// A common class for general resource information
    public partial interface ILocalNetworkGateway :
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
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get; set; }
        /// <summary>IP address of local network gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"IP address of local network gateway.",
        SerializedName = @"gatewayIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string GatewayIPAddress { get; set; }
        /// <summary>
        /// The provisioning state of the LocalNetworkGateway resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the LocalNetworkGateway resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>The resource GUID property of the LocalNetworkGateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource GUID property of the LocalNetworkGateway resource.",
        SerializedName = @"resourceGuid",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGuid { get; set; }

    }
    /// A common class for general resource information
    internal partial interface ILocalNetworkGatewayInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal
    {
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        string[] AddressPrefix { get; set; }
        /// <summary>The BGP speaker's ASN.</summary>
        long? BgpAsn { get; set; }
        /// <summary>The weight added to routes learned from this BGP speaker.</summary>
        int? BgpPeerWeight { get; set; }
        /// <summary>The BGP peering address and BGP identifier of this BGP speaker.</summary>
        string BgpPeeringAddress { get; set; }
        /// <summary>Local network gateway's BGP speaker settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettings BgpSetting { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>IP address of local network gateway.</summary>
        string GatewayIPAddress { get; set; }
        /// <summary>Local network site address space.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace LocalNetworkAddressSpace { get; set; }
        /// <summary>Properties of the local network gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormat Property { get; set; }
        /// <summary>
        /// The provisioning state of the LocalNetworkGateway resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The resource GUID property of the LocalNetworkGateway resource.</summary>
        string ResourceGuid { get; set; }

    }
}