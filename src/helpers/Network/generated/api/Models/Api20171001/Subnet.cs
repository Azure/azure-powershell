namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Subnet in a virtual network resource.</summary>
    public partial class Subnet :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource __subResource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource();

        /// <summary>The address prefix for the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string AddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).AddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).AddressPrefix = value; }

        /// <summary>The default security rules of network security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[] DefaultSecurityRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).DefaultSecurityRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).DefaultSecurityRule = value; }

        /// <summary>
        /// Gets or sets whether to disable the routes learned by BGP on that route table. True means disable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? DisableBgpRoutePropagation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).DisableBgpRoutePropagation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).DisableBgpRoutePropagation = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>
        /// Gets an array of references to the network interface IP configurations using subnet.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration[] IPConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).IPConfiguration; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)__subResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)__subResource).Id = value; }

        /// <summary>Internal Acessors for IPConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal.IPConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).IPConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).IPConfiguration = value; }

        /// <summary>Internal Acessors for NetworkInterface</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal.NetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NetworkInterface; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NetworkInterface = value; }

        /// <summary>Internal Acessors for Nsg</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroup Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal.Nsg { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).Nsg; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).Nsg = value; }

        /// <summary>Internal Acessors for NsgName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal.NsgName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NsgName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NsgName = value; }

        /// <summary>Internal Acessors for NsgPropertiesSubnet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal.NsgPropertiesSubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NsgPropertiesSubnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NsgPropertiesSubnet = value; }

        /// <summary>Internal Acessors for NsgProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal.NsgProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NsgProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NsgProperty = value; }

        /// <summary>Internal Acessors for NsgType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal.NsgType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NsgType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NsgType = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubnetPropertiesFormat()); set { {_property = value;} } }

        /// <summary>Internal Acessors for RouteTable</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteTable Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal.RouteTable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).RouteTable; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).RouteTable = value; }

        /// <summary>Internal Acessors for RouteTableName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal.RouteTableName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).RouteTableName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).RouteTableName = value; }

        /// <summary>Internal Acessors for RouteTablePropertiesSubnet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal.RouteTablePropertiesSubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).RouteTablePropertiesSubnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).RouteTablePropertiesSubnet = value; }

        /// <summary>Internal Acessors for RouteTableProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteTablePropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal.RouteTableProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).RouteTableProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).RouteTableProperty = value; }

        /// <summary>Internal Acessors for RouteTableType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal.RouteTableType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).RouteTableType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).RouteTableType = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>A collection of references to network interfaces.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface[] NetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NetworkInterface; }

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NsgEtag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NsgEtag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NsgId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NsgId = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NsgLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NsgLocation = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NsgName; }

        /// <summary>
        /// The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgPropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NsgPropertiesProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NsgPropertiesProvisioningState = value; }

        /// <summary>A collection of references to subnets.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[] NsgPropertiesSubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NsgPropertiesSubnet; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags NsgTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NsgTag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NsgTag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).NsgType; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormat _property;

        /// <summary>Properties of the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubnetPropertiesFormat()); set => this._property = value; }

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>The resource GUID property of the network security group resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ResourceGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).ResourceGuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).ResourceGuid = value; }

        /// <summary>Gets an array of references to the external resources using subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceNavigationLink[] ResourceNavigationLink { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).ResourceNavigationLink; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).ResourceNavigationLink = value; }

        /// <summary>Collection of routes contained within a route table.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRoute[] Route { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).Route; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).Route = value; }

        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteTableEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).RouteTableEtag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).RouteTableEtag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteTableId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).RouteTableId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).RouteTableId = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteTableLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).RouteTableLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).RouteTableLocation = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteTableName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).RouteTableName; }

        /// <summary>
        /// The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteTablePropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).RouteTablePropertiesProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).RouteTablePropertiesProvisioningState = value; }

        /// <summary>A collection of references to subnets.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[] RouteTablePropertiesSubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).RouteTablePropertiesSubnet; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags RouteTableTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).RouteTableTag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).RouteTableTag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouteTableType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).RouteTableType; }

        /// <summary>A collection of security rules of the network security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[] SecurityRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).SecurityRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).SecurityRule = value; }

        /// <summary>An array of service endpoints.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IServiceEndpointPropertiesFormat[] ServiceEndpoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).ServiceEndpoint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormatInternal)Property).ServiceEndpoint = value; }

        /// <summary>Creates an new <see cref="Subnet" /> instance.</summary>
        public Subnet()
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
            await eventListener.AssertNotNull(nameof(__subResource), __subResource);
            await eventListener.AssertObjectIsValid(nameof(__subResource), __subResource);
        }
    }
    /// Subnet in a virtual network resource.
    public partial interface ISubnet :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource
    {
        /// <summary>The address prefix for the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The address prefix for the subnet.",
        SerializedName = @"addressPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string AddressPrefix { get; set; }
        /// <summary>The default security rules of network security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The default security rules of network security group.",
        SerializedName = @"defaultSecurityRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[] DefaultSecurityRule { get; set; }
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
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get; set; }
        /// <summary>
        /// Gets an array of references to the network interface IP configurations using subnet.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets an array of references to the network interface IP configurations using subnet.",
        SerializedName = @"ipConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration[] IPConfiguration { get;  }
        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the resource that is unique within a resource group. This name can be used to access the resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>A collection of references to network interfaces.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A collection of references to network interfaces.",
        SerializedName = @"networkInterfaces",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface[] NetworkInterface { get;  }
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[] NsgPropertiesSubnet { get;  }
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags NsgTag { get; set; }
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceNavigationLink) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceNavigationLink[] ResourceNavigationLink { get; set; }
        /// <summary>Collection of routes contained within a route table.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of routes contained within a route table.",
        SerializedName = @"routes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRoute) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRoute[] Route { get; set; }
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[] RouteTablePropertiesSubnet { get;  }
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags RouteTableTag { get; set; }
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[] SecurityRule { get; set; }
        /// <summary>An array of service endpoints.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"An array of service endpoints.",
        SerializedName = @"serviceEndpoints",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IServiceEndpointPropertiesFormat) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IServiceEndpointPropertiesFormat[] ServiceEndpoint { get; set; }

    }
    /// Subnet in a virtual network resource.
    internal partial interface ISubnetInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal
    {
        /// <summary>The address prefix for the subnet.</summary>
        string AddressPrefix { get; set; }
        /// <summary>The default security rules of network security group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[] DefaultSecurityRule { get; set; }
        /// <summary>
        /// Gets or sets whether to disable the routes learned by BGP on that route table. True means disable.
        /// </summary>
        bool? DisableBgpRoutePropagation { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>
        /// Gets an array of references to the network interface IP configurations using subnet.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration[] IPConfiguration { get; set; }
        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        string Name { get; set; }
        /// <summary>A collection of references to network interfaces.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface[] NetworkInterface { get; set; }
        /// <summary>The reference of the NetworkSecurityGroup resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroup Nsg { get; set; }
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
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[] NsgPropertiesSubnet { get; set; }
        /// <summary>Properties of the network security group</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupPropertiesFormat NsgProperty { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags NsgTag { get; set; }
        /// <summary>Resource type.</summary>
        string NsgType { get; set; }
        /// <summary>Properties of the subnet.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormat Property { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        string ProvisioningState { get; set; }
        /// <summary>The resource GUID property of the network security group resource.</summary>
        string ResourceGuid { get; set; }
        /// <summary>Gets an array of references to the external resources using subnet.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceNavigationLink[] ResourceNavigationLink { get; set; }
        /// <summary>Collection of routes contained within a route table.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRoute[] Route { get; set; }
        /// <summary>The reference of the RouteTable resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteTable RouteTable { get; set; }
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
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[] RouteTablePropertiesSubnet { get; set; }
        /// <summary>Properties of the route table.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteTablePropertiesFormat RouteTableProperty { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags RouteTableTag { get; set; }
        /// <summary>Resource type.</summary>
        string RouteTableType { get; set; }
        /// <summary>A collection of security rules of the network security group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[] SecurityRule { get; set; }
        /// <summary>An array of service endpoints.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IServiceEndpointPropertiesFormat[] ServiceEndpoint { get; set; }

    }
}