namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Frontend IP address of the load balancer.</summary>
    public partial class FrontendIPConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource __subResource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource();

        /// <summary>
        /// Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the
        /// fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record
        /// is created for the public IP in the Microsoft Azure DNS system.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DnsSettingDomainNameLabel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).DnsSettingDomainNameLabel; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).DnsSettingDomainNameLabel = value; }

        /// <summary>
        /// Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP. This is the concatenation
        /// of the domainNameLabel and the regionalized DNS zone.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DnsSettingFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).DnsSettingFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).DnsSettingFqdn = value; }

        /// <summary>
        /// Gets or Sets the Reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If
        /// the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain
        /// to the reverse FQDN.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DnsSettingReverseFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).DnsSettingReverseFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).DnsSettingReverseFqdn = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>The IP address associated with the public IP address resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string IPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).IPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).IPAddress = value; }

        /// <summary>The IP configuration associated with the public IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration IPConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).IPConfiguration; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)__subResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)__subResource).Id = value; }

        /// <summary>The idle timeout of the public IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? IdleTimeoutInMinutes { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).IdleTimeoutInMinutes; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).IdleTimeoutInMinutes = value; }

        /// <summary>Read only. Inbound pools URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] InboundNatPool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).InboundNatPool; }

        /// <summary>Read only. Inbound rules URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] InboundNatRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).InboundNatRule; }

        /// <summary>Gets load balancing rules URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] LoadBalancingRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).LoadBalancingRule; }

        /// <summary>Internal Acessors for DnsSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressDnsSettings Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationInternal.DnsSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).DnsSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).DnsSetting = value; }

        /// <summary>Internal Acessors for IPConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationInternal.IPConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).IPConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).IPConfiguration = value; }

        /// <summary>Internal Acessors for InboundNatPool</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationInternal.InboundNatPool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).InboundNatPool; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).InboundNatPool = value; }

        /// <summary>Internal Acessors for InboundNatRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationInternal.InboundNatRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).InboundNatRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).InboundNatRule = value; }

        /// <summary>Internal Acessors for LoadBalancingRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationInternal.LoadBalancingRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).LoadBalancingRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).LoadBalancingRule = value; }

        /// <summary>Internal Acessors for OutboundNatRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationInternal.OutboundNatRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).OutboundNatRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).OutboundNatRule = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.FrontendIPConfigurationPropertiesFormat()); set { {_property = value;} } }

        /// <summary>Internal Acessors for PublicIPAddress</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddress Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationInternal.PublicIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddress = value; }

        /// <summary>Internal Acessors for PublicIPAddressName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationInternal.PublicIPAddressName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressName = value; }

        /// <summary>Internal Acessors for PublicIPAddressProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationInternal.PublicIPAddressProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressProperty = value; }

        /// <summary>Internal Acessors for PublicIPAddressSku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressSku Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationInternal.PublicIPAddressSku { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressSku; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressSku = value; }

        /// <summary>Internal Acessors for PublicIPAddressType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationInternal.PublicIPAddressType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressType = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Read only. Outbound rules URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] OutboundNatRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).OutboundNatRule; }

        /// <summary>The private IP address of the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PrivateIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PrivateIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PrivateIPAddress = value; }

        /// <summary>The Private IP allocation method. Possible values are: 'Static' and 'Dynamic'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PrivateIPAllocationMethod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PrivateIPAllocationMethod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PrivateIPAllocationMethod = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormat _property;

        /// <summary>Properties of the load balancer probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.FrontendIPConfigurationPropertiesFormat()); set => this._property = value; }

        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PublicIPAddressEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressEtag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressEtag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PublicIPAddressId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressId = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PublicIPAddressLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressLocation = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PublicIPAddressName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressName; }

        /// <summary>
        /// The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PublicIPAddressPropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressPropertiesProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressPropertiesProvisioningState = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags PublicIPAddressTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressTag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressTag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PublicIPAddressType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressType; }

        /// <summary>The public IP address version. Possible values are: 'IPv4' and 'IPv6'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? PublicIPAddressVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressVersion = value; }

        /// <summary>
        /// A list of availability zones denoting the IP allocated for the resource needs to come from.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] PublicIPAddressZone { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressZone; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressZone = value; }

        /// <summary>The public IP allocation method. Possible values are: 'Static' and 'Dynamic'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PublicIPAllocationMethod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAllocationMethod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).PublicIPAllocationMethod = value; }

        /// <summary>The resource GUID property of the public IP resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ResourceGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).ResourceGuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).ResourceGuid = value; }

        /// <summary>Name of a public IP address SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName? SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).SkuName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).SkuName = value; }

        /// <summary>The reference of the subnet resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet Subnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).Subnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormatInternal)Property).Subnet = value; }

        /// <summary>Backing field for <see cref="Zone" /> property.</summary>
        private string[] _zone;

        /// <summary>
        /// A list of availability zones denoting the IP allocated for the resource needs to come from.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] Zone { get => this._zone; set => this._zone = value; }

        /// <summary>Creates an new <see cref="FrontendIPConfiguration" /> instance.</summary>
        public FrontendIPConfiguration()
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
    /// Frontend IP address of the load balancer.
    public partial interface IFrontendIPConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource
    {
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
        /// <summary>Read only. Inbound pools URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Read only. Inbound pools URIs that use this frontend IP.",
        SerializedName = @"inboundNatPools",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] InboundNatPool { get;  }
        /// <summary>Read only. Inbound rules URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Read only. Inbound rules URIs that use this frontend IP.",
        SerializedName = @"inboundNatRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] InboundNatRule { get;  }
        /// <summary>Gets load balancing rules URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets load balancing rules URIs that use this frontend IP.",
        SerializedName = @"loadBalancingRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] LoadBalancingRule { get;  }
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
        /// <summary>Read only. Outbound rules URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Read only. Outbound rules URIs that use this frontend IP.",
        SerializedName = @"outboundNatRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] OutboundNatRule { get;  }
        /// <summary>The private IP address of the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The private IP address of the IP configuration.",
        SerializedName = @"privateIPAddress",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateIPAddress { get; set; }
        /// <summary>The Private IP allocation method. Possible values are: 'Static' and 'Dynamic'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Private IP allocation method. Possible values are: 'Static' and 'Dynamic'.",
        SerializedName = @"privateIPAllocationMethod",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PrivateIPAllocationMethod { get; set; }
        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
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
        /// <summary>The reference of the subnet resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reference of the subnet resource.",
        SerializedName = @"subnet",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet Subnet { get; set; }
        /// <summary>
        /// A list of availability zones denoting the IP allocated for the resource needs to come from.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of availability zones denoting the IP allocated for the resource needs to come from.",
        SerializedName = @"zones",
        PossibleTypes = new [] { typeof(string) })]
        string[] Zone { get; set; }

    }
    /// Frontend IP address of the load balancer.
    internal partial interface IFrontendIPConfigurationInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal
    {
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
        /// <summary>Read only. Inbound pools URIs that use this frontend IP.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] InboundNatPool { get; set; }
        /// <summary>Read only. Inbound rules URIs that use this frontend IP.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] InboundNatRule { get; set; }
        /// <summary>Gets load balancing rules URIs that use this frontend IP.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] LoadBalancingRule { get; set; }
        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        string Name { get; set; }
        /// <summary>Read only. Outbound rules URIs that use this frontend IP.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] OutboundNatRule { get; set; }
        /// <summary>The private IP address of the IP configuration.</summary>
        string PrivateIPAddress { get; set; }
        /// <summary>The Private IP allocation method. Possible values are: 'Static' and 'Dynamic'.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PrivateIPAllocationMethod { get; set; }
        /// <summary>Properties of the load balancer probe.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IFrontendIPConfigurationPropertiesFormat Property { get; set; }
        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The reference of the Public IP resource.</summary>
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
        /// <summary>The reference of the subnet resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet Subnet { get; set; }
        /// <summary>
        /// A list of availability zones denoting the IP allocated for the resource needs to come from.
        /// </summary>
        string[] Zone { get; set; }

    }
}