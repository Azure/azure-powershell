namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of the subnet.</summary>
    public partial class SubnetPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="AddressPrefix" /> property.</summary>
        private string _addressPrefix;

        /// <summary>The address prefix for the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string AddressPrefix { get => this._addressPrefix; set => this._addressPrefix = value; }

        /// <summary>Backing field for <see cref="AddressPrefixes" /> property.</summary>
        private string[] _addressPrefixes;

        /// <summary>List of address prefixes for the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] AddressPrefixes { get => this._addressPrefixes; set => this._addressPrefixes = value; }

        /// <summary>The default security rules of network security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] DefaultSecurityRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).DefaultSecurityRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).DefaultSecurityRule = value; }

        /// <summary>Backing field for <see cref="Delegation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDelegation[] _delegation;

        /// <summary>Gets an array of references to the delegations on the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDelegation[] Delegation { get => this._delegation; set => this._delegation = value; }

        /// <summary>
        /// Gets or sets whether to disable the routes learned by BGP on that route table. True means disable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? DisableBgpRoutePropagation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTableInternal)RouteTable).DisableBgpRoutePropagation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTableInternal)RouteTable).DisableBgpRoutePropagation = value; }

        /// <summary>Backing field for <see cref="IPConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfiguration[] _iPConfiguration;

        /// <summary>
        /// Gets an array of references to the network interface IP configurations using subnet.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfiguration[] IPConfiguration { get => this._iPConfiguration; }

        /// <summary>Backing field for <see cref="IPConfigurationProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfigurationProfile[] _iPConfigurationProfile;

        /// <summary>Array of IP configuration profiles which reference this subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfigurationProfile[] IPConfigurationProfile { get => this._iPConfigurationProfile; }

        /// <summary>Backing field for <see cref="InterfaceEndpoint" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpoint[] _interfaceEndpoint;

        /// <summary>An array of references to interface endpoints</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpoint[] InterfaceEndpoint { get => this._interfaceEndpoint; }

        /// <summary>Internal Acessors for IPConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfiguration[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetPropertiesFormatInternal.IPConfiguration { get => this._iPConfiguration; set { {_iPConfiguration = value;} } }

        /// <summary>Internal Acessors for IPConfigurationProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfigurationProfile[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetPropertiesFormatInternal.IPConfigurationProfile { get => this._iPConfigurationProfile; set { {_iPConfigurationProfile = value;} } }

        /// <summary>Internal Acessors for InterfaceEndpoint</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpoint[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetPropertiesFormatInternal.InterfaceEndpoint { get => this._interfaceEndpoint; set { {_interfaceEndpoint = value;} } }

        /// <summary>Internal Acessors for NatGateway</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetPropertiesFormatInternal.NatGateway { get => (this._natGateway = this._natGateway ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_natGateway = value;} } }

        /// <summary>Internal Acessors for NetworkInterface</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetPropertiesFormatInternal.NetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).NetworkInterface; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).NetworkInterface = value; }

        /// <summary>Internal Acessors for Nsg</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroup Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetPropertiesFormatInternal.Nsg { get => (this._nsg = this._nsg ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkSecurityGroup()); set { {_nsg = value;} } }

        /// <summary>Internal Acessors for NsgName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetPropertiesFormatInternal.NsgName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Name = value; }

        /// <summary>Internal Acessors for NsgPropertiesSubnet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetPropertiesFormatInternal.NsgPropertiesSubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).Subnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).Subnet = value; }

        /// <summary>Internal Acessors for NsgProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetPropertiesFormatInternal.NsgProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).Property = value; }

        /// <summary>Internal Acessors for NsgType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetPropertiesFormatInternal.NsgType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Type = value; }

        /// <summary>Internal Acessors for Purpose</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetPropertiesFormatInternal.Purpose { get => this._purpose; set { {_purpose = value;} } }

        /// <summary>Internal Acessors for RouteTable</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTable Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetPropertiesFormatInternal.RouteTable { get => (this._routeTable = this._routeTable ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.RouteTable()); set { {_routeTable = value;} } }

        /// <summary>Internal Acessors for RouteTableName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetPropertiesFormatInternal.RouteTableName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteTable).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteTable).Name = value; }

        /// <summary>Internal Acessors for RouteTablePropertiesSubnet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetPropertiesFormatInternal.RouteTablePropertiesSubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTableInternal)RouteTable).Subnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTableInternal)RouteTable).Subnet = value; }

        /// <summary>Internal Acessors for RouteTableProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTablePropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetPropertiesFormatInternal.RouteTableProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTableInternal)RouteTable).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTableInternal)RouteTable).Property = value; }

        /// <summary>Internal Acessors for RouteTableType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetPropertiesFormatInternal.RouteTableType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteTable).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteTable).Type = value; }

        /// <summary>Backing field for <see cref="NatGateway" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _natGateway;

        /// <summary>Nat gateway associated with this subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource NatGateway { get => (this._natGateway = this._natGateway ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._natGateway = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NatGatewayId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)NatGateway).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)NatGateway).Id = value; }

        /// <summary>A collection of references to network interfaces.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface[] NetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).NetworkInterface; }

        /// <summary>Backing field for <see cref="Nsg" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroup _nsg;

        /// <summary>The reference of the NetworkSecurityGroup resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroup Nsg { get => (this._nsg = this._nsg ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkSecurityGroup()); set => this._nsg = value; }

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).Etag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).Etag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Id = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Location = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Name; }

        /// <summary>
        /// The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgPropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).ProvisioningState = value; }

        /// <summary>A collection of references to subnets.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet[] NsgPropertiesSubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).Subnet; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags NsgTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Type; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="Purpose" /> property.</summary>
        private string _purpose;

        /// <summary>
        /// A read-only string identifying the intention of use for this subnet based on delegations and other user-defined properties.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Purpose { get => this._purpose; }

        /// <summary>The resource GUID property of the network security group resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ResourceGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).ResourceGuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).ResourceGuid = value; }

        /// <summary>Backing field for <see cref="ResourceNavigationLink" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceNavigationLink[] _resourceNavigationLink;

        /// <summary>Gets an array of references to the external resources using subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceNavigationLink[] ResourceNavigationLink { get => this._resourceNavigationLink; set => this._resourceNavigationLink = value; }

        /// <summary>Collection of routes contained within a route table.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRoute[] Route { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTableInternal)RouteTable).Route; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTableInternal)RouteTable).Route = value; }

        /// <summary>Backing field for <see cref="RouteTable" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTable _routeTable;

        /// <summary>The reference of the RouteTable resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTable RouteTable { get => (this._routeTable = this._routeTable ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.RouteTable()); set => this._routeTable = value; }

        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteTableEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTableInternal)RouteTable).Etag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTableInternal)RouteTable).Etag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteTableId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteTable).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteTable).Id = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteTableLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteTable).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteTable).Location = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteTableName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteTable).Name; }

        /// <summary>
        /// The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteTablePropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTableInternal)RouteTable).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTableInternal)RouteTable).ProvisioningState = value; }

        /// <summary>A collection of references to subnets.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet[] RouteTablePropertiesSubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTableInternal)RouteTable).Subnet; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags RouteTableTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteTable).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteTable).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteTableType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)RouteTable).Type; }

        /// <summary>A collection of security rules of the network security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] SecurityRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).SecurityRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).SecurityRule = value; }

        /// <summary>Backing field for <see cref="ServiceAssociationLink" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceAssociationLink[] _serviceAssociationLink;

        /// <summary>Gets an array of references to services injecting into this subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceAssociationLink[] ServiceAssociationLink { get => this._serviceAssociationLink; set => this._serviceAssociationLink = value; }

        /// <summary>Backing field for <see cref="ServiceEndpoint" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceEndpointPropertiesFormat[] _serviceEndpoint;

        /// <summary>An array of service endpoints.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceEndpointPropertiesFormat[] ServiceEndpoint { get => this._serviceEndpoint; set => this._serviceEndpoint = value; }

        /// <summary>Backing field for <see cref="ServiceEndpointPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceEndpointPolicy[] _serviceEndpointPolicy;

        /// <summary>An array of service endpoint policies.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceEndpointPolicy[] ServiceEndpointPolicy { get => this._serviceEndpointPolicy; set => this._serviceEndpointPolicy = value; }

        /// <summary>Creates an new <see cref="SubnetPropertiesFormat" /> instance.</summary>
        public SubnetPropertiesFormat()
        {

        }
    }
    /// Properties of the subnet.
    public partial interface ISubnetPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The address prefix for the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The address prefix for the subnet.",
        SerializedName = @"addressPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string AddressPrefix { get; set; }
        /// <summary>List of address prefixes for the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of  address prefixes for the subnet.",
        SerializedName = @"addressPrefixes",
        PossibleTypes = new [] { typeof(string) })]
        string[] AddressPrefixes { get; set; }
        /// <summary>The default security rules of network security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The default security rules of network security group.",
        SerializedName = @"defaultSecurityRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] DefaultSecurityRule { get; set; }
        /// <summary>Gets an array of references to the delegations on the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets an array of references to the delegations on the subnet.",
        SerializedName = @"delegations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDelegation) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDelegation[] Delegation { get; set; }
        /// <summary>
        /// Gets or sets whether to disable the routes learned by BGP on that route table. True means disable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets whether to disable the routes learned by BGP on that route table. True means disable.",
        SerializedName = @"disableBgpRoutePropagation",
        PossibleTypes = new [] { typeof(bool) })]
        bool? DisableBgpRoutePropagation { get; set; }
        /// <summary>
        /// Gets an array of references to the network interface IP configurations using subnet.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets an array of references to the network interface IP configurations using subnet.",
        SerializedName = @"ipConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfiguration[] IPConfiguration { get;  }
        /// <summary>Array of IP configuration profiles which reference this subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Array of IP configuration profiles which reference this subnet.",
        SerializedName = @"ipConfigurationProfiles",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfigurationProfile) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfigurationProfile[] IPConfigurationProfile { get;  }
        /// <summary>An array of references to interface endpoints</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"An array of references to interface endpoints ",
        SerializedName = @"interfaceEndpoints",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpoint) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpoint[] InterfaceEndpoint { get;  }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string NatGatewayId { get; set; }
        /// <summary>A collection of references to network interfaces.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A collection of references to network interfaces.",
        SerializedName = @"networkInterfaces",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface[] NetworkInterface { get;  }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string NsgEtag { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string NsgId { get; set; }
        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource location.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string NsgLocation { get; set; }
        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string NsgName { get;  }
        /// <summary>
        /// The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string NsgPropertiesProvisioningState { get; set; }
        /// <summary>A collection of references to subnets.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A collection of references to subnets.",
        SerializedName = @"subnets",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet[] NsgPropertiesSubnet { get;  }
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags NsgTag { get; set; }
        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string NsgType { get;  }
        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }
        /// <summary>
        /// A read-only string identifying the intention of use for this subnet based on delegations and other user-defined properties.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A read-only string identifying the intention of use for this subnet based on delegations and other user-defined properties.",
        SerializedName = @"purpose",
        PossibleTypes = new [] { typeof(string) })]
        string Purpose { get;  }
        /// <summary>The resource GUID property of the network security group resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource GUID property of the network security group resource.",
        SerializedName = @"resourceGuid",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGuid { get; set; }
        /// <summary>Gets an array of references to the external resources using subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets an array of references to the external resources using subnet.",
        SerializedName = @"resourceNavigationLinks",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceNavigationLink) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceNavigationLink[] ResourceNavigationLink { get; set; }
        /// <summary>Collection of routes contained within a route table.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of routes contained within a route table.",
        SerializedName = @"routes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRoute) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRoute[] Route { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets a unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string RouteTableEtag { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string RouteTableId { get; set; }
        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource location.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string RouteTableLocation { get; set; }
        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string RouteTableName { get;  }
        /// <summary>
        /// The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string RouteTablePropertiesProvisioningState { get; set; }
        /// <summary>A collection of references to subnets.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A collection of references to subnets.",
        SerializedName = @"subnets",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet[] RouteTablePropertiesSubnet { get;  }
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags RouteTableTag { get; set; }
        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string RouteTableType { get;  }
        /// <summary>A collection of security rules of the network security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of security rules of the network security group.",
        SerializedName = @"securityRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] SecurityRule { get; set; }
        /// <summary>Gets an array of references to services injecting into this subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets an array of references to services injecting into this subnet.",
        SerializedName = @"serviceAssociationLinks",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceAssociationLink) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceAssociationLink[] ServiceAssociationLink { get; set; }
        /// <summary>An array of service endpoints.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"An array of service endpoints.",
        SerializedName = @"serviceEndpoints",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceEndpointPropertiesFormat) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceEndpointPropertiesFormat[] ServiceEndpoint { get; set; }
        /// <summary>An array of service endpoint policies.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"An array of service endpoint policies.",
        SerializedName = @"serviceEndpointPolicies",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceEndpointPolicy) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceEndpointPolicy[] ServiceEndpointPolicy { get; set; }

    }
    /// Properties of the subnet.
    internal partial interface ISubnetPropertiesFormatInternal

    {
        /// <summary>The address prefix for the subnet.</summary>
        string AddressPrefix { get; set; }
        /// <summary>List of address prefixes for the subnet.</summary>
        string[] AddressPrefixes { get; set; }
        /// <summary>The default security rules of network security group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] DefaultSecurityRule { get; set; }
        /// <summary>Gets an array of references to the delegations on the subnet.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDelegation[] Delegation { get; set; }
        /// <summary>
        /// Gets or sets whether to disable the routes learned by BGP on that route table. True means disable.
        /// </summary>
        bool? DisableBgpRoutePropagation { get; set; }
        /// <summary>
        /// Gets an array of references to the network interface IP configurations using subnet.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfiguration[] IPConfiguration { get; set; }
        /// <summary>Array of IP configuration profiles which reference this subnet.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfigurationProfile[] IPConfigurationProfile { get; set; }
        /// <summary>An array of references to interface endpoints</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpoint[] InterfaceEndpoint { get; set; }
        /// <summary>Nat gateway associated with this subnet.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource NatGateway { get; set; }
        /// <summary>Resource ID.</summary>
        string NatGatewayId { get; set; }
        /// <summary>A collection of references to network interfaces.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface[] NetworkInterface { get; set; }
        /// <summary>The reference of the NetworkSecurityGroup resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroup Nsg { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string NsgEtag { get; set; }
        /// <summary>Resource ID.</summary>
        string NsgId { get; set; }
        /// <summary>Resource location.</summary>
        string NsgLocation { get; set; }
        /// <summary>Resource name.</summary>
        string NsgName { get; set; }
        /// <summary>
        /// The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string NsgPropertiesProvisioningState { get; set; }
        /// <summary>A collection of references to subnets.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet[] NsgPropertiesSubnet { get; set; }
        /// <summary>Properties of the network security group</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupPropertiesFormat NsgProperty { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags NsgTag { get; set; }
        /// <summary>Resource type.</summary>
        string NsgType { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        string ProvisioningState { get; set; }
        /// <summary>
        /// A read-only string identifying the intention of use for this subnet based on delegations and other user-defined properties.
        /// </summary>
        string Purpose { get; set; }
        /// <summary>The resource GUID property of the network security group resource.</summary>
        string ResourceGuid { get; set; }
        /// <summary>Gets an array of references to the external resources using subnet.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceNavigationLink[] ResourceNavigationLink { get; set; }
        /// <summary>Collection of routes contained within a route table.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRoute[] Route { get; set; }
        /// <summary>The reference of the RouteTable resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTable RouteTable { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        string RouteTableEtag { get; set; }
        /// <summary>Resource ID.</summary>
        string RouteTableId { get; set; }
        /// <summary>Resource location.</summary>
        string RouteTableLocation { get; set; }
        /// <summary>Resource name.</summary>
        string RouteTableName { get; set; }
        /// <summary>
        /// The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string RouteTablePropertiesProvisioningState { get; set; }
        /// <summary>A collection of references to subnets.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet[] RouteTablePropertiesSubnet { get; set; }
        /// <summary>Properties of the route table.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTablePropertiesFormat RouteTableProperty { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags RouteTableTag { get; set; }
        /// <summary>Resource type.</summary>
        string RouteTableType { get; set; }
        /// <summary>A collection of security rules of the network security group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] SecurityRule { get; set; }
        /// <summary>Gets an array of references to services injecting into this subnet.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceAssociationLink[] ServiceAssociationLink { get; set; }
        /// <summary>An array of service endpoints.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceEndpointPropertiesFormat[] ServiceEndpoint { get; set; }
        /// <summary>An array of service endpoint policies.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IServiceEndpointPolicy[] ServiceEndpointPolicy { get; set; }

    }
}