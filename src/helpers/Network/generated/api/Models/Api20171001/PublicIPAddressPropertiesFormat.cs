namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Public IP address properties.</summary>
    public partial class PublicIPAddressPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="DnsSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressDnsSettings _dnsSetting;

        /// <summary>The FQDN of the DNS record associated with the public IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressDnsSettings DnsSetting { get => (this._dnsSetting = this._dnsSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.PublicIPAddressDnsSettings()); set => this._dnsSetting = value; }

        /// <summary>
        /// Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the
        /// fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record
        /// is created for the public IP in the Microsoft Azure DNS system.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DnsSettingDomainNameLabel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressDnsSettingsInternal)DnsSetting).DomainNameLabel; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressDnsSettingsInternal)DnsSetting).DomainNameLabel = value; }

        /// <summary>
        /// Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP. This is the concatenation
        /// of the domainNameLabel and the regionalized DNS zone.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DnsSettingFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressDnsSettingsInternal)DnsSetting).Fqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressDnsSettingsInternal)DnsSetting).Fqdn = value; }

        /// <summary>
        /// Gets or Sets the Reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If
        /// the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain
        /// to the reverse FQDN.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DnsSettingReverseFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressDnsSettingsInternal)DnsSetting).ReverseFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressDnsSettingsInternal)DnsSetting).ReverseFqdn = value; }

        /// <summary>Backing field for <see cref="IPAddress" /> property.</summary>
        private string _iPAddress;

        /// <summary>The IP address associated with the public IP address resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string IPAddress { get => this._iPAddress; set => this._iPAddress = value; }

        /// <summary>Backing field for <see cref="IPConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration _iPConfiguration;

        /// <summary>The IP configuration associated with the public IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration IPConfiguration { get => (this._iPConfiguration = this._iPConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPConfiguration()); }

        /// <summary>Backing field for <see cref="IdleTimeoutInMinutes" /> property.</summary>
        private int? _idleTimeoutInMinutes;

        /// <summary>The idle timeout of the public IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? IdleTimeoutInMinutes { get => this._idleTimeoutInMinutes; set => this._idleTimeoutInMinutes = value; }

        /// <summary>Internal Acessors for DnsSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressDnsSettings Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressPropertiesFormatInternal.DnsSetting { get => (this._dnsSetting = this._dnsSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.PublicIPAddressDnsSettings()); set { {_dnsSetting = value;} } }

        /// <summary>Internal Acessors for IPConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressPropertiesFormatInternal.IPConfiguration { get => (this._iPConfiguration = this._iPConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPConfiguration()); set { {_iPConfiguration = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="PublicIPAddressVersion" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? _publicIPAddressVersion;

        /// <summary>The public IP address version. Possible values are: 'IPv4' and 'IPv6'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? PublicIPAddressVersion { get => this._publicIPAddressVersion; set => this._publicIPAddressVersion = value; }

        /// <summary>Backing field for <see cref="PublicIPAllocationMethod" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? _publicIPAllocationMethod;

        /// <summary>The public IP allocation method. Possible values are: 'Static' and 'Dynamic'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PublicIPAllocationMethod { get => this._publicIPAllocationMethod; set => this._publicIPAllocationMethod = value; }

        /// <summary>Backing field for <see cref="ResourceGuid" /> property.</summary>
        private string _resourceGuid;

        /// <summary>The resource GUID property of the public IP resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ResourceGuid { get => this._resourceGuid; set => this._resourceGuid = value; }

        /// <summary>Creates an new <see cref="PublicIPAddressPropertiesFormat" /> instance.</summary>
        public PublicIPAddressPropertiesFormat()
        {

        }
    }
    /// Public IP address properties.
    public partial interface IPublicIPAddressPropertiesFormat :
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
        /// <summary>The public IP address version. Possible values are: 'IPv4' and 'IPv6'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The public IP address version. Possible values are: 'IPv4' and 'IPv6'.",
        SerializedName = @"publicIPAddressVersion",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? PublicIPAddressVersion { get; set; }
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

    }
    /// Public IP address properties.
    internal partial interface IPublicIPAddressPropertiesFormatInternal

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
        /// <summary>
        /// The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The public IP address version. Possible values are: 'IPv4' and 'IPv6'.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? PublicIPAddressVersion { get; set; }
        /// <summary>The public IP allocation method. Possible values are: 'Static' and 'Dynamic'.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PublicIPAllocationMethod { get; set; }
        /// <summary>The resource GUID property of the public IP resource.</summary>
        string ResourceGuid { get; set; }

    }
}