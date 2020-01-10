namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>DNS settings of a network interface.</summary>
    public partial class NetworkInterfaceDnsSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceDnsSettings,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceDnsSettingsInternal
    {

        /// <summary>Backing field for <see cref="AppliedDnsServer" /> property.</summary>
        private string[] _appliedDnsServer;

        /// <summary>
        /// If the VM that uses this NIC is part of an Availability Set, then this list will have the union of all DNS servers from
        /// all NICs that are part of the Availability Set. This property is what is configured on each of those VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] AppliedDnsServer { get => this._appliedDnsServer; set => this._appliedDnsServer = value; }

        /// <summary>Backing field for <see cref="DnsServer" /> property.</summary>
        private string[] _dnsServer;

        /// <summary>
        /// List of DNS servers IP addresses. Use 'AzureProvidedDNS' to switch to azure provided DNS resolution. 'AzureProvidedDNS'
        /// value cannot be combined with other IPs, it must be the only value in dnsServers collection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] DnsServer { get => this._dnsServer; set => this._dnsServer = value; }

        /// <summary>Backing field for <see cref="InternalDnsNameLabel" /> property.</summary>
        private string _internalDnsNameLabel;

        /// <summary>
        /// Relative DNS name for this NIC used for internal communications between VMs in the same virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string InternalDnsNameLabel { get => this._internalDnsNameLabel; set => this._internalDnsNameLabel = value; }

        /// <summary>Backing field for <see cref="InternalDomainNameSuffix" /> property.</summary>
        private string _internalDomainNameSuffix;

        /// <summary>
        /// Even if internalDnsNameLabel is not specified, a DNS entry is created for the primary NIC of the VM. This DNS name can
        /// be constructed by concatenating the VM name with the value of internalDomainNameSuffix.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string InternalDomainNameSuffix { get => this._internalDomainNameSuffix; set => this._internalDomainNameSuffix = value; }

        /// <summary>Backing field for <see cref="InternalFqdn" /> property.</summary>
        private string _internalFqdn;

        /// <summary>
        /// Fully qualified DNS name supporting internal communications between VMs in the same virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string InternalFqdn { get => this._internalFqdn; set => this._internalFqdn = value; }

        /// <summary>Creates an new <see cref="NetworkInterfaceDnsSettings" /> instance.</summary>
        public NetworkInterfaceDnsSettings()
        {

        }
    }
    /// DNS settings of a network interface.
    public partial interface INetworkInterfaceDnsSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// If the VM that uses this NIC is part of an Availability Set, then this list will have the union of all DNS servers from
        /// all NICs that are part of the Availability Set. This property is what is configured on each of those VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If the VM that uses this NIC is part of an Availability Set, then this list will have the union of all DNS servers from all NICs that are part of the Availability Set. This property is what is configured on each of those VMs.",
        SerializedName = @"appliedDnsServers",
        PossibleTypes = new [] { typeof(string) })]
        string[] AppliedDnsServer { get; set; }
        /// <summary>
        /// List of DNS servers IP addresses. Use 'AzureProvidedDNS' to switch to azure provided DNS resolution. 'AzureProvidedDNS'
        /// value cannot be combined with other IPs, it must be the only value in dnsServers collection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of DNS servers IP addresses. Use 'AzureProvidedDNS' to switch to azure provided DNS resolution. 'AzureProvidedDNS' value cannot be combined with other IPs, it must be the only value in dnsServers collection.",
        SerializedName = @"dnsServers",
        PossibleTypes = new [] { typeof(string) })]
        string[] DnsServer { get; set; }
        /// <summary>
        /// Relative DNS name for this NIC used for internal communications between VMs in the same virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Relative DNS name for this NIC used for internal communications between VMs in the same virtual network.",
        SerializedName = @"internalDnsNameLabel",
        PossibleTypes = new [] { typeof(string) })]
        string InternalDnsNameLabel { get; set; }
        /// <summary>
        /// Even if internalDnsNameLabel is not specified, a DNS entry is created for the primary NIC of the VM. This DNS name can
        /// be constructed by concatenating the VM name with the value of internalDomainNameSuffix.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Even if internalDnsNameLabel is not specified, a DNS entry is created for the primary NIC of the VM. This DNS name can be constructed by concatenating the VM name with the value of internalDomainNameSuffix.",
        SerializedName = @"internalDomainNameSuffix",
        PossibleTypes = new [] { typeof(string) })]
        string InternalDomainNameSuffix { get; set; }
        /// <summary>
        /// Fully qualified DNS name supporting internal communications between VMs in the same virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Fully qualified DNS name supporting internal communications between VMs in the same virtual network.",
        SerializedName = @"internalFqdn",
        PossibleTypes = new [] { typeof(string) })]
        string InternalFqdn { get; set; }

    }
    /// DNS settings of a network interface.
    internal partial interface INetworkInterfaceDnsSettingsInternal

    {
        /// <summary>
        /// If the VM that uses this NIC is part of an Availability Set, then this list will have the union of all DNS servers from
        /// all NICs that are part of the Availability Set. This property is what is configured on each of those VMs.
        /// </summary>
        string[] AppliedDnsServer { get; set; }
        /// <summary>
        /// List of DNS servers IP addresses. Use 'AzureProvidedDNS' to switch to azure provided DNS resolution. 'AzureProvidedDNS'
        /// value cannot be combined with other IPs, it must be the only value in dnsServers collection.
        /// </summary>
        string[] DnsServer { get; set; }
        /// <summary>
        /// Relative DNS name for this NIC used for internal communications between VMs in the same virtual network.
        /// </summary>
        string InternalDnsNameLabel { get; set; }
        /// <summary>
        /// Even if internalDnsNameLabel is not specified, a DNS entry is created for the primary NIC of the VM. This DNS name can
        /// be constructed by concatenating the VM name with the value of internalDomainNameSuffix.
        /// </summary>
        string InternalDomainNameSuffix { get; set; }
        /// <summary>
        /// Fully qualified DNS name supporting internal communications between VMs in the same virtual network.
        /// </summary>
        string InternalFqdn { get; set; }

    }
}