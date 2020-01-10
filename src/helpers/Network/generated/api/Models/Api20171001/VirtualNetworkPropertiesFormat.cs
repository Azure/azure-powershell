namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of the virtual network.</summary>
    public partial class VirtualNetworkPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="AddressSpace" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAddressSpace _addressSpace;

        /// <summary>
        /// The AddressSpace that contains an array of IP address ranges that can be used by subnets.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAddressSpace AddressSpace { get => (this._addressSpace = this._addressSpace ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.AddressSpace()); set => this._addressSpace = value; }

        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] AddressSpaceAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAddressSpaceInternal)AddressSpace).AddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAddressSpaceInternal)AddressSpace).AddressPrefix = value; }

        /// <summary>Backing field for <see cref="DhcpOption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IDhcpOptions _dhcpOption;

        /// <summary>
        /// The dhcpOptions that contains an array of DNS servers available to VMs deployed in the virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IDhcpOptions DhcpOption { get => (this._dhcpOption = this._dhcpOption ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.DhcpOptions()); set => this._dhcpOption = value; }

        /// <summary>The list of DNS servers IP addresses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] DhcpOptionDnsServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IDhcpOptionsInternal)DhcpOption).DnsServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IDhcpOptionsInternal)DhcpOption).DnsServer = value; }

        /// <summary>Backing field for <see cref="EnableDdosProtection" /> property.</summary>
        private bool? _enableDdosProtection;

        /// <summary>
        /// Indicates if DDoS protection is enabled for all the protected resources in a Virtual Network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? EnableDdosProtection { get => this._enableDdosProtection; set => this._enableDdosProtection = value; }

        /// <summary>Backing field for <see cref="EnableVMProtection" /> property.</summary>
        private bool? _enableVMProtection;

        /// <summary>Indicates if Vm protection is enabled for all the subnets in a Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? EnableVMProtection { get => this._enableVMProtection; set => this._enableVMProtection = value; }

        /// <summary>Internal Acessors for AddressSpace</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAddressSpace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPropertiesFormatInternal.AddressSpace { get => (this._addressSpace = this._addressSpace ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.AddressSpace()); set { {_addressSpace = value;} } }

        /// <summary>Internal Acessors for DhcpOption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IDhcpOptions Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPropertiesFormatInternal.DhcpOption { get => (this._dhcpOption = this._dhcpOption ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.DhcpOptions()); set { {_dhcpOption = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="ResourceGuid" /> property.</summary>
        private string _resourceGuid;

        /// <summary>The resourceGuid property of the Virtual Network resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ResourceGuid { get => this._resourceGuid; set => this._resourceGuid = value; }

        /// <summary>Backing field for <see cref="Subnet" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[] _subnet;

        /// <summary>A list of subnets in a Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[] Subnet { get => this._subnet; set => this._subnet = value; }

        /// <summary>Backing field for <see cref="VnetPeering" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeering[] _vnetPeering;

        /// <summary>A list of peerings in a Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeering[] VnetPeering { get => this._vnetPeering; set => this._vnetPeering = value; }

        /// <summary>Creates an new <see cref="VirtualNetworkPropertiesFormat" /> instance.</summary>
        public VirtualNetworkPropertiesFormat()
        {

        }
    }
    /// Properties of the virtual network.
    public partial interface IVirtualNetworkPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of address blocks reserved for this virtual network in CIDR notation.",
        SerializedName = @"addressPrefixes",
        PossibleTypes = new [] { typeof(string) })]
        string[] AddressSpaceAddressPrefix { get; set; }
        /// <summary>The list of DNS servers IP addresses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of DNS servers IP addresses.",
        SerializedName = @"dnsServers",
        PossibleTypes = new [] { typeof(string) })]
        string[] DhcpOptionDnsServer { get; set; }
        /// <summary>
        /// Indicates if DDoS protection is enabled for all the protected resources in a Virtual Network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates if DDoS protection is enabled for all the protected resources in a Virtual Network.",
        SerializedName = @"enableDdosProtection",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableDdosProtection { get; set; }
        /// <summary>Indicates if Vm protection is enabled for all the subnets in a Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates if Vm protection is enabled for all the subnets in a Virtual Network.",
        SerializedName = @"enableVmProtection",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableVMProtection { get; set; }
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
        /// <summary>The resourceGuid property of the Virtual Network resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resourceGuid property of the Virtual Network resource.",
        SerializedName = @"resourceGuid",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGuid { get; set; }
        /// <summary>A list of subnets in a Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of subnets in a Virtual Network.",
        SerializedName = @"subnets",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[] Subnet { get; set; }
        /// <summary>A list of peerings in a Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of peerings in a Virtual Network.",
        SerializedName = @"virtualNetworkPeerings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeering) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeering[] VnetPeering { get; set; }

    }
    /// Properties of the virtual network.
    internal partial interface IVirtualNetworkPropertiesFormatInternal

    {
        /// <summary>
        /// The AddressSpace that contains an array of IP address ranges that can be used by subnets.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAddressSpace AddressSpace { get; set; }
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        string[] AddressSpaceAddressPrefix { get; set; }
        /// <summary>
        /// The dhcpOptions that contains an array of DNS servers available to VMs deployed in the virtual network.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IDhcpOptions DhcpOption { get; set; }
        /// <summary>The list of DNS servers IP addresses.</summary>
        string[] DhcpOptionDnsServer { get; set; }
        /// <summary>
        /// Indicates if DDoS protection is enabled for all the protected resources in a Virtual Network.
        /// </summary>
        bool? EnableDdosProtection { get; set; }
        /// <summary>Indicates if Vm protection is enabled for all the subnets in a Virtual Network.</summary>
        bool? EnableVMProtection { get; set; }
        /// <summary>
        /// The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The resourceGuid property of the Virtual Network resource.</summary>
        string ResourceGuid { get; set; }
        /// <summary>A list of subnets in a Virtual Network.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[] Subnet { get; set; }
        /// <summary>A list of peerings in a Virtual Network.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeering[] VnetPeering { get; set; }

    }
}