namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Public IP address resource.</summary>
    public partial class PublicIPAddress :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.Resource();

        /// <summary>The public IP address allocation method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 3, Label = @"Allocation Method")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? AllocationMethod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).PublicIPAllocationMethod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).PublicIPAllocationMethod = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string DdosCustomPolicyId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).DdosCustomPolicyId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).DdosCustomPolicyId = value; }

        /// <summary>
        /// The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosSettingsProtectionCoverage? DdosProtectionCoverage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).DdosSettingProtectionCoverage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).DdosSettingProtectionCoverage = value; }

        /// <summary>
        /// Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the
        /// fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record
        /// is created for the public IP in the Microsoft Azure DNS system.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string DnsSettingDomainNameLabel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).DnsSettingDomainNameLabel; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).DnsSettingDomainNameLabel = value; }

        /// <summary>
        /// Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP. This is the concatenation
        /// of the domainNameLabel and the regionalized DNS zone.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string DnsSettingFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).DnsSettingFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).DnsSettingFqdn = value; }

        /// <summary>
        /// Gets or Sets the Reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If
        /// the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain
        /// to the reverse FQDN.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string DnsSettingReverseFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).DnsSettingReverseFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).DnsSettingReverseFqdn = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>The IP address associated with the public IP address resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 4, Label = @"IP Address")]
        public string IPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).IPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).IPAddress = value; }

        /// <summary>The public IP address version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 5, Label = @"Version")]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? IPAddressVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).PublicIPAddressVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).PublicIPAddressVersion = value; }

        /// <summary>The IP configuration associated with the public IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfiguration IPConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).IPConfiguration; }

        /// <summary>The list of tags associated with the public IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTag[] IPTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).IPTag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).IPTag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Id = value; }

        /// <summary>The idle timeout of the public IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 6, Label = @"Idle Timeout [minutes]")]
        public int? IdleTimeoutInMinutes { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).IdleTimeoutInMinutes; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).IdleTimeoutInMinutes = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 2)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Location = value; }

        /// <summary>Internal Acessors for DdosSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosSettings Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressInternal.DdosSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).DdosSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).DdosSetting = value; }

        /// <summary>Internal Acessors for DdosSettingDdosCustomPolicy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressInternal.DdosSettingDdosCustomPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).DdosSettingDdosCustomPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).DdosSettingDdosCustomPolicy = value; }

        /// <summary>Internal Acessors for DnsSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressDnsSettings Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressInternal.DnsSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).DnsSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).DnsSetting = value; }

        /// <summary>Internal Acessors for IPConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfiguration Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressInternal.IPConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).IPConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).IPConfiguration = value; }

        /// <summary>Internal Acessors for Prefix</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressInternal.Prefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).PublicIPPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).PublicIPPrefix = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PublicIPAddressPropertiesFormat()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressSku Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PublicIPAddressSku()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 1)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string PrefixId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).PublicIPPrefixId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).PublicIPPrefixId = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormat _property;

        /// <summary>Public IP address properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PublicIPAddressPropertiesFormat()); set => this._property = value; }

        /// <summary>
        /// The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 7, Label = @"Provisioning State")]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>The resource GUID property of the public IP resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 0, Label = @"GUID")]
        public string ResourceGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).ResourceGuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormatInternal)Property).ResourceGuid = value; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressSku _sku;

        /// <summary>The public IP address SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressSku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PublicIPAddressSku()); set => this._sku = value; }

        /// <summary>Name of a public IP address SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName? SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressSkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressSkuInternal)Sku).Name = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type; }

        /// <summary>Backing field for <see cref="Zone" /> property.</summary>
        private string[] _zone;

        /// <summary>
        /// A list of availability zones denoting the IP allocated for the resource needs to come from.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string[] Zone { get => this._zone; set => this._zone = value; }

        /// <summary>Creates an new <see cref="PublicIPAddress" /> instance.</summary>
        public PublicIPAddress()
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
    /// Public IP address resource.
    public partial interface IPublicIPAddress :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource
    {
        /// <summary>The public IP address allocation method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The public IP address allocation method.",
        SerializedName = @"publicIPAllocationMethod",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? AllocationMethod { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string DdosCustomPolicyId { get; set; }
        /// <summary>
        /// The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized.",
        SerializedName = @"protectionCoverage",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosSettingsProtectionCoverage) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosSettingsProtectionCoverage? DdosProtectionCoverage { get; set; }
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
        /// <summary>The public IP address version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The public IP address version.",
        SerializedName = @"publicIPAddressVersion",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? IPAddressVersion { get; set; }
        /// <summary>The IP configuration associated with the public IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The IP configuration associated with the public IP address.",
        SerializedName = @"ipConfiguration",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfiguration IPConfiguration { get;  }
        /// <summary>The list of tags associated with the public IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of tags associated with the public IP address.",
        SerializedName = @"ipTags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTag) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTag[] IPTag { get; set; }
        /// <summary>The idle timeout of the public IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The idle timeout of the public IP address.",
        SerializedName = @"idleTimeoutInMinutes",
        PossibleTypes = new [] { typeof(int) })]
        int? IdleTimeoutInMinutes { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string PrefixId { get; set; }
        /// <summary>
        /// The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }
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
    /// Public IP address resource.
    internal partial interface IPublicIPAddressInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal
    {
        /// <summary>The public IP address allocation method.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? AllocationMethod { get; set; }
        /// <summary>Resource ID.</summary>
        string DdosCustomPolicyId { get; set; }
        /// <summary>
        /// The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosSettingsProtectionCoverage? DdosProtectionCoverage { get; set; }
        /// <summary>The DDoS protection custom policy associated with the public IP address.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosSettings DdosSetting { get; set; }
        /// <summary>The DDoS custom policy associated with the public IP.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource DdosSettingDdosCustomPolicy { get; set; }
        /// <summary>The FQDN of the DNS record associated with the public IP address.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressDnsSettings DnsSetting { get; set; }
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
        /// <summary>The public IP address version.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? IPAddressVersion { get; set; }
        /// <summary>The IP configuration associated with the public IP address.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfiguration IPConfiguration { get; set; }
        /// <summary>The list of tags associated with the public IP address.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTag[] IPTag { get; set; }
        /// <summary>The idle timeout of the public IP address.</summary>
        int? IdleTimeoutInMinutes { get; set; }
        /// <summary>The Public IP Prefix this Public IP Address should be allocated from.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Prefix { get; set; }
        /// <summary>Resource ID.</summary>
        string PrefixId { get; set; }
        /// <summary>Public IP address properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressPropertiesFormat Property { get; set; }
        /// <summary>
        /// The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The resource GUID property of the public IP resource.</summary>
        string ResourceGuid { get; set; }
        /// <summary>The public IP address SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddressSku Sku { get; set; }
        /// <summary>Name of a public IP address SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName? SkuName { get; set; }
        /// <summary>
        /// A list of availability zones denoting the IP allocated for the resource needs to come from.
        /// </summary>
        string[] Zone { get; set; }

    }
}