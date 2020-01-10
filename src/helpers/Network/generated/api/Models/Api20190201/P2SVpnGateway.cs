namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>P2SVpnGateway Resource.</summary>
    public partial class P2SVpnGateway :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGateway,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal,
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
        public string[] CustomRouteAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).CustomRouteAddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).CustomRouteAddressPrefix = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Etag { get => this._etag; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Id = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 1)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Location = value; }

        /// <summary>Internal Acessors for CustomRoute</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal.CustomRoute { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).CustomRoute; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).CustomRoute = value; }

        /// <summary>Internal Acessors for Etag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal.Etag { get => this._etag; set { {_etag = value;} } }

        /// <summary>Internal Acessors for P2SVpnServerConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal.P2SVpnServerConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).P2SVpnServerConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).P2SVpnServerConfiguration = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayProperties Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.P2SVpnGatewayProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for VirtualHub</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal.VirtualHub { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).VirtualHub; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).VirtualHub = value; }

        /// <summary>Internal Acessors for VpnClientAddressPool</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal.VpnClientAddressPool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).VpnClientAddressPool; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).VpnClientAddressPool = value; }

        /// <summary>Internal Acessors for VpnClientConnectionHealth</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealth Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal.VpnClientConnectionHealth { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).VpnClientConnectionHealth; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).VpnClientConnectionHealth = value; }

        /// <summary>Internal Acessors for VpnClientEgressBytesTransferred</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal.VpnClientEgressBytesTransferred { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).VpnClientConnectionHealthTotalEgressBytesTransferred; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).VpnClientConnectionHealthTotalEgressBytesTransferred = value; }

        /// <summary>Internal Acessors for VpnClientIngressBytesTransferred</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayInternal.VpnClientIngressBytesTransferred { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).VpnClientConnectionHealthTotalIngressBytesTransferred; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).VpnClientConnectionHealthTotalIngressBytesTransferred = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 0)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string P2SVpnServerConfigurationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).P2SVpnServerConfigurationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).P2SVpnServerConfigurationId = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayProperties _property;

        /// <summary>Properties of the P2SVpnGateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.P2SVpnGatewayProperties()); set => this._property = value; }

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 3, Label = @"Provisioning State")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>The scale unit for this p2s vpn gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public int? ScaleUnit { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).VpnGatewayScaleUnit; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).VpnGatewayScaleUnit = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 2)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string VirtualHubId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).VirtualHubId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).VirtualHubId = value; }

        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string[] VpnClientAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).VpnClientAddressPoolAddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).VpnClientAddressPoolAddressPrefix = value; }

        /// <summary>List of allocated ip addresses to the connected p2s vpn clients.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string[] VpnClientAllocatedIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).VpnClientConnectionHealthAllocatedIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).VpnClientConnectionHealthAllocatedIPAddress = value; }

        /// <summary>The total of p2s vpn clients connected at this time to this P2SVpnGateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public int? VpnClientConnectionCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).VpnClientConnectionHealthVpnClientConnectionsCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).VpnClientConnectionHealthVpnClientConnectionsCount = value; }

        /// <summary>Total of the Egress Bytes Transferred in this connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public long? VpnClientEgressBytesTransferred { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).VpnClientConnectionHealthTotalEgressBytesTransferred; }

        /// <summary>Total of the Ingress Bytes Transferred in this P2S Vpn connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public long? VpnClientIngressBytesTransferred { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)Property).VpnClientConnectionHealthTotalIngressBytesTransferred; }

        /// <summary>Creates an new <see cref="P2SVpnGateway" /> instance.</summary>
        public P2SVpnGateway()
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
    /// P2SVpnGateway Resource.
    public partial interface IP2SVpnGateway :
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
        string[] CustomRouteAddressPrefix { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get;  }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string P2SVpnServerConfigurationId { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The scale unit for this p2s vpn gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The scale unit for this p2s vpn gateway.",
        SerializedName = @"vpnGatewayScaleUnit",
        PossibleTypes = new [] { typeof(int) })]
        int? ScaleUnit { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualHubId { get; set; }
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of address blocks reserved for this virtual network in CIDR notation.",
        SerializedName = @"addressPrefixes",
        PossibleTypes = new [] { typeof(string) })]
        string[] VpnClientAddressPrefix { get; set; }
        /// <summary>List of allocated ip addresses to the connected p2s vpn clients.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of allocated ip addresses to the connected p2s vpn clients.",
        SerializedName = @"allocatedIpAddresses",
        PossibleTypes = new [] { typeof(string) })]
        string[] VpnClientAllocatedIPAddress { get; set; }
        /// <summary>The total of p2s vpn clients connected at this time to this P2SVpnGateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The total of p2s vpn clients connected at this time to this P2SVpnGateway.",
        SerializedName = @"vpnClientConnectionsCount",
        PossibleTypes = new [] { typeof(int) })]
        int? VpnClientConnectionCount { get; set; }
        /// <summary>Total of the Egress Bytes Transferred in this connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Total of the Egress Bytes Transferred in this connection",
        SerializedName = @"totalEgressBytesTransferred",
        PossibleTypes = new [] { typeof(long) })]
        long? VpnClientEgressBytesTransferred { get;  }
        /// <summary>Total of the Ingress Bytes Transferred in this P2S Vpn connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Total of the Ingress Bytes Transferred in this P2S Vpn connection",
        SerializedName = @"totalIngressBytesTransferred",
        PossibleTypes = new [] { typeof(long) })]
        long? VpnClientIngressBytesTransferred { get;  }

    }
    /// P2SVpnGateway Resource.
    internal partial interface IP2SVpnGatewayInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal
    {
        /// <summary>
        /// The reference of the address space resource which represents the custom routes specified by the customer for P2SVpnGateway
        /// and P2S VpnClient.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace CustomRoute { get; set; }
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        string[] CustomRouteAddressPrefix { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>The P2SVpnServerConfiguration to which the p2sVpnGateway is attached to.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource P2SVpnServerConfiguration { get; set; }
        /// <summary>Resource ID.</summary>
        string P2SVpnServerConfigurationId { get; set; }
        /// <summary>Properties of the P2SVpnGateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayProperties Property { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The scale unit for this p2s vpn gateway.</summary>
        int? ScaleUnit { get; set; }
        /// <summary>The VirtualHub to which the gateway belongs</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource VirtualHub { get; set; }
        /// <summary>Resource ID.</summary>
        string VirtualHubId { get; set; }
        /// <summary>
        /// The reference of the address space resource which represents Address space for P2S VpnClient.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace VpnClientAddressPool { get; set; }
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        string[] VpnClientAddressPrefix { get; set; }
        /// <summary>List of allocated ip addresses to the connected p2s vpn clients.</summary>
        string[] VpnClientAllocatedIPAddress { get; set; }
        /// <summary>The total of p2s vpn clients connected at this time to this P2SVpnGateway.</summary>
        int? VpnClientConnectionCount { get; set; }
        /// <summary>All P2S VPN clients' connection health status.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealth VpnClientConnectionHealth { get; set; }
        /// <summary>Total of the Egress Bytes Transferred in this connection</summary>
        long? VpnClientEgressBytesTransferred { get; set; }
        /// <summary>Total of the Ingress Bytes Transferred in this P2S Vpn connection</summary>
        long? VpnClientIngressBytesTransferred { get; set; }

    }
}