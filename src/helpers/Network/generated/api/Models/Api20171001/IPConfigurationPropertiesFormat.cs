namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of IP configuration.</summary>
    public partial class IPConfigurationPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfigurationPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfigurationPropertiesFormatInternal
    {

        /// <summary>
        /// Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the
        /// fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record
        /// is created for the public IP in the Microsoft Azure DNS system.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DnsSettingDomainNameLabel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).DnsSettingDomainNameLabel; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).DnsSettingDomainNameLabel = value; }

        /// <summary>
        /// Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP. This is the concatenation
        /// of the domainNameLabel and the regionalized DNS zone.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DnsSettingFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).DnsSettingFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).DnsSettingFqdn = value; }

        /// <summary>
        /// Gets or Sets the Reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If
        /// the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain
        /// to the reverse FQDN.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DnsSettingReverseFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).DnsSettingReverseFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).DnsSettingReverseFqdn = value; }

        /// <summary>The IP address associated with the public IP address resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string IPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).IPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).IPAddress = value; }

        /// <summary>The IP configuration associated with the public IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration IPConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).IPConfiguration; }

        /// <summary>The idle timeout of the public IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? IdleTimeoutInMinutes { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).IdleTimeoutInMinutes; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).IdleTimeoutInMinutes = value; }

        /// <summary>Internal Acessors for DnsSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressDnsSettings Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfigurationPropertiesFormatInternal.DnsSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).DnsSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).DnsSetting = value; }

        /// <summary>Internal Acessors for IPConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfigurationPropertiesFormatInternal.IPConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).IPConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).IPConfiguration = value; }

        /// <summary>Internal Acessors for PublicIPAddress</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddress Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfigurationPropertiesFormatInternal.PublicIPAddress { get => (this._publicIPAddress = this._publicIPAddress ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.PublicIPAddress()); set { {_publicIPAddress = value;} } }

        /// <summary>Internal Acessors for PublicIPAddressName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfigurationPropertiesFormatInternal.PublicIPAddressName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)PublicIPAddress).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)PublicIPAddress).Name = value; }

        /// <summary>Internal Acessors for PublicIPAddressProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfigurationPropertiesFormatInternal.PublicIPAddressProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).Property = value; }

        /// <summary>Internal Acessors for PublicIPAddressSku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressSku Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfigurationPropertiesFormatInternal.PublicIPAddressSku { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).Sku; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).Sku = value; }

        /// <summary>Internal Acessors for PublicIPAddressType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfigurationPropertiesFormatInternal.PublicIPAddressType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)PublicIPAddress).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)PublicIPAddress).Type = value; }

        /// <summary>Backing field for <see cref="PrivateIPAddress" /> property.</summary>
        private string _privateIPAddress;

        /// <summary>The private IP address of the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string PrivateIPAddress { get => this._privateIPAddress; set => this._privateIPAddress = value; }

        /// <summary>Backing field for <see cref="PrivateIPAllocationMethod" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? _privateIPAllocationMethod;

        /// <summary>The private IP allocation method. Possible values are 'Static' and 'Dynamic'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PrivateIPAllocationMethod { get => this._privateIPAllocationMethod; set => this._privateIPAllocationMethod = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="PublicIPAddress" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddress _publicIPAddress;

        /// <summary>The reference of the public IP resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddress PublicIPAddress { get => (this._publicIPAddress = this._publicIPAddress ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.PublicIPAddress()); set => this._publicIPAddress = value; }

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PublicIPAddressEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).Etag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).Etag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PublicIPAddressId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)PublicIPAddress).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)PublicIPAddress).Id = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PublicIPAddressLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)PublicIPAddress).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)PublicIPAddress).Location = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PublicIPAddressName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)PublicIPAddress).Name; }

        /// <summary>
        /// The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PublicIPAddressPropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).ProvisioningState = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags PublicIPAddressTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)PublicIPAddress).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)PublicIPAddress).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PublicIPAddressType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)PublicIPAddress).Type; }

        /// <summary>The public IP address version. Possible values are: 'IPv4' and 'IPv6'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? PublicIPAddressVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).IPAddressVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).IPAddressVersion = value; }

        /// <summary>
        /// A list of availability zones denoting the IP allocated for the resource needs to come from.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] PublicIPAddressZone { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).Zone; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).Zone = value; }

        /// <summary>The public IP allocation method. Possible values are: 'Static' and 'Dynamic'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PublicIPAllocationMethod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).AllocationMethod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).AllocationMethod = value; }

        /// <summary>The resource GUID property of the public IP resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ResourceGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).ResourceGuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).ResourceGuid = value; }

        /// <summary>Name of a public IP address SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName? SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).SkuName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressInternal)PublicIPAddress).SkuName = value; }

        /// <summary>Backing field for <see cref="Subnet" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet _subnet;

        /// <summary>The reference of the subnet resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet Subnet { get => (this._subnet = this._subnet ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.Subnet()); set => this._subnet = value; }

        /// <summary>Creates an new <see cref="IPConfigurationPropertiesFormat" /> instance.</summary>
        public IPConfigurationPropertiesFormat()
        {

        }
    }
    /// Properties of IP configuration.
    public partial interface IIPConfigurationPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
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
        /// <summary>The private IP address of the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The private IP address of the IP configuration.",
        SerializedName = @"privateIPAddress",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateIPAddress { get; set; }
        /// <summary>The private IP allocation method. Possible values are 'Static' and 'Dynamic'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The private IP allocation method. Possible values are 'Static' and 'Dynamic'.",
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

    }
    /// Properties of IP configuration.
    internal partial interface IIPConfigurationPropertiesFormatInternal

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
        /// <summary>The IP address associated with the public IP address resource.</summary>
        string IPAddress { get; set; }
        /// <summary>The IP configuration associated with the public IP address.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration IPConfiguration { get; set; }
        /// <summary>The idle timeout of the public IP address.</summary>
        int? IdleTimeoutInMinutes { get; set; }
        /// <summary>The private IP address of the IP configuration.</summary>
        string PrivateIPAddress { get; set; }
        /// <summary>The private IP allocation method. Possible values are 'Static' and 'Dynamic'.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PrivateIPAllocationMethod { get; set; }
        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The reference of the public IP resource.</summary>
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

    }
}