namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>IPConfiguration in a network interface.</summary>
    public partial class NetworkInterfaceIPConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource __subResource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource();

        /// <summary>The reference of ApplicationGatewayBackendAddressPool resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendAddressPool[] ApplicationGatewayBackendAddressPool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).ApplicationGatewayBackendAddressPool; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).ApplicationGatewayBackendAddressPool = value; }

        /// <summary>Application security groups in which the IP configuration is included.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationSecurityGroup[] ApplicationSecurityGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).ApplicationSecurityGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).ApplicationSecurityGroup = value; }

        /// <summary>
        /// Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the
        /// fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record
        /// is created for the public IP in the Microsoft Azure DNS system.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DnsSettingDomainNameLabel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).DnsSettingDomainNameLabel; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).DnsSettingDomainNameLabel = value; }

        /// <summary>
        /// Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP. This is the concatenation
        /// of the domainNameLabel and the regionalized DNS zone.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DnsSettingFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).DnsSettingFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).DnsSettingFqdn = value; }

        /// <summary>
        /// Gets or Sets the Reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If
        /// the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain
        /// to the reverse FQDN.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DnsSettingReverseFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).DnsSettingReverseFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).DnsSettingReverseFqdn = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>The IP address associated with the public IP address resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string IPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).IPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).IPAddress = value; }

        /// <summary>The IP configuration associated with the public IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration IPConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).IPConfiguration; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)__subResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)__subResource).Id = value; }

        /// <summary>The idle timeout of the public IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? IdleTimeoutInMinutes { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).IdleTimeoutInMinutes; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).IdleTimeoutInMinutes = value; }

        /// <summary>The reference of LoadBalancerBackendAddressPool resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBackendAddressPool[] LoadBalancerBackendAddressPool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).LoadBalancerBackendAddressPool; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).LoadBalancerBackendAddressPool = value; }

        /// <summary>A list of references of LoadBalancerInboundNatRules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatRule[] LoadBalancerInboundNatRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).LoadBalancerInboundNatRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).LoadBalancerInboundNatRule = value; }

        /// <summary>Internal Acessors for DnsSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressDnsSettings Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal.DnsSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).DnsSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).DnsSetting = value; }

        /// <summary>Internal Acessors for IPConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal.IPConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).IPConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).IPConfiguration = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfaceIPConfigurationPropertiesFormat()); set { {_property = value;} } }

        /// <summary>Internal Acessors for PublicIPAddress</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddress Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal.PublicIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddress = value; }

        /// <summary>Internal Acessors for PublicIPAddressName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal.PublicIPAddressName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressName = value; }

        /// <summary>Internal Acessors for PublicIPAddressProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal.PublicIPAddressProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressProperty = value; }

        /// <summary>Internal Acessors for PublicIPAddressSku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressSku Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal.PublicIPAddressSku { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressSku; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressSku = value; }

        /// <summary>Internal Acessors for PublicIPAddressType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal.PublicIPAddressType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressType = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Gets whether this is a primary customer address on the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? Primary { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).Primary; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).Primary = value; }

        /// <summary>Private IP address of the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PrivateIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PrivateIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PrivateIPAddress = value; }

        /// <summary>
        /// Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default
        /// is taken as IPv4. Possible values are: 'IPv4' and 'IPv6'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? PrivateIPAddressVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PrivateIPAddressVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PrivateIPAddressVersion = value; }

        /// <summary>
        /// Defines how a private IP address is assigned. Possible values are: 'Static' and 'Dynamic'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PrivateIPAllocationMethod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PrivateIPAllocationMethod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PrivateIPAllocationMethod = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormat _property;

        /// <summary>Network interface IP configuration properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfaceIPConfigurationPropertiesFormat()); set => this._property = value; }

        /// <summary>
        /// The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PublicIPAddressEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressEtag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressEtag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PublicIPAddressId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressId = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PublicIPAddressLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressLocation = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PublicIPAddressName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressName; }

        /// <summary>
        /// The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PublicIPAddressPropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressPropertiesProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressPropertiesProvisioningState = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags PublicIPAddressTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressTag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressTag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PublicIPAddressType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressType; }

        /// <summary>The public IP address version. Possible values are: 'IPv4' and 'IPv6'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? PublicIPAddressVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressVersion = value; }

        /// <summary>
        /// A list of availability zones denoting the IP allocated for the resource needs to come from.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] PublicIPAddressZone { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressZone; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressZone = value; }

        /// <summary>The public IP allocation method. Possible values are: 'Static' and 'Dynamic'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PublicIPAllocationMethod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAllocationMethod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).PublicIPAllocationMethod = value; }

        /// <summary>The resource GUID property of the public IP resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ResourceGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).ResourceGuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).ResourceGuid = value; }

        /// <summary>Name of a public IP address SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName? SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).SkuName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).SkuName = value; }

        /// <summary>Subnet bound to the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet Subnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).Subnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormatInternal)Property).Subnet = value; }

        /// <summary>Creates an new <see cref="NetworkInterfaceIPConfiguration" /> instance.</summary>
        public NetworkInterfaceIPConfiguration()
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
    /// IPConfiguration in a network interface.
    public partial interface INetworkInterfaceIPConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource
    {
        /// <summary>The reference of ApplicationGatewayBackendAddressPool resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reference of ApplicationGatewayBackendAddressPool resource.",
        SerializedName = @"applicationGatewayBackendAddressPools",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendAddressPool) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendAddressPool[] ApplicationGatewayBackendAddressPool { get; set; }
        /// <summary>Application security groups in which the IP configuration is included.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Application security groups in which the IP configuration is included.",
        SerializedName = @"applicationSecurityGroups",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationSecurityGroup) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationSecurityGroup[] ApplicationSecurityGroup { get; set; }
        /// <summary>
        /// Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the
        /// fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record
        /// is created for the public IP in the Microsoft Azure DNS system.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record is created for the public IP in the Microsoft Azure DNS system.",
        SerializedName = @"domainNameLabel",
        PossibleTypes = new [] { typeof(string) })]
        string DnsSettingDomainNameLabel { get; set; }
        /// <summary>
        /// Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP. This is the concatenation
        /// of the domainNameLabel and the regionalized DNS zone.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP. This is the concatenation of the domainNameLabel and the regionalized DNS zone.",
        SerializedName = @"fqdn",
        PossibleTypes = new [] { typeof(string) })]
        string DnsSettingFqdn { get; set; }
        /// <summary>
        /// Gets or Sets the Reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If
        /// the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain
        /// to the reverse FQDN.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or Sets the Reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain to the reverse FQDN. ",
        SerializedName = @"reverseFqdn",
        PossibleTypes = new [] { typeof(string) })]
        string DnsSettingReverseFqdn { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get; set; }
        /// <summary>The IP address associated with the public IP address resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The IP address associated with the public IP address resource.",
        SerializedName = @"ipAddress",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddress { get; set; }
        /// <summary>The IP configuration associated with the public IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The IP configuration associated with the public IP address.",
        SerializedName = @"ipConfiguration",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration IPConfiguration { get;  }
        /// <summary>The idle timeout of the public IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The idle timeout of the public IP address.",
        SerializedName = @"idleTimeoutInMinutes",
        PossibleTypes = new [] { typeof(int) })]
        int? IdleTimeoutInMinutes { get; set; }
        /// <summary>The reference of LoadBalancerBackendAddressPool resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reference of LoadBalancerBackendAddressPool resource.",
        SerializedName = @"loadBalancerBackendAddressPools",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBackendAddressPool) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBackendAddressPool[] LoadBalancerBackendAddressPool { get; set; }
        /// <summary>A list of references of LoadBalancerInboundNatRules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of references of LoadBalancerInboundNatRules.",
        SerializedName = @"loadBalancerInboundNatRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatRule[] LoadBalancerInboundNatRule { get; set; }
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
        /// <summary>Gets whether this is a primary customer address on the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets whether this is a primary customer address on the network interface.",
        SerializedName = @"primary",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Primary { get; set; }
        /// <summary>Private IP address of the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Private IP address of the IP configuration.",
        SerializedName = @"privateIPAddress",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateIPAddress { get; set; }
        /// <summary>
        /// Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default
        /// is taken as IPv4. Possible values are: 'IPv4' and 'IPv6'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.  Possible values are: 'IPv4' and 'IPv6'.",
        SerializedName = @"privateIPAddressVersion",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? PrivateIPAddressVersion { get; set; }
        /// <summary>
        /// Defines how a private IP address is assigned. Possible values are: 'Static' and 'Dynamic'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Defines how a private IP address is assigned. Possible values are: 'Static' and 'Dynamic'.",
        SerializedName = @"privateIPAllocationMethod",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PrivateIPAllocationMethod { get; set; }
        /// <summary>
        /// The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string PublicIPAddressEtag { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string PublicIPAddressId { get; set; }
        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource location.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string PublicIPAddressLocation { get; set; }
        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string PublicIPAddressName { get;  }
        /// <summary>
        /// The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string PublicIPAddressPropertiesProvisioningState { get; set; }
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags PublicIPAddressTag { get; set; }
        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string PublicIPAddressType { get;  }
        /// <summary>The public IP address version. Possible values are: 'IPv4' and 'IPv6'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The public IP address version. Possible values are: 'IPv4' and 'IPv6'.",
        SerializedName = @"publicIPAddressVersion",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? PublicIPAddressVersion { get; set; }
        /// <summary>
        /// A list of availability zones denoting the IP allocated for the resource needs to come from.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of availability zones denoting the IP allocated for the resource needs to come from.",
        SerializedName = @"zones",
        PossibleTypes = new [] { typeof(string) })]
        string[] PublicIPAddressZone { get; set; }
        /// <summary>The public IP allocation method. Possible values are: 'Static' and 'Dynamic'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The public IP allocation method. Possible values are: 'Static' and 'Dynamic'.",
        SerializedName = @"publicIPAllocationMethod",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PublicIPAllocationMethod { get; set; }
        /// <summary>The resource GUID property of the public IP resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource GUID property of the public IP resource.",
        SerializedName = @"resourceGuid",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGuid { get; set; }
        /// <summary>Name of a public IP address SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of a public IP address SKU.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName? SkuName { get; set; }
        /// <summary>Subnet bound to the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Subnet bound to the IP configuration.",
        SerializedName = @"subnet",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet Subnet { get; set; }

    }
    /// IPConfiguration in a network interface.
    internal partial interface INetworkInterfaceIPConfigurationInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal
    {
        /// <summary>The reference of ApplicationGatewayBackendAddressPool resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendAddressPool[] ApplicationGatewayBackendAddressPool { get; set; }
        /// <summary>Application security groups in which the IP configuration is included.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationSecurityGroup[] ApplicationSecurityGroup { get; set; }
        /// <summary>The FQDN of the DNS record associated with the public IP address.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressDnsSettings DnsSetting { get; set; }
        /// <summary>
        /// Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the
        /// fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record
        /// is created for the public IP in the Microsoft Azure DNS system.
        /// </summary>
        string DnsSettingDomainNameLabel { get; set; }
        /// <summary>
        /// Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP. This is the concatenation
        /// of the domainNameLabel and the regionalized DNS zone.
        /// </summary>
        string DnsSettingFqdn { get; set; }
        /// <summary>
        /// Gets or Sets the Reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If
        /// the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain
        /// to the reverse FQDN.
        /// </summary>
        string DnsSettingReverseFqdn { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>The IP address associated with the public IP address resource.</summary>
        string IPAddress { get; set; }
        /// <summary>The IP configuration associated with the public IP address.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration IPConfiguration { get; set; }
        /// <summary>The idle timeout of the public IP address.</summary>
        int? IdleTimeoutInMinutes { get; set; }
        /// <summary>The reference of LoadBalancerBackendAddressPool resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBackendAddressPool[] LoadBalancerBackendAddressPool { get; set; }
        /// <summary>A list of references of LoadBalancerInboundNatRules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatRule[] LoadBalancerInboundNatRule { get; set; }
        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        string Name { get; set; }
        /// <summary>Gets whether this is a primary customer address on the network interface.</summary>
        bool? Primary { get; set; }
        /// <summary>Private IP address of the IP configuration.</summary>
        string PrivateIPAddress { get; set; }
        /// <summary>
        /// Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default
        /// is taken as IPv4. Possible values are: 'IPv4' and 'IPv6'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? PrivateIPAddressVersion { get; set; }
        /// <summary>
        /// Defines how a private IP address is assigned. Possible values are: 'Static' and 'Dynamic'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PrivateIPAllocationMethod { get; set; }
        /// <summary>Network interface IP configuration properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormat Property { get; set; }
        /// <summary>
        /// The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>Public IP address bound to the IP configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddress PublicIPAddress { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string PublicIPAddressEtag { get; set; }
        /// <summary>Resource ID.</summary>
        string PublicIPAddressId { get; set; }
        /// <summary>Resource location.</summary>
        string PublicIPAddressLocation { get; set; }
        /// <summary>Resource name.</summary>
        string PublicIPAddressName { get; set; }
        /// <summary>
        /// The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string PublicIPAddressPropertiesProvisioningState { get; set; }
        /// <summary>Public IP address properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressPropertiesFormat PublicIPAddressProperty { get; set; }
        /// <summary>The public IP address SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressSku PublicIPAddressSku { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags PublicIPAddressTag { get; set; }
        /// <summary>Resource type.</summary>
        string PublicIPAddressType { get; set; }
        /// <summary>The public IP address version. Possible values are: 'IPv4' and 'IPv6'.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? PublicIPAddressVersion { get; set; }
        /// <summary>
        /// A list of availability zones denoting the IP allocated for the resource needs to come from.
        /// </summary>
        string[] PublicIPAddressZone { get; set; }
        /// <summary>The public IP allocation method. Possible values are: 'Static' and 'Dynamic'.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PublicIPAllocationMethod { get; set; }
        /// <summary>The resource GUID property of the public IP resource.</summary>
        string ResourceGuid { get; set; }
        /// <summary>Name of a public IP address SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName? SkuName { get; set; }
        /// <summary>Subnet bound to the IP configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet Subnet { get; set; }

    }
}